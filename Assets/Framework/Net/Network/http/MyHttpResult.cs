using System;
using LitJson;
using System.Text;
using UnityEngine;

namespace Network.http
{
	public class MyHttpResult
	{
		private int status;
		private byte[] data;
		private string responseText;
		private JsonData jsonData;
		private string filePath;
		private string errorStack;

		public MyHttpResult (byte[] data,int status)
		{
			this.data = data;
			this.status = status;
		}

		/// <summary>
		/// 获取返回的字符串
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="Network.http.MyHttpResult"/>.</returns>
		public override string ToString()
		{
            if (data == null)
            {
                return string.Empty;
            }
            return Encoding.UTF8.GetString(data);
		}

		/// <summary>
		/// 服务端返回的状态码
		/// </summary>
		/// <value>The status.</value>
		public int Status
		{
			get {return status;}
			set {status=value;}
		}

		/// <summary>
		/// 数据流
		/// </summary>
		/// <value>The data.</value>
		public byte[] Data
		{
			get {return data;}
			set {data=value;}
		}

		/// <summary>
		/// 下载文件的本地路径
		/// </summary>
		/// <value>The file path.</value>
		public string FilePath
		{
			get { return filePath; }
			set { filePath=value; }
		}

		public string ErrorStack
		{
			get { return errorStack; }
			set { errorStack=value; }
		}

		public string ResponseText
		{
			get
			{
				if (string.IsNullOrEmpty(responseText))
				{
					responseText = ExecData(data);
					Debug.Log(responseText);
				}
				return responseText;
			}
		}

		public JsonData JsonData
		{
			get
			{
				LogUtil.Log("HTTP接收到数据：start....");

				if (jsonData == null)
				{
					string res = ExecData(data);

                    LogUtil.Log("HTTP接收到数据："+res);
					jsonData = JsonMapper.ToObject(res);
				}
				return jsonData;
			}
			set { jsonData=value; }
		}

		private String ExecData(byte[] data)
		{
			if (data == null)
			{
				return "{\"code\":0,\"msg\":\"网络异常\"}";
			}
			string res = Encoding.UTF8.GetString(data);
			res = WWW.UnEscapeURL(res);
			if (res.StartsWith("\""))
			{
				res = res.Substring(1,res.Length-2);
			}
			return res;
		}
	}
}

