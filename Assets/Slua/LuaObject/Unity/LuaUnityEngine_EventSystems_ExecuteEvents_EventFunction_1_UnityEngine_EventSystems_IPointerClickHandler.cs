﻿
using System;
using System.Collections.Generic;
namespace SLua
{
    public partial class LuaDelegation : LuaObject
    {

        static internal void Lua_UnityEngine_EventSystems_ExecuteEvents_EventFunction_1_UnityEngine_EventSystems_IPointerClickHandler(LuaFunction ld ,UnityEngine.EventSystems.IPointerClickHandler a1,UnityEngine.EventSystems.BaseEventData a2) {
            IntPtr l = ld.L;
            int error = pushTry(l);

			pushValue(l,a1);
			pushValue(l,a2);
			ld.pcall(2, error);
			LuaDLL.lua_settop(l, error-1);
		}
	}
}
