// **********************************************************************
/// <summary>
// 作者(Author):                    左慈
// 创建时间(CreateTime):             2017-04-12 11:41:51
// 模块描述(Module description):     资源管理器
/// </summary>
// **********************************************************************
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

[SLua.CustomLuaClassAttribute]
public static class ResManager
{
    private static FrameMono _mono = null;
	/// 公用组件，用于给非MonoBehaviour的类调用
	public static FrameMono Mono
	{
		get
		{
			if (_mono == null)
			{
                _mono = Camera.main.gameObject.GetComponent<FrameMono>();
				if (_mono == null)
				{
                    _mono = Camera.main.gameObject.AddComponent<FrameMono>();
                }
            }
            return _mono;
        }
	}

    public static UpdateMono GetUpdateMono()
    {
        UpdateMono updater = Camera.main.gameObject.GetComponent<UpdateMono>();
        if (updater == null)
        {
            updater = Camera.main.gameObject.AddComponent<UpdateMono>();
        }
        return updater;
    }

    private static List<string> _commonAssets = null;

    [SLua.DoNotToLua]
    public static bool _updateres = false;

#region 变量
    // ***********************************************************************************************************
    /// <summary>
    /// <变量 (Start)>
    /// </summary>
    // ***********************************************************************************************************

    /// <summary>
	/// PC保存的资源列表
    /// </summary>
    private static Dictionary<string, List<string>> _pcAssetPaths = new Dictionary<string, List<string>>();

    /// <summary>
	/// 字典AssetBundleName, AssetBundle
    /// </summary>
    private static Dictionary<string, AssetBundle> _dictAssetBundle = new Dictionary<string, AssetBundle>();
	
    /// <summary>
    /// 字典AssetBundleName, AssetBundle的引用计数
    /// </summary>
    private static Dictionary<string, int> _dictAssetBundleRef = new Dictionary<string, int>();

    /// <summary>
    /// <AssetBundleName,List<dependAssetBundleName>> 用来存放assetBundle的依赖关系
    /// </summary>
    private static Dictionary<string, List<string>> _dictDepend = new Dictionary<string, List<string>>();

    /// <summary>
    /// <AssetBundleName,<SpriteName,Sprite>> 用来存放assetbundle中的图片集
    /// </summary>
    private static Dictionary<string, Dictionary<string, Sprite>> _dictSprite = new Dictionary<string, Dictionary<string, Sprite>>();

    /// <summary>
    // <AssetbundleName,<prefabName,prefabFullName>> 用来存放assetbundle中预制的资源路径
    /// </summary>
    private static Dictionary<string, Dictionary<string, string>> _dictPrefab = new Dictionary<string, Dictionary<string, string>>();

    /// <summary>
    // <AssetbundleName,<prefabName,prefabFullName>> 用来存放assetbundle中其他的资源路径
    /// </summary>
    private static Dictionary<string, Dictionary<string, string>> _dictOther = new Dictionary<string, Dictionary<string, string>>();

#if !(UNITY_EDITOR && !debugassets)
    /// <summary>
    /// 用户保存场景所加载的资源(不包括窗口资源)
    /// </summary>
    private static Dictionary<string, string[]> _dictSceneAsset = new Dictionary<string, string[]>();

    /// <summary>
    /// 用户保存场景资源的引用次数
    /// </summary>
    private static Dictionary<string, int> _dictSceneAssetRef = new Dictionary<string, int>();

    /// <summary>
    /// 判断是否正在移除场景资源，如果是，不再移除窗口资源
    /// </summary>
    private static bool _bRemoveingSceneAssetBundle = false;

    /// <summary>
    /// 用于保存窗口所加载的资源
    /// </summary>
    private static Dictionary<string, string[]> _dictWindowAsset = new Dictionary<string, string[]>();

    /// <summary>
    /// 用于保存窗口资源的引用次数
    /// </summary>
    private static Dictionary<string, int> _dictWindowAssetRef = new Dictionary<string, int>();
#endif

    // ***********************************************************************************************************
    /// <summary>
    /// <变量 (End)>
    /// </summary>
    // ***********************************************************************************************************
#endregion //变量
    
#region 私有函数
    // ***********************************************************************************************************
    /// <summary>
    /// <私有函数 (Start)>
    /// </summary>
    // ***********************************************************************************************************

