using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarGrow : MonoBehaviour {
    public int Length = 0;
    public Dictionary<int, C_StarGrow> StarGrowData = new Dictionary<int, C_StarGrow>();
    Transform BaseStarGrow;
    private InputField _StarType;
    private InputField _ATKGrow;
    private InputField _VitalityGrow;
    private InputField _ATKSpeedGrow;
    private InputField _HitRateGrow;
    private InputField _DodgeGrow;
    private InputField _CritGrow;
    private InputField _TenacityGrow;
    private InputField _GrowUp;
    private InputField _AdditionalFighting;

	// Use this for initialization
	void Start () {
        inintUI();
        Init();
	}
	
    void inintUI()
    {
        BaseStarGrow = transform.Find("Scroll/Viewport/Type");
    }
    public void Add()
    {
        Length += 1;
        GameObject BasicInformationObj = Instantiate(BaseStarGrow.gameObject, BaseStarGrow.parent.Find("Content"));
        BasicInformationObj.name = "obj" + Length;
        BasicInformationObj.GetComponent<StarGrowAssist>().ID = Length;
        C_StarGrow strarGrow = new C_StarGrow();
        StarGrowData[Length] = strarGrow;
    }

    void Init()
    {
        if(!DataManage.StarGrowJsonData.IsArray)
        {
            return;
        }
        for (int i = 0;i< DataManage.StarGrowJsonData.Count;i++)
        {
            Add();
            _StarType = transform.Find("Scroll/Viewport/Content/obj" + Length + "/StarType").GetComponent<InputField>();
            _ATKGrow = transform.Find("Scroll/Viewport/Content/obj" + Length + "/ATKGrow").GetComponent<InputField>();
            _VitalityGrow = transform.Find("Scroll/Viewport/Content/obj" + Length + "/VitalityGrow").GetComponent<InputField>();
            _ATKSpeedGrow = transform.Find("Scroll/Viewport/Content/obj" + Length + "/ATKSpeedGrow").GetComponent<InputField>();
            _HitRateGrow = transform.Find("Scroll/Viewport/Content/obj" + Length + "/HitRateGrow").GetComponent<InputField>();
            _DodgeGrow = transform.Find("Scroll/Viewport/Content/obj" + Length + "/DodgeGrow").GetComponent<InputField>();
            _CritGrow = transform.Find("Scroll/Viewport/Content/obj" + Length + "/CritGrow").GetComponent<InputField>();
            _TenacityGrow = transform.Find("Scroll/Viewport/Content/obj" + Length + "/TenacityGrow").GetComponent<InputField>();
            _GrowUp = transform.Find("Scroll/Viewport/Content/obj" + Length + "/GrowUp").GetComponent<InputField>();
            _AdditionalFighting = transform.Find("Scroll/Viewport/Content/obj" + Length + "/AdditionalFighting").GetComponent<InputField>();

            StarGrowData[Length].StarType = DataManage.StarGrowJsonData[i]["StarType"].ToInt32();
            StarGrowData[Length].ATKGrow = DataManage.StarGrowJsonData[i]["ATKGrow"].ToInt32();
            StarGrowData[Length].VitalityGrow = DataManage.StarGrowJsonData[i]["VitalityGrow"].ToInt32();
            StarGrowData[Length].ATKSpeedGrow = DataManage.StarGrowJsonData[i]["ATKSpeedGrow"].ToInt32();
            StarGrowData[Length].HitRateGrow = DataManage.StarGrowJsonData[i]["HitRateGrow"].ToInt32();
            StarGrowData[Length].DodgeGrow = DataManage.StarGrowJsonData[i]["DodgeGrow"].ToInt32();
            StarGrowData[Length].CritGrow = DataManage.StarGrowJsonData[i]["CritGrow"].ToInt32();
            StarGrowData[Length].TenacityGrow = DataManage.StarGrowJsonData[i]["TenacityGrow"].ToInt32();
            StarGrowData[Length].GrowUp = DataManage.StarGrowJsonData[i]["GrowCoefficient"].ToInt32();
            StarGrowData[Length].AdditionalFighting = DataManage.StarGrowJsonData[i]["AdditionalFighting"].ToInt32();
            StarGrowData[Length].isJson = true;

            _StarType.text = StarGrowData[Length].StarType.ToString();
            _ATKGrow.text = StarGrowData[Length].ATKGrow.ToString();
            _VitalityGrow.text = StarGrowData[Length].VitalityGrow.ToString();
            _ATKSpeedGrow.text = StarGrowData[Length].ATKSpeedGrow.ToString();
            _HitRateGrow.text = StarGrowData[Length].HitRateGrow.ToString();
            _DodgeGrow.text = StarGrowData[Length].DodgeGrow.ToString();
            _CritGrow.text = StarGrowData[Length].CritGrow.ToString();
            _TenacityGrow.text = StarGrowData[Length].TenacityGrow.ToString();
            _GrowUp.text = StarGrowData[Length].GrowUp.ToString();
            _AdditionalFighting.text = StarGrowData[Length].AdditionalFighting.ToString();

        }
    }

    public void Save(int ID)
    {
        _StarType = transform.Find("Scroll/Viewport/Content/obj"+ID+"/StarType").GetComponent<InputField>();
        _ATKGrow = transform.Find("Scroll/Viewport/Content/obj" + ID + "/ATKGrow").GetComponent<InputField>();
        _VitalityGrow = transform.Find("Scroll/Viewport/Content/obj" + ID + "/VitalityGrow").GetComponent<InputField>();
        _ATKSpeedGrow = transform.Find("Scroll/Viewport/Content/obj" + ID + "/ATKSpeedGrow").GetComponent<InputField>();
        _HitRateGrow = transform.Find("Scroll/Viewport/Content/obj" + ID + "/HitRateGrow").GetComponent<InputField>();
        _DodgeGrow = transform.Find("Scroll/Viewport/Content/obj" + ID + "/DodgeGrow").GetComponent<InputField>();
        _CritGrow = transform.Find("Scroll/Viewport/Content/obj" + ID + "/CritGrow").GetComponent<InputField>();
        _TenacityGrow = transform.Find("Scroll/Viewport/Content/obj" + ID + "/TenacityGrow").GetComponent<InputField>();
        _GrowUp = transform.Find("Scroll/Viewport/Content/obj" + ID + "/GrowUp").GetComponent<InputField>();
        _AdditionalFighting = transform.Find("Scroll/Viewport/Content/obj" + ID + "/AdditionalFighting").GetComponent<InputField>();

        try
        {
            StarGrowData[ID].StarType = int.Parse(_StarType.text);
            StarGrowData[ID].ATKGrow = int.Parse(_ATKGrow.text);
            StarGrowData[ID].VitalityGrow = int.Parse(_VitalityGrow.text);
            StarGrowData[ID].ATKSpeedGrow = int.Parse(_ATKSpeedGrow.text);
            StarGrowData[ID].HitRateGrow = int.Parse(_HitRateGrow.text);
            StarGrowData[ID].DodgeGrow = int.Parse(_DodgeGrow.text);
            StarGrowData[ID].CritGrow = int.Parse(_CritGrow.text);
            StarGrowData[ID].TenacityGrow = int.Parse(_TenacityGrow.text);
            StarGrowData[ID].GrowUp = int.Parse(_GrowUp.text);
            StarGrowData[ID].AdditionalFighting = int.Parse(_AdditionalFighting.text);
        }
        catch(Exception ex)
        {
            WindowControl.SetConsole("输入类型不对，详细："+ex);
            return;
        }

        if (DataManage.SaveStarGrowJson(StarGrowData, ID))
        {
            StarGrowData[ID].isJson = true;
        }


    }

    public void Del(int ID)
    {
        if (ID == 0)
        {
            return;
        }
        Destroy(transform.Find("Scroll/Viewport/Content/obj" + ID).gameObject);

        for (int i = ID + 1; i <= Length; i++)
        {
            transform.Find("Scroll/Viewport/Content/obj" + i).GetComponent<StarGrowAssist>().ID = i - 1;
            transform.Find("Scroll/Viewport/Content/obj" + i).name = "obj" + (i - 1);
            StarGrowData[ID] = StarGrowData[i];

        }
        StarGrowData.Remove(Length);
        print("集合长度=" + StarGrowData.Count);
        Length -= 1;
        DataManage.DelStarGrowJson(ID);
        WindowControl.SetConsole("删除成功");
    }

}
