using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using LitJson;

public class DataManage : MonoBehaviour
{
    static JsonData _heroJsonData;
    public static JsonData HeroJsonData
    {
        get
        {
            if (_heroJsonData == null)
            {
                if (File.Exists(@"Assets/Res/JsonConfig/HeroData.json"))
                {
                    _heroJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/HeroData.json"));
                }
                else
                {
                    File.Create(@"Assets/Res/JsonConfig/HeroData.json");
                    // _heroJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/HeroData.json"));
                    _heroJsonData = new JsonData();
                }
                //print("数据："+data[0]["Id"]);
                return _heroJsonData;
            }
            else
            {
                return _heroJsonData;
            }
        }
        set
        {
            if (value != null)
            {
                _heroJsonData = value;
            }
        }
    }

    static JsonData _basicInfoJsonData;
    public static JsonData BasicInfoJsonData
    {
        get
        {
            if (_basicInfoJsonData == null)
            {
                if (File.Exists(@"Assets/Res/JsonConfig/HeroBaseInfo.json"))
                {
                    _basicInfoJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/HeroBaseInfo.json"));
                }
                else
                {
                    File.Create(@"Assets/Res/JsonConfig/HeroBaseInfo.json");
                    // _heroJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/HeroData.json"));
                    _basicInfoJsonData = new JsonData();
                }
                //print("数据："+data[0]["Id"]);
                return _basicInfoJsonData;
            }
            else
            {
                return _basicInfoJsonData;
            }
        }
        set
        {
            if (value != null)
            {
                _basicInfoJsonData = value;
            }
        }
    }

    static JsonData _starGrowJsonData;
    public static JsonData StarGrowJsonData
    {
        get
        {
            if (_starGrowJsonData == null)
            {
                if (File.Exists(@"Assets/Res/JsonConfig/StarGrow.json"))
                {
                    _starGrowJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/StarGrow.json"));
                }
                else
                {
                    File.Create(@"Assets/Res/JsonConfig/StarGrow.json");
                    // _heroJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/HeroData.json"));
                    _starGrowJsonData = new JsonData();
                }
                //print("数据："+data[0]["Id"]);
                return _starGrowJsonData;
            }
            else
            {
                return _starGrowJsonData;
            }
        }
        set
        {
            if (value != null)
            {
                _starGrowJsonData = value;
            }
        }
    }