    /// <summary>
    /// 开启协程，加载主依赖项
    /// </summary>
    private static IEnumerator LoadMainfestIE(Action callback)
    {
        string strManifest = PathUtil.ResPath + "/data";
        bool inresPath = true;
        if(!File.Exists(strManifest))
        {
            inresPath = false;
            strManifest = PathUtil.DataPath + "/data";
        }

        AssetBundle abManifest = null;
        if (inresPath)
        {
            byte[] tempbytes = File.ReadAllBytes(strManifest);
            if (ToolUtil.EntryRes)
            {
                ToolUtil.PackXor(tempbytes);
            }

            abManifest = AssetBundle.LoadFromMemory(tempbytes);
        }
        else
        {
            WWW wwwManifest = new WWW(strManifest);
            yield return wwwManifest;

            if (!ToolUtil.EntryRes)
            {
                abManifest = wwwManifest.assetBundle;
            }
            
            if (abManifest == null)
            {
                byte[] bytes = wwwManifest.bytes;
                ToolUtil.PackXor(bytes);
                abManifest = AssetBundle.LoadFromMemory(bytes);
            }
        }

        if (abManifest == null)
        {
            LogUtil.LogError("create Manifest's AssetBundle failed!");
            yield break;
        }

        AssetBundleManifest manifest = abManifest.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        if (manifest == null)
        {
            LogUtil.LogError("manifest AssetBundle can't find AssetBundleManifest.");
            yield break;
        }

        _dictDepend.Clear();
        string[] strAllAssetBundleArray = manifest.GetAllAssetBundles();
        for (int i = 0; i < strAllAssetBundleArray.Length; i++)
        {
            string strAssetName = strAllAssetBundleArray[i];
            if (_dictDepend.ContainsKey(strAssetName))
            {
                continue;
            }

            List<string> listDepend = new List<string>();
            _dictDepend.Add(strAssetName, listDepend);

            string[] strAllDependenciesArray = manifest.GetAllDependencies(strAssetName);
            for (int j = 0; j < strAllDependenciesArray.Length; j++)
            {
                listDepend.Add(strAllDependenciesArray[j]);
            }
        }

        abManifest.Unload(true);
        if (callback != null)
        {
            callback();
        }
    }

    /// <summary>
    /// 是否为共有资源
    /// </summary>
    private static bool IsCommonAssetBundle(string strAssetBundleName)
    {
        if (string.IsNullOrEmpty(strAssetBundleName))
        {
            return false;
        }

        if (_commonAssets == null)
        {
            return false;
        }

        return _commonAssets.Contains(strAssetBundleName);
    }

    /// <summary>
    /// 注册资源，内部调用执行
    /// </summary>
    private static void RegisterAssetBundle(Action callback, int idx, params string[] vAssetBundle)
    {
#if !(UNITY_EDITOR && !debugassets)
        if (vAssetBundle == null)
        {
            return;
        }

        // 加载完最后一个资源，调用回调，并退出
        if (idx >= vAssetBundle.Length)
        {
            if (callback != null)
            {
                callback();
            }
            return;
        }

        Mono.StartCoroutine(LoadAssetBundleIE(vAssetBundle[idx], delegate ()
        {
            RegisterAssetBundle(callback, idx + 1, vAssetBundle);
        }));
#endif
    }

    /// <summary>
    /// 卸载AssetBundle
    /// </summary>
    private static void UnLoadAssetBundle(string strAssetBundle, bool force)
    {
#if !(UNITY_EDITOR && !debugassets)
        if (string.IsNullOrEmpty(strAssetBundle))
        {
            return;
        }

        string strAssetBundleName = ResetAssetBundleName(strAssetBundle);
        if (!_dictAssetBundle.ContainsKey(strAssetBundleName))
        {
            return;
        }

        --_dictAssetBundleRef[strAssetBundleName];
        if (_dictAssetBundleRef[strAssetBundleName] == 0 && !IsCommonAssetBundle(strAssetBundleName))
        {
            _dictAssetBundle[strAssetBundleName].Unload(force);
            _dictAssetBundle.Remove(strAssetBundleName);
            _dictAssetBundleRef.Remove(strAssetBundleName);
            _dictSprite.Remove(strAssetBundleName);
            _dictPrefab.Remove(strAssetBundleName);
            _dictOther.Remove(strAssetBundleName);
            LogUtil.Log(strAssetBundle + " unload success");
        }
#endif
        // 释放没有使用的资源
        Resources.UnloadUnusedAssets();
    }

