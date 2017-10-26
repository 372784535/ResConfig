using System;
using LitJson;

namespace Network.http
{
	[SLua.CustomLuaClassAttribute]
	public class MyHttp
	{
        private static RequestCache Cache = new RequestCache();

		public static int _timeout = 8000;

        //cacheKey 需要缓存传对应URL 默认为空
		private static void GetData (string cacheKey, string url, JsonData para, Action<string, bool> callback, bool encrypt)
		{
            if (cacheKey != null)
            {
                if (!Cache.CanUpdate(cacheKey) && Cache.getResult(cacheKey) != null)
                {
                    callback(Cache.getResult(cacheKey).ResponseText, true);
                    return;
                }
            }

            if (para == null)
            {
                para = new JsonData();
            }
            url = GetURL(url, para, encrypt);

            HTTP.Request someRequest = new HTTP.Request ("get", url);
			someRequest.Send (delegate(HTTP.Request req)
			{
				if(callback != null)
				{
					if(req.response!=null)
					{
                        callback(new MyHttpResult(req.response.bytes,req.response.status).ResponseText, req.response.status == 200);
                        if (cacheKey != null)
                        {
                            Cache.UpdateRequestCache(cacheKey, new MyHttpResult(req.response.bytes, req.response.status));
                        }
					}
					else
					{
						callback(new MyHttpResult(null,-1).ResponseText, false);
					}
				}
			});
		}

		private static string GetURL(string url, JsonData requestParams, bool encrypt)
		{
			string paramStr = requestParams.ToJson();
#if UNITY_EDITOR
			LogUtil.Log(UrlPutParam(url, "encryptdata", paramStr));
#endif
			return UrlPutParam(url,"encryptdata",(encrypt ? ObfuseTableBase64.encode(paramStr).Replace("#","@") : paramStr));;
		}

		private static string UrlPutParam(string url, string key, string value)
		{
			if (url.IndexOf("?") > 0)
			{
				url += "&" + key + "=" + value;
			}
			else
			{
				url += "?" + key + "=" + value;
			}

			return url;
		}

		[SLua.DoNotToLua]
		public static void GetData(string url, JsonData para, Action<string, bool> callback, bool encrypt)
        {
            GetData(null, url, para, callback, encrypt);
        }

		public static void GetData(string url, string sparams, Action<string, bool> callback, bool encrypt)
		{
			JsonData data = new JsonData();

			if (!string.IsNullOrEmpty(sparams))
			{
				string[] vstr = sparams.Split('|');
				for (int i = 0; i < vstr.Length; i += 2)
				{
					if (!string.IsNullOrEmpty(vstr[i]) && !string.IsNullOrEmpty(vstr[i+1]))
					{
						data.Add(vstr[i], vstr[i+1]);
					}
				}
			}

			GetData(null, url, data, callback, encrypt);
		}
	}
}