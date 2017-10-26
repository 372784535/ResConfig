// **********************************************************************
/// <summary>
// 作者(Author):                    左慈
// 创建时间(CreateTime):             2017-04-13 10:28:33
// 模块描述(Module description):     AssetBundle打包
/// </summary>
// **********************************************************************
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Collections;
using System.Text;
using System;
using LitJson;
using SLua;

public class PackEditor : EditorWindow
{
    /// 更新地址
    static string _updateurl = "";
    /// 当前游戏版本
    static string _version = "10000";
    /// 是否删除.manifest文件
    static bool _deletemanifest = false;
    /// 打包apk的时候，是否重新打包AssetBundle资源
    static bool _rebuildab = true;

    /// <summary>
    /// 上一次保存的地址
    /// </summary>
    private static string _strPrePath = string.Empty;

    [MenuItem("Tools/AssetBundle %g")]
    static void Init()
    {
        PackEditor window = (PackEditor)EditorWindow.GetWindow(typeof(PackEditor));  
		window.Show();
    }

    void OnGUI()
    {
        PackEditor window = (PackEditor)EditorWindow.GetWindow(typeof(PackEditor));  
        GUILayout.Label ("版本");
		_version = GUILayout.TextField(_version);
		GUILayout.Space (12);

        GUILayout.Label("-----------------resource package-----------------");
        _deletemanifest = GUILayout.Toggle (_deletemanifest, "删除.manifest");
		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Android", GUILayout.Height(30f)))
        {
			BuildAssetBundle(BuildTarget.Android, _deletemanifest);
            window.Close();
		}
		if (GUILayout.Button ("Ios", GUILayout.Height(30f)))
        {
			BuildAssetBundle(BuildTarget.iOS, _deletemanifest);
            window.Close();
		}
		GUILayout.EndHorizontal ();

        GUILayout.Space (20);
        GUILayout.Label("---------------------打包apk---------------------");
        _rebuildab = GUILayout.Toggle (_rebuildab, "重新打包AssetBundle资源，并删除.manifest");
        if (GUILayout.Button ("打包.apk", GUILayout.Height(30f)))
        {
			BuildPackage(BuildTarget.Android);
            window.Close();
		}

        GUILayout.Space (20);
        GUILayout.Label("---------------------服务器专用升级包---------------------");
        if (GUILayout.Button ("Update升级包", GUILayout.Height(30f)))
        {
            BuildUpdatePackage();
            window.Close();
		}
    }