    /// <summary>
    /// 添加协程,加载AssetBundle
    /// </summary>
    private static IEnumerator LoadAssetBundleIE(string strAssetBundle, Action callback)
    {
        string strAssetBundleName = ResetAssetBundleName(strAssetBundle);
        if (!string.IsNullOrEmpty(strAssetBundleName))
        {
            if (_dictAssetBundle.ContainsKey(strAssetBundleName))
            {
                ++_dictAssetBundleRef[strAssetBundleName];
                if (callback != null)
                {
                    callback();
                }
                yield return _dictAssetBundle[strAssetBundleName];
            }
            else
            {
                string strAssetBundleFullPath = PathUtil.ResPath + "/" + strAssetBundleName;
                bool inresPath = true;
                if(!File.Exists(strAssetBundleFullPath))
                {
                    inresPath = false;
                    strAssetBundleFullPath = PathUtil.DataPath + "/" + strAssetBundleName;
                }

                AssetBundle ab = null;
                if (inresPath)
                {
                    byte[] tempbytes = File.ReadAllBytes(strAssetBundleFullPath);
                    if (strAssetBundle.IndexOf("luascript") == -1)
                    {
                        if (ToolUtil.EntryRes)
                        {
                            ToolUtil.PackXor(tempbytes);
                        }
                    }
                    else
                    {
                        if (ToolUtil.EntryScript)
                        {
                            ToolUtil.PackXor(tempbytes);
                        }
                    }

                    ab = AssetBundle.LoadFromMemory(tempbytes);
                }
                else
                {
                    WWW wwwAssetBundle = new WWW(strAssetBundleFullPath);
                    yield return wwwAssetBundle;

                    if (strAssetBundle.IndexOf("luascript") == -1)
                    {
                        if (!ToolUtil.EntryRes)
                        {
                            ab = wwwAssetBundle.assetBundle;
                        }
                    }
                    else
                    {
                        if (!ToolUtil.EntryScript)
                        {
                            ab = wwwAssetBundle.assetBundle;
                        }
                    }
                    
                    if (ab == null)
                    {
                        byte[] bytes = wwwAssetBundle.bytes;
                        ToolUtil.PackXor(bytes);
                        ab = AssetBundle.LoadFromMemory(bytes);
                    }
                }

                if (ab != null)
                {
                    _dictAssetBundle.Add(strAssetBundleName, ab);
                    _dictAssetBundleRef.Add(strAssetBundleName, 1);
                    // 加载AssetBundle中的Sprite
                    Dictionary<string, Sprite> dictAsset = new Dictionary<string, Sprite>();
                    _dictSprite.Add(strAssetBundleName, dictAsset);

                    Sprite[] sprList = ab.LoadAllAssets<Sprite>();
                    for (int i = 0; i < sprList.Length; i++)
                    {
                        Sprite sp = sprList[i];
                        if (sp != null)
                        {
                            dictAsset.Add(sp.name, sp);
                        }
                    }

                    // 添加assetbundle中预制资源的路径
                    Dictionary<string, string> dictPrefabName = new Dictionary<string, string>();
                    _dictPrefab.Add(strAssetBundleName, dictPrefabName);

                    // 添加assetbundle中其他资源的路径
                    Dictionary<string, string> dictOtherName = new Dictionary<string, string>();
                    _dictOther.Add(strAssetBundleName, dictOtherName);

                    // 获取Assetbundle里面所有资源
                    string[] strAllAssetNames = ab.GetAllAssetNames();
                    for (int i = 0; i < strAllAssetNames.Length; i++)
                    {
                        string strName = strAllAssetNames[i];
                        if (string.IsNullOrEmpty(strName))
                        {
                            continue;
                        }
                        
                        if (strName.EndsWith(".prefab"))
                        {
                            string strPrefab = Path.GetFileName(strName);
                            dictPrefabName.Add(strPrefab, strName);
                        }
                        else if (strName.EndsWith(".txt") || strName.EndsWith(".bytes"))
                        {
                            string strOther = strName.Substring(strName.IndexOf("luascript") + 10);
                            strOther = strOther.Replace('/', '.');
                            dictOtherName.Add(strOther, strName);
                        }
                        else
                        {
                            string strOther = Path.GetFileName(strName);
                            dictOtherName.Add(strOther, strName);
                        }
                    }

                    LogUtil.Log(strAssetBundle + " load success");
                    if (callback != null)
                    {
                        callback();
                    }
                }
            }
        }
    }

    /// <summary>
    /// 通过名字获取AssetBundle
    /// </summary>
    private static AssetBundle GetAssetBundle(string strAssetBundle)
    {
        string strAssetBundleName = ResetAssetBundleName(strAssetBundle);
        if (!_dictAssetBundle.ContainsKey(strAssetBundleName))
        {
            return null;
        }
        return _dictAssetBundle[strAssetBundleName];
    }

