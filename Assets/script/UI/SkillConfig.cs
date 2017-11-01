using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System;
                 

public class SkillConfig : MonoBehaviour {
    public int Length = 0;

    private InputField _heroID;
    private InputField _SkillConfigId;
    private InputField _ATKEffect;
    private InputField _TowerPassivity;
    private InputField _TowerLittleSkill;
    private InputField _TowerBigSkill;
    private InputField _FightInitiative;
    private InputField _FightPassivity;
    private InputField _InnateSkill10;
    private InputField _InnateSkill11;
    private InputField _InnateSkill12;
    private InputField _InnateSkill13;
    private InputField _InnateSkill20;
    private InputField _InnateSkill21;
    private InputField _InnateSkill22;
    private InputField _InnateSkill23;
    private InputField _InnateSkill30;
    private InputField _InnateSkill31;
    private InputField _InnateSkill32;
    private InputField _InnateSkill33;
    private InputField _InnateSkill40;
    private InputField _InnateSkill41;
    private InputField _InnateSkill42;
    private InputField _InnateSkill43;
    private InputField _Awaken111;
    private InputField _Awaken121;
    private InputField _Awaken122;
    private InputField _Awaken131;
    private InputField _Awaken132;
    private InputField _Awaken141;
    private InputField _Awaken211;
    private InputField _Awaken221;
    private InputField _Awaken222;
    private InputField _Awaken231;
    private InputField _Awaken232;
    private InputField _Awaken241;
    private InputField _Awaken311;
    private InputField _Awaken321;
    private InputField _Awaken322;
    private InputField _Awaken331;
    private InputField _Awaken332;
    private InputField _Awaken341;

