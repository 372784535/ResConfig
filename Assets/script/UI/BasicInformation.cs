using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System;

public class BasicInformation : MonoBehaviour
{
    public static int opIndex = -1;
    public C_HeroMessage heroMessage = new C_HeroMessage();
    private C_HeroData heroData = new C_HeroData();

    private InputField SarchID;

    private InputField HeroID;
    private InputField InfoId;
    private InputField Name;
    private InputField Nickname;
    private Dropdown Sex;
    private Dropdown Camp;
    private InputField StoryBG;
    private InputField TowerDD;
    private InputField FightD;
    private Transform DataDynamiticTest;
    private Text Tip;

    //-------------------------测试区UI-------------------------
    //入口
    private InputField _Test_Level;
    private InputField _Test_StarLevel;
    private InputField _Test_ExponentBit;
    private InputField _Test_ATKBreakLevel;
    private InputField _Test_VitalityBreakLevel;
    //基础属性
    private InputField _Test_Base_Vitality;
    private InputField _Test_Base_ATK;
    private InputField _Test_Base_Speed;
    private InputField _Test_Base_Skill;
    private InputField _Test_Base_HitRate;
    private InputField _Test_Base_Dodge;
    private InputField _Test_Base_Crit;
    private InputField _Test_Base_Tenacity;
    private InputField _Test_Base_Penetrate;
    private InputField _Test_Base_Defense;
    private InputField _Test_Base_AttacksGrow;
    private InputField _Test_Base_VitalityGrow;
    private InputField _Test_Base_SpeedGrow;
    private InputField _Test_Base_TowerATKFrequency;
    //测试结果
    private Text _Test_Results_FightingForce;
    private Text _Test_Results_Vitality;
    private Text _Test_Results_ATK;
    private Text _Test_Results_Tenacity;
    private Text _Test_Results_Crit;
    private Text _Test_Results_Skill;
    private Text _Test_Results_Speed;
    private Text _Test_Results_Penetrate;
    private Text _Test_Results_Defense;
    private Text _Test_Results_HitRate;
    private Text _Test_Results_Dodge;
    private Text _Test_Results_AttacksGrow;
    private Text _Test_Results_VitalityGrow;
    private Text _Test_Results_SpeedGrow;
    private Text _Test_Results_TowerATKFrequency;

    //---------------------------------------------------------

    // Use this for initialization
    void Start()
    {
        UIInit();
        TestUIInit();
    }

    void UIInit()
    {
        SarchID = transform.Find("Top").GetComponent<InputField>();
        HeroID = transform.Find("HeroId/Text").GetComponent<InputField>();
        InfoId = transform.Find("InfoId/Text").GetComponent<InputField>();
        Name = transform.Find("Name/Text").GetComponent<InputField>();
        Nickname = transform.Find("Nickname/Text").GetComponent<InputField>();
        Sex = transform.Find("Sex").GetComponent<Dropdown>();
        Camp = transform.Find("Camp").GetComponent<Dropdown>();
        StoryBG = transform.Find("StoryBG").GetComponent<InputField>();
        TowerDD = transform.Find("TowerDD").GetComponent<InputField>();
        FightD = transform.Find("FightD").GetComponent<InputField>();
        Tip = transform.Find("Top/Tip").GetComponent<Text>();



        DataDynamiticTest = transform.Find("DataDynamiticTest");
    }