    /// <summary>
    /// 将AssetBundle的名字添加 .dat后缀
    /// </summary>
    private static string ResetAssetBundleName(string strAssetBundle)
    {
        strAssetBundle = strAssetBundle.ToLower();
        if (string.IsNullOrEmpty(strAssetBundle))
        {
            return string.Empty;
        }

        if (strAssetBundle.EndsWith(".dat"))
        {
            return strAssetBundle;
        }

        return string.Format("{0}.dat", strAssetBundle);
    }

    /// <summary>
    /// 获取预制的名字
    /// </summary>
    private static string GetPrefabName(string strPrefab)
    {
        if (string.IsNullOrEmpty(strPrefab))
        {
            return string.Empty;
        }

        if (strPrefab.EndsWith(".prefab"))
        {
            return strPrefab;
        }

        return string.Format("{0}.prefab", strPrefab);
    }

    /// <summary>
    /// 获取预制的路径
    /// </summary>
    private static string GetPrefabPath(string strAssetBundle, string strPrefab)
    {
        if (string.IsNullOrEmpty(strAssetBundle) || string.IsNullOrEmpty(strPrefab))
        {
            return string.Empty;
        }

        string strAssetBundleName = ResetAssetBundleName(strAssetBundle);
        if (!_dictPrefab.ContainsKey(strAssetBundleName))
        {
            return string.Empty;
        }
        Dictionary<string, string> dictAsset = _dictPrefab[strAssetBundleName];

        strPrefab = GetPrefabName(strPrefab);
        if (!dictAsset.ContainsKey(strPrefab))
        {
            return string.Empty;
        }
        return dictAsset[strPrefab];
    }

    /// <summary>
    /// 获取AssetBundle名字集合
    /// </summary>
    private static string[] ResetAssetBundleNameSet(params string[] strAssetBundleSet)
    {
        List<string> strSet = new List<string>();
        for (int i = 0; i < strAssetBundleSet.Length; i++)
        {
            string str = strAssetBundleSet[i];
            if (string.IsNullOrEmpty(str))
            {
                LogUtil.LogError("the string in strAssetBundleSet is null or empty");
                continue;
            }

            string strAssetBundleName = ResetAssetBundleName(str);
            if (string.IsNullOrEmpty(strAssetBundleName))
            {
                LogUtil.LogError("the strAssetBundleName is null or empty");
                continue;
            }

            strSet.Add(strAssetBundleName);
        }

        return strSet.ToArray();
    }

    /// <summary>
    /// 获取其他的Object路径 (比如 声音)
    /// <summary>
    private static string GetOtherPath(string strAssetBundle, string strOther)
    {
        if (string.IsNullOrEmpty(strAssetBundle) || string.IsNullOrEmpty(strOther))
        {
            return string.Empty;
        }

        string strAssetBundleName = ResetAssetBundleName(strAssetBundle);
        if (!_dictOther.ContainsKey(strAssetBundleName))
        {
            return string.Empty;
        }

        Dictionary<string, string> dictAsset = _dictOther[strAssetBundleName];

        strOther = strOther.ToLower();
        if (!dictAsset.ContainsKey(strOther))
        {
            return string.Empty;
        }

        return dictAsset[strOther];
    }

    /// <summary>
    /// 从pcurl获取资源路径
    /// assetBundleName = 资源所在的AssetBundle
    /// assetName = 要加载的资源名
    /// </summary>
    private static string GetPCUrl(string abName, string assetName)
    {
        List<string> listpath = null;
        if (assetName.EndsWith(".png") || assetName.EndsWith(".jpg"))
        {
            listpath = _pcAssetPaths["pic"];
        }
        else if (assetName.EndsWith(".mp3") ||
            assetName.EndsWith(".wav") ||
            assetName.EndsWith(".ogg") ||
            assetName.EndsWith(".aiff"))
        {
            listpath = _pcAssetPaths["voice"];
        }
        else if (assetName.EndsWith(".prefab"))
        {
            listpath = _pcAssetPaths["prefab"];
        }

        if (listpath != null)
        {
            foreach (string path in listpath)
            {
                if (path.EndsWith(assetName) && path.IndexOf(abName) != -1)
                {
                    return path;
                }
            }
        }

        return string.Empty;
    }