    public Dictionary<int, C_SkillConfig> skillConfig = new Dictionary<int, C_SkillConfig>();
	// Use this for initialization
	void Start () {
		
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

    public void OnAdd()
    {
        Length += 1;
        GameObject BasicInformationObj = Instantiate(BasicInformation.gameObject, BasicInformation.parent.Find("Content"));
        GameObject TipTitleObj = Instantiate(TipTitle.gameObject, TipTitle.parent.Find("Content"));
        BasicInformationObj.name = "obj" + Length;
        TipTitleObj.name = "obj" + Length;
        TipTitleObj.GetComponent<SKillConfigAssist>().ID = Length;
        transform.Find("Scrollbar Horizontal").GetComponent<Scrollbar>().value = 1;
        //------------数据处理------------------//
        C_SkillConfig c_skillConfig = new C_SkillConfig();
        //heroData[Length-1] = s_heroData;
        //heroData.Add(Length, c_heroData);
        skillConfig[Length] = (c_skillConfig);
        //print("集合长度="+heroData.Count);
        _heroID = transform.Find("Viewport/Content/obj" + Length + "/HeroID").GetComponent<InputField>();
        _SkillConfigId = transform.Find("Viewport/Content/obj" + Length + "/SkillConfigId").GetComponent<InputField>();
        _ATKEffect = transform.Find("Viewport/Content/obj" + Length + "/ATKEffect").GetComponent<InputField>();
        _TowerPassivity = transform.Find("Viewport/Content/obj" + Length + "/TowerPassivity").GetComponent<InputField>();
        _TowerLittleSkill = transform.Find("Viewport/Content/obj" + Length + "/TowerLittleSkill").GetComponent<InputField>();
        _TowerBigSkill = transform.Find("Viewport/Content/obj" + Length + "/TowerBigSkill").GetComponent<InputField>();
        _FightInitiative = transform.Find("Viewport/Content/obj" + Length + "/FightInitiative").GetComponent<InputField>();
        _FightPassivity = transform.Find("Viewport/Content/obj" + Length + "/FightPassivity").GetComponent<InputField>();
        _InnateSkill10 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill10").GetComponent<InputField>();
        _InnateSkill11= transform.Find("Viewport/Content/obj" + Length + "/InnateSkill11").GetComponent<InputField>();
        _InnateSkill12 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill12").GetComponent<InputField>();
        _InnateSkill13 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill13").GetComponent<InputField>();
        _InnateSkill20 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill20").GetComponent<InputField>();
        _InnateSkill21 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill21").GetComponent<InputField>();
        _InnateSkill22 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill22").GetComponent<InputField>();
        _InnateSkill23 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill23").GetComponent<InputField>();
        _InnateSkill30 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill30").GetComponent<InputField>();
        _InnateSkill31 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill31").GetComponent<InputField>();
        _InnateSkill32 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill32").GetComponent<InputField>();
        _InnateSkill33 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill33").GetComponent<InputField>();
        _InnateSkill40 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill40").GetComponent<InputField>();
        _InnateSkill41 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill41").GetComponent<InputField>();
        _InnateSkill42 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill42").GetComponent<InputField>();
        _InnateSkill43 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill43").GetComponent<InputField>();
        _Awaken111 = transform.Find("Viewport/Content/obj" + Length + "/Awaken111").GetComponent<InputField>();
        _Awaken121 = transform.Find("Viewport/Content/obj" + Length + "/Awaken121").GetComponent<InputField>();
        _Awaken122 = transform.Find("Viewport/Content/obj" + Length + "/Awaken122").GetComponent<InputField>();
        _Awaken131 = transform.Find("Viewport/Content/obj" + Length + "/Awaken131").GetComponent<InputField>();
        _Awaken132 = transform.Find("Viewport/Content/obj" + Length + "/Awaken132").GetComponent<InputField>();
        _Awaken141 = transform.Find("Viewport/Content/obj" + Length + "/Awaken141").GetComponent<InputField>();
        _Awaken211 = transform.Find("Viewport/Content/obj" + Length + "/Awaken211").GetComponent<InputField>();
        _Awaken221 = transform.Find("Viewport/Content/obj" + Length + "/Awaken221").GetComponent<InputField>();
        _Awaken222 = transform.Find("Viewport/Content/obj" + Length + "/Awaken222").GetComponent<InputField>();
        _Awaken231 = transform.Find("Viewport/Content/obj" + Length + "/Awaken231").GetComponent<InputField>();
        _Awaken232 = transform.Find("Viewport/Content/obj" + Length + "/Awaken232").GetComponent<InputField>();
        _Awaken241 = transform.Find("Viewport/Content/obj" + Length + "/Awaken241").GetComponent<InputField>();
        _Awaken311 = transform.Find("Viewport/Content/obj" + Length + "/Awaken311").GetComponent<InputField>();
        _Awaken321 = transform.Find("Viewport/Content/obj" + Length + "/Awaken321").GetComponent<InputField>();
        _Awaken322 = transform.Find("Viewport/Content/obj" + Length + "/Awaken322").GetComponent<InputField>();
        _Awaken331 = transform.Find("Viewport/Content/obj" + Length + "/Awaken331").GetComponent<InputField>();
        _Awaken332 = transform.Find("Viewport/Content/obj" + Length + "/Awaken332").GetComponent<InputField>();
        _Awaken341 = transform.Find("Viewport/Content/obj" + Length + "/Awaken341").GetComponent<InputField>();

        _heroID.text = "0";
        _SkillConfigId.text = "0";
        _ATKEffect.text = "0";
        _TowerPassivity.text = "0";
        _TowerLittleSkill.text ="0";
        _TowerBigSkill.text = "0";
        _FightInitiative.text = "0";
        _FightPassivity.text = "0";
        _InnateSkill10.text = "0";
        _InnateSkill11.text = "0";
        _InnateSkill12.text = "0";
        _InnateSkill13.text = "0";
        _InnateSkill20.text = "0";
        _InnateSkill21.text = "0";
        _InnateSkill22.text = "0";
        _InnateSkill23.text = "0";
        _InnateSkill30.text ="0";
        _InnateSkill31.text = "0";
        _InnateSkill32.text = "0";
        _InnateSkill33.text = "0";
        _InnateSkill40.text = "0";
        _InnateSkill41.text = "0";
        _InnateSkill42.text = "0";
        _InnateSkill43.text = "0";
        _Awaken111.text = "0";
        _Awaken121.text = "0";
        _Awaken122.text = "0";
        _Awaken131.text = "0";
        _Awaken132.text = "0";
        _Awaken141.text = "0";
        _Awaken211.text = "0";
        _Awaken221.text = "0";
        _Awaken222.text = "0";
        _Awaken231.text = "0";
        _Awaken232.text = "0";
        _Awaken241.text = "0";
        _Awaken311.text = "0";
        _Awaken321.text = "0";
        _Awaken322.text ="0";
        _Awaken331.text ="0";
        _Awaken332.text = "0";
        _Awaken341.text = "0";
    }

    public void Save(int ID)
    {
        _heroID = transform.Find("Viewport/Content/obj" + Length + "/HeroID").GetComponent<InputField>();
        _SkillConfigId = transform.Find("Viewport/Content/obj" + Length + "/SkillConfigId").GetComponent<InputField>();
        _ATKEffect = transform.Find("Viewport/Content/obj" + Length + "/ATKEffect").GetComponent<InputField>();
        _TowerPassivity = transform.Find("Viewport/Content/obj" + Length + "/TowerPassivity").GetComponent<InputField>();
        _TowerLittleSkill = transform.Find("Viewport/Content/obj" + Length + "/TowerLittleSkill").GetComponent<InputField>();
        _TowerBigSkill = transform.Find("Viewport/Content/obj" + Length + "/TowerBigSkill").GetComponent<InputField>();
        _FightInitiative = transform.Find("Viewport/Content/obj" + Length + "/FightInitiative").GetComponent<InputField>();
        _FightPassivity = transform.Find("Viewport/Content/obj" + Length + "/FightPassivity").GetComponent<InputField>();
        _InnateSkill10 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill10").GetComponent<InputField>();
        _InnateSkill11 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill11").GetComponent<InputField>();
        _InnateSkill12 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill12").GetComponent<InputField>();
        _InnateSkill13 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill13").GetComponent<InputField>();
        _InnateSkill20 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill20").GetComponent<InputField>();
        _InnateSkill21 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill21").GetComponent<InputField>();
        _InnateSkill22 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill22").GetComponent<InputField>();
        _InnateSkill23 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill23").GetComponent<InputField>();
        _InnateSkill30 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill30").GetComponent<InputField>();
        _InnateSkill31 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill31").GetComponent<InputField>();
        _InnateSkill32 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill32").GetComponent<InputField>();
        _InnateSkill33 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill33").GetComponent<InputField>();
        _InnateSkill40 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill40").GetComponent<InputField>();
        _InnateSkill41 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill41").GetComponent<InputField>();
        _InnateSkill42 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill42").GetComponent<InputField>();
        _InnateSkill43 = transform.Find("Viewport/Content/obj" + Length + "/InnateSkill43").GetComponent<InputField>();
        _Awaken111 = transform.Find("Viewport/Content/obj" + Length + "/Awaken111").GetComponent<InputField>();
        _Awaken121 = transform.Find("Viewport/Content/obj" + Length + "/Awaken121").GetComponent<InputField>();
        _Awaken122 = transform.Find("Viewport/Content/obj" + Length + "/Awaken122").GetComponent<InputField>();
        _Awaken131 = transform.Find("Viewport/Content/obj" + Length + "/Awaken131").GetComponent<InputField>();
        _Awaken132 = transform.Find("Viewport/Content/obj" + Length + "/Awaken132").GetComponent<InputField>();
        _Awaken141 = transform.Find("Viewport/Content/obj" + Length + "/Awaken141").GetComponent<InputField>();
        _Awaken211 = transform.Find("Viewport/Content/obj" + Length + "/Awaken211").GetComponent<InputField>();
        _Awaken221 = transform.Find("Viewport/Content/obj" + Length + "/Awaken221").GetComponent<InputField>();
        _Awaken222 = transform.Find("Viewport/Content/obj" + Length + "/Awaken222").GetComponent<InputField>();
        _Awaken231 = transform.Find("Viewport/Content/obj" + Length + "/Awaken231").GetComponent<InputField>();
        _Awaken232 = transform.Find("Viewport/Content/obj" + Length + "/Awaken232").GetComponent<InputField>();
        _Awaken241 = transform.Find("Viewport/Content/obj" + Length + "/Awaken241").GetComponent<InputField>();
        _Awaken311 = transform.Find("Viewport/Content/obj" + Length + "/Awaken311").GetComponent<InputField>();
        _Awaken321 = transform.Find("Viewport/Content/obj" + Length + "/Awaken321").GetComponent<InputField>();
        _Awaken322 = transform.Find("Viewport/Content/obj" + Length + "/Awaken322").GetComponent<InputField>();
        _Awaken331 = transform.Find("Viewport/Content/obj" + Length + "/Awaken331").GetComponent<InputField>();
        _Awaken332 = transform.Find("Viewport/Content/obj" + Length + "/Awaken332").GetComponent<InputField>();
        _Awaken341 = transform.Find("Viewport/Content/obj" + Length + "/Awaken341").GetComponent<InputField>();

        try
        {
            skillConfig[ID].HeroID = int.Parse(_heroID.text);
            skillConfig[ID].SkillConfigId = int.Parse(_SkillConfigId.text);
            skillConfig[ID].ATKEffect = int.Parse(_ATKEffect.text);
            skillConfig[ID].TowerPassivity = int.Parse(_TowerPassivity.text);
            skillConfig[ID].TowerLittleSkill = int.Parse(_TowerLittleSkill.text);
            skillConfig[ID].TowerBigSkill = int.Parse(_TowerBigSkill.text);
            skillConfig[ID].FightInitiative = int.Parse(_FightInitiative.text);
            skillConfig[ID].FightPassivity = int.Parse(_FightPassivity.text);
            skillConfig[ID].InnateSkill10 = int.Parse(_InnateSkill10.text);
            skillConfig[ID].InnateSkill11 = int.Parse(_InnateSkill11.text);
            skillConfig[ID].InnateSkill12 = int.Parse(_InnateSkill12.text);
            skillConfig[ID].InnateSkill13 = int.Parse(_InnateSkill13.text);
            skillConfig[ID].InnateSkill20 = int.Parse(_InnateSkill20.text);
            skillConfig[ID].InnateSkill21 = int.Parse(_InnateSkill21.text);
            skillConfig[ID].InnateSkill22 = int.Parse(_InnateSkill22.text);
            skillConfig[ID].InnateSkill23 = int.Parse(_InnateSkill23.text);
            skillConfig[ID].InnateSkill30 = int.Parse(_InnateSkill30.text);
            skillConfig[ID].InnateSkill31 = int.Parse(_InnateSkill31.text);
            skillConfig[ID].InnateSkill32 = int.Parse(_InnateSkill32.text);
            skillConfig[ID].InnateSkill33 = int.Parse(_InnateSkill33.text);
            skillConfig[ID].Awaken111 = int.Parse(_Awaken111.text);
            skillConfig[ID].Awaken121 = int.Parse(_Awaken121.text);
            skillConfig[ID].Awaken122 = int.Parse(_Awaken122.text);
            skillConfig[ID].Awaken131 = int.Parse(_Awaken131.text);
            skillConfig[ID].Awaken132 = int.Parse(_Awaken132.text);
            skillConfig[ID].Awaken141 = int.Parse(_Awaken141.text);
            skillConfig[ID].Awaken211 = int.Parse(_Awaken211.text);
            skillConfig[ID].Awaken221 = int.Parse(_Awaken221.text);
            skillConfig[ID].Awaken222 = int.Parse(_Awaken222.text);
            skillConfig[ID].Awaken231 = int.Parse(_Awaken231.text);
            skillConfig[ID].Awaken232 = int.Parse(_Awaken232.text);
            skillConfig[ID].Awaken241 = int.Parse(_Awaken241.text);
            skillConfig[ID].Awaken311 = int.Parse(_Awaken311.text);
            skillConfig[ID].Awaken321 = int.Parse(_Awaken321.text);
            skillConfig[ID].Awaken322 = int.Parse(_Awaken322.text);
            skillConfig[ID].Awaken331 = int.Parse(_Awaken331.text);
            skillConfig[ID].Awaken332 = int.Parse(_Awaken332.text);
            skillConfig[ID].Awaken341 = int.Parse(_Awaken341.text);
        }
        catch (Exception ex)
        {
            // 错误处理代码
            WindowControl.SetConsole("保存失败，你填写的数据类型不对,详细：" + ex.Message);
            //transform.parent.Find("Console/Text").GetComponent<Text>().text = "保存失败，你填写的数据类型不对,详细："+ex.Message+"--------------时间："+DateTime.Now.ToString();
            return;
        }

        if (DataManage.SaveSkillConfig(skillConfig, ID))
        {
            skillConfig[ID].Isjson = true;
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
            skillConfig[ID] = skillConfig[i];

        }
        skillConfig.Remove(Length);
        print("集合长度=" + skillConfig.Count);
        Length -= 1;
        DataManage.DelSkillConfig(ID);
        WindowControl.SetConsole("删除成功");
        //transform.parent.Find("Console/Text").GetComponent<Text>().text = "删除成功-----------------时间" + DateTime.Now.ToString();
    }

}