    static JsonData _skillConfigJsonData;
    public static JsonData SkillConfigJsonData
    {
        get
        {
            if (_skillConfigJsonData == null)
            {
                if (File.Exists(@"Assets/Res/JsonConfig/SkillConfig.json"))
                {
                    _skillConfigJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/SkillConfig.json"));
                }
                else
                {
                    File.Create(@"Assets/Res/JsonConfig/SkillConfig.json");
                    // _heroJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/HeroData.json"));
                    _skillConfigJsonData = new JsonData();
                }
                //print("数据："+data[0]["Id"]);
                return _skillConfigJsonData;
            }
            else
            {
                return _skillConfigJsonData;
            }
        }
        set
        {
            if (value != null)
            {
                _skillConfigJsonData = value;
            }
        }
    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static bool HeroDataSave(Dictionary<int, C_HeroData> heroData, int id)
    {

        if (HeroJsonData.IsArray)
        {
            for (int i = 0; i < HeroJsonData.Count; i++)
            {
                if (HeroJsonData[i]["Id"].ToInt32() == heroData[id].ID && i != id - 1)
                {
                    WindowControl.SetConsole("保存失败,英雄ID：" + heroData[id].ID + ",已经存在，请仔细填写");
                    return false;
                }
                else if (HeroJsonData[i]["SkillConfigId"].ToInt32() == heroData[id].SkillConfigID && i != id - 1)
                {
                    WindowControl.SetConsole("保存失败,SkillConfigId（技能配置ID）：" + heroData[id].SkillConfigID + ",已经存在，请仔细填写");
                    return false;
                }
                else if (HeroJsonData[i]["ExclusiveEquipId"].ToInt32() == heroData[id].ExclusiveEquipID && i != id - 1)
                {
                    WindowControl.SetConsole("保存失败,ExclusiveEquipId（专属装备ID）：" + heroData[id].ExclusiveEquipID + ",已经存在，请仔细填写");
                    return false;
                }
                else if (HeroJsonData[i]["MessageConfigId"].ToInt32() == heroData[id].MessageConfigID && i != id - 1)
                {
                    WindowControl.SetConsole("保存失败,MessageConfigID（信息配置ID）：" + heroData[id].MessageConfigID + ",已经存在，请仔细填写");
                    return false;
                }

            }
        }


        print("该数据状态" + id + "IsJson=" + heroData[id].IsJson.ToString());
        if (!heroData[id].IsJson)
        {
            print("新增:" + HeroJsonData.IsArray);
            HeroJsonData.Add(heroData[id].getJsonData());//新增操作

        }
        else
        {
            print("修改");
            HeroJsonData[id - 1] = heroData[id].getJsonData();//修改操作
        }
        File.WriteAllText(@"Assets/Res/JsonConfig/HeroData.json", HeroJsonData.ToJsonFile());
        WindowControl.SetConsole("保存成功");
        return true;
    }

    public static void HeroDataDel(int id)
    {
        if (id <= HeroJsonData.Count)
        {
            if (HeroJsonData.Count == 1)
            {
                HeroJsonData.Clear();
                File.WriteAllText(@"Assets/Res/JsonConfig/HeroData.json", "");
                return;
            }
            JsonData jd = new JsonData();
            for (int i = 0; i < id - 1; i++)
            {
                jd.Add(HeroJsonData[i]);
            }
            for (int i = id - 1; i < HeroJsonData.Count; i++)
            {
                if (i == HeroJsonData.Count - 1)
                {
                    break;
                }
                jd.Add(HeroJsonData[i + 1]);
            }
            HeroJsonData = jd;
            File.WriteAllText(@"Assets/Res/JsonConfig/HeroData.json", HeroJsonData.ToJsonFile());
        }
    }

    public static bool HeroMessageSave(C_HeroMessage heroMessage, int opIndex)
    {
        print("保存时的状态:isJson=+" + heroMessage.IsJson.ToString() + "||opIndex=" + opIndex);
        if (BasicInfoJsonData.IsArray)
        {
            for (int i = 0; i < BasicInfoJsonData.Count; i++)
            {
                if ((BasicInfoJsonData[i]["HeroId"].ToInt64() == heroMessage.HeroID || BasicInfoJsonData[i]["InfoId"].ToInt64() == heroMessage.InfoId) && !heroMessage.IsJson)
                {
                    WindowControl.SetConsole("1...保存失败ID：" + heroMessage.InfoId + ",已经存在，请仔细填写");
                    return false;
                }
                if ((BasicInfoJsonData[i]["HeroId"].ToInt64() == heroMessage.HeroID || BasicInfoJsonData[i]["InfoId"].ToInt64() == heroMessage.InfoId) && i != opIndex)
                {
                    WindowControl.SetConsole("2...保存失败ID：" + heroMessage.InfoId + ",已经存在，请仔细填写");
                    return false;
                }


            }
        }
        if (!heroMessage.IsJson)
        {
            print("新增");
            //新增
            BasicInformation.opIndex = BasicInfoJsonData.Add(heroMessage.getJsonData());
            print(BasicInformation.opIndex);
        }
        else
        {
            print("修改");
            print("ID=======" + opIndex);
            //修改
            BasicInfoJsonData[opIndex] = heroMessage.getJsonData();
        }
        File.WriteAllText(@"Assets/Res/JsonConfig/HeroBaseInfo.json", BasicInfoJsonData.ToJsonFile());
        WindowControl.SetConsole("保存成功");
        return true;
    }

    public static void DelHeroMessage(int opIndex)
    {
        if (opIndex < _basicInfoJsonData.Count)
        {
            if (_basicInfoJsonData.Count == 1)
            {
                _basicInfoJsonData.Clear();
                File.WriteAllText(@"Assets/Res/JsonConfig/HeroBaseInfo.json", "");
                return;
            }
            JsonData jd = new JsonData();
            for (int i = 0; i < opIndex; i++)
            {
                jd.Add(BasicInfoJsonData[i]);
            }
            for (int i = opIndex; i < BasicInfoJsonData.Count; i++)
            {
                if (i == BasicInfoJsonData.Count - 1)
                {
                    break;
                }
                jd.Add(BasicInfoJsonData[i + 1]);
            }
            BasicInfoJsonData = jd;
            File.WriteAllText(@"Assets/Res/JsonConfig/HeroBaseInfo.json", BasicInfoJsonData.ToJsonFile());
            WindowControl.SetConsole("删除成功");
        }
    }

    public static bool SaveStarGrowJson(Dictionary<int, C_StarGrow> starGrowData, int id)
    {
        if (StarGrowJsonData.IsArray)
        {
            for (int i = 0; i < StarGrowJsonData.Count; i++)
            {
                if (StarGrowJsonData[i]["StarType"].ToInt32() == starGrowData[id].StarType && i != id - 1)
                {
                    WindowControl.SetConsole("保存失败,星级：" + starGrowData[id].StarType + ",已经存在，请仔细填写");
                    return false;
                }

            }
        }


        print("该数据状态" + id + "IsJson=" + starGrowData[id].isJson.ToString());
        if (!starGrowData[id].isJson)
        {
            print("新增:" + StarGrowJsonData.IsArray);
            StarGrowJsonData.Add(starGrowData[id].getJsonDate());//新增操作

        }
        else
        {
            print("修改");
            StarGrowJsonData[id - 1] = starGrowData[id].getJsonDate();//修改操作
        }
        File.WriteAllText(@"Assets/Res/JsonConfig/StarGrow.json", StarGrowJsonData.ToJsonFile());
        WindowControl.SetConsole("保存成功");
        return true;
    }

    public static void DelStarGrowJson(int id)
    {
        if (id <= StarGrowJsonData.Count)
        {
            if (StarGrowJsonData.Count == 1)
            {
                StarGrowJsonData.Clear();
                File.WriteAllText(@"Assets/Res/JsonConfig/StarGrow.json", "");
                return;
            }
            JsonData jd = new JsonData();
            for (int i = 0; i < id - 1; i++)
            {
                jd.Add(StarGrowJsonData[i]);
            }
            for (int i = id - 1; i < StarGrowJsonData.Count; i++)
            {
                if (i == StarGrowJsonData.Count - 1)
                {
                    break;
                }
                jd.Add(StarGrowJsonData[i + 1]);
            }
            StarGrowJsonData = jd;
            File.WriteAllText(@"Assets/Res/JsonConfig/StarGrow.json", StarGrowJsonData.ToJsonFile());
        }
    }

    public static bool SaveSkillConfig(Dictionary<int, C_SkillConfig> skillConfig,int id)
    {
        if (SkillConfigJsonData.IsArray)
        {
            for (int i = 0; i < SkillConfigJsonData.Count; i++)
            {
                if (SkillConfigJsonData[i]["SkillConfigId"].ToInt32() == skillConfig[id].SkillConfigId && i != id - 1)
                {
                    WindowControl.SetConsole("保存失败,技能ID：" + skillConfig[id].SkillConfigId + ",已经存在，请仔细填写");
                    return false;
                }
            }
        }


        print("该数据状态" + id + "IsJson=" + skillConfig[id].Isjson.ToString());
        if (!skillConfig[id].Isjson)
        {
            print("新增:" + SkillConfigJsonData.IsArray);
            SkillConfigJsonData.Add(skillConfig[id].GetJson());//新增操作

        }
        else
        {
            print("修改");
            SkillConfigJsonData[id - 1] = skillConfig[id].GetJson();//修改操作
        }
        File.WriteAllText(@"Assets/Res/JsonConfig/SkillConfig.json", SkillConfigJsonData.ToJsonFile());
        WindowControl.SetConsole("保存成功");
        return true;
    }

    public static void DelSkillConfig(int id)
    {
        if (id <= SkillConfigJsonData.Count)
        {
            if (SkillConfigJsonData.Count == 1)
            {
                SkillConfigJsonData.Clear();
                File.WriteAllText(@"Assets/Res/JsonConfig/killConfig.json", "");
                return;
            }
            JsonData jd = new JsonData();
            for (int i = 0; i < id - 1; i++)
            {
                jd.Add(SkillConfigJsonData[i]);
            }
            for (int i = id - 1; i < SkillConfigJsonData.Count; i++)
            {
                if (i == SkillConfigJsonData.Count - 1)
                {
                    break;
                }
                jd.Add(SkillConfigJsonData[i + 1]);
            }
            SkillConfigJsonData = jd;
            File.WriteAllText(@"Assets/Res/JsonConfig/killConfig.json", SkillConfigJsonData.ToJsonFile());
        }
    }
}

public class C_HeroData
{
    public enum HeroQuality
    {
        UR = 6,
        SSR = 5,
        SR = 4,
        R = 3,
        N = 2,
        E = 1
    }

