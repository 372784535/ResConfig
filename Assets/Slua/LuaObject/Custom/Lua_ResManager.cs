using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_ResManager : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetUpdateMono_s(IntPtr l) {
		try {
			var ret=ResManager.GetUpdateMono();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CheckUpdate_s(IntPtr l) {
		try {
			System.Action<System.Int32,System.String> a1;
			checkDelegate(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			ResManager.CheckUpdate(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LoadPcUrl_s(IntPtr l) {
		try {
			ResManager.LoadPcUrl();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LoadMainfest_s(IntPtr l) {
		try {
			System.Action a1;
			checkDelegate(l,1,out a1);
			ResManager.LoadMainfest(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LoadCommonAssetBundle_s(IntPtr l) {
		try {
			System.Action a1;
			checkDelegate(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			ResManager.LoadCommonAssetBundle(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RegisterAssetBundle_s(IntPtr l) {
		try {
			System.Action a1;
			checkDelegate(l,1,out a1);
			System.String[] a2;
			checkParams(l,2,out a2);
			ResManager.RegisterAssetBundle(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UnRegisterAssetBundle_s(IntPtr l) {
		try {
			System.String[] a1;
			checkParams(l,1,out a1);
			ResManager.UnRegisterAssetBundle(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UnRegisterUnusedAssetBundle_s(IntPtr l) {
		try {
			System.String[] a1;
			checkParams(l,1,out a1);
			ResManager.UnRegisterUnusedAssetBundle(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LoadSceneAsset_s(IntPtr l) {
		try {
			System.Action a1;
			checkDelegate(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.String a3;
			checkType(l,3,out a3);
			ResManager.LoadSceneAsset(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveSceneAsset_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			ResManager.RemoveSceneAsset(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LoadWindowAsset_s(IntPtr l) {
		try {
			System.Action a1;
			checkDelegate(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.String a3;
			checkType(l,3,out a3);
			ResManager.LoadWindowAsset(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveAllWindowAsset_s(IntPtr l) {
		try {
			ResManager.RemoveAllWindowAsset();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveWindowAsset_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			ResManager.RemoveWindowAsset(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LoadPrefab_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			var ret=ResManager.LoadPrefab(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LoadAsset_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.String a3;
			checkType(l,3,out a3);
			var ret=ResManager.LoadAsset(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LoadLuaFile_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=ResManager.LoadLuaFile(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LoadSprite_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			var ret=ResManager.LoadSprite(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ResetRes_s(IntPtr l) {
		try {
			ResManager.ResetRes();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Mono(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,ResManager.Mono);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"ResManager");
		addMember(l,GetUpdateMono_s);
		addMember(l,CheckUpdate_s);
		addMember(l,LoadPcUrl_s);
		addMember(l,LoadMainfest_s);
		addMember(l,LoadCommonAssetBundle_s);
		addMember(l,RegisterAssetBundle_s);
		addMember(l,UnRegisterAssetBundle_s);
		addMember(l,UnRegisterUnusedAssetBundle_s);
		addMember(l,LoadSceneAsset_s);
		addMember(l,RemoveSceneAsset_s);
		addMember(l,LoadWindowAsset_s);
		addMember(l,RemoveAllWindowAsset_s);
		addMember(l,RemoveWindowAsset_s);
		addMember(l,LoadPrefab_s);
		addMember(l,LoadAsset_s);
		addMember(l,LoadLuaFile_s);
		addMember(l,LoadSprite_s);
		addMember(l,ResetRes_s);
		addMember(l,"Mono",get_Mono,null,false);
		createTypeMetatable(l,null, typeof(ResManager));
	}
}
