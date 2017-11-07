using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerDefenseSkill : MonoBehaviour {
    public int Length = 0;
    public Dictionary<int, C_TowerDefenseSkill> towerDefenseSkills=new Dictionary<int, C_TowerDefenseSkill>();

    private InputField HeroID;
    private InputField SkillId;
    private InputField SkillName;
    private InputField ReleaseNum;
    private InputField Duration;
    private InputField AttackRange;
    private InputField TrajectorySpeed;
    private Dropdown DamageType;
    private Dropdown SkillType;
    private InputField SkillRange;
    private InputField SkillBaseDamage;
    private InputField DamageCoefficient;
    private InputField SpeedCut;
    private InputField SpeedCutTime;
    private InputField DizzinessTime;
    private InputField DisorderTime;
    private InputField AttackIncrease;
    private InputField AttackIncreaseTime;
    private Dropdown IsWhetherFly;
    private InputField UpATK;
    private InputField UpATKTime;
    private InputField RespondEnergy;
    private InputField EnergyConsumption;
    private InputField RelevantTalentId1;
    private InputField RelevantTalentId2;
    private InputField RelevantTalentId3;
    private InputField SkillDescribe;

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
    // Use this for initialization
    void Start () {
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
        if (!DataManage.TowerDefenseSkillJsonData.IsArray)
        {
            return;
        }

        for (int i = 0; i < DataManage.TowerDefenseSkillJsonData.Count; i++)
        {
            OnAdd();
            HeroID = transform.Find("Viewport/Content/obj" + Length + "/HeroID").GetComponent<InputField>();
            SkillId = transform.Find("Viewport/Content/obj" + Length + "/SkillId").GetComponent<InputField>();
            SkillName = transform.Find("Viewport/Content/obj" + Length + "/SkillName").GetComponent<InputField>();
            ReleaseNum = transform.Find("Viewport/Content/obj" + Length + "/ReleaseNum").GetComponent<InputField>();
            Duration = transform.Find("Viewport/Content/obj" + Length + "/Duration").GetComponent<InputField>();
            AttackRange = transform.Find("Viewport/Content/obj" + Length + "/AttackRange").GetComponent<InputField>();
            TrajectorySpeed = transform.Find("Viewport/Content/obj" + Length + "/TrajectorySpeed").GetComponent<InputField>();
            DamageType = transform.Find("Viewport/Content/obj" + Length + "/DamageType").GetComponent<Dropdown>();
            SkillType = transform.Find("Viewport/Content/obj" + Length + "/SkillType").GetComponent<Dropdown>();
            SkillRange = transform.Find("Viewport/Content/obj" + Length + "/SkillRange").GetComponent<InputField>();
            SkillBaseDamage = transform.Find("Viewport/Content/obj" + Length + "/SkillBaseDamage").GetComponent<InputField>();
            DamageCoefficient = transform.Find("Viewport/Content/obj" + Length + "/DamageCoefficient").GetComponent<InputField>();
            SpeedCut = transform.Find("Viewport/Content/obj" + Length + "/SpeedCut").GetComponent<InputField>();
            SpeedCutTime = transform.Find("Viewport/Content/obj" + Length + "/SpeedCutTime").GetComponent<InputField>();
            DizzinessTime = transform.Find("Viewport/Content/obj" + Length + "/DizzinessTime").GetComponent<InputField>();
            DisorderTime = transform.Find("Viewport/Content/obj" + Length + "/DisorderTime").GetComponent<InputField>();
            AttackIncrease = transform.Find("Viewport/Content/obj" + Length + "/AttackIncrease").GetComponent<InputField>();
            AttackIncreaseTime = transform.Find("Viewport/Content/obj" + Length + "/AttackIncreaseTime").GetComponent<InputField>();
            IsWhetherFly = transform.Find("Viewport/Content/obj" + Length + "/IsWhetherFly").GetComponent<Dropdown>();
            UpATK = transform.Find("Viewport/Content/obj" + Length + "/UpATK").GetComponent<InputField>();
            UpATKTime = transform.Find("Viewport/Content/obj" + Length + "/UpATKTime").GetComponent<InputField>();
            RespondEnergy = transform.Find("Viewport/Content/obj" + Length + "/RespondEnergy").GetComponent<InputField>();
            EnergyConsumption = transform.Find("Viewport/Content/obj" + Length + "/EnergyConsumption").GetComponent<InputField>();
            RelevantTalentId1 = transform.Find("Viewport/Content/obj" + Length + "/RelevantTalentId1").GetComponent<InputField>();
            RelevantTalentId2 = transform.Find("Viewport/Content/obj" + Length + "/RelevantTalentId2").GetComponent<InputField>();
            RelevantTalentId3 = transform.Find("Viewport/Content/obj" + Length + "/RelevantTalentId3").GetComponent<InputField>();
            SkillDescribe = transform.Find("Viewport/Content/obj" + Length + "/SkillDescribe").GetComponent<InputField>();

            towerDefenseSkills[Length].HeroId = DataManage.TowerDefenseSkillJsonData[i]["HeroId"].ToInt32();
            towerDefenseSkills[Length].SkillId = DataManage.TowerDefenseSkillJsonData[i]["SkillId"].ToInt32();
            towerDefenseSkills[Length].SkillName = DataManage.TowerDefenseSkillJsonData[i]["SkillName"].ToString();
            towerDefenseSkills[Length].ReleaseNum = DataManage.TowerDefenseSkillJsonData[i]["ReleaseNum"].ToInt32();
            towerDefenseSkills[Length].Duration = DataManage.TowerDefenseSkillJsonData[i]["Duration"].ToInt32();
            towerDefenseSkills[Length].AttackRange = DataManage.TowerDefenseSkillJsonData[i]["AttackRange"].ToInt32();
            towerDefenseSkills[Length].TrajectorySpeed = DataManage.TowerDefenseSkillJsonData[i]["TrajectorySpeed"].ToInt32();
            towerDefenseSkills[Length].DamageType = DataManage.TowerDefenseSkillJsonData[i]["DamageType"].ToInt32();
            towerDefenseSkills[Length].SkillType = DataManage.TowerDefenseSkillJsonData[i]["SkillType"].ToInt32();
            towerDefenseSkills[Length].SkillRange = DataManage.TowerDefenseSkillJsonData[i]["SkillRange"].ToInt32();
            towerDefenseSkills[Length].SkillBaseDamage = DataManage.TowerDefenseSkillJsonData[i]["SkillBaseDamage"].ToInt32();
            towerDefenseSkills[Length].DamageCoefficient = DataManage.TowerDefenseSkillJsonData[i]["DamageCoefficient"].ToInt32();
            towerDefenseSkills[Length].SpeedCut = DataManage.TowerDefenseSkillJsonData[i]["SpeedCut"].ToInt32();
            towerDefenseSkills[Length].SpeedCutTime = DataManage.TowerDefenseSkillJsonData[i]["SpeedCutTime"].ToInt32();
            towerDefenseSkills[Length].DizzinessTime = DataManage.TowerDefenseSkillJsonData[i]["DizzinessTime"].ToInt32();
            towerDefenseSkills[Length].DisorderTime = DataManage.TowerDefenseSkillJsonData[i]["DisorderTime"].ToInt32();
            towerDefenseSkills[Length].AttackIncrease = DataManage.TowerDefenseSkillJsonData[i]["AttackIncrease"].ToInt32();
            towerDefenseSkills[Length].AttackIncreaseTime = DataManage.TowerDefenseSkillJsonData[i]["AttackIncreaseTime"].ToInt32();
            towerDefenseSkills[Length].IsWhetherFly = DataManage.TowerDefenseSkillJsonData[i]["IsWhetherFly"].ToInt32();
            towerDefenseSkills[Length].UpATK = DataManage.TowerDefenseSkillJsonData[i]["UpATK"].ToInt32();
            towerDefenseSkills[Length].UpATKTime = DataManage.TowerDefenseSkillJsonData[i]["UpATKTime"].ToInt32();
            towerDefenseSkills[Length].RespondEnergy = DataManage.TowerDefenseSkillJsonData[i]["RespondEnergy"].ToInt32();
            towerDefenseSkills[Length].EnergyConsumption = DataManage.TowerDefenseSkillJsonData[i]["EnergyConsumption"].ToInt32();
            towerDefenseSkills[Length].RelevantTalentId1 = DataManage.TowerDefenseSkillJsonData[i]["RelevantTalentId1"].ToInt32();
            towerDefenseSkills[Length].RelevantTalentId2 = DataManage.TowerDefenseSkillJsonData[i]["RelevantTalentId2"].ToInt32();
            towerDefenseSkills[Length].RelevantTalentId3 = DataManage.TowerDefenseSkillJsonData[i]["RelevantTalentId3"].ToInt32();
            towerDefenseSkills[Length].SkillDescribe = DataManage.TowerDefenseSkillJsonData[i]["SkillDescribe"].ToString(); ;
            towerDefenseSkills[Length].IsJson = true;

            print("DataManage=" + DataManage.HeroJsonData.Count);
            HeroID.text = towerDefenseSkills[Length].HeroId.ToString();
            SkillId.text = towerDefenseSkills[Length].SkillId.ToString();
            SkillName.text = towerDefenseSkills[Length].SkillName;
            ReleaseNum.text = towerDefenseSkills[Length].ReleaseNum.ToString();
            Duration.text = towerDefenseSkills[Length].Duration.ToString();
            AttackRange.text = towerDefenseSkills[Length].AttackRange.ToString();
            TrajectorySpeed.text = towerDefenseSkills[Length].TrajectorySpeed.ToString();
            DamageType.value = towerDefenseSkills[Length].DamageType-1;
            SkillType.value = towerDefenseSkills[Length].SkillType-1;
            SkillRange.text = towerDefenseSkills[Length].SkillRange.ToString();
            SkillBaseDamage.text = towerDefenseSkills[Length].SkillBaseDamage.ToString();
            DamageCoefficient.text = towerDefenseSkills[Length].DamageCoefficient.ToString();
            SpeedCut.text = towerDefenseSkills[Length].SpeedCut.ToString();
            SpeedCutTime.text = towerDefenseSkills[Length].SpeedCutTime.ToString();
            DizzinessTime.text = towerDefenseSkills[Length].DizzinessTime.ToString();
            DisorderTime.text = towerDefenseSkills[Length].DisorderTime.ToString();
            AttackIncrease.text = towerDefenseSkills[Length].AttackIncrease.ToString();
            AttackIncreaseTime.text = towerDefenseSkills[Length].AttackIncreaseTime.ToString();
            IsWhetherFly.value = towerDefenseSkills[Length].IsWhetherFly-1;
            UpATK.text = towerDefenseSkills[Length].UpATK.ToString();
            UpATKTime.text = towerDefenseSkills[Length].UpATKTime.ToString();
            RespondEnergy.text = towerDefenseSkills[Length].RespondEnergy.ToString();
            EnergyConsumption.text = towerDefenseSkills[Length].EnergyConsumption.ToString();
            RelevantTalentId1.text = towerDefenseSkills[Length].RelevantTalentId1.ToString();
            RelevantTalentId2.text = towerDefenseSkills[Length].RelevantTalentId2.ToString();
            RelevantTalentId3.text = towerDefenseSkills[Length].RelevantTalentId3.ToString();
            SkillDescribe.text = towerDefenseSkills[Length].SkillDescribe.ToString();
        }
    }
    public void Save(int ID)
    {
        HeroID = transform.Find("Viewport/Content/obj" + ID + "/HeroID").GetComponent<InputField>();
        SkillId = transform.Find("Viewport/Content/obj" + ID + "/SkillId").GetComponent<InputField>();
        SkillName = transform.Find("Viewport/Content/obj" + ID + "/SkillName").GetComponent<InputField>();
        ReleaseNum = transform.Find("Viewport/Content/obj" + ID + "/ReleaseNum").GetComponent<InputField>();
        Duration = transform.Find("Viewport/Content/obj" + ID + "/Duration").GetComponent<InputField>();
        AttackRange = transform.Find("Viewport/Content/obj" + ID + "/AttackRange").GetComponent<InputField>();
        TrajectorySpeed = transform.Find("Viewport/Content/obj" + ID + "/TrajectorySpeed").GetComponent<InputField>();
        DamageType = transform.Find("Viewport/Content/obj" + ID + "/DamageType").GetComponent<Dropdown>();
        SkillType = transform.Find("Viewport/Content/obj" + ID + "/SkillType").GetComponent<Dropdown>();
        SkillRange = transform.Find("Viewport/Content/obj" + ID + "/SkillRange").GetComponent<InputField>();
        SkillBaseDamage = transform.Find("Viewport/Content/obj" + ID + "/SkillBaseDamage").GetComponent<InputField>();
        DamageCoefficient = transform.Find("Viewport/Content/obj" + ID + "/DamageCoefficient").GetComponent<InputField>();
        SpeedCut = transform.Find("Viewport/Content/obj" + ID + "/SpeedCut").GetComponent<InputField>();
        SpeedCutTime = transform.Find("Viewport/Content/obj" + ID + "/SpeedCutTime").GetComponent<InputField>();
        DizzinessTime = transform.Find("Viewport/Content/obj" + ID + "/DizzinessTime").GetComponent<InputField>();
        DisorderTime = transform.Find("Viewport/Content/obj" + ID + "/DisorderTime").GetComponent<InputField>();
        AttackIncrease = transform.Find("Viewport/Content/obj" + ID + "/AttackIncrease").GetComponent<InputField>();
        AttackIncreaseTime = transform.Find("Viewport/Content/obj" + ID + "/AttackIncreaseTime").GetComponent<InputField>();
        IsWhetherFly = transform.Find("Viewport/Content/obj" + ID + "/IsWhetherFly").GetComponent<Dropdown>();
        UpATK = transform.Find("Viewport/Content/obj" + ID + "/UpATK").GetComponent<InputField>();
        UpATKTime = transform.Find("Viewport/Content/obj" + ID + "/UpATKTime").GetComponent<InputField>();
        RespondEnergy = transform.Find("Viewport/Content/obj" + ID + "/RespondEnergy").GetComponent<InputField>();
        EnergyConsumption = transform.Find("Viewport/Content/obj" + ID + "/EnergyConsumption").GetComponent<InputField>();
        RelevantTalentId1 = transform.Find("Viewport/Content/obj" + ID + "/RelevantTalentId1").GetComponent<InputField>();
        RelevantTalentId2 = transform.Find("Viewport/Content/obj" + ID + "/RelevantTalentId2").GetComponent<InputField>();
        RelevantTalentId3 = transform.Find("Viewport/Content/obj" + ID + "/RelevantTalentId3").GetComponent<InputField>();
        SkillDescribe = transform.Find("Viewport/Content/obj" + ID + "/SkillDescribe").GetComponent<InputField>();


        try
        {
            towerDefenseSkills[ID].HeroId = int.Parse(HeroID.text);
            towerDefenseSkills[ID].SkillId = int.Parse(SkillId.text);
            towerDefenseSkills[ID].SkillName = SkillName.text;
            towerDefenseSkills[ID].ReleaseNum = int.Parse(ReleaseNum.text);
            towerDefenseSkills[ID].Duration = int.Parse(Duration.text);
            towerDefenseSkills[ID].AttackRange = int.Parse(AttackRange.text);
            towerDefenseSkills[ID].TrajectorySpeed = int.Parse(TrajectorySpeed.text);
            towerDefenseSkills[ID].DamageType = DamageType.value+1;
            towerDefenseSkills[ID].SkillType =SkillType.value+1;
            towerDefenseSkills[ID].SkillRange = int.Parse(SkillRange.text);
            towerDefenseSkills[ID].SkillBaseDamage = int.Parse(SkillBaseDamage.text);
            towerDefenseSkills[ID].DamageCoefficient = int.Parse(DamageCoefficient.text);
            towerDefenseSkills[ID].SpeedCut = int.Parse(SpeedCut.text);
            towerDefenseSkills[ID].SpeedCutTime = int.Parse(SpeedCutTime.text);
            towerDefenseSkills[ID].DizzinessTime = int.Parse(DizzinessTime.text);
            towerDefenseSkills[ID].DisorderTime = int.Parse(DisorderTime.text);
            towerDefenseSkills[ID].AttackIncrease = int.Parse(AttackIncrease.text);
            towerDefenseSkills[ID].AttackIncreaseTime = int.Parse(AttackIncreaseTime.text);
            towerDefenseSkills[ID].IsWhetherFly = IsWhetherFly.value;
            towerDefenseSkills[ID].UpATK = int.Parse(UpATK.text);
            towerDefenseSkills[ID].UpATKTime = int.Parse(UpATKTime.text);
            towerDefenseSkills[ID].RespondEnergy = int.Parse(RespondEnergy.text);
            towerDefenseSkills[ID].EnergyConsumption = int.Parse(EnergyConsumption.text);
            towerDefenseSkills[ID].RelevantTalentId1 = int.Parse(RelevantTalentId1.text);
            towerDefenseSkills[ID].RelevantTalentId2 = int.Parse(RelevantTalentId2.text);
            towerDefenseSkills[ID].RelevantTalentId3 = int.Parse(RelevantTalentId3.text);
            towerDefenseSkills[ID].SkillDescribe = SkillDescribe.text;

        }
        catch (Exception ex)
        {
            // 错误处理代码
            WindowControl.SetConsole("保存失败，你填写的数据类型不对,详细：" + ex.Message);
            //transform.parent.Find("Console/Text").GetComponent<Text>().text = "保存失败，你填写的数据类型不对,详细："+ex.Message+"--------------时间："+DateTime.Now.ToString();
            return;
        }

        if (DataManage.SaveTowerDefenseSkill(towerDefenseSkills, ID))
        {
            towerDefenseSkills[ID].IsJson = true;
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
        C_TowerDefenseSkill c_towerDefenseSkill = new C_TowerDefenseSkill();
        //heroData[Length-1] = s_heroData;
        //heroData.Add(Length, c_heroData);
        towerDefenseSkills[Length] = (c_towerDefenseSkill);
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
            towerDefenseSkills[ID] = towerDefenseSkills[i];

        }
        towerDefenseSkills.Remove(Length);
        print("集合长度=" + towerDefenseSkills.Count);
        Length -= 1;
        DataManage.DelTowerDefenseSkill(ID);
        WindowControl.SetConsole("删除成功");
        //transform.parent.Find("Console/Text").GetComponent<Text>().text = "删除成功-----------------时间" + DateTime.Now.ToString();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