    public enum HeroType
    {
        shooter = 5,
        mage = 4,
        assassin = 3,
        tank = 2,
        warrior = 1
    }

    public int ID;
    public HeroQuality Quality;
    public HeroType Type;
    public int StarID;
    public int Fighting;
    public int ExponentBit;
    public int Level;
    public int Vitality;
    public int Attack;
    public int AttackSpeed;
    public int Skill;
    /// <summary>
    /// 闪避
    /// </summary>
    public int HitRate;
    /// <summary>
    /// 暴击
    /// </summary>
    public int Dodge;
    public int CriticalStrike;
    public int Tenacity;
    public int Pierce;
    public int Defense;
    public int ActGrow;
    public int VitalityGrow;
    public int ActSpeedGrow;
    public int GrowCoefficient;
    public int ActBreakLevel;
    public int VitalityBreakLevel;
    public int BaseStrikeDamage;
    public int TowerActFrequency;
    public long SkillConfigID;
    public long ExclusiveEquipID;
    public long ByConfigID1;
    public long ByConfigID2;
    public long ByConfigID3;
    public long ByConfigID4;
    public long MessageConfigID;

    public bool IsJson = false;

    public JsonData getJsonData()
    {
        JsonData temdata = new JsonData();
        temdata.Add("Id", ID);
        temdata.Add("Quality", (int)Quality);
        temdata.Add("Type", (int)Type);
        temdata.Add("StarId", StarID);
        temdata.Add("Fighting", Fighting);
        temdata.Add("ExponentBit", ExponentBit);
        temdata.Add("Level", Level);
        temdata.Add("Vitality", Vitality);
        temdata.Add("ATK", Attack);
        temdata.Add("ATKSpeed", AttackSpeed);
        temdata.Add("Skill", Skill);
        temdata.Add("HitRate", HitRate);
        temdata.Add("Dodge", Dodge);
        temdata.Add("CriticalStrike", CriticalStrike);
        temdata.Add("Tenacity", Tenacity);
        temdata.Add("Pierce", Pierce);
        temdata.Add("Defense", Defense);
        temdata.Add("ATKGrow", ActGrow);
        temdata.Add("VitalityGrow", VitalityGrow);
        temdata.Add("ATKSpeedGrow", ActSpeedGrow);
        temdata.Add("GrowCoefficient", GrowCoefficient);
        temdata.Add("ATKBreakLevel", ActBreakLevel);
        temdata.Add("VitalityBreakLevel", VitalityBreakLevel);
        temdata.Add("BaseStrikeDamage", BaseStrikeDamage);
        temdata.Add("TowerATKFrequency", TowerActFrequency);
        temdata.Add("SkillConfigId", SkillConfigID);
        temdata.Add("ExclusiveEquipId", ExclusiveEquipID);
        temdata.Add("ByConfigId1", ByConfigID1);
        temdata.Add("ByConfigId2", ByConfigID2);
        temdata.Add("ByConfigId3", ByConfigID3);
        temdata.Add("ByConfigId4", ByConfigID4);
        temdata.Add("MessageConfigId", MessageConfigID);

        return temdata;

    }
}

public class C_HeroMessage
{

