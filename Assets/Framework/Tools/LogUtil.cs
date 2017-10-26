// **********************************************************************
/// <summary>
// 作者(Author):                    左慈
// 创建时间(CreateTime):             2017-04-10 18:17:18
// 模块描述(Module description):     Log日志打印 用于lua调用
/// </summary>
// **********************************************************************
using UnityEngine;

public static class LogUtil
{
    // 是否打印Log
#if UNITY_EDITOR
    public static bool Enable = true;
#else
	public static bool Enable = false;
#endif

	/// <summary>
    /// 打印日志
    /// </summary>
    public static void Log (object str,params object[] args)
	{
		if (Enable)
		{
			string outstr = args.Length == 0? ""+str:string.Format(""+str,args);
			Debug.Log (outstr);
		}
	}

	/// <summary>
    /// 打印警告
    /// </summary>
	public static void LogWarning(object str)
	{
		if (Enable)
		{
			Debug.LogWarning(str);
		}
	}

	/// <summary>
    /// 打印错误
    /// </summary>
	public static void LogError (object str,params object[] args)
	{
		if (Enable)
		{
			string outstr = args.Length == 0? ""+str:string.Format(""+str,args);
			Debug.LogError ("!!!!!!" + outstr);
		}
	}

	/// <summary>
    /// 打印异常
    /// </summary>
	public static void LogException(System.Exception e)
	{
		Debug.LogException(e);
	}
}

