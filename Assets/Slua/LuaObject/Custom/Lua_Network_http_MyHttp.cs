using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Network_http_MyHttp : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			Network.http.MyHttp o;
			o=new Network.http.MyHttp();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetData_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.Action<System.String,System.Boolean> a3;
			checkDelegate(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			Network.http.MyHttp.GetData(a1,a2,a3,a4);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get__timeout(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Network.http.MyHttp._timeout);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set__timeout(IntPtr l) {
		try {
			System.Int32 v;
			checkType(l,2,out v);
			Network.http.MyHttp._timeout=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"Network.http.MyHttp");
		addMember(l,GetData_s);
		addMember(l,"_timeout",get__timeout,set__timeout,false);
		createTypeMetatable(l,constructor, typeof(Network.http.MyHttp));
	}
}