    private static void LoadUrl(string dirPath)
    {
        foreach (string file in Directory.GetFiles(dirPath))
        {
            if (file.EndsWith(".png") || file.EndsWith(".jpg"))
            {
                string temPath = file.Substring(file.IndexOf("Assets"));
                _pcAssetPaths["pic"].Add(temPath);
            }
            else if (file.EndsWith(".mp3") || file.EndsWith(".wav") || file.EndsWith(".ogg") || file.EndsWith(".aiff"))
            {
                string temPath = file.Substring(file.IndexOf("Assets"));
                _pcAssetPaths["voice"].Add(temPath);
            }
            else if (file.EndsWith(".prefab"))
            {
                string temPath = file.Substring(file.IndexOf("Assets"));
                _pcAssetPaths["prefab"].Add(temPath);
            }
        }

        DirectoryInfo source = new DirectoryInfo(dirPath);
        DirectoryInfo[] dirs = source.GetDirectories();
        for (int i = 0; i < dirs.Length; i++)
        {
            LoadUrl(dirs[i].FullName);
        }
    }

    /// <summary>
    /// 获取AssetBun的依赖
    /// </summary>
    private static string[] GetNeededAssetBundle(string assetBundleName)
    {
        assetBundleName = ResetAssetBundleName(assetBundleName);
        if (string.IsNullOrEmpty(assetBundleName))
        {
            return null;
        }

        List<string> strAssetBundleList = new List<string>();
        if (_dictDepend.ContainsKey(assetBundleName))
        {
            foreach (string str in _dictDepend[assetBundleName])
            {
                if (!strAssetBundleList.Contains(str) && !string.IsNullOrEmpty(str))
                {
                    strAssetBundleList.Add(str);
                }
            }
        }
        strAssetBundleList.Add(assetBundleName);
        string[] vStrAssetBundle = strAssetBundleList.ToArray();
        return vStrAssetBundle;
    }

    // ***********************************************************************************************************
    /// <summary>
    /// <私有函数 (End)>
    /// </summary>
    // ***********************************************************************************************************
#endregion // 私有函数
    

#region 公有函数
    // ***********************************************************************************************************
    /// <summary>
    /// <公有函数 (Start)>
    /// </summary>
    // ***********************************************************************************************************

    public static void CheckUpdate(Action<int, string> callback, string updateurl)
    {
        UpdateMono updater = GetUpdateMono();
        updater.CheckUpdate((int a, string b) =>
        {
            callback(a, b);
            UnityEngine.Object.Destroy(updater);
        }, updateurl);
    }

    /// <summary>
    /// 加载PC路径存储列表
    /// </summary>
    public static void LoadPcUrl()
    {
#if (UNITY_EDITOR && !debugassets)
       string assetPath = Application.dataPath;
       _pcAssetPaths.Clear();
       List<string> listPic = new List<string>();
       List<string> listVoice = new List<string>();
       List<string> listprefab = new List<string>();
       _pcAssetPaths.Add("pic", listPic);
       _pcAssetPaths.Add("voice", listVoice);
       _pcAssetPaths.Add("prefab", listprefab);

       LoadUrl(assetPath);
#endif
    }

    /// <summary>
    /// 加载主依赖项
    /// </summary>
    public static void LoadMainfest(Action callback)
    {
#if (UNITY_EDITOR && !debugassets)
       callback();
#else
        Mono.StartCoroutine(LoadMainfestIE(callback));
#endif
    }

    /// <summary>
    /// 注册公共资源
    /// </summary>
    public static void LoadCommonAssetBundle(Action callback, string sparams)
    {
        if (!string.IsNullOrEmpty(sparams))
		{
            List<string> commonAssets = new List<string>();
			string[] vstr = sparams.Split('|');
			for (int i = 0; i < vstr.Length; i += 2)
			{
				if (!string.IsNullOrEmpty(vstr[i+1]))
				{
                    commonAssets.Add(vstr[i+1]);
				}
			}
            ResManager.LoadCommonAssetBundle(callback, commonAssets);
		}
        else
        {
            callback();
        }
    }

    /// <summary>
    /// 加载公共资源
    /// </summary>
    [SLua.DoNotToLua]
    public static void LoadCommonAssetBundle(Action callback, List<string> commonAssets)
    {
        _commonAssets = commonAssets;
#if (UNITY_EDITOR && !debugassets)
       callback();
#else
        RegisterAssetBundle(callback, _commonAssets.ToArray());
#endif
    }

    /// <summary>
    /// 注册资源 --> vAssetBundle = 依赖的AssetBundle
    /// </summary>
    public static void RegisterAssetBundle(Action callback, params string[] vAssetBundle)
    {
#if (UNITY_EDITOR && !debugassets)
       callback();
#else
        RegisterAssetBundle(callback, 0, vAssetBundle);
#endif
    }

