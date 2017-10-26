// **********************************************************************
/// <summary>
// 作者(Author):                    左慈
// 创建时间(CreateTime):             2017-05-09 12:26:48
// 模块描述(Module description):     
/// </summary>
// **********************************************************************
using LitJson;
using System;
using System.Globalization;

public static class MyLitJson
{

	public static string ToString (this JsonData data)
	{
        if (data == null)
        {
            return string.Empty;
        }
        return data.ToString ();
	}

	public static int ToInt16 (JsonData data)
	{
        if (data == null)
        {
            return 0;
        }
        return Convert.ToInt16 (data.ToString ());
	}

	public static int ToInt32 (this JsonData data)
	{
        if (data == null)
        {
            return 0;
        }
        return Convert.ToInt32 (data.ToString ());
	}

	public static long ToInt64 (this JsonData data)
	{
        if (data == null)
        {
            return 0;
        }
        return Convert.ToInt64 (data.ToString ());
	}

	public static bool ToBoolean (this JsonData data)
	{
        if (data == null)
        {
            return false;
        }
        if (data.GetJsonType () == JsonType.Int)
		{
			return ToInt32 (data) == 1;
		}
		return Convert.ToBoolean (data.ToJson ());
	}

	public static double ToDouble (this JsonData data)
	{
        if (data == null)
        {
            return 0d;
        }
        return Convert.ToDouble (data.ToString ());
	}

	public static float ToSingle (this JsonData data)
	{
        if (data == null)
        {
            return 0f;
        }
        return Convert.ToSingle (data.ToString ());
	}

	public static DateTime ToDate (this JsonData data)
	{
		if (data == null)
		{
			return new DateTime (0);
		}
		DateTime dtToday = DateTime.Now;//UserInfoMgr.getInstance().today;

		string strData = string.Format ("1990-10-10 00:00:00");
		string strDateTime = data.ToString ();
		if (!string.IsNullOrEmpty (strDateTime))
		{
            if (data.ToString().Length > strData.Length)
            {
                strData = data.ToString().Substring(0, strData.Length);
            }
            else
            {
                strData = data.ToString();
            }
        }

		IFormatProvider culture = new CultureInfo ("en-us");
		string strTimeFormat = "yyyy-MM-dd";
		if (strData.Length > 10)
		{
			strTimeFormat = string.Format ("yyyy-MM-dd HH:mm:ss");
		}

		try
		{
			dtToday = DateTime.ParseExact (strData, strTimeFormat, culture, DateTimeStyles.AllowWhiteSpaces);
		}
		catch (Exception e)
		{
			LogUtil.Log (data.ToJson ());
			LogUtil.Log ("conver json data to datetime failed!\n" + e.ToString ());
		}
		return dtToday;
	}
}

