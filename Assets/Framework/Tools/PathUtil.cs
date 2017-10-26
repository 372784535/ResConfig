// **********************************************************************
/// <summary>
// 作者(Author):                    左慈
// 创建时间(CreateTime):             2017-04-12 14:18:13
// 模块描述(Module description):     打包路径 用于lua调用
/// </summary>
// **********************************************************************
using UnityEngine;

[SLua.CustomLuaClassAttribute]
public static class PathUtil
{
	private static string _dataPath = string.Empty;
	/// <summary>
    /// 数据目录，指安装包中的数据的路径
    /// </summary>
	public static string DataPath
	{
		get
		{
			if (_dataPath == string.Empty)
			{
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        		_dataPath = "file://" + Application.dataPath + "/StreamingAssets/data";
#elif UNITY_ANDROID
				_dataPath = "jar:file://" + Application.dataPath + "!/assets/data";
#elif UNITY_IPHONE
				_dataPath = "file://"+ Application.dataPath + "/Raw/data";
#endif
			}
            return _dataPath;
        }
	}

    private static string _resPath = string.Empty;
	/// <summary>
    /// 可写目录，用于资源下载，更新
    /// </summary>
	public static string ResPath
	{
		get
		{
			if (_resPath == string.Empty)
			{
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
				_resPath = Application.dataPath + "/StreamingAssets/dest";
#elif UNITY_ANDROID
				_resPath = Application.persistentDataPath + @"/assets/res";
#elif UNITY_IPHONE
				_resPath = Application.persistentDataPath + @"/Raw/res";
#endif
			}
            return _resPath;
        }
	}

	private static string _temSavePath = string.Empty;
	/// <summary>
    /// 可写目录，用于临时资源下载，显示(头像，声音，截图。。。)
    /// </summary>
	public static string TemSavePath
	{
		get
		{
			if (_temSavePath == string.Empty)
			{
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
				_temSavePath = Application.dataPath + "/StreamingAssets/dest";
#elif UNITY_ANDROID
				_temSavePath = Application.persistentDataPath + @"/assets/tem";
#elif UNITY_IPHONE
				_temSavePath = Application.persistentDataPath + @"/Raw/tem";
#endif
			}
            return _temSavePath;
        }
	}
}