    /// <summary>
    /// 注销资源
    /// </summary>
    public static void UnRegisterAssetBundle(params string[] vAssetBundle)
    {
#if !(UNITY_EDITOR && !debugassets)
        if (vAssetBundle == null)
        {
            return;
        }

        for (int i = 0; i < vAssetBundle.Length; i++)
        {
            string strAssetBundle = vAssetBundle[i];
            if (string.IsNullOrEmpty(strAssetBundle))
            {
                continue;
            }
            UnLoadAssetBundle(strAssetBundle, true);
        }
#endif
    }

    /// <summary>
    /// 注销资源
    /// </summary>
    public static void UnRegisterUnusedAssetBundle(params string[] vAssetBundle)
    {
#if !(UNITY_EDITOR && !debugassets)
        if (vAssetBundle == null)
        {
            return;
        }

        for (int i = 0; i < vAssetBundle.Length; i++)
        {
            string strAssetBundle = vAssetBundle[i];
            if (string.IsNullOrEmpty(strAssetBundle))
            {
                continue;
            }
            UnLoadAssetBundle(strAssetBundle, false);
        }
#endif
    }

    /// <summary>
    /// 加载的场景资源
    /// callback = 回调
    /// strSceneName = 场景名
    /// strAssetBundleSet = 依赖的AssetBundle
    /// </summary>
    public static void LoadSceneAsset(Action callback, string assetBundleName, string strSceneName)
    {
#if (UNITY_EDITOR && !debugassets)
       if (callback != null)
       {
           callback();
       }
#else
        if (string.IsNullOrEmpty(strSceneName))
        {
            LogUtil.LogError ("strSceneName is null or empty");
            return;
        }

        // 获取窗口及其依赖项assetbundle
        string[] strAssetBundleSet = GetNeededAssetBundle(assetBundleName);
        strAssetBundleSet = ResetAssetBundleNameSet(strAssetBundleSet);
        if (strAssetBundleSet == null)
        {
            LogUtil.LogError ("strAssetBundleSet is null");
            return;
        }

        // 加载资源
        RegisterAssetBundle(delegate ()
        {
            if (_dictSceneAsset.ContainsKey(strSceneName))
            {
                ++_dictSceneAssetRef[strSceneName];
            }
            else
            {
                _dictSceneAsset.Add(strSceneName, strAssetBundleSet);
                _dictSceneAssetRef.Add(strSceneName, 1);
            }
            if (callback != null)
            {
                callback();
            }
        }, strAssetBundleSet);
#endif
    }

    /// <summary>
    /// 移除场景资源
    /// </summary>
    public static void RemoveSceneAsset(string strSceneName)
    {
#if !(UNITY_EDITOR && !debugassets)
        _bRemoveingSceneAssetBundle = true;
        RemoveAllWindowAsset();

        if (string.IsNullOrEmpty(strSceneName))
        {
            LogUtil.Log("strScene is null");
            return;
        }

        if (!_dictSceneAsset.ContainsKey(strSceneName))
        {
            LogUtil.LogError ("dictSceneAsset do not contain " + strSceneName);
            return;
        }

        if (!_dictSceneAssetRef.ContainsKey(strSceneName))
        {
            LogUtil.LogError ("dictSceneAssetRef do not contain " + strSceneName);
            return;
        }

        --_dictSceneAssetRef[strSceneName];
        if (_dictSceneAssetRef[strSceneName] == 0)
        {
            // 卸载资源
            UnRegisterAssetBundle(_dictSceneAsset[strSceneName]);
            _dictSceneAsset.Remove(strSceneName);
            _dictSceneAssetRef.Remove(strSceneName);
        }

        _bRemoveingSceneAssetBundle = false;
        GC.Collect();
#endif
    }

    /// <summary>
    /// 加载的窗口资源
    /// callback = 回调
    /// assetBundleName = 窗口对应assetbundle
    /// strWindowName = 窗口名
    /// </summary>
    public static void LoadWindowAsset(Action callback, string assetBundleName, string strWindowName)
    {
#if (UNITY_EDITOR && !debugassets)
       if (callback != null)
       {
           callback();
       }
#else
        // 获取窗口及其依赖项assetbundle
        string[] strAssetBundleSet = GetNeededAssetBundle(assetBundleName);
        strAssetBundleSet = ResetAssetBundleNameSet(strAssetBundleSet);
        if (string.IsNullOrEmpty(strWindowName))
        {
            LogUtil.LogError("strWindowName is null or empty");
            return;
        }

        if (strAssetBundleSet == null)
        {
            LogUtil.LogError("strAssetBundle is null");
            return;
        }

        // 加载资源
        RegisterAssetBundle(delegate ()
        {
            if (_dictWindowAsset.ContainsKey(strWindowName))
            {
                ++_dictWindowAssetRef[strWindowName];
            }
            else
            {
                _dictWindowAsset.Add(strWindowName, strAssetBundleSet);
                _dictWindowAssetRef.Add(strWindowName, 1);
            }

            if (callback != null)
            {
                callback();
            }
        }, strAssetBundleSet);
#endif
    }

