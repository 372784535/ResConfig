using UnityEngine;
using System;
using LitJson;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using Network.http;

public class UpdateMono : MonoBehaviour
{
	// **********************************************************************
	// ********************     获取本地资源列表    ****************************
	// **********************************************************************
	private int? _curVer = null;
	private JsonData _verList = null;

	public void CheckLocalData(Action callback)
	{
	#if (UNITY_EDITOR && !debugassets)
		ResManager.LoadPcUrl();
		if (callback != null)
		{
			callback();
		}
	#else
		StartCoroutine(CheckLocalDataForUpdate(delegate()
		{
			if (callback != null)
			{
				callback();
			}
		}));
	#endif
	}

	private JsonData ToJson(byte[] bytes)
	{
		try
		{
			string ver = ToolUtil.DecryptDESToStr(bytes);
			return JsonMapper.ToObject(ver);
		}
		catch (System.Exception)
		{
			JsonData jd = new JsonData();
			jd["ver"] = 0;
			return jd;
		}
	}

	private void ClearUpResource()
	{
		if (!Directory.Exists(PathUtil.ResPath))
		{
			Directory.CreateDirectory(PathUtil.ResPath);
		}
		DirectoryInfo dir = new DirectoryInfo(PathUtil.ResPath);
		FileInfo[] infos = dir.GetFiles();
		for (int i = 0; i < infos.Length; i++)
		{
			infos[i].Delete();
		}
	}

	private IEnumerator CheckLocalDataForUpdate(Action callback)
	{
		string verDataPath = PathUtil.DataPath + "/assets.dat";
		WWW verWWW = new WWW(verDataPath);
		yield return verWWW;
		byte[] bytes = verWWW.bytes;
		verWWW.Dispose();
		JsonData verJson = ToJson(bytes);
		string verResPath = PathUtil.ResPath + "/assets.dat";
		if (File.Exists(verResPath))
		{
			JsonData verFileJson = ToJson(File.ReadAllBytes(verResPath));
			if (verJson["ver"].ToInt32() > verFileJson["ver"].ToInt32())
			{
				ClearUpResource();
				File.WriteAllBytes(verResPath, bytes);
			}
			else
			{
				verJson = verFileJson;
			}
		}
		else
		{
			ClearUpResource();
			File.WriteAllBytes(verResPath, bytes);
		}
		
		_curVer = verJson["ver"].ToInt32();
		_verList = verJson["list"];
		if (callback != null)
		{
			callback();
		}
	}

// **********************************************************************
// ************************     更新资源    *******************************
// **********************************************************************
	private int _nRetryTime = 3;
	private JsonData _updateList = null;

	/// <updatecallback: 0-100 更新中  200 更新成功  -100 不用更新  -101 游戏客户端需要更新  -102 资源更新  -1更新失败 >
	public void CheckUpdate(Action<int, string> updatecallback, string updateurl)
	{
		_nRetryTime = 3;
#if (UNITY_EDITOR && !debugassets)
		if (updatecallback != null)
		{
			updatecallback(-100, string.Empty);
		}
#else
		CheckServerVersion(delegate()
		{
			CheckRemoteData(updatecallback, updateurl);
		}, updatecallback, updateurl);
#endif
	}

	private void CheckServerVersion(Action callback, Action<int, string> updatecallback, string updateurl)
	{
		JsonData data = new JsonData();
		data.Add("ver", _curVer);
        data.Add("appver", 1);
#if UNITY_IPHONE
        data.Add("os", "ios");
#else
		data.Add("os", "android");
#endif

		MyHttp.GetData(updateurl, data, delegate (string sresult, bool b)
		{
			if (b)
			{
				JsonData jsonData = JsonMapper.ToObject(sresult);
				if (jsonData != null && jsonData["code"] != null)
				{
					int code = jsonData["code"].ToInt32();
					if (code == -100 || code == -101)
					{
						// 没有更新
						if (updatecallback != null)
						{
							updatecallback(code, string.Empty);
						}
						return;
					}
					else if (code == -102)
					{
						// 游戏资源更新
						_updateList = jsonData["data"];
						if (_updateList != null)
						{
							if (updatecallback != null)
							{
								updatecallback(code, string.Empty);
							}
							if (callback != null)
							{
								callback();
							}
							return;
						}
					}
				}
			}

			--_nRetryTime;
			if (_nRetryTime > 0)
			{
				CheckServerVersion(callback, updatecallback, updateurl);
			}
			else
			{
				updatecallback(-1, string.Empty);
			}
		}, true);
	}

	private void CheckRemoteData(Action<int, string> updatecallback, string updateurl)
	{
		StartCoroutine(CheckRemoteDataForUpdate(updatecallback, updateurl));
	}

