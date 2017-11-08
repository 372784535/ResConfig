using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using LitJson;
using UnityEngine.UI;

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

    static JsonData _fetterJsonData;
    public static JsonData FetterJsonData
    {
        get
        {
            if (_fetterJsonData == null)
            {
                if (File.Exists(@"Assets/Res/JsonConfig/Fetter.json"))
                {
                    _fetterJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/Fetter.json"));
                }
                else
                {
                    File.Create(@"Assets/Res/JsonConfig/Fetter.json");
                    // _heroJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/HeroData.json"));
                    _fetterJsonData = new JsonData();
                }
                //print("数据："+data[0]["Id"]);
                return _fetterJsonData;
            }
            else
            {
                return _fetterJsonData;
            }
        }
        set
        {
            if (value != null)
            {
                _fetterJsonData = value;
            }
        }
    }

    static JsonData _talentSkill_BuffJsonData;
    public static JsonData TalentSkill_BuffJsonData
    {
        get
        {
            if (_talentSkill_BuffJsonData == null)
            {
                if (File.Exists(@"Assets/Res/JsonConfig/FightSkill_Buff.json"))
                {
                    _talentSkill_BuffJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/FightSkill_Buff.json"));
                }
                else
                {
                    File.Create(@"Assets/Res/JsonConfig/FightSkill_Buff.json");
                    // _heroJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/HeroData.json"));
                    _talentSkill_BuffJsonData = new JsonData();
                }
                //print("数据："+data[0]["Id"]);
                return _talentSkill_BuffJsonData;
            }
            else
            {
                return _talentSkill_BuffJsonData;
            }
        }
        set
        {
            if (value != null)
            {
                _talentSkill_BuffJsonData = value;
            }
        }
    }

    static JsonData _talentSkillJsonData;
    public static JsonData TalentSkillJsonData
    {
        get
        {
            if (_talentSkillJsonData == null)
            {
                if (File.Exists(@"Assets/Res/JsonConfig/TalentSkill.json"))
                {
                    _talentSkillJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/TalentSkill.json"));
                }
                else
                {
                    File.Create(@"Assets/Res/JsonConfig/TalentSkill.json");
                    // _heroJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/HeroData.json"));
                    _talentSkillJsonData = new JsonData();
                }
                //print("数据："+data[0]["Id"]);
                return _talentSkillJsonData;
            }
            else
            {
                return _talentSkillJsonData;
            }
        }
        set
        {
            if (value != null)
            {
                _talentSkillJsonData = value;
            }
        }
    }

    static JsonData _talentStoneConditionJsonData;
    public static JsonData TalentStoneConditionJsonData
    {
        get
        {
            if (_talentStoneConditionJsonData == null)
            {
                if (File.Exists(@"Assets/Res/JsonConfig/TalentStoneCondition.json"))
                {
                    _talentStoneConditionJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/TalentStoneCondition.json"));
                }
                else
                {
                    File.Create(@"Assets/Res/JsonConfig/TalentStoneCondition.json");
                    // _heroJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/HeroData.json"));
                    _talentStoneConditionJsonData = new JsonData();
                }
                //print("数据："+data[0]["Id"]);
                return _talentStoneConditionJsonData;
            }
            else
            {
                return _talentStoneConditionJsonData;
            }
        }
        set
        {
            if (value != null)
            {
                _talentStoneConditionJsonData = value;
            }
        }
    }

    static JsonData _towerDefenseSkillJsonData;
    public static JsonData TowerDefenseSkillJsonData
    {
        get
        {
            if (_towerDefenseSkillJsonData == null)
            {
                if (File.Exists(@"Assets/Res/JsonConfig/TowerDefenseSkill.json"))
                {
                    _towerDefenseSkillJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/TowerDefenseSkill.json"));
                }
                else
                {
                    File.Create(@"Assets/Res/JsonConfig/TowerDefenseSkill.json");
                    // _heroJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/HeroData.json"));
                    _towerDefenseSkillJsonData = new JsonData();
                }
                //print("数据："+data[0]["Id"]);
                return _towerDefenseSkillJsonData;
            }
            else
            {
                return _towerDefenseSkillJsonData;
            }
        }
        set
        {
            if (value != null)
            {
                _towerDefenseSkillJsonData = value;
            }
        }
    }

    static JsonData _breakGrowJsonData;
    public static JsonData BreakGrowJsonData
    {
        get
        {
            if (_breakGrowJsonData == null)
            {
                if (File.Exists(@"Assets/Res/JsonConfig/BreakGrow.json"))
                {
                    _breakGrowJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/BreakGrow.json"));
                }
                else
                {
                    File.Create(@"Assets/Res/JsonConfig/BreakGrow.json");
                    // _heroJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/HeroData.json"));
                    _breakGrowJsonData = new JsonData();
                }
                //print("数据："+data[0]["Id"]);
                return _breakGrowJsonData;
            }
            else
            {
                return _breakGrowJsonData;
            }
        }
        set
        {
            if (value != null)
            {
                _breakGrowJsonData = value;
            }
        }
    }

    static JsonData _fightSkillJsonData;
    public static JsonData FightSkillJsonData
    {
        get
        {
            if (_fightSkillJsonData == null)
            {
                if (File.Exists(@"Assets/Res/JsonConfig/FightSkill.json"))
                {
                    _fightSkillJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/FightSkill.json"));
                }
                else
                {
                    File.Create(@"Assets/Res/JsonConfig/FightSkill.json");
                    // _heroJsonData = JsonMapper.ToObject(File.ReadAllText(@"Assets/Res/JsonConfig/HeroData.json"));
                    _fightSkillJsonData = new JsonData();
                }
                //print("数据："+data[0]["Id"]);
                return _fightSkillJsonData;
            }
            else
            {
                return _fightSkillJsonData;
            }
        }
        set
        {
            if (value != null)
            {
                _fightSkillJsonData = value;
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

    public static bool SaveSkillConfig(Dictionary<int, C_SkillConfig> skillConfig, int id)
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
                File.WriteAllText(@"Assets/Res/JsonConfig/SkillConfig.json", "");
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
            File.WriteAllText(@"Assets/Res/JsonConfig/SkillConfig.json", SkillConfigJsonData.ToJsonFile());
        }
    }

    public static bool SaveFetterData(Dictionary<int, C_Frtter> c_frtter, int Id)
    {
        if (FetterJsonData.IsArray)
        {
            for (int i = 0; i < FetterJsonData.Count; i++)
            {
                if (FetterJsonData[i]["FrtterId"].ToInt32() == c_frtter[Id].FrtterId && i != Id - 1)
                {
                    WindowControl.SetConsole("保存失败,技能ID：" + c_frtter[Id].FrtterId + ",已经存在，请仔细填写");
                    return false;
                }
            }
        }
        print("该数据状态" + Id + "IsJson=" + c_frtter[Id].IsJson.ToString());
        if (!c_frtter[Id].IsJson)
        {
            print("新增:" + FetterJsonData.IsArray);
            FetterJsonData.Add(c_frtter[Id].GetJson());//新增操作

        }
        else
        {
            print("修改");
            FetterJsonData[Id - 1] = c_frtter[Id].GetJson();//修改操作
        }
        File.WriteAllText(@"Assets/Res/JsonConfig/Fetter.json", FetterJsonData.ToJsonFile());
        WindowControl.SetConsole("保存成功");
        return true;
    }

    public static void DelFetterData(int id)
    {
        if (id <= FetterJsonData.Count)
        {
            if (FetterJsonData.Count == 1)
            {
                FetterJsonData.Clear();
                File.WriteAllText(@"Assets/Res/JsonConfig/Fetter.json", "");
                return;
            }
            JsonData jd = new JsonData();
            for (int i = 0; i < id - 1; i++)
            {
                jd.Add(FetterJsonData[i]);
            }
            for (int i = id - 1; i < FetterJsonData.Count; i++)
            {
                if (i == FetterJsonData.Count - 1)
                {
                    break;
                }
                jd.Add(FetterJsonData[i + 1]);
            }
            FetterJsonData = jd;
            File.WriteAllText(@"Assets/Res/JsonConfig/Fetter.json", FetterJsonData.ToJsonFile());
        }
    }

    public static bool SavetalentSkill_Buff(Dictionary<int, C_TalentSkill_Buff> talentSkill_Buff, int id)
    {
        if (TalentSkill_BuffJsonData.IsArray)
        {
            for (int i = 0; i < TalentSkill_BuffJsonData.Count; i++)
            {
                if (TalentSkill_BuffJsonData[i]["Id"].ToInt32() == talentSkill_Buff[id].Id && i != id - 1)
                {
                    WindowControl.SetConsole("保存失败,ID：" + talentSkill_Buff[id].Id + ",已经存在，请仔细填写");
                    return false;
                }

            }
        }
        print("该数据状态" + id + "IsJson=" + talentSkill_Buff[id].IsJson.ToString());
        if (!talentSkill_Buff[id].IsJson)
        {
            print("新增:" + TalentSkill_BuffJsonData.IsArray);
            TalentSkill_BuffJsonData.Add(talentSkill_Buff[id].GetJson());//新增操作

        }
        else
        {
            print("修改");
            TalentSkill_BuffJsonData[id - 1] = talentSkill_Buff[id].GetJson();//修改操作
        }
        File.WriteAllText(@"Assets/Res/JsonConfig/FightSkill_Buff.json", TalentSkill_BuffJsonData.ToJsonFile());
        WindowControl.SetConsole("保存成功");
        return true;
    }

    public static void DelTalentSkill_BuffData(int id)
    {
        if (id <= TalentSkill_BuffJsonData.Count)
        {
            if (TalentSkill_BuffJsonData.Count == 1)
            {
                TalentSkill_BuffJsonData.Clear();
                File.WriteAllText(@"Assets/Res/JsonConfig/FightSkill_Buff.json", "");
                return;
            }
            JsonData jd = new JsonData();
            for (int i = 0; i < id - 1; i++)
            {
                jd.Add(TalentSkill_BuffJsonData[i]);
            }
            for (int i = id - 1; i < TalentSkill_BuffJsonData.Count; i++)
            {
                if (i == TalentSkill_BuffJsonData.Count - 1)
                {
                    break;
                }
                jd.Add(TalentSkill_BuffJsonData[i + 1]);
            }
            TalentSkill_BuffJsonData = jd;
            File.WriteAllText(@"Assets/Res/JsonConfig/FightSkill_Buff.json", TalentSkill_BuffJsonData.ToJsonFile());
        }
    }

    public static bool SavetalentSkill(Dictionary<int, C_TalentSkill> talentSkill, int id)
    {
        if (TalentSkillJsonData.IsArray)
        {
            for (int i = 0; i < TalentSkillJsonData.Count; i++)
            {
                if (TalentSkillJsonData[i]["Id"].ToInt32() == talentSkill[id].Id && i != id - 1)
                {
                    WindowControl.SetConsole("保存失败,ID：" + talentSkill[id].Id + ",已经存在，请仔细填写");
                    return false;
                }

            }
        }
        print("该数据状态" + id + "IsJson=" + talentSkill[id].IsJson.ToString());
        if (!talentSkill[id].IsJson)
        {
            print("新增:" + TalentSkillJsonData.IsArray);
            TalentSkillJsonData.Add(talentSkill[id].Getjson());//新增操作

        }
        else
        {
            print("修改");
            TalentSkillJsonData[id - 1] = talentSkill[id].Getjson();//修改操作
        }
        File.WriteAllText(@"Assets/Res/JsonConfig/TalentSkill.json", TalentSkillJsonData.ToJsonFile());
        WindowControl.SetConsole("保存成功");
        return true;
    }

    public static void DelTalentSkillData(int id)
    {
        if (id <= TalentSkillJsonData.Count)
        {
            if (TalentSkillJsonData.Count == 1)
            {
                TalentSkillJsonData.Clear();
                File.WriteAllText(@"Assets/Res/JsonConfig/TalentSkill.json", "");
                return;
            }
            JsonData jd = new JsonData();
            for (int i = 0; i < id - 1; i++)
            {
                jd.Add(TalentSkillJsonData[i]);
            }
            for (int i = id - 1; i < TalentSkillJsonData.Count; i++)
            {
                if (i == TalentSkillJsonData.Count - 1)
                {
                    break;
                }
                jd.Add(TalentSkillJsonData[i + 1]);
            }
            TalentSkillJsonData = jd;
            File.WriteAllText(@"Assets/Res/JsonConfig/TalentSkill.json", TalentSkillJsonData.ToJsonFile());
        }
    }

    public static bool SaveTalentStoneConditionDate(Dictionary <int,C_TalentStoneCondition> talentStoneConditions,int id)
    {
        if (TalentStoneConditionJsonData.IsArray)
        {
            for (int i = 0; i < TalentStoneConditionJsonData.Count; i++)
            {
                if (TalentStoneConditionJsonData[i]["Id"].ToInt32() == talentStoneConditions[id].Id && i != id - 1)
                {
                    WindowControl.SetConsole("保存失败,ID：" + talentStoneConditions[id].Id + ",已经存在，请仔细填写");
                    return false;
                }
            }
        }


        print("该数据状态" + id + "IsJson=" + talentStoneConditions[id].IsJson.ToString());
        if (!talentStoneConditions[id].IsJson)
        {
            print("新增:" + TalentStoneConditionJsonData.IsArray);
            TalentStoneConditionJsonData.Add(talentStoneConditions[id].getJson());//新增操作

        }
        else
        {
            print("修改");
            TalentStoneConditionJsonData[id - 1] = talentStoneConditions[id].getJson();//修改操作
        }
        File.WriteAllText(@"Assets/Res/JsonConfig/TalentStoneCondition.json", TalentStoneConditionJsonData.ToJsonFile());
        WindowControl.SetConsole("保存成功");
        return true;
    }

    public static void DelTalentStoneConditionDate(int id)
    {
        if (id <= TalentStoneConditionJsonData.Count)
        {
            if (TalentStoneConditionJsonData.Count == 1)
            {
                TalentStoneConditionJsonData.Clear();
                File.WriteAllText(@"Assets/Res/JsonConfig/TalentStoneCondition.json", "");
                return;
            }
            JsonData jd = new JsonData();
            for (int i = 0; i < id - 1; i++)
            {
                jd.Add(TalentStoneConditionJsonData[i]);
            }
            for (int i = id - 1; i < TalentStoneConditionJsonData.Count; i++)
            {
                if (i == TalentStoneConditionJsonData.Count - 1)
                {
                    break;
                }
                jd.Add(TalentStoneConditionJsonData[i + 1]);
            }
            TalentStoneConditionJsonData = jd;
            File.WriteAllText(@"Assets/Res/JsonConfig/TalentStoneCondition.json", TalentStoneConditionJsonData.ToJsonFile());
        }
    }

    public static bool SaveTowerDefenseSkill(Dictionary<int, C_TowerDefenseSkill> towerDefenseSkill, int id)
    {
        if (TowerDefenseSkillJsonData.IsArray)
        {
            for (int i = 0; i < TowerDefenseSkillJsonData.Count; i++)
            {
                if (TowerDefenseSkillJsonData[i]["SkillId"].ToInt32() == towerDefenseSkill[id].SkillId && i != id - 1)
                {
                    WindowControl.SetConsole("保存失败,技能ID：" + towerDefenseSkill[id].SkillId + ",已经存在，请仔细填写");
                    return false;
                }
            }
        }


        print("该数据状态" + id + "IsJson=" + towerDefenseSkill[id].IsJson.ToString());
        if (!towerDefenseSkill[id].IsJson)
        {
            print("新增:" + SkillConfigJsonData.IsArray);
            TowerDefenseSkillJsonData.Add(towerDefenseSkill[id].GetJson());//新增操作

        }
        else
        {
            print("修改");
            TowerDefenseSkillJsonData[id - 1] = towerDefenseSkill[id].GetJson();//修改操作
        }
        File.WriteAllText(@"Assets/Res/JsonConfig/TowerDefenseSkill.json", TowerDefenseSkillJsonData.ToJsonFile());
        WindowControl.SetConsole("保存成功");
        return true;
    }

    public static void DelTowerDefenseSkill(int id)
    {
        if (id <= TowerDefenseSkillJsonData.Count)
        {
            if (TowerDefenseSkillJsonData.Count == 1)
            {
                TowerDefenseSkillJsonData.Clear();
                File.WriteAllText(@"Assets/Res/JsonConfig/TowerDefenseSkill.json", "");
                return;
            }
            JsonData jd = new JsonData();
            for (int i = 0; i < id - 1; i++)
            {
                jd.Add(TowerDefenseSkillJsonData[i]);
            }
            for (int i = id - 1; i < TowerDefenseSkillJsonData.Count; i++)
            {
                if (i == TowerDefenseSkillJsonData.Count - 1)
                {
                    break;
                }
                jd.Add(TowerDefenseSkillJsonData[i + 1]);
            }
            TowerDefenseSkillJsonData = jd;
            File.WriteAllText(@"Assets/Res/JsonConfig/TowerDefenseSkill.json", TowerDefenseSkillJsonData.ToJsonFile());
        }
    }

    public static bool SaveBreakGrowsJson(Dictionary<int,C_BreakGrow> breakGrows, int id)
    {
        if (BreakGrowJsonData.IsArray)
        {
            for (int i = 0; i < BreakGrowJsonData.Count; i++)
            {
                if (BreakGrowJsonData[i]["Level"].ToInt32() == breakGrows[id].Level && i != id - 1)
                {
                    WindowControl.SetConsole("保存失败,对应等级：" + breakGrows[id].Level+ ",已经存在，请仔细填写");
                    return false;
                }

            }
        }
        print("该数据状态" + id + "IsJson=" + breakGrows[id].IsJson.ToString());
        if (!breakGrows[id].IsJson)
        {
            print("新增:" + BreakGrowJsonData.IsArray);
            BreakGrowJsonData.Add(breakGrows[id].getJsonDate());//新增操作

        }
        else
        {
            print("修改");
            BreakGrowJsonData[id - 1] = breakGrows[id].getJsonDate();//修改操作
        }
        File.WriteAllText(@"Assets/Res/JsonConfig/BreakGrow.json", BreakGrowJsonData.ToJsonFile());
        WindowControl.SetConsole("保存成功");
        return true;
    }

    public static void DelBreakGrowsJson(int id)
    {
        if (id <= BreakGrowJsonData.Count)
        {
            if (BreakGrowJsonData.Count == 1)
            {
                BreakGrowJsonData.Clear();
                File.WriteAllText(@"Assets/Res/JsonConfig/BreakGrow.json", "");
                return;
            }
            JsonData jd = new JsonData();
            for (int i = 0; i < id - 1; i++)
            {
                jd.Add(BreakGrowJsonData[i]);
            }
            for (int i = id - 1; i < BreakGrowJsonData.Count; i++)
            {
                if (i == BreakGrowJsonData.Count - 1)
                {
                    break;
                }
                jd.Add(BreakGrowJsonData[i + 1]);
            }
            BreakGrowJsonData = jd;
            File.WriteAllText(@"Assets/Res/JsonConfig/BreakGrow.json", BreakGrowJsonData.ToJsonFile());
        }
    }

    public static bool SaveFightSkill(Dictionary<int,C_FightSkill> fightSkill ,int id)
    {
        if (FightSkillJsonData.IsArray)
        {
            for (int i = 0; i < FightSkillJsonData.Count; i++)
            {
                if (FightSkillJsonData[i]["SkillId"].ToInt32() == fightSkill[id].SkillId && i != id - 1)
                {
                    WindowControl.SetConsole("保存失败,技能ID：" + fightSkill[id].SkillId + ",已经存在，请仔细填写");
                    return false;
                }
            }
        }


        print("该数据状态" + id + "IsJson=" + fightSkill[id].IsJson.ToString());
        if (!fightSkill[id].IsJson)
        {
            print("新增:" + FightSkillJsonData.IsArray);
            FightSkillJsonData.Add(fightSkill[id].GetJson());//新增操作

        }
        else
        {
            print("修改");
            FightSkillJsonData[id - 1] = fightSkill[id].GetJson();//修改操作
        }
        File.WriteAllText(@"Assets/Res/JsonConfig/FightSkill.json", FightSkillJsonData.ToJsonFile());
        WindowControl.SetConsole("保存成功");
        return true;
    }

    public static void DelFightSkill(int id)
    {
        if (id <= FightSkillJsonData.Count)
        {
            if (FightSkillJsonData.Count == 1)
            {
                FightSkillJsonData.Clear();
                File.WriteAllText(@"Assets/Res/JsonConfig/FightSkill.json", "");
                return;
            }
            JsonData jd = new JsonData();
            for (int i = 0; i < id - 1; i++)
            {
                jd.Add(FightSkillJsonData[i]);
            }
            for (int i = id - 1; i < FightSkillJsonData.Count; i++)
            {
                if (i == FightSkillJsonData.Count - 1)
                {
                    break;
                }
                jd.Add(FightSkillJsonData[i + 1]);
            }
            FightSkillJsonData = jd;
            File.WriteAllText(@"Assets/Res/JsonConfig/FightSkill.json", FightSkillJsonData.ToJsonFile());
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
    public string Quality;
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
    public int ATKType;

    public bool IsJson = false;

    public JsonData getJsonData()
    {
        JsonData temdata = new JsonData();
        temdata.Add("Id", ID);
        temdata.Add("Quality", Quality);
        temdata.Add("ATKType",ATKType);
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
        jd.Add("InnateSkill40", InnateSkill40);
        jd.Add("InnateSkill41", InnateSkill41);
        jd.Add("InnateSkill42", InnateSkill42);
        jd.Add("InnateSkill43", InnateSkill43);
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

public class C_Frtter
{
    public int HeroID;
    public int FrtterId;
    public int NeedHeroIDLength;
    public List<Transform> NeedHeroList = new List<Transform>();
    public List<int> NeedexponentBit = new List<int>();
    public int PropertyAddLength;
    public List<Transform> PropertyAddList = new List<Transform>();

    public bool IsJson = false;

    public JsonData GetJson()
    {
        JsonData jd = new JsonData();
        jd.Add("HeroID",HeroID);
        jd.Add("FrtterId",FrtterId);

        JsonData needHero = new JsonData();
        for (int i = 0; i < NeedHeroList.Count;i++)
        {
            JsonData js = new JsonData();
            js.Add("HeroId",int.Parse(NeedHeroList[i].Find("HeroId").GetComponent<InputField>().text));
            js.Add("NeedStars", int.Parse(NeedHeroList[i].Find("NeedStars").GetComponent<InputField>().text));
            js.Add("NeedexponentBit", int.Parse(NeedHeroList[i].Find("NeedexponentBit").GetComponent<InputField>().text));
            needHero.Add(js);
        }
        jd.Add("NeedHeroList",needHero);

        JsonData propertyAdd = new JsonData();
        for (int i = 0; i < PropertyAddList.Count;i++)
        {
            JsonData js = new JsonData();
            js.Add("PropertyType", PropertyAddList[i].Find("PropertyType").GetComponent<Dropdown>().value);
            js.Add("PropertyAdd", int.Parse(PropertyAddList[i].Find("Property").GetComponent<InputField>().text));
            propertyAdd.Add(js);
        }
        jd.Add("propertyAddList",propertyAdd);
        return jd;
    }
}

public class C_TalentSkill_Buff
{
    public int Id;
    public int Type;
    public int IsDispel;
    public int IsSuperposition;
    public int TimeDuration;
    public string Explain;

    public bool IsJson = false;

    public JsonData GetJson()
    {
        JsonData js = new JsonData();
        js.Add("Id",Id);
        js.Add("Type",Type);
        js.Add("IsDispel",IsDispel);
        js.Add("IsSuperposition",IsSuperposition);
        js.Add("TimeDuration",TimeDuration);
        js.Add("Explain",Explain);
        return js;
    }
}

public class C_TalentSkill
{
    public int Id;
    public int HeroId;
    public string TalentName;
    public int Type;
    public int IsActivate;
    public int RelevantSkill;
    public string Result;
    public int ActivateResource1;
    public int Resource1Count;
    public int ActivateResource2;
    public int Resource2Count;
    public int ActivateResource3;
    public int Resource3Count;

    public bool IsJson = false;

    public JsonData Getjson()
    {
        JsonData jd = new JsonData();
        jd.Add("Id",Id);
        jd.Add("HeroId", HeroId);
        jd.Add("TalentName",TalentName);
        jd.Add("Type", Type);
        jd.Add("IsActivate", IsActivate);
        jd.Add("RelevantSkill", RelevantSkill);
        jd.Add("Result", Result);
        jd.Add("ActivateResource1", ActivateResource1);
        jd.Add("Resource1Count", Resource1Count);
        jd.Add("ActivateResource2", ActivateResource2);
        jd.Add("Resource2Count", Resource2Count);
        jd.Add("ActivateResource3", ActivateResource3);
        jd.Add("Resource3Count", Resource3Count);
        return jd;
    }
}

public class C_TalentStoneCondition
{
    public int Id;
    public int HeroId;
    public int Slot1_1;
    public int Slot1_2;
    public int Slot1_3;
    public int Slot1_4;
    public int Slot1_LevelConfine;
    public int Slot2_1;
    public int Slot2_2;
    public int Slot2_3;
    public int Slot2_4;
    public int Slot2_5;
    public int Slot2_6;
    public int Slot2_7;
    public int Slot2_8;
    public int Slot2_LevelConfine;
    public int Slot3_1;
    public int Slot3_2;
    public int Slot3_3;
    public int Slot3_4;
    public int Slot3_5;
    public int Slot3_6;
    public int Slot3_7;
    public int Slot3_8;
    public int Slot3_9;
    public int Slot3_10;
    public int Slot3_11;
    public int Slot3_12;
    public int Slot3_LevelConfine;
    public int Slot4_1;
    public int Slot4_2;
    public int Slot4_3;
    public int Slot4_4;
    public int Slot4_5;
    public int Slot4_6;
    public int Slot4_7;
    public int Slot4_8;
    public int Slot4_9;
    public int Slot4_10;
    public int Slot4_11;
    public int Slot4_12;
    public int Slot4_13;
    public int Slot4_14;
    public int Slot4_15;
    public int Slot4_16;
    public int Slot4_LevelConfine;

    public bool IsJson = false;

    public JsonData getJson()
    {
        JsonData jd = new JsonData();
        jd.Add("Id", Id);
        jd.Add("HeroId", HeroId);
        jd.Add("Slot1_1", Slot1_1);
        jd.Add("Slot1_2", Slot1_2);
        jd.Add("Slot1_3", Slot1_3);
        jd.Add("Slot1_4", Slot1_4);
        jd.Add("Slot1_LevelConfine", Slot1_LevelConfine);
        jd.Add("Slot2_1", Slot2_1);
        jd.Add("Slot2_2", Slot2_2);
        jd.Add("Slot2_3", Slot2_3);
        jd.Add("Slot2_4", Slot2_4);
        jd.Add("Slot2_5", Slot2_5);
        jd.Add("Slot2_6", Slot2_6);
        jd.Add("Slot2_7", Slot2_7);
        jd.Add("Slot2_8", Slot2_8);
        jd.Add("Slot2_LevelConfine", Slot2_LevelConfine);
        jd.Add("Slot3_1", Slot3_1);
        jd.Add("Slot3_2", Slot3_2);
        jd.Add("Slot3_3", Slot3_3);
        jd.Add("Slot3_4", Slot3_4);
        jd.Add("Slot3_5", Slot3_5);
        jd.Add("Slot3_6", Slot3_6);
        jd.Add("Slot3_7", Slot3_7);
        jd.Add("Slot3_8", Slot3_8);
        jd.Add("Slot3_9", Slot3_9);
        jd.Add("Slot3_10", Slot3_10);
        jd.Add("Slot3_11", Slot3_11);
        jd.Add("Slot3_12", Slot3_12);
        jd.Add("Slot3_LevelConfine", Slot3_LevelConfine);
        jd.Add("Slot4_1", Slot4_1);
        jd.Add("Slot4_2", Slot4_2);
        jd.Add("Slot4_3", Slot4_3);
        jd.Add("Slot4_4", Slot4_4);
        jd.Add("Slot4_5", Slot4_5);
        jd.Add("Slot4_6", Slot4_6);
        jd.Add("Slot4_7", Slot4_7);
        jd.Add("Slot4_8", Slot4_8);
        jd.Add("Slot4_9", Slot4_9);
        jd.Add("Slot4_10", Slot4_10);
        jd.Add("Slot4_11", Slot4_11);
        jd.Add("Slot4_12", Slot4_12);
        jd.Add("Slot4_13", Slot4_13);
        jd.Add("Slot4_14", Slot4_14);
        jd.Add("Slot4_15", Slot4_15);
        jd.Add("Slot4_16", Slot4_16);
        jd.Add("Slot4_LevelConfine", Slot4_LevelConfine);
        return jd;
    }
}

public class C_TowerDefenseSkill
{
    public int HeroId;
    public int SkillId;
    public string SkillName;
    public int ReleaseNum;
    public int Duration;
    public int AttackRange;
    public int TrajectorySpeed;
    public int DamageType;
    public int SkillType;
    public int SkillRange;
    public int SkillBaseDamage;
    public int DamageCoefficient;
    public int SpeedCut;
    public int SpeedCutTime;
    public int DizzinessTime;
    public int DisorderTime;
    public int AttackIncrease;
    public int AttackIncreaseTime;
    public int IsWhetherFly;
    public int UpATK;
    public int UpATKTime;
    public int RespondEnergy;
    public int EnergyConsumption;
    public int RelevantTalentId1;
    public int RelevantTalentId2;
    public int RelevantTalentId3;
    public string SkillDescribe;

    public bool IsJson = false;

    public JsonData GetJson()
    {
        JsonData jd = new JsonData();
        jd.Add("HeroId", HeroId);
        jd.Add("SkillId", SkillId);
        jd.Add("SkillName", SkillName);
        jd.Add("ReleaseNum", ReleaseNum);
        jd.Add("Duration", Duration);
        jd.Add("AttackRange", AttackRange);
        jd.Add("TrajectorySpeed", TrajectorySpeed);
        jd.Add("DamageType", DamageType);
        jd.Add("SkillType", SkillType);
        jd.Add("SkillRange", SkillRange);
        jd.Add("SkillBaseDamage", SkillBaseDamage);
        jd.Add("DamageCoefficient", DamageCoefficient);
        jd.Add("SpeedCut", SpeedCut);
        jd.Add("SpeedCutTime", SpeedCutTime);
        jd.Add("DizzinessTime", DizzinessTime);
        jd.Add("DisorderTime", DisorderTime);
        jd.Add("AttackIncrease", AttackIncrease);
        jd.Add("AttackIncreaseTime", AttackIncreaseTime);
        jd.Add("IsWhetherFly", IsWhetherFly);
        jd.Add("UpATK", UpATK);
        jd.Add("UpATKTime", UpATKTime);
        jd.Add("RespondEnergy", RespondEnergy);
        jd.Add("EnergyConsumption", EnergyConsumption);
        jd.Add("RelevantTalentId1", RelevantTalentId1);
        jd.Add("RelevantTalentId2", RelevantTalentId2);
        jd.Add("RelevantTalentId3", RelevantTalentId3);
        jd.Add("SkillDescribe", SkillDescribe);
        return jd;
    }
}

public class C_BreakGrow
{

    public int Level;
    public int BreakNum;
    public int ConsumptionGold;
    public int ConsumptionBG;
    public int ConsumptionEssence;

    public bool IsJson = false;

    public JsonData getJsonDate()
    {
        JsonData jd = new JsonData();
        jd.Add("Level", Level);
        jd.Add("BreakNum", BreakNum);
        jd.Add("ConsumptionGold", ConsumptionGold);
        jd.Add("ConsumptionBG", ConsumptionBG);
        jd.Add("ConsumptionEssence", ConsumptionEssence);
        return jd;
    }
}

    public class C_FightSkill
    {
        public int SkillId;
        public int HeroId;
        public string SkillName;
        public int ATKType;
        public int DamageCoefficient;
        public int Effect1;
        public string SpecialCase1;
        public int Target1;
        public string Dispose1;
        public int Effect2;
        public string SpecialCase2;
        public int Target2;
        public string Dispose2;
        public int RelevantTalentId1;
        public int RelevantTalentId2;
        public int RelevantTalentId3;
        public string SkillDescribe;

        public bool IsJson = false;

        public JsonData GetJson()
        {
            JsonData jd = new JsonData();
            jd.Add("SkillId", SkillId);
            jd.Add("HeroId", HeroId);
            jd.Add("SkillName", SkillName);
            jd.Add("ATKType", ATKType);
            jd.Add("DamageCoefficient", DamageCoefficient);
            jd.Add("Effect1", Effect1);
            jd.Add("SpecialCase1", SpecialCase1);
            jd.Add("Target1", Target1);
            jd.Add("Dispose1", Dispose1);
            jd.Add("Effect2", Effect2);
            jd.Add("SpecialCase2", SpecialCase2);
            jd.Add("Target2", Target2);
            jd.Add("Dispose2", Dispose2);
            jd.Add("RelevantTalentId1", RelevantTalentId1);
            jd.Add("RelevantTalentId2", RelevantTalentId2);
            jd.Add("RelevantTalentId3", RelevantTalentId3);
            jd.Add("SkillDescribe", SkillDescribe);
            return jd;
        }
    
}

public class C_ResourceConfig
{
    public int Id;
    public int HeroId;
    public string ModelTarget;
    public string ATK1Target;
    public int ATK1Frame;
    public string ATK2Target;
    public int ATK2Frame;
    public string SkillTarget1;
    public string SkillTarget2;
    public string ShowTarget;
    public string RandomTarget;

    public bool IsJson = false;

    public JsonData GetJson()
    {
        JsonData jd = new JsonData();
        jd.Add("Id",Id);
        jd.Add("HeroId", HeroId);
        jd.Add("ModelTarget", ModelTarget);
        return jd;
    }

}