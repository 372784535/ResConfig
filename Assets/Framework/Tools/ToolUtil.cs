using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System.Security.Cryptography;

public class ToolUtil
{
	/// <summary>
    /// 加密码
    /// </summary>
	private static string scrt = "http://qiook.com/tower&defence/client";

	// ***********************************  Warning: 一旦确定后，不可修改(Start) ***********************************
	// 资源AssetBundle是否加密
	public static readonly bool EntryRes = false;
	// lua代码AssetBundle是否加密
	public static readonly bool EntryScript = true;
	// ***********************************  Warning: 一旦确定后，不可修改(End) ***********************************

	private static DateTime jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    /// <summary>
    /// 当前时间戳
    /// </summary>
	public static long currentTimeMillis
    {
		get
        {
			return (long) ((DateTime.UtcNow - jan1st1970).TotalMilliseconds);
		}
	}

	public static void PackXor(byte[] _data)
	{
		int length = _data.Length;
		int strCount = 0;

		for (int i = 0; i < length; i++)
		{
			if (strCount >= scrt.Length)
			{
				strCount = 0;
			}
			_data[i] ^= (byte)scrt[strCount++];
		}
	}

	public static void SaveAndEncryptFile(string path, string ctx)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(ctx);
		PackXor(bytes);
		File.WriteAllBytes(path, bytes);
	}

	public static void SaveFile(string path, string ctx)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(ctx);
		File.WriteAllBytes(path, bytes);
	}

	public static string DecryptDESToStr(byte[] inputByteArray)
	{
		byte[] tmp = new byte[inputByteArray.Length];
		for (int i = 0; i < inputByteArray.Length; i++)
		{
			tmp[i] = inputByteArray[i];
		}
		PackXor(tmp);
		return UTF8Encoding.UTF8.GetString(tmp);
	}

	public static void WriteFile(string path, byte[] bytes)
	{
		FileStream fs = new FileStream(path, FileMode.Create);
		BinaryWriter bw = new BinaryWriter(fs);
		bw.Write(bytes);
		bw.Close();
		fs.Close();
	}

	// 获取文件大小，以KB为单位
	public static int GetFileSize(string filePath)
	{
		if (!File.Exists(filePath))
		{
			return 0;
		}

		FileInfo file = new FileInfo(filePath);
		return (int)(file.Length/1000);
	}

	public static string GetMD5(string filePath)
	{
		if (!File.Exists(filePath))
		{
			return string.Empty;
		}
		byte[] fileByte = File.ReadAllBytes(filePath);
		if (fileByte == null)
		{
			return string.Empty;
		}
		byte[] hashByte = new MD5CryptoServiceProvider().ComputeHash(fileByte);
		return ByteArrayToString (hashByte);
	}

	public static string getMD5String(string str)
	{
		byte[] hashByte = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(str));
		return ByteArrayToString (hashByte);
	}

	private static string ByteArrayToString(byte[] arrInput)
	{
		StringBuilder sOutput = new StringBuilder(arrInput.Length);
		for (int i = 0; i < arrInput.Length; i++)
		{
			sOutput.Append(arrInput[i].ToString("X2"));
		}
		return sOutput.ToString().ToLower();
	}
}
