// **********************************************************************
/// <summary>
// 作者(Author):                    左慈
// 创建时间(CreateTime):             2017-04-14 17:59:11
// 模块描述(Module description):     批量修改UGUI字体
/// </summary>
// **********************************************************************
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
  
//[InitializeOnLoad]  
public class ChangeFontWindow : EditorWindow
{
    [MenuItem("Tools/修改字体 %t")]
    private static void ShowWindow()
	{
		ChangeFontWindow cw = EditorWindow.GetWindow<ChangeFontWindow>(true, "修改字体");
		if (cw.toFont == null)
		{
			cw.toFont = new Font("Arial");
		}
    }
	
    public Font toFont;
    static Font toChangeFont;
    FontStyle toFontStyle;
    static FontStyle toChangeFontStyle;
    private void OnGUI()
	{
        GUILayout.Space(10);
        GUILayout.Label("目标字体:");
        toFont = (Font)EditorGUILayout.ObjectField(toFont, typeof(Font), true, GUILayout.MinWidth(100f));
        toChangeFont = toFont;
        GUILayout.Space(10);
        GUILayout.Label("类型:");
        toFontStyle = (FontStyle)EditorGUILayout.EnumPopup(toFontStyle, GUILayout.MinWidth(100f));
        toChangeFontStyle = toFontStyle;
        if (GUILayout.Button("修改字体！"))
		{
            Change();
        }
    }

    public static void Change()
	{
        //获取所有UILabel组件  
        if (Selection.objects == null || Selection.objects.Length == 0)
		{
			return;
		}
        //如果是UGUI将UILabel换成Text就可以
        Object[] labels = Selection.GetFiltered(typeof(Text), SelectionMode.Deep);  
        foreach (Object item in labels)
		{
            //如果是UGUI将UILabel换成Text就可以
            Text label = (Text)item;
            label.font = toChangeFont;
            label.fontStyle = toChangeFontStyle;
            Debug.Log(item.name + ":" + label.text);
            // 重要
            EditorUtility.SetDirty(item);
        }
    }
}
