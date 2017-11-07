using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightSkill : MonoBehaviour {

    public int Length = 0;

    private InputField SkillId;
    private InputField HeroId;
    private InputField SkillName;
    private Dropdown ATKType;
    private InputField DamageCoefficient;
    private Dropdown Effect1;
    private InputField SpecialCase1;
    private Dropdown Target1;
    private InputField Dispose1;
    private Dropdown Effect2;
    private InputField SpecialCase2;
    private Dropdown Target2;
    private InputField Dispose2;
    private InputField RelevantTalentId1;
    private InputField RelevantTalentId2;
    private InputField RelevantTalentId3;
    private InputField SkillDescribe;
    

    public Dictionary<int, C_FightSkill> fightSkills = new Dictionary<int, C_FightSkill>();
    // Use this for initialization
    void Start()
    {
        Init();
    }

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
        if (!DataManage.FightSkillJsonData.IsArray)
        {
            return;
        }

        for (int i = 0; i < DataManage.FightSkillJsonData.Count; i++)
        {
            OnAdd();
            SkillId = transform.Find("Viewport/Content/obj" + Length + "/SkillId").GetComponent<InputField>();
            HeroId = transform.Find("Viewport/Content/obj" + Length + "/HeroId").GetComponent<InputField>();
            SkillName = transform.Find("Viewport/Content/obj" + Length + "/SkillName").GetComponent<InputField>();
            ATKType = transform.Find("Viewport/Content/obj" + Length + "/ATKType").GetComponent<Dropdown>();
            DamageCoefficient = transform.Find("Viewport/Content/obj" + Length + "/DamageCoefficient").GetComponent<InputField>();
            Effect1 = transform.Find("Viewport/Content/obj" + Length + "/Effect1").GetComponent<Dropdown>();
            SpecialCase1 = transform.Find("Viewport/Content/obj" + Length + "/SpecialCase1").GetComponent<InputField>();
            Target1 = transform.Find("Viewport/Content/obj" + Length + "/Target1").GetComponent<Dropdown>();
            Dispose1 = transform.Find("Viewport/Content/obj" + Length + "/Dispose1").GetComponent<InputField>();
            Effect2 = transform.Find("Viewport/Content/obj" + Length + "/Effect2").GetComponent<Dropdown>();
            SpecialCase2 = transform.Find("Viewport/Content/obj" + Length + "/SpecialCase2").GetComponent<InputField>();
            Target2 = transform.Find("Viewport/Content/obj" + Length + "/Target2").GetComponent<Dropdown>();
            Dispose2 = transform.Find("Viewport/Content/obj" + Length + "/Dispose2").GetComponent<InputField>();
            RelevantTalentId1 = transform.Find("Viewport/Content/obj" + Length + "/RelevantTalentId1").GetComponent<InputField>();
            RelevantTalentId2 = transform.Find("Viewport/Content/obj" + Length + "/RelevantTalentId2").GetComponent<InputField>();
            RelevantTalentId3 = transform.Find("Viewport/Content/obj" + Length + "/RelevantTalentId3").GetComponent<InputField>();
            SkillDescribe = transform.Find("Viewport/Content/obj" + Length + "/SkillDescribe").GetComponent<InputField>();


            fightSkills[Length].SkillId = DataManage.FightSkillJsonData[i]["SkillId"].ToInt32();
            fightSkills[Length].HeroId = DataManage.FightSkillJsonData[i]["HeroId"].ToInt32();
            fightSkills[Length].SkillName = DataManage.FightSkillJsonData[i]["SkillName"].ToString();
            fightSkills[Length].ATKType = DataManage.FightSkillJsonData[i]["ATKType"].ToInt32();
            fightSkills[Length].DamageCoefficient = DataManage.FightSkillJsonData[i]["DamageCoefficient"].ToInt32();
            fightSkills[Length].Effect1 = DataManage.FightSkillJsonData[i]["Effect1"].ToInt32();
            fightSkills[Length].SpecialCase1 = DataManage.FightSkillJsonData[i]["SpecialCase1"].ToString();
            fightSkills[Length].Target1 = DataManage.FightSkillJsonData[i]["Target1"].ToInt32();
            fightSkills[Length].Dispose1 = DataManage.FightSkillJsonData[i]["Dispose1"].ToString();
            fightSkills[Length].Effect2 = DataManage.FightSkillJsonData[i]["Effect2"].ToInt32();
            fightSkills[Length].SpecialCase2 = DataManage.FightSkillJsonData[i]["SpecialCase2"].ToString();
            fightSkills[Length].Target2 = DataManage.FightSkillJsonData[i]["Target2"].ToInt32();
            fightSkills[Length].Dispose2 = DataManage.FightSkillJsonData[i]["Dispose2"].ToString();
            fightSkills[Length].RelevantTalentId1 = DataManage.FightSkillJsonData[i]["RelevantTalentId1"].ToInt32();
            fightSkills[Length].RelevantTalentId2 = DataManage.FightSkillJsonData[i]["RelevantTalentId2"].ToInt32();
            fightSkills[Length].RelevantTalentId3 = DataManage.FightSkillJsonData[i]["RelevantTalentId3"].ToInt32();
            fightSkills[Length].SkillDescribe = DataManage.FightSkillJsonData[i]["SkillDescribe"].ToString();
            fightSkills[Length].IsJson = true;

            print("DataManage=" + DataManage.HeroJsonData.Count);
            SkillId.text = fightSkills[Length].SkillId.ToString();
            HeroId.text = fightSkills[Length].HeroId.ToString();
            SkillName.text = fightSkills[Length].SkillName;
            ATKType.value = fightSkills[Length].ATKType;
            DamageCoefficient.text = fightSkills[Length].DamageCoefficient.ToString();
            Effect1.value = fightSkills[Length].Effect1-1;
            SpecialCase1.text = fightSkills[Length].SpecialCase1.ToString();
            Target1.value = fightSkills[Length].Target1-1;
            Dispose1.text = fightSkills[Length].Dispose1.ToString();
            Effect2.value = fightSkills[Length].Effect2-1;
            SpecialCase2.text = fightSkills[Length].SpecialCase2.ToString();
            Target2.value = fightSkills[Length].Target2-1;
            Dispose2.text = fightSkills[Length].Dispose2.ToString();
            RelevantTalentId1.text = fightSkills[Length].RelevantTalentId1.ToString();
            RelevantTalentId2.text = fightSkills[Length].RelevantTalentId2.ToString();
            RelevantTalentId3.text = fightSkills[Length].RelevantTalentId3.ToString();
            SkillDescribe.text = fightSkills[Length].SkillDescribe.ToString();

        }
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
        C_FightSkill c_fightSkill = new C_FightSkill();
        //heroData[Length-1] = s_heroData;
        //heroData.Add(Length, c_heroData);
        fightSkills[Length] = (c_fightSkill);
        //print("集合长度="+heroData.Count);
    }

    public void Save(int ID)
    {
        SkillId = transform.Find("Viewport/Content/obj" + ID + "/SkillId").GetComponent<InputField>();
        HeroId = transform.Find("Viewport/Content/obj" + ID + "/HeroId").GetComponent<InputField>();
        SkillName = transform.Find("Viewport/Content/obj" + ID + "/SkillName").GetComponent<InputField>();
        ATKType = transform.Find("Viewport/Content/obj" + ID + "/ATKType").GetComponent<Dropdown>();
        DamageCoefficient = transform.Find("Viewport/Content/obj" + ID + "/DamageCoefficient").GetComponent<InputField>();
        Effect1 = transform.Find("Viewport/Content/obj" + ID + "/Effect1").GetComponent<Dropdown>();
        SpecialCase1 = transform.Find("Viewport/Content/obj" + ID + "/SpecialCase1").GetComponent<InputField>();
        Target1 = transform.Find("Viewport/Content/obj" + ID + "/Target1").GetComponent<Dropdown>();
        Dispose1 = transform.Find("Viewport/Content/obj" + ID + "/Dispose1").GetComponent<InputField>();
        Effect2 = transform.Find("Viewport/Content/obj" + ID + "/Effect2").GetComponent<Dropdown>();
        SpecialCase2 = transform.Find("Viewport/Content/obj" + ID + "/SpecialCase2").GetComponent<InputField>();
        Target2 = transform.Find("Viewport/Content/obj" + ID + "/Target2").GetComponent<Dropdown>();
        Dispose2 = transform.Find("Viewport/Content/obj" + ID + "/Dispose2").GetComponent<InputField>();
        RelevantTalentId1 = transform.Find("Viewport/Content/obj" + ID + "/RelevantTalentId1").GetComponent<InputField>();
        RelevantTalentId2 = transform.Find("Viewport/Content/obj" + ID + "/RelevantTalentId2").GetComponent<InputField>();
        RelevantTalentId3 = transform.Find("Viewport/Content/obj" + ID + "/RelevantTalentId3").GetComponent<InputField>();
        SkillDescribe = transform.Find("Viewport/Content/obj" + ID + "/SkillDescribe").GetComponent<InputField>();
        try
        {
            fightSkills[ID].SkillId = int.Parse(SkillId.text);
            fightSkills[ID].HeroId = int.Parse(HeroId.text);
            fightSkills[ID].SkillName = SkillName.text;
            fightSkills[ID].ATKType = ATKType.value;
            fightSkills[ID].DamageCoefficient = int.Parse(DamageCoefficient.text);
            fightSkills[ID].Effect1 = Effect1.value+1;
            fightSkills[ID].SpecialCase1 = SpecialCase1.text;
            fightSkills[ID].Target1 = Target1.value + 1;
            fightSkills[ID].Dispose1 = Dispose1.text;
            fightSkills[ID].Effect2 = Effect2.value + 1;
            fightSkills[ID].SpecialCase2 = SpecialCase2.text;
            fightSkills[ID].Target2 = Target2.value + 1;
            fightSkills[ID].Dispose2 = Dispose2.text;
            fightSkills[ID].RelevantTalentId1 = int.Parse(RelevantTalentId1.text);
            fightSkills[ID].RelevantTalentId2 = int.Parse(RelevantTalentId2.text);
            fightSkills[ID].RelevantTalentId3 = int.Parse(RelevantTalentId3.text);
            fightSkills[ID].SkillDescribe = SkillDescribe.text;


        }
        catch (Exception ex)
        {
            // 错误处理代码
            WindowControl.SetConsole("保存失败，你填写的数据类型不对,详细：" + ex.Message);
            //transform.parent.Find("Console/Text").GetComponent<Text>().text = "保存失败，你填写的数据类型不对,详细："+ex.Message+"--------------时间："+DateTime.Now.ToString();
            return;
        }

        if (DataManage.SaveFightSkill(fightSkills, ID))
        {
            fightSkills[ID].IsJson = true;
        }

        //transform.parent.Find("Console/Text").GetComponent<Text>().text = "保存成功-----------------时间"+DateTime.Now.ToString();

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
            transform.Find("TipTitleX/Viewport/Content/obj" + i).GetComponent<SKillConfigAssist>().ID = i - 1;
            transform.Find("Viewport/Content/obj" + i).name = "obj" + (i - 1);
            transform.Find("TipTitleX/Viewport/Content/obj" + i).name = "obj" + (i - 1);
            fightSkills[ID] = fightSkills[i];

        }
        fightSkills.Remove(Length);
        print("集合长度=" + fightSkills.Count);
        Length -= 1;
        DataManage.DelFightSkill(ID);
        WindowControl.SetConsole("删除成功");
        //transform.parent.Find("Console/Text").GetComponent<Text>().text = "删除成功-----------------时间" + DateTime.Now.ToString();
    }

}