    public enum CampType
    {
        kingdom = 1,
        GodDomain = 2,
        Ghostdom = 3,
        Kitazakai = 4,
        Leta = 5,
        Chaos = 6,
        Forget = 7,
        Spirit = 8,
        Traveller = 9,
    }

    public long InfoId;
    public long HeroID;
    public string Name;
    public string Nickname;
    public int Sex;
    public string TowerDefenceDefinite;
    public string FightDefinite;
    public CampType Camp;
    public string Backstory;

    public bool IsJson = false;

    public JsonData getJsonData()
    {
        JsonData jd = new JsonData();
        jd.Add("InfoId", InfoId);
        jd.Add("HeroId", HeroID);
        jd.Add("Nickname", Nickname);
        jd.Add("Name", Name);
        jd.Add("Sex", Sex);
        jd.Add("TowerDefenceDefinite", TowerDefenceDefinite);
        jd.Add("FightDefinite", FightDefinite);
        jd.Add("HeroCamp", (int)Camp);
        jd.Add("Backstory", Backstory);
        return jd;
    }
}

public class C_StarGrow
{
    public int StarType;
    public int ATKGrow;
    public int VitalityGrow;
    public int ATKSpeedGrow;
    public int HitRateGrow;
    public int DodgeGrow;
    public int CritGrow;
    public int TenacityGrow;
    public int GrowUp;
    public int AdditionalFighting;