    void TestUIInit()
    {

        Transform TestPanel = transform.Find("DataDynamiticTest/TestPanel");
        //入口UI
        _Test_Level = TestPanel.Find("AccessPoint/Level").GetComponent<InputField>();
        _Test_StarLevel = TestPanel.Find("AccessPoint/StarLevel").GetComponent<InputField>();
        _Test_ExponentBit = TestPanel.Find("AccessPoint/ExponentBit").GetComponent<InputField>();
        _Test_ATKBreakLevel = TestPanel.Find("AccessPoint/ATKBreakLevel").GetComponent<InputField>();
        _Test_VitalityBreakLevel = TestPanel.Find("AccessPoint/VitalityBreakLevel").GetComponent<InputField>();
        //基础属性
        _Test_Base_Vitality = TestPanel.Find("BasicsProperty/Vitality").GetComponent<InputField>();
        _Test_Base_ATK = TestPanel.Find("BasicsProperty/ATK").GetComponent<InputField>();
        _Test_Base_Speed = TestPanel.Find("BasicsProperty/Speed").GetComponent<InputField>();
        _Test_Base_Skill = TestPanel.Find("BasicsProperty/Skill").GetComponent<InputField>();
        _Test_Base_HitRate = TestPanel.Find("BasicsProperty/HitRate").GetComponent<InputField>();
        _Test_Base_Dodge = TestPanel.Find("BasicsProperty/Dodge").GetComponent<InputField>();
        _Test_Base_Crit = TestPanel.Find("BasicsProperty/Crit").GetComponent<InputField>();
        _Test_Base_Tenacity = TestPanel.Find("BasicsProperty/Tenacity").GetComponent<InputField>();
        _Test_Base_Penetrate = TestPanel.Find("BasicsProperty/Penetrate").GetComponent<InputField>();
        _Test_Base_Defense = TestPanel.Find("BasicsProperty/Defense").GetComponent<InputField>();
        _Test_Base_AttacksGrow = TestPanel.Find("BasicsProperty/AttacksGrow").GetComponent<InputField>();
        _Test_Base_VitalityGrow = TestPanel.Find("BasicsProperty/VitalityGrow").GetComponent<InputField>();
        _Test_Base_SpeedGrow = TestPanel.Find("BasicsProperty/SpeedGrow").GetComponent<InputField>();
        _Test_Base_TowerATKFrequency = TestPanel.Find("BasicsProperty/TowerATKFrequency").GetComponent<InputField>();
        //测试结果
        _Test_Results_FightingForce = TestPanel.Find("AccessResults/FightingForce/Text").GetComponent<Text>();
        _Test_Results_Vitality = TestPanel.Find("AccessResults/Vitality/Text").GetComponent<Text>();
        _Test_Results_ATK = TestPanel.Find("AccessResults/ATK/Text").GetComponent<Text>();
        _Test_Results_Tenacity = TestPanel.Find("AccessResults/Tenacity/Text").GetComponent<Text>();
        _Test_Results_Crit = TestPanel.Find("AccessResults/Crit/Text").GetComponent<Text>();
        _Test_Results_Skill = TestPanel.Find("AccessResults/Skill/Text").GetComponent<Text>();
        _Test_Results_Speed = TestPanel.Find("AccessResults/Speed/Text").GetComponent<Text>();
        _Test_Results_Penetrate = TestPanel.Find("AccessResults/Penetrate/Text").GetComponent<Text>();
        _Test_Results_Defense = TestPanel.Find("AccessResults/Defense/Text").GetComponent<Text>();
        _Test_Results_HitRate = TestPanel.Find("AccessResults/HitRate/Text").GetComponent<Text>();
        _Test_Results_Dodge = TestPanel.Find("AccessResults/Dodge/Text").GetComponent<Text>();
        _Test_Results_AttacksGrow = TestPanel.Find("AccessResults/AttacksGrow/Text").GetComponent<Text>();
        _Test_Results_VitalityGrow = TestPanel.Find("AccessResults/VitalityGrow/Text").GetComponent<Text>();
        _Test_Results_SpeedGrow = TestPanel.Find("AccessResults/SpeedGrow/Text").GetComponent<Text>();
        _Test_Results_TowerATKFrequency = TestPanel.Find("AccessResults/TowerATKFrequency/Text").GetComponent<Text>();

    }