	private IEnumerator CheckRemoteDataForUpdate(Action<int, string> updatecallback, string updateurl)
	{
		bool update = true;
		bool updateres = false;

		if (_updateList != null)
		{
			JsonData updateList = _updateList["list"];
			JsonData downloadhttp = _updateList["down"];
			if (updateList != null && downloadhttp != null)
			{
				string sdownload = downloadhttp.ToString();
				int totaldownloadsize = 0;
				for (int i = 0; i < updateList.Count; i++)
				{
					JsonData oneUpdate = updateList[i];
					string name = oneUpdate["name"].ToString();
					string md5 = FindMd5(name);
					string updatemd5 = oneUpdate["md5"].ToString();
					if (!md5.Equals(updatemd5, StringComparison.InvariantCultureIgnoreCase))
					{
						int filesize = oneUpdate["size"].ToInt32();
						totaldownloadsize += filesize;
					}
				}

				int curdownloadsize = 0;
				updatecallback(curdownloadsize * 100 / totaldownloadsize,
					Getfilesize(curdownloadsize) + "/" + Getfilesize(totaldownloadsize));
				for (int i = 0; i < updateList.Count; i++)
				{
					JsonData oneUpdate = updateList[i];
					string name = oneUpdate["name"].ToString();
					string md5 = FindMd5(name);
					string updatemd5 = oneUpdate["md5"].ToString();
					if (md5.Equals(updatemd5, StringComparison.InvariantCultureIgnoreCase))
					{
						continue;
					}
					
					WWW curLoad = new WWW(sdownload + name);
					yield return curLoad;

					if (string.IsNullOrEmpty(curLoad.error))
					{
						string path = PathUtil.ResPath + "/" + name;
						File.WriteAllBytes(path, curLoad.bytes);
						updateres = true;
						int filesize = oneUpdate["size"].ToInt32();
						curdownloadsize += filesize;
						updatecallback(curdownloadsize * 100 / totaldownloadsize,
							Getfilesize(curdownloadsize) + "/" + Getfilesize(totaldownloadsize));
						SaveUpdateVerFile(name, updatemd5);
					}
					else
					{
						i--;
					}
					curLoad.Dispose();
					curLoad = null;
				}
			}
			else
			{
				update = false;
			}
		}
		else
		{
			update = false;
		}

		if (update)
		{
			if (updateres)
			{
				if (_updateList != null && _updateList["ver"] != null)
				{
					SaveUpdateSucc(_updateList["ver"].ToInt32());
				}
			}
			if (updatecallback != null)
			{
				updatecallback(200, string.Empty);
			}
		}
		else
		{
			--_nRetryTime;
			if (_nRetryTime > 0)
			{
				CheckUpdate(updatecallback, updateurl);
			}
			else
			{
				if (updatecallback != null)
				{
					updatecallback(-1, string.Empty);
				}
			}
		}
	}

	private string FindMd5(string name)
	{
		if (_verList == null)
		{
			return string.Empty;
		}

		for (int i = 0; i < _verList.Count; ++i)
		{
			JsonData data = _verList[i];
			if (data != null && data["name"] != null && data["md5"] != null)
			{
				string tempname = data["name"].ToString();
				string md5 = data["md5"].ToString();
				if (tempname.Equals(name, StringComparison.InvariantCultureIgnoreCase))
				{
					return md5;
				}
			}
		}

		return string.Empty;
	}

	private string Getfilesize( int size )
	{
		int m = size / 1024;
		if (m > 0)
		{
			int kb = (int)((size % 1024) / 1024 * 100);
			if (kb % 10 == 0)
			{
				kb = kb / 10;
			}
			return (m + "." + kb + "M");
		}
		else
		{
			return (size + "KB");
		}
	}

	private void SaveUpdateVerFile(string name, string md5)
	{
		int c = _verList.Count;
		bool update = false;
		for (int i = 0; i < c; i++)
		{
			JsonData data = _verList[i];
			if (name.Equals(data["name"].ToString(), StringComparison.InvariantCultureIgnoreCase))
			{
				data["md5"] = md5;
				update = true;
				break;
			}
		}

		if (!update)
		{
			JsonData one = new JsonData();
			one["name"] = name;
			one["md5"] = md5;
			_verList.Add(one);
		}

		JsonData saveJson = new JsonData();
		saveJson["ver"] = _curVer;
		saveJson["list"] = _verList;
		ToolUtil.SaveAndEncryptFile(PathUtil.ResPath + "/assets.dat", saveJson.ToJson());
	}

	private void SaveUpdateSucc(int ver)
	{
		JsonData saveJson = new JsonData();
		saveJson["ver"] = ver;
		saveJson["list"] = _verList;
		ToolUtil.SaveAndEncryptFile(PathUtil.ResPath + "/assets.dat", saveJson.ToJson());
		_curVer = ver;
		ResManager._updateres = true;
	}
}