    public bool isJson;

    public JsonData getJsonDate()
    {
        JsonData jd = new JsonData();
        jd.Add("StarType", StarType);
        jd.Add("ATKGrow", ATKGrow);
        jd.Add("VitalityGrow", VitalityGrow);
        jd.Add("ATKSpeedGrow", ATKSpeedGrow);
        jd.Add("HitRateGrow", HitRateGrow);
        jd.Add("DodgeGrow", DodgeGrow);
        jd.Add("CritGrow", CritGrow);
        jd.Add("TenacityGrow", TenacityGrow);
        jd.Add("GrowCoefficient", GrowUp);
        jd.Add("AdditionalFighting", AdditionalFighting);
        return jd;
    }

}

public class C_SkillConfig
{
    public int HeroID;
    public int SkillConfigId;
    public int ATKEffect;
    public int TowerPassivity;
    public int TowerLittleSkill;
    public int TowerBigSkill;
    public int FightInitiative;
    public int FightPassivity;
    public int InnateSkill10;
    public int InnateSkill11;
    public int InnateSkill12;
    public int InnateSkill13;
    public int InnateSkill20;
    public int InnateSkill21;
    public int InnateSkill22;
    public int InnateSkill23;
    public int InnateSkill30;
    public int InnateSkill31;
    public int InnateSkill32;
    public int InnateSkill33;
    public int InnateSkill40;
    public int InnateSkill41;
    public int InnateSkill42;
    public int InnateSkill43;
    public int Awaken111;
    public int Awaken121;
    public int Awaken122;
    public int Awaken131;
    public int Awaken132;
    public int Awaken141;
    public int Awaken211;
    public int Awaken221;
    public int Awaken222;
    public int Awaken231;
    public int Awaken232;
    public int Awaken241;
    public int Awaken311;
    public int Awaken321;
    public int Awaken322;
    public int Awaken331;
    public int Awaken332;
    public int Awaken341;

    public bool Isjson = false;

    public JsonData GetJson()
    {
        JsonData jd = new JsonData();
        jd.Add("HeroID",HeroID);
        jd.Add("SkillConfigId", SkillConfigId);
        jd.Add("ATKEffect", ATKEffect);
        jd.Add("TowerPassivity", TowerPassivity);
        jd.Add("TowerLittleSkill", TowerLittleSkill);
        jd.Add("TowerBigSkill", TowerBigSkill);
        jd.Add("FightInitiative", FightInitiative);
        jd.Add("FightPassivity", FightPassivity);
        jd.Add("InnateSkill10", InnateSkill10);
        jd.Add("InnateSkill11", InnateSkill11);
        jd.Add("InnateSkill12", InnateSkill12);
        jd.Add("InnateSkill13", InnateSkill13);
        jd.Add("InnateSkill20", InnateSkill20);
        jd.Add("InnateSkill21", InnateSkill21);
        jd.Add("InnateSkill22", InnateSkill22);
        jd.Add("InnateSkill23", InnateSkill23); 
        jd.Add("InnateSkill30", InnateSkill30);
        jd.Add("InnateSkill31", InnateSkill31);
        jd.Add("InnateSkill32", InnateSkill32);
        jd.Add("InnateSkill33", InnateSkill33);
        jd.Add("Awaken111", Awaken111);
        jd.Add("Awaken121", Awaken121);
        jd.Add("Awaken122", Awaken122);
        jd.Add("Awaken131", Awaken131);
        jd.Add("Awaken132", Awaken132);
        jd.Add("Awaken141", Awaken141);
        jd.Add("Awaken211", Awaken211);
        jd.Add("Awaken221", Awaken221);
        jd.Add("Awaken222", Awaken222);
        jd.Add("Awaken231", Awaken231);
        jd.Add("Awaken232", Awaken232);
        jd.Add("Awaken241", Awaken241);
        jd.Add("Awaken311", Awaken311);
        jd.Add("Awaken321", Awaken321);
        jd.Add("Awaken322", Awaken322);
        jd.Add("Awaken331", Awaken331);
        jd.Add("Awaken332", Awaken332);
        jd.Add("Awaken341", Awaken341);
     
        return jd;
    }

}