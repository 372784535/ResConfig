// **********************************************************************
/// <summary>
// 作者(Author):                    左慈
// 创建时间(CreateTime):             2017-04-27 14:52:38
// 模块描述(Module description):     字体效果，描边，阴影，渐变
/// </summary>
// **********************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public struct EffectStyle
{
	public bool gradient;
	public Color32 topColor;
	public Color32 bottomColor;

	public bool outline;
	public Color32 outlineColor;
	public Vector2 outlineDistance;
	public bool outlineUseGraphicAlpha;

	public bool shadow;
	public Color32 shadowColor;
	public Vector2 shadowDistance;
	public bool shadowUseGraphicAlpha;

	public EffectStyle(bool gradient,Color32 topColor,Color32 bottomColor,
	              bool outline,Color32 outlineColor,Vector2 outlineDistance,bool outlineUseGraphicAlpha,
	              bool shadow,Color32 shadowColor,Vector2 shadowDistance,bool shadowUseGraphicAlpha)
	{
		this.gradient = gradient;
		this.topColor = topColor;
		this.bottomColor = bottomColor;
		this.outline = outline;
		this.outlineColor = outlineColor;
		this.outlineDistance = outlineDistance;
		this.outlineUseGraphicAlpha = outlineUseGraphicAlpha;
		this.shadow = shadow;
		this.shadowColor = shadowColor;
		this.shadowDistance = shadowDistance;
		this.shadowUseGraphicAlpha = shadowUseGraphicAlpha;
	}


	public static EffectStyle none
	{
		get
		{
			return new EffectStyle (false, Color.white, Color.black,
		            false, Color.white, new Vector2 (1f, -1f), true,
		            false, Color.white, new Vector2 (1f, -1f), true);
		}
	}
}

[AddComponentMenu("UI/Effects/TextEffect")]
public class TextEffect : BaseMeshEffect
{
	[SerializeField]
	private EffectStyle effect = EffectStyle.none;

	public EffectStyle Effect
	{
		get
		{
			return this.effect;
		}
		set
		{
			this.effect = value;
			SetDirty();
		}
	}


	public void SetDirty()
	{
		if (graphic != null)
		{
			graphic.SetVerticesDirty ();
		}
	}

	public override void ModifyMesh (Mesh mesh)
	{

	}

	public override void ModifyMesh(VertexHelper mesh)
	{
		if (!IsActive ())
		{
			return;
		}

		List<UIVertex> vertexList = new List<UIVertex>();
		mesh.GetUIVertexStream(vertexList);
		applyGradient (vertexList);
		applyOutline (vertexList);
		applyShadow (vertexList);
		mesh.Clear();
		mesh.AddUIVertexTriangleStream(vertexList);
	}

	private void applyShadow(List<UIVertex> vertexList)
	{
		if (effect.shadow)
		{
			ApplyShadow(vertexList, effect.shadowColor, 0, vertexList.Count, effect.shadowDistance.x, effect.shadowDistance.y,effect.shadowUseGraphicAlpha);		
		}
	}

	private void applyOutline(List<UIVertex> vertexList)
	{
		if (effect.outline)
		{
			var start = 0;
			var end = vertexList.Count;
			ApplyShadow(vertexList, effect.outlineColor, start, vertexList.Count, effect.outlineDistance.x, effect.outlineDistance.y,effect.outlineUseGraphicAlpha);
			
			start = end;
			end = vertexList.Count;
			ApplyShadow(vertexList, effect.outlineColor, start, vertexList.Count, effect.outlineDistance.x, -effect.outlineDistance.y,effect.outlineUseGraphicAlpha);
			
			start = end;
			end = vertexList.Count;
			ApplyShadow(vertexList, effect.outlineColor, start, vertexList.Count, -effect.outlineDistance.x, effect.outlineDistance.y,effect.outlineUseGraphicAlpha);
			
			start = end;
			end = vertexList.Count;
			ApplyShadow(vertexList, effect.outlineColor, start, vertexList.Count, -effect.outlineDistance.x, -effect.outlineDistance.y,effect.outlineUseGraphicAlpha);
		}
	}

	private void applyGradient(List<UIVertex> vertexList)
	{
		if (effect.gradient && vertexList.Count > 0)
		{
			int count = vertexList.Count;
			float bottomY = vertexList[0].position.y;
			float topY = vertexList[0].position.y;
			
			for (int i = 1; i < count; i++)
			{
				float y = vertexList[i].position.y;
				if (y > topY)
				{
					topY = y;
				}
				else if (y < bottomY)
				{
					bottomY = y;
				}
			}
			
			float uiElementHeight = topY - bottomY;
			
			for (int i = 0; i < count; i++)
			{
				UIVertex uiVertex = vertexList[i];
				uiVertex.color = Color32.Lerp(effect.bottomColor, effect.topColor, (uiVertex.position.y - bottomY) / uiElementHeight);
				vertexList[i] = uiVertex;
			}
		}
	}

	private void ApplyShadow(List<UIVertex> verts, Color32 color, int start, int end, float x, float y,bool useGraphicAlpha)
	{
		UIVertex vt;
		
		var neededCpacity = verts.Count * 2;
		if (verts.Capacity < neededCpacity)
			verts.Capacity = neededCpacity;
		
		for (int i = start; i < end; ++i)
		{
			vt = verts[i];
			verts.Add(vt);
			
			Vector3 v = vt.position;
			v.x += x;
			v.y += y;
			vt.position = v;
			var newColor = color;
			if (useGraphicAlpha)
				newColor.a = (byte)((newColor.a * verts[i].color.a) / 255);
			vt.color = newColor;
			verts[i] = vt;
		}
	}
}