    public void StartTest()
    {
        if(_Test_Level.text=="0"||_Test_StarLevel.text=="0"||_Test_ExponentBit.text=="0")
        {
            WindowControl.SetConsole("测试失败，请输入有效数据");
        }
        C_HeroData Text_Hd = new C_HeroData();
        int Level = int.Parse(_Test_Level.text);
        int StarLevel = int.Parse(_Test_StarLevel.text);
        int ExponentBit = int.Parse(_Test_ExponentBit.text);
        int ATKBreakLevel = int.Parse(_Test_ATKBreakLevel.text);
        int VitalityBreakLevel = int.Parse(_Test_VitalityBreakLevel.text);
        //属性=（基础属性+基础成长值*成长系数*等级）*突破成长系数+星级额外属性加成+天赋属性加成
        //优先处理动态属性
        Text_Hd.Level = Level;
        Text_Hd.StarID = StarLevel;
        Text_Hd.ExponentBit = ExponentBit;

        Text_Hd.GrowCoefficient = -1;

        //星级额外属性初始化
        C_StarGrow sg = new C_StarGrow();
        //增长系数
        for (int i = 0; i < DataManage.StarGrowJsonData.Count; i++)
        {
            if( DataManage.StarGrowJsonData[i]["StarType"].ToInt32()==Text_Hd.StarID)
            {
                Text_Hd.GrowCoefficient = DataManage.StarGrowJsonData[i]["GrowCoefficient"].ToInt32();
                sg.StarType = DataManage.StarGrowJsonData[i]["StarType"].ToInt32();
                sg.StarType = DataManage.StarGrowJsonData[i]["StarType"].ToInt32();
                sg.ATKGrow = DataManage.StarGrowJsonData[i]["ATKGrow"].ToInt32();
                sg.VitalityGrow = DataManage.StarGrowJsonData[i]["VitalityGrow"].ToInt32();
                sg.ATKSpeedGrow = DataManage.StarGrowJsonData[i]["ATKSpeedGrow"].ToInt32();
                sg.HitRateGrow = DataManage.StarGrowJsonData[i]["HitRateGrow"].ToInt32();
                sg.DodgeGrow = DataManage.StarGrowJsonData[i]["DodgeGrow"].ToInt32();
                sg.CritGrow = DataManage.StarGrowJsonData[i]["CritGrow"].ToInt32();
                sg.TenacityGrow = DataManage.StarGrowJsonData[i]["TenacityGrow"].ToInt32();
                sg.GrowUp = DataManage.StarGrowJsonData[i]["GrowCoefficient"].ToInt32();
                sg.AdditionalFighting = DataManage.StarGrowJsonData[i]["AdditionalFighting"].ToInt32();
            }
        }

        if( Text_Hd.GrowCoefficient==-1)
        {
            WindowControl.SetConsole("测试失败，所填信息的星级，星级表里没有查找到");
            return;
        }
        //突破等级处理
        const double coefficient = 1.03;
        Text_Hd.ActBreakLevel = (int)(Math.Pow(coefficient, ATKBreakLevel) * 10000);
        Text_Hd.VitalityBreakLevel = (int)(Math.Pow(coefficient, VitalityBreakLevel) * 10000);

        //计算生命
        double Vitality = ((double)heroData.Vitality+((double)heroData.VitalityGrow/10000.00)*(double)(Text_Hd.GrowCoefficient/10000.00)*(Text_Hd.Level - 1))*(double)Text_Hd.VitalityBreakLevel/10000.00+(sg.VitalityGrow)*(heroData.VitalityGrow/10000.00);
        Text_Hd.Vitality = (int)Vitality;
        _Test_Results_Vitality.text = Text_Hd.Vitality.ToString();
        //计算攻击
        double Attack = ((double)heroData.Attack + ((double)heroData.ActGrow / 10000.00) * (double)(Text_Hd.GrowCoefficient / 10000.00) * (Text_Hd.Level - 1)) * (double)Text_Hd.ActBreakLevel / 10000.00 + (sg.ATKGrow) * (heroData.ActGrow / 10000.00);
        Text_Hd.Attack = (int)Attack;
        _Test_Results_ATK.text = Text_Hd.Attack.ToString();
        //计算韧性
        Text_Hd.Tenacity = heroData.Tenacity + sg.TenacityGrow;
        _Test_Results_Tenacity.text = Text_Hd.Tenacity.ToString();
        //计算暴击
        Text_Hd.CriticalStrike = heroData.CriticalStrike + sg.CritGrow;
        _Test_Results_Crit.text = Text_Hd.CriticalStrike.ToString();
        //计算技能
        Text_Hd.Skill = heroData.Skill;
        _Test_Results_Skill.text = Text_Hd.Skill.ToString();
        //计算速度
        double AttackSpeed = ((double)heroData.AttackSpeed + ((double)heroData.AttackSpeed / 10000.00) * (double)(Text_Hd.GrowCoefficient / 10000.00) * (Text_Hd.Level - 1))/* * (double)Text_Hd.ActBreakLevel / 10000.00 */+ (sg.ATKGrow) * (heroData.ActGrow / 10000.00);
        Text_Hd.AttackSpeed = (int)AttackSpeed;
        _Test_Results_Speed.text = Text_Hd.AttackSpeed.ToString();
        //计算穿透
        Text_Hd.Pierce = heroData.Pierce;
        _Test_Results_Penetrate.text = Text_Hd.Pierce.ToString();
        //计算防御
        Text_Hd.Defense = heroData.Defense;
        _Test_Results_Defense.text = Text_Hd.Defense.ToString();
        //计算命中
        Text_Hd.HitRate = heroData.HitRate+sg.HitRateGrow;
        _Test_Results_HitRate.text = Text_Hd.HitRate.ToString();
        //计算闪避
        Text_Hd.Dodge = heroData.Dodge + sg.DodgeGrow;
        _Test_Results_Dodge.text = Text_Hd.Dodge.ToString();
        //计算闪避
        Text_Hd.Dodge = heroData.Dodge + sg.DodgeGrow;
        _Test_Results_Dodge.text = Text_Hd.Dodge.ToString();

        //生命成长
        _Test_Results_VitalityGrow.text = Text_Hd.Dodge.ToString();



    }