    /// <summary>
    /// 移除所有窗口的资源
    /// </summary>
    public static void RemoveAllWindowAsset()
    {
#if !(UNITY_EDITOR && !debugassets)
        foreach (string[] strValue in _dictWindowAsset.Values)
        {
            UnRegisterAssetBundle(strValue);
        }

        _dictWindowAsset = new Dictionary<string, string[]>();
        _dictWindowAssetRef = new Dictionary<string, int>();
#endif
    }

    /// <summary>
    /// 移除窗口资源
    /// </summary>
    public static void RemoveWindowAsset(string strWindowName)
    {
#if !(UNITY_EDITOR && !debugassets)
        if (_bRemoveingSceneAssetBundle)
        {
            return;
        }

        if (string.IsNullOrEmpty(strWindowName))
        {
            LogUtil.Log("strWindowName is null");
            return;
        }

        if (!_dictWindowAsset.ContainsKey(strWindowName))
        {
            return;
        }

        if (!_dictWindowAssetRef.ContainsKey(strWindowName))
        {
            return;
        }

        --_dictWindowAssetRef[strWindowName];
        if (_dictWindowAssetRef[strWindowName] == 0)
        {
            // 卸载资源
            UnRegisterAssetBundle(_dictWindowAsset[strWindowName]);
            _dictWindowAsset.Remove(strWindowName);
            _dictWindowAssetRef.Remove(strWindowName);
            LogUtil.Log(strWindowName = " assetBundle remove success");
        }
        GC.Collect();
#endif
    }

    /// <summary>
    /// 加载预制
    /// </summary>
    public static GameObject LoadPrefab(string strAssetBundle, string strPrefab)
    {
        string strAssetBundleName = ResetAssetBundleName(strAssetBundle);
        if (string.IsNullOrEmpty(strAssetBundleName) || string.IsNullOrEmpty(strPrefab))
        {
            return null;
        }
        
        string strPrefabName = GetPrefabName(strPrefab);
        if (string.IsNullOrEmpty(strPrefabName))
        {
            return null;
        }
#if (UNITY_EDITOR && !debugassets)
       GameObject go = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(GetPCUrl(strAssetBundle, strPrefabName));
       return go;
#else
        AssetBundle ab = GetAssetBundle(strAssetBundleName);
        string strAssetPath = GetPrefabPath(strAssetBundleName, strPrefabName.ToLower());
        if (ab != null && !string.IsNullOrEmpty(strAssetPath))
        {
            UnityEngine.Object o = ab.LoadAsset(strAssetPath);
            if (o != null)
            {
                GameObject go = o as GameObject;
                return go;
            }
        }
        return null;
#endif
    }

    /// <summary>
    /// 加载资源
    /// strAssetBundle = 资源所在的AssetBundle
    /// strOther = 资源名 带后缀
    /// </summary>
    public static UnityEngine.Object LoadAsset(string stype, string strAssetBundle, string strOther)
    {
        switch (stype)
        {
            case "AudioClip":
            {
                return ResManager.LoadAsset<AudioClip>(strAssetBundle, strOther);
            }
        }
        return null;
    }

    /// <summary>
    /// txt文件，lua转换为txt, 然后读取
    /// strOther = 资源名
    /// </summary>
    public static string LoadLuaFile(string strBytes)
    {
        if (string.IsNullOrEmpty(strBytes))
        {
            return string.Empty;
        }

        if (!strBytes.EndsWith(".txt"))
        {
            strBytes += ".txt";
        }

        TextAsset txt = ResManager.LoadAsset<TextAsset>("luascript", strBytes);
        return txt.text;
    }

