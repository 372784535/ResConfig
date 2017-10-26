using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using LitJson;

public class DataManage : MonoBehaviour {
    static JsonData _data;
    public static JsonData Data
    {
        get
        {
            if (_data == null)
            {
                _data = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/HeroData.json"));
                //print("数据："+data[0]["Id"]);
                return _data;
            }
            else
            {
                return _data;
            }
        }
        set
        {
            if(value!=null)
            {
                _data = value;
            }
        }
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static bool HeroDataWriting( Dictionary<int, C_HeroData> heroData,int id)
    {
        
        if (Data.IsArray)
        {
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i]["Id"].ToInt32() == heroData[id].ID&&i!=id-1)
                {
                    WindowControl.SetConsole("保存失败,英雄ID：" + heroData[id].ID + ",已经存在，请仔细填写");
                    return false;
                }
                else if (Data[i]["SkillConfigID"].ToInt32() == heroData[id].SkillConfigID&& i != id - 1)
                {
                    WindowControl.SetConsole("保存失败,SkillConfigID（技能配置ID）：" + heroData[id].SkillConfigID + ",已经存在，请仔细填写");
                    return false;
                }
                else if (Data[i]["ExclusiveEquipID"].ToInt32() == heroData[id].ExclusiveEquipID&& i != id - 1)
                {
                    print("s1010101"+i);
                    WindowControl.SetConsole("保存失败,ExclusiveEquipID（专属装备ID）：" + heroData[id].ExclusiveEquipID + ",已经存在，请仔细填写");
                    return false;
                }
                else if (Data[i]["ByConfigID"].ToInt32() == heroData[id].ByConfigID&& i != id - 1)
                {
                    WindowControl.SetConsole("保存失败,ByConfigID（羁绊配置ID）：" + heroData[id].ByConfigID + ",已经存在，请仔细填写");
                    return false;
                }
                else if (Data[i]["MessageConfigID"].ToInt32() == heroData[id].MessageConfigID&& i != id - 1)
                {
                    WindowControl.SetConsole("保存失败,MessageConfigID（信息配置ID）：" + heroData[id].MessageConfigID + ",已经存在，请仔细填写");
                    return false;
                }

            }
        }


        print("该数据状态"+id+"IsJson="+heroData[id].IsJson.ToString());
        if (!heroData[id].IsJson)
        {
            print("新增:"+Data.IsArray);
            Data.Add(heroData[id].getJsonData());//新增操作

        }
        else
        {
            print("修改");
            Data[id - 1] = heroData[id].getJsonData();//修改操作
        }
        File.WriteAllText(@"Assets/Res/JsonConfig/HeroData.json", Data.ToJsonFile());
        WindowControl.SetConsole("保存成功");
        return true;
    }

    public static void HeroDataDel(int id)
    {
        if (id <= Data.Count)
        {
            if(Data.Count==1)
            {
                File.WriteAllText(@"Assets/Res/JsonConfig/HeroData.json", Data.ToJsonFile());
                return;
            }
            JsonData jd = new JsonData();
            for (int i = 0; i < id - 1;i++)
            {
                jd.Add(Data[i]);
            }
            for (int i = id-1; i < Data.Count;i++)
            {
                if (i == Data.Count - 1)
                {
                    break;
                }
                jd.Add(Data[i+1]);
            }
            Data = jd;
            File.WriteAllText(@"Assets/Res/JsonConfig/HeroData.json", Data.ToJsonFile());
        }
    }
}

public class C_HeroData
{
    public enum HeroQuality
    {
        UR=6,
        SSR=5,
        SR=4,
        R=3,
        N=2,
        E=1
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
    public double ActGrow;
    public double VitalityGrow;
    public double ActSpeedGrow;
    public int GrowCoefficient;
    public int ActBreakLevel;
    public int VitalityBreakLevel;
    public int BaseStrikeDamage;
    public int TowerActFrequency;
    public long SkillConfigID;
    public long ExclusiveEquipID;
    public long ByConfigID;
    public long MessageConfigID;

    public bool IsJson = false;

    public JsonData getJsonData()
    {
        JsonData temdata = new JsonData();
        temdata.Add("Id",ID);
        temdata.Add("Quality", (int)Quality);
        temdata.Add("Type", (int)Type);
        temdata.Add("StarID", StarID);
        temdata.Add("Fighting", Fighting);
        temdata.Add("ExponentBit", ExponentBit);
        temdata.Add("Level", Level);
        temdata.Add("Vitality",Vitality);
        temdata.Add("Attack",Attack);
        temdata.Add("AttackSpeed",AttackSpeed);
        temdata.Add("Skill",Skill);
        temdata.Add("HitRate",HitRate);
        temdata.Add("Dodge",Dodge);
        temdata.Add("CriticalStrike",CriticalStrike);
        temdata.Add("Tenacity",Tenacity);
        temdata.Add("Pierce",Pierce);
        temdata.Add("Defense",Defense);
        temdata.Add("ActGrow",ActGrow);
        temdata.Add("VitalityGrow",VitalityGrow);
        temdata.Add("ActSpeedGrow",ActSpeedGrow);
        temdata.Add("GrowCoefficient",GrowCoefficient);
        temdata.Add("ActBreakLevel",ActBreakLevel);
        temdata.Add("VitalityBreakLevel",VitalityBreakLevel);
        temdata.Add("BaseStrikeDamage",BaseStrikeDamage);
        temdata.Add("TowerActFrequency",TowerActFrequency);
        temdata.Add("SkillConfigID",SkillConfigID);
        temdata.Add("ExclusiveEquipID",ExclusiveEquipID);
        temdata.Add("ByConfigID",ByConfigID);
        temdata.Add("MessageConfigID",MessageConfigID);

        return temdata;

    }

    public void init()
    {
        ID = 0;
        Quality = HeroQuality.E;
        Type = HeroType.warrior;
        StarID = 0;
        Level = 0;
        Vitality = 0;
        Attack = 0;
        AttackSpeed = 0;
        Skill = 0;
        HitRate = 0;
        Dodge = 0;
        CriticalStrike = 0;
        Tenacity = 0;
        Pierce = 0;
        Defense = 0;
        ActGrow = 0;
        VitalityGrow = 0;
        ActSpeedGrow = 0;
        GrowCoefficient = 0;
        ActBreakLevel = 0;
        VitalityBreakLevel = 0;
        BaseStrikeDamage = 0;
        TowerActFrequency = 0;
        SkillConfigID = 0;
        ExclusiveEquipID = 0;
        ByConfigID=0;
        MessageConfigID = 0;

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
    
    public long MessageID;
    public long HeroID;
    public string Name;
    public string Nickname;
    public int Sex;
    public string TowerDefenceDefinite;
    public string FightDefinite;
    public CampType HeroCamp;
    public string Backstory;

}