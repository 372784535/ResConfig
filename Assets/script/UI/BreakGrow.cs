using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakGrow : MonoBehaviour {
    public int Length = 0;
    public Dictionary<int, C_BreakGrow> breakGrows = new Dictionary<int, C_BreakGrow>();
    Transform BaseBreakGrow;
    private InputField Level;
    private InputField AddCoefficient;
    private InputField VitalityGrow;
    private InputField BreakNum;
    private InputField ConsumptionGold;
    private InputField ConsumptionBG;
    private InputField ConsumptionEssence;
    // Use this for initialization
    void Start () {
        BaseBreakGrow = transform.Find("Scroll/Viewport/Type");
        Init();
    }

    void Init()
    {
        if (!DataManage.BreakGrowJsonData.IsArray)
        {
            return;
        }
        for (int i = 0; i < DataManage.BreakGrowJsonData.Count; i++)
        {
            Add();
            Level = transform.Find("Scroll/Viewport/Content/obj" + Length + "/Level").GetComponent<InputField>();
            AddCoefficient = transform.Find("Scroll/Viewport/Content/obj" + Length + "/AddCoefficient").GetComponent<InputField>();
            VitalityGrow = transform.Find("Scroll/Viewport/Content/obj" + Length + "/VitalityGrow").GetComponent<InputField>();
            BreakNum = transform.Find("Scroll/Viewport/Content/obj" + Length + "/BreakNum").GetComponent<InputField>();
            ConsumptionGold = transform.Find("Scroll/Viewport/Content/obj" + Length + "/ConsumptionGold").GetComponent<InputField>();
            ConsumptionBG = transform.Find("Scroll/Viewport/Content/obj" + Length + "/ConsumptionBG").GetComponent<InputField>();
            ConsumptionEssence = transform.Find("Scroll/Viewport/Content/obj" + Length + "/ConsumptionEssence").GetComponent<InputField>();;

            breakGrows[Length].Level = DataManage.BreakGrowJsonData[i]["Level"].ToInt32();
            breakGrows[Length].AddCoefficient = DataManage.BreakGrowJsonData[i]["AddCoefficient"].ToInt32();
            breakGrows[Length].VitalityGrow = DataManage.BreakGrowJsonData[i]["VitalityGrow"].ToInt32();
            breakGrows[Length].BreakNum = DataManage.BreakGrowJsonData[i]["BreakNum"].ToInt32();
            breakGrows[Length].ConsumptionGold = DataManage.BreakGrowJsonData[i]["ConsumptionGold"].ToInt32();
            breakGrows[Length].ConsumptionBG = DataManage.BreakGrowJsonData[i]["ConsumptionBG"].ToInt32();
            breakGrows[Length].ConsumptionEssence = DataManage.BreakGrowJsonData[i]["ConsumptionEssence"].ToInt32();
            breakGrows[Length].IsJson = true;

            Level.text = breakGrows[Length].Level.ToString();
            AddCoefficient.text = breakGrows[Length].AddCoefficient.ToString();
            VitalityGrow.text = breakGrows[Length].VitalityGrow.ToString();
            BreakNum.text = breakGrows[Length].BreakNum.ToString();
            ConsumptionGold.text = breakGrows[Length].ConsumptionGold.ToString();
            ConsumptionBG.text = breakGrows[Length].ConsumptionBG.ToString();
            ConsumptionEssence.text = breakGrows[Length].ConsumptionEssence.ToString();
        }
    }

    public void Add()
    {
        Length += 1;
        GameObject BasicInformationObj = Instantiate(BaseBreakGrow.gameObject, BaseBreakGrow.parent.Find("Content"));
        BasicInformationObj.name = "obj" + Length;
        BasicInformationObj.GetComponent<CommonAssist>().ID = Length;
        C_BreakGrow breakGrow = new C_BreakGrow();
        breakGrows[Length] = breakGrow;
    }

    public void Save(int ID)
    {
        Level = transform.Find("Scroll/Viewport/Content/obj" + ID + "/Level").GetComponent<InputField>();
        AddCoefficient = transform.Find("Scroll/Viewport/Content/obj" + ID + "/AddCoefficient").GetComponent<InputField>();
        VitalityGrow = transform.Find("Scroll/Viewport/Content/obj" + ID + "/VitalityGrow").GetComponent<InputField>();
        BreakNum = transform.Find("Scroll/Viewport/Content/obj" + ID + "/BreakNum").GetComponent<InputField>();
        ConsumptionGold = transform.Find("Scroll/Viewport/Content/obj" + ID + "/ConsumptionGold").GetComponent<InputField>();
        ConsumptionBG = transform.Find("Scroll/Viewport/Content/obj" + ID + "/ConsumptionBG").GetComponent<InputField>();
        ConsumptionEssence = transform.Find("Scroll/Viewport/Content/obj" + ID + "/ConsumptionEssence").GetComponent<InputField>();

        try
        {
            breakGrows[ID].Level = int.Parse(Level.text);
            breakGrows[ID].AddCoefficient = int.Parse(AddCoefficient.text);
            breakGrows[ID].VitalityGrow = int.Parse(VitalityGrow.text);
            breakGrows[ID].BreakNum = int.Parse(BreakNum.text);
            breakGrows[ID].ConsumptionGold = int.Parse(ConsumptionGold.text);
            breakGrows[ID].ConsumptionBG = int.Parse(ConsumptionBG.text);
            breakGrows[ID].ConsumptionEssence = int.Parse(ConsumptionEssence.text);
        }

        catch (Exception ex)
        {
            WindowControl.SetConsole("输入类型不对，详细：" + ex);
            return;
        }

        if (DataManage.SaveBreakGrowsJson(breakGrows, ID))
        {
            breakGrows[ID].IsJson = true;
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
            transform.Find("Scroll/Viewport/Content/obj" + i).GetComponent<CommonAssist>().ID = i - 1;
            transform.Find("Scroll/Viewport/Content/obj" + i).name = "obj" + (i - 1);
            breakGrows[ID] = breakGrows[i];

        }
        breakGrows.Remove(Length);
        print("集合长度=" + breakGrows.Count);
        Length -= 1;
        DataManage.DelBreakGrowsJson(ID);
        WindowControl.SetConsole("删除成功");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