    void Test_BaseDataInit()
    {
        TestUIInit();
        
        for (int i = 0; i< DataManage.HeroJsonData.Count;i++)
        {
            if(DataManage.HeroJsonData[i]["Id"].ToString()==heroMessage.HeroID.ToString())
            {
                print("测试数据初始化||I"+i+"HeroID"+heroMessage.HeroID.ToString());
                heroData.Vitality = DataManage.HeroJsonData[i]["Vitality"].ToInt32();
                heroData.Attack = DataManage.HeroJsonData[i]["ATK"].ToInt32();
                heroData.AttackSpeed = DataManage.HeroJsonData[i]["ATKSpeed"].ToInt32();
                heroData.Skill = DataManage.HeroJsonData[i]["Skill"].ToInt32();
                heroData.HitRate = DataManage.HeroJsonData[i]["HitRate"].ToInt32();
                heroData.Dodge = DataManage.HeroJsonData[i]["Dodge"].ToInt32();
                heroData.CriticalStrike = DataManage.HeroJsonData[i]["CriticalStrike"].ToInt32();
                heroData.Tenacity = DataManage.HeroJsonData[i]["Tenacity"].ToInt32();
                heroData.Pierce = DataManage.HeroJsonData[i]["Pierce"].ToInt32();
                heroData.Defense = DataManage.HeroJsonData[i]["Defense"].ToInt32();
                heroData.ActGrow = DataManage.HeroJsonData[i]["ATKGrow"].ToInt32();
                heroData.VitalityGrow = DataManage.HeroJsonData[i]["VitalityGrow"].ToInt32();
                heroData.ActSpeedGrow = DataManage.HeroJsonData[i]["ATKSpeedGrow"].ToInt32();
                heroData.TowerActFrequency = DataManage.HeroJsonData[i]["TowerATkFrequency"].ToInt32();

                break;
            }
        }
        _Test_Base_Vitality.text = heroData.Vitality.ToString();
        _Test_Base_ATK.text = heroData.Attack.ToString();
        _Test_Base_Speed.text = heroData.AttackSpeed.ToString();
        _Test_Base_Skill.text = heroData.Skill.ToString();
        _Test_Base_HitRate.text = heroData.HitRate.ToString();
        _Test_Base_Dodge.text = heroData.Dodge.ToString();
        _Test_Base_Crit.text = heroData.CriticalStrike.ToString();
        _Test_Base_Tenacity.text = heroData.Tenacity.ToString();
        _Test_Base_Penetrate.text = heroData.Pierce.ToString();
        _Test_Base_Defense.text = heroData.Defense.ToString();
        _Test_Base_AttacksGrow.text = heroData.ActGrow.ToString();
        _Test_Base_VitalityGrow.text = heroData.VitalityGrow.ToString();
        _Test_Base_SpeedGrow.text = heroData.ActSpeedGrow.ToString();
        _Test_Base_TowerATKFrequency.text = heroData.TowerActFrequency.ToString();

    }

