using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentStoneCondition : MonoBehaviour {
    public int Length = 0;

    private InputField _Id;
    private InputField _HeroId;
    private InputField _Slot1_1;
    private InputField _Slot1_2;
    private InputField _Slot1_3;
    private InputField _Slot1_4;
    private InputField _Slot1_LevelConfine;
    private InputField _Slot2_1;
    private InputField _Slot2_2;
    private InputField _Slot2_3;
    private InputField _Slot2_4;
    private InputField _Slot2_5;
    private InputField _Slot2_6;
    private InputField _Slot2_7;
    private InputField _Slot2_8;
    private InputField _Slot2_LevelConfine;
    private InputField _Slot3_1;
    private InputField _Slot3_2;
    private InputField _Slot3_3;
    private InputField _Slot3_4;
    private InputField _Slot3_5;
    private InputField _Slot3_6;
    private InputField _Slot3_7;
    private InputField _Slot3_8;
    private InputField _Slot3_9;
    private InputField _Slot3_10;
    private InputField _Slot3_11;
    private InputField _Slot3_12;
    private InputField _Slot3_LevelConfine;
    private InputField _Slot4_1;
    private InputField _Slot4_2;
    private InputField _Slot4_3;
    private InputField _Slot4_4;
    private InputField _Slot4_5;
    private InputField _Slot4_6;
    private InputField _Slot4_7;
    private InputField _Slot4_8;
    private InputField _Slot4_9;
    private InputField _Slot4_10;
    private InputField _Slot4_11;
    private InputField _Slot4_12;
    private InputField _Slot4_13;
    private InputField _Slot4_14;
    private InputField _Slot4_15;
    private InputField _Slot4_16;
    private InputField _Slot4_LevelConfine;

    public Dictionary<int, C_TalentStoneCondition> talentStoneConditions = new Dictionary<int, C_TalentStoneCondition>();

    Transform _basicInformation;
    public Transform BasicInformation
    {
        get
        {
            if (_basicInformation == null)
            {
                _basicInformation = transform.Find("Viewport/type");
                return _basicInformation;
            }
            return _basicInformation;
        }
    }

    Transform _tipTitle;
    public Transform TipTitle
    {
        get
        {
            if (_tipTitle == null)
            {
                _tipTitle = transform.Find("TipTitleX/Viewport/type");
                return _tipTitle;
            }
            return _tipTitle;
        }
    }
    void Start()
    {
        Init();
    }

    public void Init()
    {
        /*Length = 0;


        for (int i = 0; i < transform.Find("Viewport/Content").childCount;i++)
        {
            Destroy(transform.Find("Viewport/Content/obj" + (i + 1)).gameObject);
            Destroy(transform.Find("TipTitleX/Viewport/Content/obj" + (i + 1)).gameObject);
            heroData.Remove(i+1);
        }*/
        //print("dddd" + DataManage.Data.ToJson());
        if (!DataManage.TalentStoneConditionJsonData.IsArray)
        {
            return;
        }

        for (int i = 0; i < DataManage.TalentStoneConditionJsonData.Count; i++)
        {
            OnAdd();
            _Id = transform.Find("Viewport/Content/obj" + Length + "/Id").GetComponent<InputField>();
            _HeroId = transform.Find("Viewport/Content/obj" + Length + "/HeroId").GetComponent<InputField>();
            _Slot1_1 = transform.Find("Viewport/Content/obj" + Length + "/Slot1-1").GetComponent<InputField>();
            _Slot1_2 = transform.Find("Viewport/Content/obj" + Length + "/Slot1-2").GetComponent<InputField>();
            _Slot1_3 = transform.Find("Viewport/Content/obj" + Length + "/Slot1-3").GetComponent<InputField>();
            _Slot1_4 = transform.Find("Viewport/Content/obj" + Length + "/Slot1-4").GetComponent<InputField>();
            _Slot1_LevelConfine = transform.Find("Viewport/Content/obj" + Length + "/Slot1-LevelConfine").GetComponent<InputField>();
            _Slot2_1 = transform.Find("Viewport/Content/obj" + Length + "/Slot2-1").GetComponent<InputField>();
            _Slot2_2 = transform.Find("Viewport/Content/obj" + Length + "/Slot2-2").GetComponent<InputField>();
            _Slot2_3 = transform.Find("Viewport/Content/obj" + Length + "/Slot2-3").GetComponent<InputField>();
            _Slot2_4 = transform.Find("Viewport/Content/obj" + Length + "/Slot2-4").GetComponent<InputField>();
            _Slot2_5 = transform.Find("Viewport/Content/obj" + Length + "/Slot2-5").GetComponent<InputField>();
            _Slot2_6 = transform.Find("Viewport/Content/obj" + Length + "/Slot2-6").GetComponent<InputField>();
            _Slot2_7 = transform.Find("Viewport/Content/obj" + Length + "/Slot2-7").GetComponent<InputField>();
            _Slot2_8 = transform.Find("Viewport/Content/obj" + Length + "/Slot2-8").GetComponent<InputField>();
            _Slot2_LevelConfine = transform.Find("Viewport/Content/obj" + Length + "/Slot2-LevelConfine").GetComponent<InputField>();
            _Slot3_1 = transform.Find("Viewport/Content/obj" + Length + "/Slot3-1").GetComponent<InputField>();
            _Slot3_2 = transform.Find("Viewport/Content/obj" + Length + "/Slot3-2").GetComponent<InputField>();
            _Slot3_3 = transform.Find("Viewport/Content/obj" + Length + "/Slot3-3").GetComponent<InputField>();
            _Slot3_4 = transform.Find("Viewport/Content/obj" + Length + "/Slot3-4").GetComponent<InputField>();
            _Slot3_5 = transform.Find("Viewport/Content/obj" + Length + "/Slot3-5").GetComponent<InputField>();
            _Slot3_6 = transform.Find("Viewport/Content/obj" + Length + "/Slot3-6").GetComponent<InputField>();
            _Slot3_7 = transform.Find("Viewport/Content/obj" + Length + "/Slot3-7").GetComponent<InputField>();
            _Slot3_8 = transform.Find("Viewport/Content/obj" + Length + "/Slot3-8").GetComponent<InputField>();
            _Slot3_9 = transform.Find("Viewport/Content/obj" + Length + "/Slot3-9").GetComponent<InputField>();
            _Slot3_10 = transform.Find("Viewport/Content/obj" + Length + "/Slot3-10").GetComponent<InputField>();
            _Slot3_11 = transform.Find("Viewport/Content/obj" + Length + "/Slot3-11").GetComponent<InputField>();
            _Slot3_12 = transform.Find("Viewport/Content/obj" + Length + "/Slot3-12").GetComponent<InputField>();
            _Slot3_LevelConfine = transform.Find("Viewport/Content/obj" + Length + "/Slot3-LevelConfine").GetComponent<InputField>();
            _Slot4_1 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-1").GetComponent<InputField>();
            _Slot4_2 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-2").GetComponent<InputField>();
            _Slot4_3 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-3").GetComponent<InputField>();
            _Slot4_4 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-4").GetComponent<InputField>();
            _Slot4_5 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-5").GetComponent<InputField>();
            _Slot4_6 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-6").GetComponent<InputField>();
            _Slot4_7 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-7").GetComponent<InputField>();
            _Slot4_8 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-8").GetComponent<InputField>();
            _Slot4_9 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-9").GetComponent<InputField>();
            _Slot4_10 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-10").GetComponent<InputField>();
            _Slot4_11 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-11").GetComponent<InputField>();
            _Slot4_12 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-12").GetComponent<InputField>();
            _Slot4_13 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-13").GetComponent<InputField>();
            _Slot4_14 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-14").GetComponent<InputField>();
            _Slot4_15 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-15").GetComponent<InputField>();
            _Slot4_16 = transform.Find("Viewport/Content/obj" + Length + "/Slot4-16").GetComponent<InputField>();
            _Slot4_LevelConfine = transform.Find("Viewport/Content/obj" + Length + "/Slot4-LevelConfine").GetComponent<InputField>();

            talentStoneConditions[Length].Id = DataManage.TalentStoneConditionJsonData[i]["Id"].ToInt32();
            talentStoneConditions[Length].HeroId = DataManage.TalentStoneConditionJsonData[i]["HeroId"].ToInt32();
            talentStoneConditions[Length].Slot1_1 = DataManage.TalentStoneConditionJsonData[i]["Slot1_1"].ToInt32();
            talentStoneConditions[Length].Slot1_2 = DataManage.TalentStoneConditionJsonData[i]["Slot1_2"].ToInt32();
            talentStoneConditions[Length].Slot1_3 = DataManage.TalentStoneConditionJsonData[i]["Slot1_3"].ToInt32();
            talentStoneConditions[Length].Slot1_4 = DataManage.TalentStoneConditionJsonData[i]["Slot1_4"].ToInt32();
            talentStoneConditions[Length].Slot1_LevelConfine = DataManage.TalentStoneConditionJsonData[i]["Slot1_LevelConfine"].ToInt32();
            talentStoneConditions[Length].Slot2_1 = DataManage.TalentStoneConditionJsonData[i]["Slot2_1"].ToInt32();
            talentStoneConditions[Length].Slot2_2 = DataManage.TalentStoneConditionJsonData[i]["Slot2_2"].ToInt32();
            talentStoneConditions[Length].Slot2_3 = DataManage.TalentStoneConditionJsonData[i]["Slot2_3"].ToInt32();
            talentStoneConditions[Length].Slot2_4 = DataManage.TalentStoneConditionJsonData[i]["Slot2_4"].ToInt32();
            talentStoneConditions[Length].Slot2_5 = DataManage.TalentStoneConditionJsonData[i]["Slot2_5"].ToInt32();
            talentStoneConditions[Length].Slot2_6 = DataManage.TalentStoneConditionJsonData[i]["Slot2_6"].ToInt32();
            talentStoneConditions[Length].Slot2_7 = DataManage.TalentStoneConditionJsonData[i]["Slot2_7"].ToInt32();
            talentStoneConditions[Length].Slot2_8 = DataManage.TalentStoneConditionJsonData[i]["Slot2_8"].ToInt32();
            talentStoneConditions[Length].Slot2_LevelConfine = DataManage.TalentStoneConditionJsonData[i]["Slot2_LevelConfine"].ToInt32();
            talentStoneConditions[Length].Slot3_1 = DataManage.TalentStoneConditionJsonData[i]["Slot3_1"].ToInt32();
            talentStoneConditions[Length].Slot3_2 = DataManage.TalentStoneConditionJsonData[i]["Slot3_2"].ToInt32();
            talentStoneConditions[Length].Slot3_3 = DataManage.TalentStoneConditionJsonData[i]["Slot3_3"].ToInt32();
            talentStoneConditions[Length].Slot3_4 = DataManage.TalentStoneConditionJsonData[i]["Slot3_4"].ToInt32();
            talentStoneConditions[Length].Slot3_5 = DataManage.TalentStoneConditionJsonData[i]["Slot3_5"].ToInt32();
            talentStoneConditions[Length].Slot3_6 = DataManage.TalentStoneConditionJsonData[i]["Slot3_6"].ToInt32();
            talentStoneConditions[Length].Slot3_7 = DataManage.TalentStoneConditionJsonData[i]["Slot3_7"].ToInt32();
            talentStoneConditions[Length].Slot3_8 = DataManage.TalentStoneConditionJsonData[i]["Slot3_8"].ToInt32();
            talentStoneConditions[Length].Slot3_9 = DataManage.TalentStoneConditionJsonData[i]["Slot3_9"].ToInt32();
            talentStoneConditions[Length].Slot3_10 = DataManage.TalentStoneConditionJsonData[i]["Slot3_10"].ToInt32();
            talentStoneConditions[Length].Slot3_11 = DataManage.TalentStoneConditionJsonData[i]["Slot3_11"].ToInt32();
            talentStoneConditions[Length].Slot3_12 = DataManage.TalentStoneConditionJsonData[i]["Slot3_12"].ToInt32();
            talentStoneConditions[Length].Slot3_LevelConfine = DataManage.TalentStoneConditionJsonData[i]["Slot3_LevelConfine"].ToInt32();
            talentStoneConditions[Length].Slot4_1 = DataManage.TalentStoneConditionJsonData[i]["Slot4_1"].ToInt32();
            talentStoneConditions[Length].Slot4_2 = DataManage.TalentStoneConditionJsonData[i]["Slot4_2"].ToInt32();
            talentStoneConditions[Length].Slot4_3 = DataManage.TalentStoneConditionJsonData[i]["Slot4_3"].ToInt32();
            talentStoneConditions[Length].Slot4_4 = DataManage.TalentStoneConditionJsonData[i]["Slot4_4"].ToInt32();
            talentStoneConditions[Length].Slot4_5 = DataManage.TalentStoneConditionJsonData[i]["Slot4_5"].ToInt32();
            talentStoneConditions[Length].Slot4_6 = DataManage.TalentStoneConditionJsonData[i]["Slot4_6"].ToInt32();
            talentStoneConditions[Length].Slot4_7 = DataManage.TalentStoneConditionJsonData[i]["Slot4_7"].ToInt32();
            talentStoneConditions[Length].Slot4_8 = DataManage.TalentStoneConditionJsonData[i]["Slot4_8"].ToInt32();
            talentStoneConditions[Length].Slot4_9 = DataManage.TalentStoneConditionJsonData[i]["Slot4_9"].ToInt32();
            talentStoneConditions[Length].Slot4_10 = DataManage.TalentStoneConditionJsonData[i]["Slot4_10"].ToInt32();
            talentStoneConditions[Length].Slot4_11 = DataManage.TalentStoneConditionJsonData[i]["Slot4_11"].ToInt32();
            talentStoneConditions[Length].Slot4_12 = DataManage.TalentStoneConditionJsonData[i]["Slot4_12"].ToInt32();
            talentStoneConditions[Length].Slot4_13 = DataManage.TalentStoneConditionJsonData[i]["Slot4_13"].ToInt32();
            talentStoneConditions[Length].Slot4_14 = DataManage.TalentStoneConditionJsonData[i]["Slot4_14"].ToInt32();
            talentStoneConditions[Length].Slot4_15 = DataManage.TalentStoneConditionJsonData[i]["Slot4_15"].ToInt32();
            talentStoneConditions[Length].Slot4_16 = DataManage.TalentStoneConditionJsonData[i]["Slot4_16"].ToInt32();
            talentStoneConditions[Length].Slot4_LevelConfine = DataManage.TalentStoneConditionJsonData[i]["Slot4_LevelConfine"].ToInt32();

            talentStoneConditions[Length].IsJson = true;

            //print("DataManage=" + DataManage.HeroJsonData.Count);
            _Id.text = talentStoneConditions[Length].Id.ToString();
            _HeroId.text = talentStoneConditions[Length].HeroId.ToString();
            _Slot1_1.text = talentStoneConditions[Length].Slot1_1.ToString();
            _Slot1_2.text = talentStoneConditions[Length].Slot1_2.ToString();
            _Slot1_3.text = talentStoneConditions[Length].Slot1_3.ToString();
            _Slot1_4.text = talentStoneConditions[Length].Slot1_4.ToString();
            _Slot1_LevelConfine.text = talentStoneConditions[Length].Slot1_LevelConfine.ToString();
            _Slot2_1.text = talentStoneConditions[Length].Slot2_1.ToString();
            _Slot2_2.text = talentStoneConditions[Length].Slot2_2.ToString();
            _Slot2_3.text = talentStoneConditions[Length].Slot2_3.ToString();
            _Slot2_4.text = talentStoneConditions[Length].Slot2_4.ToString();
            _Slot2_5.text = talentStoneConditions[Length].Slot2_5.ToString();
            _Slot2_6.text = talentStoneConditions[Length].Slot2_6.ToString();
            _Slot2_7.text = talentStoneConditions[Length].Slot2_7.ToString();
            _Slot2_8.text = talentStoneConditions[Length].Slot2_8.ToString();
            _Slot2_LevelConfine.text = talentStoneConditions[Length].Slot2_LevelConfine.ToString();
            _Slot3_1.text = talentStoneConditions[Length].Slot3_1.ToString();
            _Slot3_2.text = talentStoneConditions[Length].Slot3_2.ToString();
            _Slot3_3.text = talentStoneConditions[Length].Slot3_3.ToString();
            _Slot3_4.text = talentStoneConditions[Length].Slot3_4.ToString();
            _Slot3_5.text = talentStoneConditions[Length].Slot3_5.ToString();
            _Slot3_6.text = talentStoneConditions[Length].Slot3_6.ToString();
            _Slot3_7.text = talentStoneConditions[Length].Slot3_7.ToString();
            _Slot3_8.text = talentStoneConditions[Length].Slot3_8.ToString();
            _Slot3_9.text = talentStoneConditions[Length].Slot3_9.ToString();
            _Slot3_10.text = talentStoneConditions[Length].Slot3_10.ToString();
            _Slot3_11.text = talentStoneConditions[Length].Slot3_11.ToString();
            _Slot3_12.text = talentStoneConditions[Length].Slot3_12.ToString();
            _Slot3_LevelConfine.text = talentStoneConditions[Length].Slot3_LevelConfine.ToString();
            _Slot4_1.text = talentStoneConditions[Length].Slot4_1.ToString();
            _Slot4_2.text = talentStoneConditions[Length].Slot4_2.ToString();
            _Slot4_3.text = talentStoneConditions[Length].Slot4_3.ToString();
            _Slot4_4.text = talentStoneConditions[Length].Slot4_4.ToString();
            _Slot4_5.text = talentStoneConditions[Length].Slot4_5.ToString();
            _Slot4_6.text = talentStoneConditions[Length].Slot4_6.ToString();
            _Slot4_7.text = talentStoneConditions[Length].Slot4_7.ToString();
            _Slot4_8.text = talentStoneConditions[Length].Slot4_8.ToString();
            _Slot4_9.text = talentStoneConditions[Length].Slot4_9.ToString();
            _Slot4_10.text = talentStoneConditions[Length].Slot4_10.ToString();
            _Slot4_11.text = talentStoneConditions[Length].Slot4_11.ToString();
            _Slot4_12.text = talentStoneConditions[Length].Slot4_12.ToString();
            _Slot4_13.text = talentStoneConditions[Length].Slot4_13.ToString();
            _Slot4_14.text = talentStoneConditions[Length].Slot4_14.ToString();
            _Slot4_15.text = talentStoneConditions[Length].Slot4_15.ToString();
            _Slot4_16.text = talentStoneConditions[Length].Slot4_16.ToString();
            _Slot4_LevelConfine.text = talentStoneConditions[Length].Slot4_LevelConfine.ToString();
        }
    }

    public void Save(int ID)
    {
        _Id= transform.Find("Viewport/Content/obj" + ID + "/Id").GetComponent<InputField>();
        _HeroId= transform.Find("Viewport/Content/obj" + ID + "/HeroId").GetComponent<InputField>();
        _Slot1_1 = transform.Find("Viewport/Content/obj" + ID + "/Slot1-1").GetComponent<InputField>();
        _Slot1_2 = transform.Find("Viewport/Content/obj" + ID + "/Slot1-2").GetComponent<InputField>();
        _Slot1_3 = transform.Find("Viewport/Content/obj" + ID + "/Slot1-3").GetComponent<InputField>();
        _Slot1_4 = transform.Find("Viewport/Content/obj" + ID + "/Slot1-4").GetComponent<InputField>();
        _Slot1_LevelConfine = transform.Find("Viewport/Content/obj" + ID + "/Slot1-LevelConfine").GetComponent<InputField>();
        _Slot2_1 = transform.Find("Viewport/Content/obj" + ID + "/Slot2-1").GetComponent<InputField>();
        _Slot2_2 = transform.Find("Viewport/Content/obj" + ID + "/Slot2-2").GetComponent<InputField>();
        _Slot2_3 = transform.Find("Viewport/Content/obj" + ID + "/Slot2-3").GetComponent<InputField>();
        _Slot2_4 = transform.Find("Viewport/Content/obj" + ID + "/Slot2-4").GetComponent<InputField>();
        _Slot2_5 = transform.Find("Viewport/Content/obj" + ID + "/Slot2-5").GetComponent<InputField>();
        _Slot2_6 = transform.Find("Viewport/Content/obj" + ID + "/Slot2-6").GetComponent<InputField>();
        _Slot2_7 = transform.Find("Viewport/Content/obj" + ID + "/Slot2-7").GetComponent<InputField>();
        _Slot2_8 = transform.Find("Viewport/Content/obj" + ID + "/Slot2-8").GetComponent<InputField>();
        _Slot2_LevelConfine = transform.Find("Viewport/Content/obj" + ID + "/Slot2-LevelConfine").GetComponent<InputField>();
        _Slot3_1 = transform.Find("Viewport/Content/obj" + ID + "/Slot3-1").GetComponent<InputField>();
        _Slot3_2 = transform.Find("Viewport/Content/obj" + ID + "/Slot3-2").GetComponent<InputField>();
        _Slot3_3 = transform.Find("Viewport/Content/obj" + ID + "/Slot3-3").GetComponent<InputField>();
        _Slot3_4 = transform.Find("Viewport/Content/obj" + ID + "/Slot3-4").GetComponent<InputField>();
        _Slot3_5 = transform.Find("Viewport/Content/obj" + ID + "/Slot3-5").GetComponent<InputField>();
        _Slot3_6 = transform.Find("Viewport/Content/obj" + ID + "/Slot3-6").GetComponent<InputField>();
        _Slot3_7 = transform.Find("Viewport/Content/obj" + ID + "/Slot3-7").GetComponent<InputField>();
        _Slot3_8 = transform.Find("Viewport/Content/obj" + ID + "/Slot3-8").GetComponent<InputField>();
        _Slot3_9 = transform.Find("Viewport/Content/obj" + ID + "/Slot3-9").GetComponent<InputField>();
        _Slot3_10 = transform.Find("Viewport/Content/obj" + ID + "/Slot3-10").GetComponent<InputField>();
        _Slot3_11 = transform.Find("Viewport/Content/obj" + ID + "/Slot3-11").GetComponent<InputField>();
        _Slot3_12 = transform.Find("Viewport/Content/obj" + ID + "/Slot3-12").GetComponent<InputField>();
        _Slot3_LevelConfine = transform.Find("Viewport/Content/obj" + ID + "/Slot3-LevelConfine").GetComponent<InputField>();
        _Slot4_1 = transform.Find("Viewport/Content/obj" + ID + "/Slot4-1").GetComponent<InputField>();
        _Slot4_2 = transform.Find("Viewport/Content/obj" + ID + "/Slot4-2").GetComponent<InputField>();
        _Slot4_3 = transform.Find("Viewport/Content/obj" + ID + "/Slot4-3").GetComponent<InputField>();
        _Slot4_4 = transform.Find("Viewport/Content/obj" + ID + "/Slot4-4").GetComponent<InputField>();
        _Slot4_5 = transform.Find("Viewport/Content/obj" + ID + "/Slot4-5").GetComponent<InputField>();
        _Slot4_6 = transform.Find("Viewport/Content/obj" + ID + "/Slot4-6").GetComponent<InputField>();
        _Slot4_7 = transform.Find("Viewport/Content/obj" + ID + "/Slot4-7").GetComponent<InputField>();
        _Slot4_8 = transform.Find("Viewport/Content/obj" + ID + "/Slot4-8").GetComponent<InputField>();
        _Slot4_9 = transform.Find("Viewport/Content/obj" + ID + "/Slot4-9").GetComponent<InputField>();
        _Slot4_10 = transform.Find("Viewport/Content/obj" + ID + "/Slot4-10").GetComponent<InputField>();
        _Slot4_11 = transform.Find("Viewport/Content/obj" + ID + "/Slot4-11").GetComponent<InputField>();
        _Slot4_12 = transform.Find("Viewport/Content/obj" + ID + "/Slot4-12").GetComponent<InputField>();
        _Slot4_13= transform.Find("Viewport/Content/obj" + ID + "/Slot4-13").GetComponent<InputField>();
        _Slot4_14 = transform.Find("Viewport/Content/obj" + ID + "/Slot4-14").GetComponent<InputField>();
        _Slot4_15 = transform.Find("Viewport/Content/obj" + ID + "/Slot4-15").GetComponent<InputField>();
        _Slot4_16 = transform.Find("Viewport/Content/obj" + ID + "/Slot4-16").GetComponent<InputField>();
        _Slot4_LevelConfine = transform.Find("Viewport/Content/obj" + ID + "/Slot4-LevelConfine").GetComponent<InputField>();

        try
        {
            talentStoneConditions[ID].Id = int.Parse(_Id.text);
            talentStoneConditions[ID].HeroId = int.Parse(_HeroId.text);
            talentStoneConditions[ID].Slot1_1 = int.Parse(_Slot1_1.text);
            talentStoneConditions[ID].Slot1_2 = int.Parse(_Slot1_2.text);
            talentStoneConditions[ID].Slot1_3 = int.Parse(_Slot1_3.text);
            talentStoneConditions[ID].Slot1_4 = int.Parse(_Slot1_4.text);
            talentStoneConditions[ID].Slot1_LevelConfine = int.Parse(_Slot1_LevelConfine.text);
            talentStoneConditions[ID].Slot2_1 = int.Parse(_Slot2_1.text);
            talentStoneConditions[ID].Slot2_2 = int.Parse(_Slot2_2.text);
            talentStoneConditions[ID].Slot2_3 = int.Parse(_Slot2_3.text);
            talentStoneConditions[ID].Slot2_4 = int.Parse(_Slot2_4.text);
            talentStoneConditions[ID].Slot2_5 = int.Parse(_Slot2_5.text);
            talentStoneConditions[ID].Slot2_6 = int.Parse(_Slot2_6.text);
            talentStoneConditions[ID].Slot2_7 = int.Parse(_Slot2_7.text);
            talentStoneConditions[ID].Slot2_8 = int.Parse(_Slot2_8.text);
            talentStoneConditions[ID].Slot2_LevelConfine = int.Parse(_Slot2_LevelConfine.text);
            talentStoneConditions[ID].Slot3_1 = int.Parse(_Slot3_1.text);
            talentStoneConditions[ID].Slot3_2 = int.Parse(_Slot3_2.text);
            talentStoneConditions[ID].Slot3_3 = int.Parse(_Slot3_3.text);
            talentStoneConditions[ID].Slot3_4 = int.Parse(_Slot3_4.text);
            talentStoneConditions[ID].Slot3_5 = int.Parse(_Slot3_5.text);
            talentStoneConditions[ID].Slot3_6 = int.Parse(_Slot3_6.text);
            talentStoneConditions[ID].Slot3_7 = int.Parse(_Slot3_7.text);
            talentStoneConditions[ID].Slot3_8 = int.Parse(_Slot3_8.text);
            talentStoneConditions[ID].Slot3_9 = int.Parse(_Slot3_9.text);
            talentStoneConditions[ID].Slot3_10 = int.Parse(_Slot3_10.text);
            talentStoneConditions[ID].Slot3_11 = int.Parse(_Slot3_11.text);
            talentStoneConditions[ID].Slot3_12 = int.Parse(_Slot3_12.text);
            talentStoneConditions[ID].Slot3_LevelConfine = int.Parse(_Slot3_LevelConfine.text);
            talentStoneConditions[ID].Slot4_1 = int.Parse(_Slot4_1.text);
            talentStoneConditions[ID].Slot4_2 = int.Parse(_Slot4_2.text);
            talentStoneConditions[ID].Slot4_3 = int.Parse(_Slot4_3.text);
            talentStoneConditions[ID].Slot4_4 = int.Parse(_Slot4_4.text);
            talentStoneConditions[ID].Slot4_5 = int.Parse(_Slot4_5.text);
            talentStoneConditions[ID].Slot4_6 = int.Parse(_Slot4_6.text);
            talentStoneConditions[ID].Slot4_7 = int.Parse(_Slot4_7.text);
            talentStoneConditions[ID].Slot4_8 = int.Parse(_Slot4_8.text);
            talentStoneConditions[ID].Slot4_9 = int.Parse(_Slot4_9.text);
            talentStoneConditions[ID].Slot4_10 = int.Parse(_Slot4_10.text);
            talentStoneConditions[ID].Slot4_11 = int.Parse(_Slot4_11.text);
            talentStoneConditions[ID].Slot4_12 = int.Parse(_Slot4_12.text);
            talentStoneConditions[ID].Slot4_13 = int.Parse(_Slot4_13.text);
            talentStoneConditions[ID].Slot4_14 = int.Parse(_Slot4_14.text);
            talentStoneConditions[ID].Slot4_15 = int.Parse(_Slot4_15.text);
            talentStoneConditions[ID].Slot4_16 = int.Parse(_Slot4_16.text);
            talentStoneConditions[ID].Slot4_LevelConfine = int.Parse(_Slot4_LevelConfine.text);


        }
        catch (Exception ex)
        {
            // 错误处理代码
            WindowControl.SetConsole("保存失败，你填写的数据类型不对,详细：" + ex.Message);
            //transform.parent.Find("Console/Text").GetComponent<Text>().text = "保存失败，你填写的数据类型不对,详细："+ex.Message+"--------------时间："+DateTime.Now.ToString();
            return;
        }

        if (DataManage.SaveTalentStoneConditionDate(talentStoneConditions, ID))
        {
            talentStoneConditions[ID].IsJson = true;
        }

        //transform.parent.Find("Console/Text").GetComponent<Text>().text = "保存成功-----------------时间"+DateTime.Now.ToString();

    }

    public void OnAdd()
    {
        Length += 1;
        GameObject BasicInformationObj = Instantiate(BasicInformation.gameObject, BasicInformation.parent.Find("Content"));
        GameObject TipTitleObj = Instantiate(TipTitle.gameObject, TipTitle.parent.Find("Content"));
        BasicInformationObj.name = "obj" + Length;
        TipTitleObj.name = "obj" + Length;
        TipTitleObj.GetComponent<CommonAssist>().ID = Length;
        transform.Find("Scrollbar Horizontal").GetComponent<Scrollbar>().value = 1;
        //------------数据处理------------------//
        C_TalentStoneCondition c_talentStoneCondition = new C_TalentStoneCondition();
        //heroData[Length-1] = s_heroData;
        //heroData.Add(Length, c_heroData);
        talentStoneConditions[Length] = (c_talentStoneCondition);
    }

    public void Del(int ID)
    {
        if (ID == 0)
        {
            return;
        }
        Destroy(transform.Find("Viewport/Content/obj" + ID).gameObject);
        Destroy(transform.Find("TipTitleX/Viewport/Content/obj" + ID).gameObject);

        for (int i = ID + 1; i <= Length; i++)
        {
            transform.Find("TipTitleX/Viewport/Content/obj" + i).GetComponent<CommonAssist>().ID = i - 1;
            transform.Find("Viewport/Content/obj" + i).name = "obj" + (i - 1);
            transform.Find("TipTitleX/Viewport/Content/obj" + i).name = "obj" + (i - 1);
            talentStoneConditions[ID] = talentStoneConditions[i];

        }
        talentStoneConditions.Remove(Length);
        print("集合长度=" + talentStoneConditions.Count);
        Length -= 1;
        DataManage.DelTalentStoneConditionDate(ID);
        WindowControl.SetConsole("删除成功");
        //transform.parent.Find("Console/Text").GetComponent<Text>().text = "删除成功-----------------时间" + DateTime.Now.ToString();
    }
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		
	}
}
