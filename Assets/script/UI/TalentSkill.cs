using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentSkill : MonoBehaviour {
    public int Length = 0;
    public Dictionary<int, C_TalentSkill> talentSkill = new Dictionary<int, C_TalentSkill>();

    private InputField _Id;
    private InputField _HeroId;
    private InputField _TalentName;
    private Dropdown _Type;
    private Dropdown _IsActivate;
    private InputField _RelevantSkill;
    private InputField _Result;
    private InputField _ActivateResource1;
    private InputField _Resource1Count;
    private InputField _ActivateResource2;
    private InputField _Resource2Count;
    private InputField _ActivateResource3;
    private InputField _Resource3Count;

    private Transform BaseTalentSkill;

	// Use this for initialization
	void Start () {
        BaseTalentSkill = transform.Find("Scroll/Viewport/Type");
        Init();
	}

    void Init()
    {
        if (!DataManage.TalentSkillJsonData.IsArray)
        {
            return;
        }
        for (int i = 0; i < DataManage.TalentSkillJsonData.Count; i++)
        {
            Add();
            _Id = transform.Find("Scroll/Viewport/Content/obj" + Length + "/Id").GetComponent<InputField>();
            _HeroId= transform.Find("Scroll/Viewport/Content/obj" + Length + "/HeroId").GetComponent<InputField>();
            _TalentName = transform.Find("Scroll/Viewport/Content/obj" + Length + "/TalentName").GetComponent<InputField>();
            _Type = transform.Find("Scroll/Viewport/Content/obj" + Length + "/Type").GetComponent<Dropdown>();
            _IsActivate = transform.Find("Scroll/Viewport/Content/obj" + Length + "/IsActivate").GetComponent<Dropdown>();
            _RelevantSkill = transform.Find("Scroll/Viewport/Content/obj" + Length + "/RelevantSkill").GetComponent<InputField>();
            _Result = transform.Find("Scroll/Viewport/Content/obj" + Length + "/Result").GetComponent<InputField>();
            _ActivateResource1 = transform.Find("Scroll/Viewport/Content/obj" + Length + "/ActivateResource1").GetComponent<InputField>();
            _Resource1Count = transform.Find("Scroll/Viewport/Content/obj" + Length + "/Resource1Count").GetComponent<InputField>();
            _ActivateResource2 = transform.Find("Scroll/Viewport/Content/obj" + Length + "/ActivateResource2").GetComponent<InputField>();
            _Resource2Count = transform.Find("Scroll/Viewport/Content/obj" + Length + "/Resource2Count").GetComponent<InputField>();
            _ActivateResource3 = transform.Find("Scroll/Viewport/Content/obj" + Length + "/ActivateResource3").GetComponent<InputField>();
            _Resource3Count = transform.Find("Scroll/Viewport/Content/obj" + Length + "/Resource3Count").GetComponent<InputField>();

            talentSkill[Length].Id = DataManage.TalentSkillJsonData[i]["Id"].ToInt32();
            talentSkill[Length].HeroId = DataManage.TalentSkillJsonData[i]["HeroId"].ToInt32();
            talentSkill[Length].TalentName = DataManage.TalentSkillJsonData[i]["TalentName"].ToString();
            talentSkill[Length].Type = DataManage.TalentSkillJsonData[i]["Type"].ToInt32();
            talentSkill[Length].IsActivate = DataManage.TalentSkillJsonData[i]["IsActivate"].ToInt32();
            talentSkill[Length].RelevantSkill = DataManage.TalentSkillJsonData[i]["RelevantSkill"].ToInt32();
            talentSkill[Length].Result = DataManage.TalentSkillJsonData[i]["Result"].ToString();
            talentSkill[Length].ActivateResource1 = DataManage.TalentSkillJsonData[i]["ActivateResource1"].ToInt32();
            talentSkill[Length].Resource1Count = DataManage.TalentSkillJsonData[i]["Resource1Count"].ToInt32();
            talentSkill[Length].ActivateResource2 = DataManage.TalentSkillJsonData[i]["ActivateResource2"].ToInt32();
            talentSkill[Length].Resource2Count = DataManage.TalentSkillJsonData[i]["Resource2Count"].ToInt32();
            talentSkill[Length].ActivateResource3 = DataManage.TalentSkillJsonData[i]["ActivateResource3"].ToInt32();
            talentSkill[Length].Resource3Count = DataManage.TalentSkillJsonData[i]["Resource3Count"].ToInt32();
            talentSkill[Length].IsJson = true;

            _Id.text = talentSkill[Length].Id.ToString();
            _HeroId.text = talentSkill[Length].Id.ToString();
            _TalentName.text = talentSkill[Length].TalentName;
            _Type.value = talentSkill[Length].Type;
            _IsActivate.value = talentSkill[Length].IsActivate;
            _RelevantSkill.text = talentSkill[Length].RelevantSkill.ToString();
            _Result.text = talentSkill[Length].Result;
            _ActivateResource1.text = talentSkill[Length].ActivateResource1.ToString();
            _Resource1Count.text = talentSkill[Length].Resource1Count.ToString();
            _ActivateResource2.text = talentSkill[Length].ActivateResource2.ToString();
            _Resource2Count.text = talentSkill[Length].Resource2Count.ToString();
            _ActivateResource3.text = talentSkill[Length].ActivateResource3.ToString();
            _Resource3Count.text = talentSkill[Length].Resource3Count.ToString();

        }
    }
	
    public void Add()
    {
        Length += 1;
        GameObject BaseTalentSkillObj = Instantiate(BaseTalentSkill.gameObject, BaseTalentSkill.parent.Find("Content"));
        BaseTalentSkillObj.name = "obj" + Length;
        BaseTalentSkillObj.GetComponent<CommonAssist>().ID = Length;
        C_TalentSkill talentSkillobj = new C_TalentSkill();
        talentSkill[Length] = talentSkillobj;
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
            talentSkill[ID] = talentSkill[i];

        }
        talentSkill.Remove(Length);
        print("集合长度=" + talentSkill.Count);
        Length -= 1;
        DataManage.DelTalentSkillData(ID);
        WindowControl.SetConsole("删除成功");
    }

    public void Save(int ID)
    {
        _Id = transform.Find("Scroll/Viewport/Content/obj" + ID + "/Id").GetComponent<InputField>();
        _HeroId = transform.Find("Scroll/Viewport/Content/obj" + ID + "/HeroId").GetComponent<InputField>();
        _TalentName = transform.Find("Scroll/Viewport/Content/obj" + ID + "/TalentName").GetComponent<InputField>();
        _Type = transform.Find("Scroll/Viewport/Content/obj" + ID + "/Type").GetComponent<Dropdown>();
        _IsActivate= transform.Find("Scroll/Viewport/Content/obj" + ID + "/IsActivate").GetComponent<Dropdown>();
        _RelevantSkill = transform.Find("Scroll/Viewport/Content/obj" + ID + "/RelevantSkill").GetComponent<InputField>();
        _Result = transform.Find("Scroll/Viewport/Content/obj" + ID + "/Result").GetComponent<InputField>();
        _ActivateResource1 = transform.Find("Scroll/Viewport/Content/obj" + ID + "/ActivateResource1").GetComponent<InputField>();
        _Resource1Count = transform.Find("Scroll/Viewport/Content/obj" + ID + "/Resource1Count").GetComponent<InputField>();
        _ActivateResource2 = transform.Find("Scroll/Viewport/Content/obj" + ID + "/ActivateResource2").GetComponent<InputField>();
        _Resource2Count = transform.Find("Scroll/Viewport/Content/obj" + ID + "/Resource2Count").GetComponent<InputField>();
        _ActivateResource3 = transform.Find("Scroll/Viewport/Content/obj" + ID + "/ActivateResource3").GetComponent<InputField>();
        _Resource3Count = transform.Find("Scroll/Viewport/Content/obj" + ID + "/Resource3Count").GetComponent<InputField>();


        try
        {
            talentSkill[ID].Id = int.Parse(_Id.text);
            talentSkill[ID].HeroId = int.Parse(_HeroId.text);
            talentSkill[ID].TalentName = _TalentName.text;
            talentSkill[ID].Type = _Type.value;
            talentSkill[ID].IsActivate = _IsActivate.value;
            talentSkill[ID].RelevantSkill =int.Parse(_RelevantSkill.text);
            talentSkill[ID].Result = _Result.text;
            talentSkill[ID].ActivateResource1 =int.Parse(_ActivateResource1.text);
            talentSkill[ID].Resource1Count = int.Parse(_Resource1Count.text);
            talentSkill[ID].ActivateResource2 = int.Parse(_ActivateResource2.text);
            talentSkill[ID].Resource2Count = int.Parse(_Resource2Count.text);
            talentSkill[ID].ActivateResource3 = int.Parse(_ActivateResource3.text);
            talentSkill[ID].Resource3Count = int.Parse(_Resource3Count.text);
        }
        catch (Exception ex)
        {
            WindowControl.SetConsole("输入类型不对，详细：" + ex);
            return;
        }

        if (DataManage.SavetalentSkill(talentSkill, ID))
        {
            talentSkill[ID].IsJson = true;
        }


    }

	// Update is called once per frame
	void Update () {
		
	}
}