    public void RemoveUIData()
    {
        print("初始化");
        HeroID.text = "";
        InfoId.text = "";
        Name.text = "";
        Nickname.text = "";
        Sex.value = 0;
        Camp.value = 0;
        StoryBG.text = "";
        TowerDD.text = "";
        FightD.text = "";


    }

    public bool SearchInit(long Id)
    {
        UIInit();
        JsonData CorresJson = null;
        //--------------------检测信息数据-----------------
        if(DataManage.BasicInfoJsonData.IsArray)
        {
            for (int i = 0; i < DataManage.BasicInfoJsonData.Count;i++)
            {
                if(DataManage.BasicInfoJsonData[i]["InfoId"].ToInt64()==Id)
                {
                    heroMessage.IsJson = true;
                    opIndex = i;
                    CorresJson = DataManage.BasicInfoJsonData[i];
                    break;
                }
                if (DataManage.BasicInfoJsonData[i]["HeroId"].ToInt64() == Id)
                {
                    heroMessage.IsJson = true;
                    opIndex = i;
                    CorresJson = DataManage.BasicInfoJsonData[i];
                    break;
                }
            }
        }

        if(CorresJson!=null)
        {
            //----------------------载入信息数据---------------------
            HeroID.text = CorresJson["HeroId"].ToString();
            InfoId.text = CorresJson["InfoId"].ToString();
            Name.text = CorresJson["Name"].ToString();
            Nickname.text = CorresJson["Nickname"].ToString();
            Sex.value = CorresJson["Sex"].ToInt32();
            Camp.value = CorresJson["HeroCamp"].ToInt32();
            StoryBG.text = CorresJson["Backstory"].ToString();
            TowerDD.text = CorresJson["TowerDefenceDefinite"].ToString();
            FightD.text = CorresJson["FightDefinite"].ToString();
        }
        //----------------------检测英雄数据---------------------
        if(DataManage.HeroJsonData.IsArray)
        {
            
            for (var i = 0; i < DataManage.HeroJsonData.Count;i++)
            {
                if(DataManage.HeroJsonData[i]["Id"].ToInt64()==Id)
                {
                    
                    if(CorresJson==null)
                    {
                        heroMessage.HeroID = Id;
                        Test_BaseDataInit();
                        RemoveUIData();
                        heroMessage.IsJson = false;
                        WindowControl.SetConsole("该ID基础信息没有，但是英雄数据存在，请尽快添加库中");
                        CorresJson = DataManage.HeroJsonData[i];
                        HeroID.text = CorresJson["Id"].ToString();
                    }
                    else
                    {
                        heroMessage.HeroID = Id;
                        Test_BaseDataInit();
                        CorresJson = DataManage.HeroJsonData[i];
                        WindowControl.SetConsole("查找成功");
                    }

                    DataDynamiticTest.gameObject.SetActive(true);
                    break;

                }
                else if(CorresJson!=null)
                {
                    if(DataManage.HeroJsonData[i]["Id"].ToInt64()==CorresJson["HeroId"].ToInt64())
                    {
                        heroMessage.HeroID = Id;
                        Test_BaseDataInit();
                        CorresJson = DataManage.HeroJsonData[i];
                        WindowControl.SetConsole("查找成功");
                        break;
                    }
                }

                if(i==DataManage.HeroJsonData.Count-1)
                {
                    if (CorresJson == null)
                    {
                        WindowControl.SetConsole("查找失败，没有找到数据");

                        return false;
                    }
                    else
                    {
                        WindowControl.SetConsole("该ID基础信息存在，但是英雄数据没有，请尽快添加库中");
                        return true;
                    }
                }
                DataDynamiticTest.gameObject.SetActive(false);
            }

        }
        //----------------------载入英雄数据---------------------
        DataDynamiticTest.gameObject.SetActive(true);

        //SarchID.text = CorresJson["Id"].ToString();
        SarchID.text = Id.ToString();
        //************
        return true;
    }