    /// <summary>
    /// 加载资源
    /// strAssetBundle = 资源所在的AssetBundle
    /// strOther = 资源名 带后缀
    /// </summary>
    [SLua.DoNotToLua]
    public static T LoadAsset<T>(string strAssetBundle, string strOther) where T : UnityEngine.Object
    {
        string strAssetBundleName = ResetAssetBundleName(strAssetBundle);
        if (string.IsNullOrEmpty(strAssetBundleName) || string.IsNullOrEmpty(strOther))
        {
            return null;
        }

#if (UNITY_EDITOR && !debugassets)
       T go = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(GetPCUrl(strAssetBundle, strOther));
       return go;
#else
        AssetBundle ab = GetAssetBundle(strAssetBundleName);
        string strAssetPath = GetOtherPath(strAssetBundleName, strOther);

        if (ab != null && !string.IsNullOrEmpty(strAssetPath))
        {
            T go = ab.LoadAsset<T>(strAssetPath);
            return go;
        }
        return null;
#endif
    }

    /// <summary>
    /// 加载精灵
    /// strAssetBundle = 精灵所在AssetBundle
    /// strSprite = 精灵的名字
    /// </summary>
    public static Sprite LoadSprite(string strAssetBundle, string strSprite)
    {
#if (UNITY_EDITOR && !debugassets)
       if (!(strSprite.EndsWith(".png") || strSprite.EndsWith(".jpg")))
       {
           strSprite += ".png";
       }
       Sprite spr = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(GetPCUrl(strAssetBundle, strSprite));
       return spr;
#else
        string strAssetBundleName = ResetAssetBundleName(strAssetBundle);
        if (string.IsNullOrEmpty(strAssetBundleName) || string.IsNullOrEmpty(strSprite))
        {
            return null;
        }

        if (string.IsNullOrEmpty(strSprite))
        {
            LogUtil.LogError("strSpriteFrame is null or empty");
            return null;
        }

        if (!_dictSprite.ContainsKey(strAssetBundleName))
        {
            return null;
        }
        Dictionary<string, Sprite> dictAsset = _dictSprite[strAssetBundleName];
        if (dictAsset.ContainsKey(strSprite))
        {
            return dictAsset[strSprite];
        }

        return null;
#endif
    }

	/// <summary>
    /// 重置ResManager数据
    /// </summary>
    public static void ResetRes()
    {
        try
        {
            _mono = null;
        #if (UNITY_EDITOR && !debugassets)
            _pcAssetPaths.Clear();
        #else
            _bRemoveingSceneAssetBundle = true;
            Dictionary<string, AssetBundle> dictAB = new Dictionary<string, AssetBundle>();
            Dictionary<string, int> dictABRef = new Dictionary<string, int>();
            Dictionary<string, List<string>> dictDepend = new Dictionary<string, List<string>>();
            Dictionary<string, Dictionary<string, Sprite>> dictSprite = new Dictionary<string, Dictionary<string, Sprite>>();
            Dictionary<string, Dictionary<string, string>> dictPrefab = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, Dictionary<string, string>> dictOther = new Dictionary<string, Dictionary<string, string>>();
            foreach (var item in _dictAssetBundle)
            {
                if (!_updateres && IsCommonAssetBundle(item.Key))
                {
                    dictAB.Add(item.Key, item.Value);
                    dictABRef.Add(item.Key, 1);
                    if (_dictDepend.ContainsKey(item.Key))
                    {
                        dictDepend.Add(item.Key, _dictDepend[item.Key]);
                    }
                    if (_dictSprite.ContainsKey(item.Key))
                    {
                        dictSprite.Add(item.Key, _dictSprite[item.Key]);
                    }
                    if (_dictPrefab.ContainsKey(item.Key))
                    {
                        dictPrefab.Add(item.Key, _dictPrefab[item.Key]);
                    }
                    if (_dictOther.ContainsKey(item.Key))
                    {
                        dictOther.Add(item.Key, _dictOther[item.Key]);
                    }
                    continue;
                }
                item.Value.Unload(true);
                LogUtil.Log(item.Key + " unload success");
            }
            _dictAssetBundle = dictAB;
            _dictAssetBundleRef = dictABRef;
            _dictDepend = dictDepend;
            _dictSprite = dictSprite;
            _dictPrefab = dictPrefab;
            _dictOther = dictOther;
            _dictSceneAsset.Clear();
            _dictSceneAssetRef.Clear();
            _dictWindowAsset.Clear();
            _dictWindowAssetRef.Clear();
            _bRemoveingSceneAssetBundle = false;
        #endif
            _updateres = false;
        }
        catch (System.Exception)
        {
            LogUtil.LogError("-------reset res exception-------");
        }
    }

    // ***********************************************************************************************************
    /// <summary>
    /// <公有函数 (End)>
    /// </summary>
    // ***********************************************************************************************************
    #endregion // 公有函数

}

