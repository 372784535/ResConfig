using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_PathUtil : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_DataPath(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,PathUtil.DataPath);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ResPath(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,PathUtil.ResPath);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_TemSavePath(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,PathUtil.TemSavePath);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"PathUtil");
		addMember(l,"DataPath",get_DataPath,null,false);
		addMember(l,"ResPath",get_ResPath,null,false);
		addMember(l,"TemSavePath",get_TemSavePath,null,false);
		createTypeMetatable(l,null, typeof(PathUtil));
	}
}