    public void OnBtnFind(int id=-1)
    {
        if(SarchID.text=="")
        {
            WindowControl.SetConsole("查找失败，请输入英雄Id");
            return;
        }
        try
        {
            if(!SearchInit(int.Parse(SarchID.text)))
            {
                RemoveUIData();
                heroMessage.IsJson = false;
                WindowControl.SetConsole("查找失败，信息数据你根本没有创建");
            }
        }
        catch(Exception ex)
        {
            WindowControl.SetConsole("查找失败，数据类型不对，详细："+ex);
        }
    }

    public void OnBtnSave()
    {
        heroMessage.InfoId = int.Parse(InfoId.text);
        heroMessage.HeroID = long.Parse(HeroID.text);
        heroMessage.Name = Name.text;
        heroMessage.Nickname = Nickname.text;
        heroMessage.Sex = Sex.value;
        print("阵营："+Camp.value);
        switch(Camp.value)
        {
            /*kingdom = 1,
        GodDomain = 2,
        Ghostdom = 3,
        Kitazakai = 4,
        Leta = 5,
        Chaos = 6,
        Forget = 7,
        Spirit = 8,
        Traveller = 9,*/
            case 0:
                heroMessage.Camp = C_HeroMessage.CampType.Kitazakai;
                break;
            case 1:
                heroMessage.Camp = C_HeroMessage.CampType.GodDomain;
                break;
            case 2:
                heroMessage.Camp = C_HeroMessage.CampType.Ghostdom;
                break;
            case 3:
                heroMessage.Camp = C_HeroMessage.CampType.kingdom;
                break;
            case 4:
                heroMessage.Camp = C_HeroMessage.CampType.Leta;
                break;
            case 5:
                heroMessage.Camp = C_HeroMessage.CampType.Chaos;
                break;
            case 6:
                heroMessage.Camp = C_HeroMessage.CampType.Forget;
                break;
            case 7:
                heroMessage.Camp = C_HeroMessage.CampType.Spirit;
                break;
            case 8:
                heroMessage.Camp = C_HeroMessage.CampType.Traveller;
                break;

        }
        heroMessage.Camp = (C_HeroMessage.CampType)Camp.value;
        heroMessage.Backstory = StoryBG.text;
        heroMessage.TowerDefenceDefinite = TowerDD.text;
        heroMessage.FightDefinite = FightD.text;

        if(DataManage.HeroMessageSave(heroMessage,opIndex))
        {
            heroMessage.IsJson = true;
        }

    }

    public void OnDel()
    {
        WindowControl.OpenDelTip(opIndex, "BasicInformation");

    }

}