    static void OnBuildLua()
    {
        var path = Application.dataPath;
		path = Path.GetDirectoryName(path);
		path = Path.Combine(path, "build_win");
		Directory.CreateDirectory(path);

		LuaState l = new LuaState ();
		foreach (string file in Directory.GetFiles(Path.Combine("Assets", "luascript"), "*.lua", SearchOption.AllDirectories))
		{
			string output = file.Substring(0, file.LastIndexOf("lua")) + "txt";
			output = Path.Combine(Path.Combine("Assets", "luaexport"), output.Substring(("Assets" + Path.DirectorySeparatorChar).Length));
			Directory.CreateDirectory(output.Substring(0, output.LastIndexOf(Path.DirectorySeparatorChar)));
			l.doString(string.Format(@"
				local f = io.open('{0}', 'w')
				local s = io.open('{1}')
                f:write(s:read('*a'))
				f:close()
				s:close()
			", output.Replace(@"\", @"\\"), file.Replace(@"\", @"\\")));
		}
        //f:write(string.dump(loadstring(s:read('*a'), '{1}')))
		l.Dispose ();

		AssetDatabase.Refresh ();
    }

    static void OndeleteLua()
    {
        var path = Application.dataPath + "/luaexport";
        if (Directory.Exists(path))
        {
            FileUtil.DeleteFileOrDirectory (path);
            FileUtil.DeleteFileOrDirectory (path + ".meta");
        }
    }

    static void OndeleteManifest(string spath)
    {
        DirectoryInfo path = new DirectoryInfo(spath);
        foreach (FileInfo file in path.GetFiles("*.*", SearchOption.AllDirectories))
        {
            string fullName = file.FullName;
            if (fullName.EndsWith(".manifest"))
            {
                FileUtil.DeleteFileOrDirectory (fullName);
            }
            else if (fullName.EndsWith(".meta"))
            {
                FileUtil.DeleteFileOrDirectory (fullName);
            }
        }
    }

    static byte[] GetEncryptBytes(string path)
    {
        byte[] b = File.ReadAllBytes(path);
        if (path.IndexOf("luascript") == -1)
        {
            if (ToolUtil.EntryRes)
            {
                 ToolUtil.PackXor(b);
            }
        }
        else
        {
            if (ToolUtil.EntryScript)
            {
                ToolUtil.PackXor(b);
            }
        }
       
        return b;
    }

    static void RecordABList(BuildTarget target)
    {
        DirectoryInfo path = new DirectoryInfo(Application.dataPath + "/StreamingAssets/data");
        JsonData assetNameJson = new JsonData();
        foreach (FileInfo file in path.GetFiles("*.*", SearchOption.AllDirectories))
        {
            string name = file.Name;
            if (name.EndsWith(".meta") || name.EndsWith(".manifest"))
            {
                continue;
            }

            ToolUtil.WriteFile(path + "/" + name, GetEncryptBytes(file.FullName));
            JsonData resJson = new JsonData();
            resJson["name"] = name;
            resJson["md5"] = ToolUtil.GetMD5(path + "/" + name);
            resJson["size"] = ToolUtil.GetFileSize(path + "/" + name);
            assetNameJson.Add(resJson);
        }

        JsonData verJson = new JsonData();
		verJson["ver"] = Convert.ToInt32(_version);
        if (target == BuildTarget.iOS)
        {
            verJson["target"] = "IOS";
            verJson["down"] = _updateurl + _version + "/ios/";
        }
        else if (target == BuildTarget.Android)
        {
            verJson["target"] = "Android";
            verJson["down"] = _updateurl + _version + "/android/";
        }
        verJson["entryres"] = ToolUtil.EntryRes;
        verJson["entryscript"] = ToolUtil.EntryScript;
        verJson["list"] = assetNameJson;
        ToolUtil.SaveAndEncryptFile(path + "/assets.dat", verJson.ToJson());

        ToolUtil.SaveFile(Application.dataPath + "/StreamingAssets/assetlist.txt", verJson.ToJson());
        Debug.Log ("version -------->" + verJson.ToJson());
    }

    /// <summary>
	/// 打包AssetBundle, target = 平台
    /// </summary>
	private static void BuildAssetBundle(BuildTarget target, bool deletemanifest)
	{
        OnBuildLua();
        var path = Application.dataPath + "/StreamingAssets";
        Debug.Log(path);
        if (Directory.Exists(path))
        {
            FileUtil.DeleteFileOrDirectory (path);
            FileUtil.DeleteFileOrDirectory (path + ".meta");
        }

        if (!File.Exists(Application.dataPath + "/StreamingAssets"))
        {
            Directory.CreateDirectory(Application.dataPath + "/StreamingAssets");
        }

        if (!File.Exists(Application.dataPath + "/StreamingAssets/data"))
        {
            Directory.CreateDirectory(Application.dataPath + "/StreamingAssets/data");
        }

         if (!File.Exists(Application.dataPath + "/StreamingAssets/dest"))
        {
            Directory.CreateDirectory(Application.dataPath + "/StreamingAssets/dest");
        }
        
		// 打包AssetBundle
        BuildPipeline.BuildAssetBundles("Assets/StreamingAssets/data", BuildAssetBundleOptions.ChunkBasedCompression, target);
        OndeleteLua();
        if (deletemanifest)
        {
            OndeleteManifest(Application.dataPath + "/StreamingAssets/data");
        }
        RecordABList(target);

        AssetDatabase.Refresh ();
    }

    /// <summary>
	/// 打包可执行文件
    /// </summary>
	private static void BuildPackage(BuildTarget target)
	{	
        string strExtension = "apk";
        _strPrePath = PlayerPrefs.GetString("BuildPackagePath", string.Empty);

        string path = EditorUtility.SaveFilePanel("请选择目录", _strPrePath, Application.productName, strExtension);
		if (string.IsNullOrEmpty(path))
		{
            return;
        }

        if (_rebuildab)
        {
            BuildAssetBundle(target, true);
        }

        // 保存上一次的地址
        _strPrePath = path.Replace("." + strExtension, "");
        PlayerPrefs.SetString("BuildPackagePath", _strPrePath);

        FileInfo d = new FileInfo(path);
		if (!d.Directory.Exists)
		{
            d.Directory.Create();
        }

		// 如果存在这个目录则删除，避免安卓打包时，资源重复
		if (Directory.Exists(Application.dataPath + "/Plugins/Android/Assets"))
		{
            Directory.Delete(Application.dataPath + "/Plugins/Android/Assets", true);
        }

        BuildPipeline.BuildPlayer(GetBuildScene(), path, target, BuildOptions.CompressWithLz4);
        Debug.Log("导出工程包成功");
        System.Diagnostics.Process.Start(d.Directory.FullName);
    }

	/// 获取要Build的场景
	private static string[] GetBuildScene()
	{
        List<string> names = new List<string>();
		foreach (EditorBuildSettingsScene e in EditorBuildSettings.scenes)
		{
			if (e == null)
			{
                continue;
            }

			if (e.enabled)
			{
                names.Add(e.path);
                Debug.Log("加入场景 name-> " + e.path);
            }
		}
        return names.ToArray();
    }

    // 打包服务器升级包
    private static void BuildUpdatePackage()
    {
        OnBuildLua();
        var path = Application.dataPath + "/../update";
        Debug.Log(path);
        if (Directory.Exists(path))
        {
            FileUtil.DeleteFileOrDirectory (path);
        }

        if (!File.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        if (!File.Exists(path + "/" + _version))
        {
            Directory.CreateDirectory(path + "/" + _version);
        }

        if (!File.Exists(path + "/" + "android"))
        {
            Directory.CreateDirectory(path + "/" + "android");
        }

        if (!File.Exists(path + "/" + "ios"))
        {
            Directory.CreateDirectory(path + "/" + "ios");
        }

        if (!File.Exists(path + "/" + _version + "/android"))
        {
            Directory.CreateDirectory(path + "/" + _version + "/android");
        }

        if (!File.Exists(path + "/" + _version + "/ios"))
        {
            Directory.CreateDirectory(path + "/" + _version + "/ios");
        }

        BuildPipeline.BuildAssetBundles("update/"+_version+"/ios",BuildAssetBundleOptions.ChunkBasedCompression,BuildTarget.iOS);
        OndeleteManifest(path+"/"+_version+"/ios");
        byte[] iosbytes = File.ReadAllBytes(path+"/"+_version+"/ios/ios");
        File.WriteAllBytes(path+"/"+_version+"/ios/data", iosbytes);
        File.Delete(path+"/"+_version+"/ios/ios");
        RecordUpdateAB("ios");
        
        BuildPipeline.BuildAssetBundles("update/"+_version+"/android",BuildAssetBundleOptions.ChunkBasedCompression,BuildTarget.Android);
        OndeleteManifest(path+"/"+_version+"/android");
        byte[] androidbytes = File.ReadAllBytes(path+"/"+_version+"/android/android");
        File.WriteAllBytes(path+"/"+_version+"/android/data", androidbytes);
        File.Delete(path+"/"+_version+"/android/android");
        RecordUpdateAB("android");

        OndeleteLua();

        AssetDatabase.Refresh ();
    }

    private static void RecordUpdateAB(string starget)
    {
        DirectoryInfo path = new DirectoryInfo(Application.dataPath + "/../update/"+_version+"/"+starget);
        JsonData assetNameJson = new JsonData();
        foreach (FileInfo file in path.GetFiles("*.*", SearchOption.AllDirectories))
        {
            string name = file.Name;
            ToolUtil.WriteFile(path + "/" + name, GetEncryptBytes(file.FullName));
            JsonData resJson = new JsonData();
            resJson["name"] = name;
            resJson["md5"] = ToolUtil.GetMD5(path + "/" + name);
            resJson["size"] = ToolUtil.GetFileSize(path + "/" + name);
            assetNameJson.Add(resJson);
        }

        JsonData verJson = new JsonData();
		verJson["ver"] = Convert.ToInt32(_version);
        verJson["target"] = starget;
        verJson["down"] = _updateurl + _version + "/" + starget + "/";
        verJson["entryres"] = ToolUtil.EntryRes;
        verJson["entryscript"] = ToolUtil.EntryScript;
        verJson["list"] = assetNameJson;
        ToolUtil.SaveAndEncryptFile(path + "/assets.dat", verJson.ToJson());

        ToolUtil.SaveFile(Application.dataPath + "/../update/"+starget+"/assets.json", verJson.ToJson());
        Debug.Log ("versionupdate -------->" + verJson.ToJson());
    }
}

