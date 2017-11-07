using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class HeroData : MonoBehaviour {
    public int Length = 0;

    private Text _heroID;
    private Dropdown _heroQuality;
    private Dropdown _heroType;
    private Text _heroStarID;
    private Text _heroFighting;
    private Text _heroExponentBit;
    private Text _heroLevel;
    private Text _heroVitality;
    private Text _heroAttack;
    private Text _heroAttackSpeed;
    private Text _heroSkill;
    private Text _heroHitRate;
    private Text _heroDodge;
    private Text _heroCriticalStrike;
    private Text _heroTenacity;
    private Text _heroPierce;
    private Text _heroDefense;
    private Text _heroActGrow;
    private Text _heroVitalityGrow;
    private Text _heroActSpeedGrow;
    private Text _heroGrowCoefficient;
    private Text _heroActBreakLevel;
    private Text _heroVitalityBreakLevel;
    private Text _heroBaseStrikeDamage;
    private Text _heroTowerActFrequency;
    private Text _heroSkillConfigID;
    private Text _heroExclusiveEquipID;
    private Text _heroByConfigID1;
    private Text _heroByConfigID2;
    private Text _heroByConfigID3;
    private Text _heroByConfigID4;
    private Text _heroMessageConfigID;
    private Dropdown _ATKType;

    public static Dictionary<int, C_HeroData> heroData = new Dictionary<int, C_HeroData>();

    Transform _basicInformation;
    public Transform BasicInformation
    {
        get{
            if(_basicInformation==null)
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
        //_basicInformation = transform.Find("Viewport/Content/type");
        //print( DataManage.Data);

	}

    void Awake()
    {
        Init();
    }
    void OnEnable()
    {
        for (int i = 0; i < DataManage.HeroJsonData.Count; i++)
        {
            _heroID = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroID").GetComponent<Text>();
            _heroQuality = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroQuality").GetComponent<Dropdown>();
            _heroType = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroType").GetComponent<Dropdown>();
            _heroStarID = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroStarID").GetComponent<Text>();
            _heroFighting = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroFighting").GetComponent<Text>();
            _heroExponentBit = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroExponentBit").GetComponent<Text>();
            _heroLevel = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroLevel").GetComponent<Text>();
            _heroVitality = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroVitality").GetComponent<Text>();
            _heroAttack = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroAttack").GetComponent<Text>();
            _heroAttackSpeed = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroAttackSpeed").GetComponent<Text>();
            _heroSkill = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroSkill").GetComponent<Text>();
            _heroHitRate = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroHitRate").GetComponent<Text>();
            _heroDodge = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroDodge").GetComponent<Text>();
            _heroCriticalStrike = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroCriticalStrike").GetComponent<Text>();
            _heroTenacity = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroTenacity").GetComponent<Text>();
            _heroPierce = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroPierce").GetComponent<Text>();
            _heroDefense = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroDefense").GetComponent<Text>();
            _heroActGrow = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroActGrow").GetComponent<Text>();
            _heroVitalityGrow = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroVitalityGrow").GetComponent<Text>();
            _heroActSpeedGrow = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroActSpeedGrow").GetComponent<Text>();
            _heroGrowCoefficient = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroGrowCoefficient").GetComponent<Text>();
            _heroActBreakLevel = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroActBreakLevel").GetComponent<Text>();
            _heroVitalityBreakLevel = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroVitalityBreakLevel").GetComponent<Text>();
            _heroBaseStrikeDamage = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroBaseStrikeDamage").GetComponent<Text>();
            _heroTowerActFrequency = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroTowerActFrequency").GetComponent<Text>();
            _heroSkillConfigID = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroSkillConfigID").GetComponent<Text>();
            _heroExclusiveEquipID = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroExclusiveEquipID").GetComponent<Text>();
            _heroByConfigID1 = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroByConfigID1").GetComponent<Text>();
            _heroByConfigID2 = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroByConfigID2").GetComponent<Text>();
            _heroByConfigID3 = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroByConfigID3").GetComponent<Text>();
            _heroByConfigID4 = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroByConfigID4").GetComponent<Text>();
            _heroMessageConfigID = transform.Find("Viewport/Content/obj" + (i + 1) + "/HeroMessageConfigID").GetComponent<Text>();
            _ATKType = transform.Find("Viewport/Content/obj" + (i + 1) + "/ATKType").GetComponent<Dropdown>();

            heroData[(i + 1)].ID = DataManage.HeroJsonData[i]["Id"].ToInt32();
            heroData[(i + 1)].StarID = DataManage.HeroJsonData[i]["StarId"].ToInt32();
            //heroData[(i + 1)].Quality = (C_HeroData.HeroQuality)DataManage.HeroJsonData[i]["Quality"].ToString();

            heroData[(i + 1)].Type = (C_HeroData.HeroType)DataManage.HeroJsonData[i]["Type"].ToInt32();
            heroData[(i + 1)].ATKType = DataManage.HeroJsonData[i]["ATKType"].ToInt32();
            heroData[(i + 1)].Fighting = DataManage.HeroJsonData[i]["Fighting"].ToInt32();
            heroData[(i + 1)].ExponentBit = DataManage.HeroJsonData[i]["ExponentBit"].ToInt32();
            heroData[(i + 1)].Level = DataManage.HeroJsonData[i]["Level"].ToInt32();
            heroData[(i + 1)].Vitality = DataManage.HeroJsonData[i]["Vitality"].ToInt32();
            heroData[(i + 1)].Attack = DataManage.HeroJsonData[i]["ATK"].ToInt32();
            heroData[(i + 1)].AttackSpeed = DataManage.HeroJsonData[i]["ATKSpeed"].ToInt32();
            heroData[(i + 1)].Skill = DataManage.HeroJsonData[i]["Skill"].ToInt32();
            heroData[(i + 1)].HitRate = DataManage.HeroJsonData[i]["HitRate"].ToInt32();
            heroData[(i + 1)].Dodge = DataManage.HeroJsonData[i]["Dodge"].ToInt32();
            heroData[(i + 1)].CriticalStrike = DataManage.HeroJsonData[i]["CriticalStrike"].ToInt32();
            heroData[(i + 1)].Tenacity = DataManage.HeroJsonData[i]["Tenacity"].ToInt32();
            heroData[(i + 1)].Pierce = DataManage.HeroJsonData[i]["Pierce"].ToInt32();
            heroData[(i + 1)].Defense = DataManage.HeroJsonData[i]["Defense"].ToInt32();
            heroData[(i + 1)].ActGrow = DataManage.HeroJsonData[i]["ATKGrow"].ToInt32();
            heroData[(i + 1)].VitalityGrow = DataManage.HeroJsonData[i]["VitalityGrow"].ToInt32();
            heroData[(i + 1)].ActSpeedGrow = DataManage.HeroJsonData[i]["ATKSpeedGrow"].ToInt32();
            heroData[(i + 1)].GrowCoefficient = DataManage.HeroJsonData[i]["GrowCoefficient"].ToInt32();
            heroData[(i + 1)].ActBreakLevel = DataManage.HeroJsonData[i]["ATKBreakLevel"].ToInt32();
            heroData[(i + 1)].VitalityBreakLevel = DataManage.HeroJsonData[i]["VitalityBreakLevel"].ToInt32();
            heroData[(i + 1)].BaseStrikeDamage = DataManage.HeroJsonData[i]["BaseStrikeDamage"].ToInt32();
            heroData[(i + 1)].TowerActFrequency = DataManage.HeroJsonData[i]["TowerATKFrequency"].ToInt32();
            heroData[(i + 1)].SkillConfigID = DataManage.HeroJsonData[i]["SkillConfigId"].ToInt32();
            heroData[(i + 1)].ExclusiveEquipID = DataManage.HeroJsonData[i]["ExclusiveEquipId"].ToInt32();
            heroData[(i + 1)].ByConfigID1 = DataManage.HeroJsonData[i]["ByConfigId1"].ToInt32();
            heroData[(i + 1)].ByConfigID2 = DataManage.HeroJsonData[i]["ByConfigId2"].ToInt32();
            heroData[(i + 1)].ByConfigID3 = DataManage.HeroJsonData[i]["ByConfigId3"].ToInt32();
            heroData[(i + 1)].ByConfigID4 = DataManage.HeroJsonData[i]["ByConfigId4"].ToInt32();
            heroData[(i + 1)].MessageConfigID = DataManage.HeroJsonData[i]["MessageConfigId"].ToInt32();
            heroData[(i + 1)].IsJson = true;

            print("DataManage=" + DataManage.HeroJsonData.Count);
            _heroID.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].ID.ToString();
            //_heroQuality.value = (int)heroData[Length].Quality - 1;
            //_heroType.value = (int)heroData[Length].Type - 1;
            _heroStarID.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].StarID.ToString();
            _ATKType.gameObject.GetComponent<Dropdown>().value = heroData[i + 1].ATKType;
            _heroFighting.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].Fighting.ToString();
            _heroExponentBit.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].ExponentBit.ToString();
            _heroLevel.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].Level.ToString();
            _heroVitality.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].Vitality.ToString();
            _heroAttack.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].Attack.ToString();
            _heroAttackSpeed.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].AttackSpeed.ToString();
            _heroSkill.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].Skill.ToString();
            _heroHitRate.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].HitRate.ToString();
            _heroDodge.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].Dodge.ToString();
            _heroCriticalStrike.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].CriticalStrike.ToString();
            _heroTenacity.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].Tenacity.ToString();
            _heroPierce.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].Pierce.ToString();
            _heroDefense.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].Defense.ToString();
            _heroActGrow.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].ActGrow.ToString();
            _heroVitalityGrow.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].VitalityGrow.ToString();
            _heroActSpeedGrow.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].ActSpeedGrow.ToString();
            _heroGrowCoefficient.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].GrowCoefficient.ToString();
            _heroActBreakLevel.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].ActBreakLevel.ToString();
            _heroVitalityBreakLevel.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].VitalityBreakLevel.ToString();
            _heroBaseStrikeDamage.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].BaseStrikeDamage.ToString();
            _heroTowerActFrequency.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].TowerActFrequency.ToString();
            _heroSkillConfigID.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].SkillConfigID.ToString();
            _heroExclusiveEquipID.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].ExclusiveEquipID.ToString();
            _heroByConfigID1.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].ByConfigID1.ToString();
            _heroByConfigID2.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].ByConfigID2.ToString();
            _heroByConfigID3.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].ByConfigID3.ToString();
            _heroByConfigID4.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].ByConfigID4.ToString();
            _heroMessageConfigID.gameObject.GetComponent<InputField>().text = heroData[(i + 1)].MessageConfigID.ToString();
        }
    }
	// Update is called once per frame
	void Update () {
		
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
        if (!DataManage.HeroJsonData.IsArray)
        {
            return;
        }

        for (int i = 0; i < DataManage.HeroJsonData.Count;i++)
        {
            OnAdd();
            _heroID = transform.Find("Viewport/Content/obj" + Length + "/HeroID").GetComponent<Text>();
            _heroQuality = transform.Find("Viewport/Content/obj" + Length + "/HeroQuality").GetComponent<Dropdown>();
            _ATKType = transform.Find("Viewport/Content/obj" + Length + "/ATKType").GetComponent<Dropdown>();
            _heroType = transform.Find("Viewport/Content/obj" + Length+ "/HeroType").GetComponent<Dropdown>();
            _heroStarID = transform.Find("Viewport/Content/obj" + Length + "/HeroStarID").GetComponent<Text>();
            _heroFighting = transform.Find("Viewport/Content/obj" + Length + "/HeroFighting").GetComponent<Text>();
            _heroExponentBit = transform.Find("Viewport/Content/obj" + Length+ "/HeroExponentBit").GetComponent<Text>();
            _heroLevel = transform.Find("Viewport/Content/obj" + Length + "/HeroLevel").GetComponent<Text>();
            _heroVitality = transform.Find("Viewport/Content/obj" + Length + "/HeroVitality").GetComponent<Text>();
            _heroAttack = transform.Find("Viewport/Content/obj" + Length + "/HeroAttack").GetComponent<Text>();
            _heroAttackSpeed = transform.Find("Viewport/Content/obj" + Length + "/HeroAttackSpeed").GetComponent<Text>();
            _heroSkill = transform.Find("Viewport/Content/obj" + Length + "/HeroSkill").GetComponent<Text>();
            _heroHitRate = transform.Find("Viewport/Content/obj" + Length + "/HeroHitRate").GetComponent<Text>();
            _heroDodge = transform.Find("Viewport/Content/obj" + Length + "/HeroDodge").GetComponent<Text>();
            _heroCriticalStrike = transform.Find("Viewport/Content/obj" + Length + "/HeroCriticalStrike").GetComponent<Text>();
            _heroTenacity = transform.Find("Viewport/Content/obj" + Length + "/HeroTenacity").GetComponent<Text>();
            _heroPierce = transform.Find("Viewport/Content/obj" + Length + "/HeroPierce").GetComponent<Text>();
            _heroDefense = transform.Find("Viewport/Content/obj" + Length + "/HeroDefense").GetComponent<Text>();
            _heroActGrow = transform.Find("Viewport/Content/obj" + Length + "/HeroActGrow").GetComponent<Text>();
            _heroVitalityGrow = transform.Find("Viewport/Content/obj" + Length + "/HeroVitalityGrow").GetComponent<Text>();
            _heroActSpeedGrow = transform.Find("Viewport/Content/obj" + Length + "/HeroActSpeedGrow").GetComponent<Text>();
            _heroGrowCoefficient = transform.Find("Viewport/Content/obj" + Length + "/HeroGrowCoefficient").GetComponent<Text>();
            _heroActBreakLevel = transform.Find("Viewport/Content/obj" + Length + "/HeroActBreakLevel").GetComponent<Text>();
            _heroVitalityBreakLevel = transform.Find("Viewport/Content/obj" + Length + "/HeroVitalityBreakLevel").GetComponent<Text>();
            _heroBaseStrikeDamage = transform.Find("Viewport/Content/obj" + Length + "/HeroBaseStrikeDamage").GetComponent<Text>();
            _heroTowerActFrequency = transform.Find("Viewport/Content/obj" + Length + "/HeroTowerActFrequency").GetComponent<Text>();
            _heroSkillConfigID = transform.Find("Viewport/Content/obj" + Length + "/HeroSkillConfigID").GetComponent<Text>();
            _heroExclusiveEquipID = transform.Find("Viewport/Content/obj" + Length + "/HeroExclusiveEquipID").GetComponent<Text>();
            _heroByConfigID1 = transform.Find("Viewport/Content/obj" + Length + "/HeroByConfigID1").GetComponent<Text>();
            _heroByConfigID2 = transform.Find("Viewport/Content/obj" + Length + "/HeroByConfigID2").GetComponent<Text>();
            _heroByConfigID3 = transform.Find("Viewport/Content/obj" + Length + "/HeroByConfigID3").GetComponent<Text>();
            _heroByConfigID4 = transform.Find("Viewport/Content/obj" + Length + "/HeroByConfigID4").GetComponent<Text>();
            _heroMessageConfigID = transform.Find("Viewport/Content/obj" + Length + "/HeroMessageConfigID").GetComponent<Text>();

            heroData[Length].ID = DataManage.HeroJsonData[i]["Id"].ToInt32();
            heroData[Length].StarID = DataManage.HeroJsonData[i]["StarId"].ToInt32();
            //heroData[Length].Quality =(C_HeroData.HeroQuality)DataManage.HeroJsonData[i]["Quality"].ToInt32();
            heroData[Length].ATKType = DataManage.HeroJsonData[i]["ATKType"].ToInt32();
            heroData[Length].Type =(C_HeroData.HeroType)DataManage.HeroJsonData[i]["Type"].ToInt32();
            heroData[Length].Fighting = DataManage.HeroJsonData[i]["Fighting"].ToInt32();
            heroData[Length].ExponentBit =DataManage.HeroJsonData[i]["ExponentBit"].ToInt32();
            heroData[Length].Level = DataManage.HeroJsonData[i]["Level"].ToInt32();
            heroData[Length].Vitality = DataManage.HeroJsonData[i]["Vitality"].ToInt32();
            heroData[Length].Attack = DataManage.HeroJsonData[i]["ATK"].ToInt32();
            heroData[Length].AttackSpeed = DataManage.HeroJsonData[i]["ATKSpeed"].ToInt32();
            heroData[Length].Skill = DataManage.HeroJsonData[i]["Skill"].ToInt32();
            heroData[Length].HitRate = DataManage.HeroJsonData[i]["HitRate"].ToInt32();
            heroData[Length].Dodge = DataManage.HeroJsonData[i]["Dodge"].ToInt32();
            heroData[Length].CriticalStrike = DataManage.HeroJsonData[i]["CriticalStrike"].ToInt32();
            heroData[Length].Tenacity = DataManage.HeroJsonData[i]["Tenacity"].ToInt32();
            heroData[Length].Pierce = DataManage.HeroJsonData[i]["Pierce"].ToInt32();
            heroData[Length].Defense = DataManage.HeroJsonData[i]["Defense"].ToInt32();
            heroData[Length].ActGrow = DataManage.HeroJsonData[i]["ATKGrow"].ToInt32();
            heroData[Length].VitalityGrow = DataManage.HeroJsonData[i]["VitalityGrow"].ToInt32();
            heroData[Length].ActSpeedGrow = DataManage.HeroJsonData[i]["ATKSpeedGrow"].ToInt32();
            heroData[Length].GrowCoefficient = DataManage.HeroJsonData[i]["GrowCoefficient"].ToInt32();
            heroData[Length].ActBreakLevel = DataManage.HeroJsonData[i]["ATKBreakLevel"].ToInt32();
            heroData[Length].VitalityBreakLevel = DataManage.HeroJsonData[i]["VitalityBreakLevel"].ToInt32();
            heroData[Length].BaseStrikeDamage = DataManage.HeroJsonData[i]["BaseStrikeDamage"].ToInt32();
            heroData[Length].TowerActFrequency = DataManage.HeroJsonData[i]["TowerATKFrequency"].ToInt32();
            heroData[Length].SkillConfigID = DataManage.HeroJsonData[i]["SkillConfigId"].ToInt32();
            heroData[Length].ExclusiveEquipID = DataManage.HeroJsonData[i]["ExclusiveEquipId"].ToInt32();
            heroData[Length].ByConfigID1 = DataManage.HeroJsonData[i]["ByConfigId1"].ToInt32();
            heroData[Length].ByConfigID2 = DataManage.HeroJsonData[i]["ByConfigId2"].ToInt32();
            heroData[Length].ByConfigID3 = DataManage.HeroJsonData[i]["ByConfigId3"].ToInt32();
            heroData[Length].ByConfigID4 = DataManage.HeroJsonData[i]["ByConfigId4"].ToInt32();
            heroData[Length].MessageConfigID = DataManage.HeroJsonData[i]["MessageConfigId"].ToInt32();
            heroData[Length].IsJson = true;

            print("DataManage=" + DataManage.HeroJsonData.Count);
            _heroID.gameObject.GetComponent<InputField>().text= heroData[Length].ID.ToString();
            _ATKType.gameObject.GetComponent<Dropdown>().value =  heroData[Length].ATKType;
            _heroQuality.value = (int)heroData[Length].Quality-1;
            _heroType.value = (int)heroData[Length].Type-1;
            _heroStarID.gameObject.GetComponent<InputField>().text = heroData[Length].StarID.ToString();
            _heroFighting.gameObject.GetComponent<InputField>().text = heroData[Length].Fighting.ToString();
            _heroExponentBit.gameObject.GetComponent<InputField>().text = heroData[Length].ExponentBit.ToString();
            _heroLevel.gameObject.GetComponent<InputField>().text = heroData[Length].Level.ToString();
            _heroVitality.gameObject.GetComponent<InputField>().text =heroData[Length].Vitality.ToString();
            _heroAttack.gameObject.GetComponent<InputField>().text = heroData[Length].Attack.ToString();
            _heroAttackSpeed.gameObject.GetComponent<InputField>().text =heroData[Length].AttackSpeed.ToString();
            _heroSkill.gameObject.GetComponent<InputField>().text = heroData[Length].Skill.ToString();
            _heroHitRate.gameObject.GetComponent<InputField>().text = heroData[Length].HitRate.ToString();
            _heroDodge.gameObject.GetComponent<InputField>().text= heroData[Length].Dodge.ToString();
            _heroCriticalStrike.gameObject.GetComponent<InputField>().text = heroData[Length].CriticalStrike.ToString();
            _heroTenacity.gameObject.GetComponent<InputField>().text = heroData[Length].Tenacity.ToString();
            _heroPierce.gameObject.GetComponent<InputField>().text = heroData[Length].Pierce.ToString();
            _heroDefense.gameObject.GetComponent<InputField>().text = heroData[Length].Defense.ToString();
            _heroActGrow.gameObject.GetComponent<InputField>().text = heroData[Length].ActGrow.ToString();
            _heroVitalityGrow.gameObject.GetComponent<InputField>().text = heroData[Length].VitalityGrow.ToString();
            _heroActSpeedGrow.gameObject.GetComponent<InputField>().text = heroData[Length].ActSpeedGrow.ToString();
            _heroGrowCoefficient.gameObject.GetComponent<InputField>().text= heroData[Length].GrowCoefficient.ToString();
            _heroActBreakLevel.gameObject.GetComponent<InputField>().text = heroData[Length].ActBreakLevel.ToString();
            _heroVitalityBreakLevel.gameObject.GetComponent<InputField>().text = heroData[Length].VitalityBreakLevel.ToString();
            _heroBaseStrikeDamage.gameObject.GetComponent<InputField>().text = heroData[Length].BaseStrikeDamage.ToString();
            _heroTowerActFrequency.gameObject.GetComponent<InputField>().text = heroData[Length].TowerActFrequency.ToString();
            _heroSkillConfigID.gameObject.GetComponent<InputField>().text = heroData[Length].SkillConfigID.ToString();
            _heroExclusiveEquipID.gameObject.GetComponent<InputField>().text = heroData[Length].ExclusiveEquipID.ToString();
            _heroByConfigID1.gameObject.GetComponent<InputField>().text = heroData[Length].ByConfigID1.ToString();
            _heroByConfigID2.gameObject.GetComponent<InputField>().text = heroData[Length].ByConfigID2.ToString();
            _heroByConfigID3.gameObject.GetComponent<InputField>().text = heroData[Length].ByConfigID3.ToString();
            _heroByConfigID4.gameObject.GetComponent<InputField>().text = heroData[Length].ByConfigID4.ToString();
            _heroMessageConfigID.gameObject.GetComponent<InputField>().text = heroData[Length].MessageConfigID.ToString();
        }
    }

    public void Save(int ID)
    {
        _heroID = transform.Find("Viewport/Content/obj" + ID+"/HeroID").GetComponent<Text>();
        _heroQuality = transform.Find("Viewport/Content/obj" + ID + "/HeroQuality").GetComponent<Dropdown>();
        _heroType = transform.Find("Viewport/Content/obj" + ID + "/HeroType").GetComponent<Dropdown>();
        _ATKType = transform.Find("Viewport/Content/obj" + ID + "/ATKType").GetComponent<Dropdown>();
        _heroStarID = transform.Find("Viewport/Content/obj" + ID + "/HeroStarID").GetComponent<Text>();
        _heroFighting = transform.Find("Viewport/Content/obj" + ID + "/HeroFighting").GetComponent<Text>();
        _heroExponentBit = transform.Find("Viewport/Content/obj" + ID + "/HeroExponentBit").GetComponent<Text>();
        _heroLevel = transform.Find("Viewport/Content/obj" + ID + "/HeroLevel").GetComponent<Text>();
        _heroVitality = transform.Find("Viewport/Content/obj" + ID + "/HeroVitality").GetComponent<Text>();
        _heroAttack = transform.Find("Viewport/Content/obj" + ID + "/HeroAttack").GetComponent<Text>();
        _heroAttackSpeed = transform.Find("Viewport/Content/obj" + ID + "/HeroAttackSpeed").GetComponent<Text>();
        _heroSkill = transform.Find("Viewport/Content/obj" + ID + "/HeroSkill").GetComponent<Text>();
        _heroHitRate = transform.Find("Viewport/Content/obj" + ID + "/HeroHitRate").GetComponent<Text>(); 
        _heroDodge = transform.Find("Viewport/Content/obj" + ID + "/HeroDodge").GetComponent<Text>(); 
        _heroCriticalStrike = transform.Find("Viewport/Content/obj" + ID + "/HeroCriticalStrike").GetComponent<Text>();
        _heroTenacity = transform.Find("Viewport/Content/obj" + ID + "/HeroTenacity").GetComponent<Text>();
        _heroPierce = transform.Find("Viewport/Content/obj" + ID + "/HeroPierce").GetComponent<Text>();
        _heroDefense = transform.Find("Viewport/Content/obj" + ID + "/HeroDefense").GetComponent<Text>();
        _heroActGrow = transform.Find("Viewport/Content/obj" + ID + "/HeroActGrow").GetComponent<Text>();
        _heroVitalityGrow = transform.Find("Viewport/Content/obj" + ID + "/HeroVitalityGrow").GetComponent<Text>();
        _heroActSpeedGrow = transform.Find("Viewport/Content/obj" + ID + "/HeroActSpeedGrow").GetComponent<Text>();
        _heroGrowCoefficient = transform.Find("Viewport/Content/obj" + ID + "/HeroGrowCoefficient").GetComponent<Text>();
        _heroActBreakLevel = transform.Find("Viewport/Content/obj" + ID + "/HeroActBreakLevel").GetComponent<Text>();
        _heroVitalityBreakLevel= transform.Find("Viewport/Content/obj" + ID + "/HeroVitalityBreakLevel").GetComponent<Text>();
        _heroBaseStrikeDamage = transform.Find("Viewport/Content/obj" + ID + "/HeroBaseStrikeDamage").GetComponent<Text>();
        _heroTowerActFrequency = transform.Find("Viewport/Content/obj" + ID + "/HeroTowerActFrequency").GetComponent<Text>();
        _heroSkillConfigID = transform.Find("Viewport/Content/obj" + ID + "/HeroSkillConfigID").GetComponent<Text>();
        _heroExclusiveEquipID = transform.Find("Viewport/Content/obj" + ID + "/HeroExclusiveEquipID").GetComponent<Text>();
        _heroByConfigID1 = transform.Find("Viewport/Content/obj" + ID + "/HeroByConfigID1").GetComponent<Text>();
        _heroByConfigID2 = transform.Find("Viewport/Content/obj" + ID + "/HeroByConfigID2").GetComponent<Text>();
        _heroByConfigID3 = transform.Find("Viewport/Content/obj" + ID + "/HeroByConfigID3").GetComponent<Text>();
        _heroByConfigID4 = transform.Find("Viewport/Content/obj" + ID + "/HeroByConfigID4").GetComponent<Text>();
        _heroMessageConfigID = transform.Find("Viewport/Content/obj" + ID + "/HeroMessageConfigID").GetComponent<Text>();

        try
        {
        heroData[ID].ID = int.Parse(_heroID.text);
        switch(_heroQuality.value)
        {
            case 0:
                    heroData[ID].Quality = C_HeroData.HeroQuality.E;
                break;
            case 1:
                    heroData[ID].Quality = C_HeroData.HeroQuality.N;
                break;
            case 2:
                    heroData[ID].Quality = C_HeroData.HeroQuality.R;
                break;
            case 3:
                    heroData[ID].Quality = C_HeroData.HeroQuality.SR;
                break;
            case 4:
                    heroData[ID].Quality = C_HeroData.HeroQuality.SSR;
                break;
            case 5:
                heroData[ID].Quality = C_HeroData.HeroQuality.UR;
                break;
                
            default:
                print("选择的品质" + _heroQuality.value);
                break;
        }

        switch (_heroType.value)
        {
            case 0:
                heroData[ID].Type = C_HeroData.HeroType.warrior;
                break;
            case 1:
                heroData[ID].Type = C_HeroData.HeroType.tank;
                break;
            case 2:
                heroData[ID].Type = C_HeroData.HeroType.assassin;
                break;
            case 3:
                heroData[ID].Type = C_HeroData.HeroType.mage;
                break;
            case 4:
                heroData[ID].Type = C_HeroData.HeroType.shooter;
                break;
        }

            heroData[ID].ATKType =_ATKType.value;
            heroData[ID].StarID = int.Parse(_heroStarID.text);
            heroData[ID].Fighting = int.Parse(_heroFighting.text);
            heroData[ID].ExponentBit = int.Parse(_heroExponentBit.text);
            heroData[ID].Level = int.Parse(_heroLevel.text);
            heroData[ID].Vitality = int.Parse(_heroVitality.text);
            heroData[ID].Attack = int.Parse(_heroAttack.text);
            heroData[ID].AttackSpeed = int.Parse(_heroAttackSpeed.text);
            heroData[ID].Skill = int.Parse(_heroSkill.text);
            heroData[ID].HitRate = int.Parse(_heroHitRate.text);
            heroData[ID].Dodge = int.Parse(_heroDodge.text);
            heroData[ID].CriticalStrike = int.Parse(_heroCriticalStrike.text);
            heroData[ID].Tenacity = int.Parse(_heroTenacity.text);
            heroData[ID].Pierce = int.Parse(_heroPierce.text);
            heroData[ID].Defense = int.Parse(_heroDefense.text);
            heroData[ID].ActGrow = int.Parse(_heroActGrow.text);
            heroData[ID].VitalityGrow = int.Parse(_heroVitalityGrow.text);
            heroData[ID].ActSpeedGrow = int.Parse(_heroActSpeedGrow.text);
            heroData[ID].GrowCoefficient = int.Parse(_heroGrowCoefficient.text);
            heroData[ID].ActBreakLevel = int.Parse(_heroActBreakLevel.text);
            heroData[ID].VitalityBreakLevel = int.Parse(_heroVitalityBreakLevel.text);
            heroData[ID].BaseStrikeDamage = int.Parse(_heroBaseStrikeDamage.text);
            heroData[ID].TowerActFrequency = int.Parse(_heroTowerActFrequency.text);
            heroData[ID].SkillConfigID = int.Parse(_heroSkillConfigID.text);
            heroData[ID].ExclusiveEquipID = int.Parse(_heroExclusiveEquipID.text);
            heroData[ID].ByConfigID1 = int.Parse(_heroByConfigID1.text);
            heroData[ID].ByConfigID2 = int.Parse(_heroByConfigID2.text);
            heroData[ID].ByConfigID3 = int.Parse(_heroByConfigID3.text);
            heroData[ID].ByConfigID4 = int.Parse(_heroByConfigID4.text);
            heroData[ID].MessageConfigID = int.Parse(_heroMessageConfigID.text);
        }
        catch (Exception ex)
        {
            // 错误处理代码
            WindowControl.SetConsole("保存失败，你填写的数据类型不对,详细：" + ex.Message);
            //transform.parent.Find("Console/Text").GetComponent<Text>().text = "保存失败，你填写的数据类型不对,详细："+ex.Message+"--------------时间："+DateTime.Now.ToString();
            return;
        }

        if (DataManage.HeroDataSave(heroData, ID))
        {
            heroData[ID].IsJson = true;
        }

        //transform.parent.Find("Console/Text").GetComponent<Text>().text = "保存成功-----------------时间"+DateTime.Now.ToString();
             
    }

    public void OnAdd()
    {
        Length += 1;
        GameObject BasicInformationObj=Instantiate(BasicInformation.gameObject, BasicInformation.parent.Find("Content"));
        GameObject TipTitleObj = Instantiate(TipTitle.gameObject,TipTitle.parent.Find("Content"));
        BasicInformationObj.name = "obj" + Length;
        TipTitleObj.name = "obj" + Length;
        TipTitleObj.transform.Find("Operation/Del").GetComponent<DelAssist>().ID = Length;
        transform.Find("Scrollbar Horizontal").GetComponent<Scrollbar>().value = 1;
        //------------数据处理------------------//
        C_HeroData c_heroData=new C_HeroData();
        //heroData[Length-1] = s_heroData;
        //heroData.Add(Length, c_heroData);
        heroData[Length]=(c_heroData);
        //print("集合长度="+heroData.Count);
        _heroID = transform.Find("Viewport/Content/obj" + Length + "/HeroID").GetComponent<Text>();
        _heroQuality = transform.Find("Viewport/Content/obj" + Length + "/HeroQuality").GetComponent<Dropdown>();
        _heroType = transform.Find("Viewport/Content/obj" + Length + "/HeroType").GetComponent<Dropdown>();
        _ATKType = transform.Find("Viewport/Content/obj" + Length + "/ATKType").GetComponent<Dropdown>();
        _heroStarID = transform.Find("Viewport/Content/obj" + Length + "/HeroStarID").GetComponent<Text>();
        _heroFighting = transform.Find("Viewport/Content/obj" + Length + "/HeroFighting").GetComponent<Text>();
        _heroExponentBit = transform.Find("Viewport/Content/obj" + Length + "/HeroExponentBit").GetComponent<Text>();
        _heroLevel = transform.Find("Viewport/Content/obj" + Length+ "/HeroLevel").GetComponent<Text>();
        _heroVitality = transform.Find("Viewport/Content/obj" + Length + "/HeroVitality").GetComponent<Text>();
        _heroAttack = transform.Find("Viewport/Content/obj" + Length + "/HeroAttack").GetComponent<Text>();
        _heroAttackSpeed = transform.Find("Viewport/Content/obj" + Length + "/HeroAttackSpeed").GetComponent<Text>();
        _heroSkill = transform.Find("Viewport/Content/obj" + Length + "/HeroSkill").GetComponent<Text>();
        _heroHitRate = transform.Find("Viewport/Content/obj" + Length + "/HeroHitRate").GetComponent<Text>();
        _heroDodge = transform.Find("Viewport/Content/obj" + Length + "/HeroDodge").GetComponent<Text>();
        _heroCriticalStrike = transform.Find("Viewport/Content/obj" + Length + "/HeroCriticalStrike").GetComponent<Text>();
        _heroTenacity = transform.Find("Viewport/Content/obj" + Length + "/HeroTenacity").GetComponent<Text>();
        _heroPierce = transform.Find("Viewport/Content/obj" + Length + "/HeroPierce").GetComponent<Text>();
        _heroDefense = transform.Find("Viewport/Content/obj" + Length + "/HeroDefense").GetComponent<Text>();
        _heroActGrow = transform.Find("Viewport/Content/obj" + Length + "/HeroActGrow").GetComponent<Text>();
        _heroVitalityGrow = transform.Find("Viewport/Content/obj" + Length + "/HeroVitalityGrow").GetComponent<Text>();
        _heroActSpeedGrow = transform.Find("Viewport/Content/obj" + Length + "/HeroActSpeedGrow").GetComponent<Text>();
        _heroGrowCoefficient = transform.Find("Viewport/Content/obj" + Length + "/HeroGrowCoefficient").GetComponent<Text>();
        _heroActBreakLevel = transform.Find("Viewport/Content/obj" + Length + "/HeroActBreakLevel").GetComponent<Text>();
        _heroVitalityBreakLevel = transform.Find("Viewport/Content/obj" + Length + "/HeroVitalityBreakLevel").GetComponent<Text>();
        _heroBaseStrikeDamage = transform.Find("Viewport/Content/obj" + Length + "/HeroBaseStrikeDamage").GetComponent<Text>();
        _heroTowerActFrequency = transform.Find("Viewport/Content/obj" + Length + "/HeroTowerActFrequency").GetComponent<Text>();
        _heroSkillConfigID = transform.Find("Viewport/Content/obj" + Length + "/HeroSkillConfigID").GetComponent<Text>();
        _heroExclusiveEquipID = transform.Find("Viewport/Content/obj" + Length + "/HeroExclusiveEquipID").GetComponent<Text>();
        _heroByConfigID1 = transform.Find("Viewport/Content/obj" + Length + "/HeroByConfigID1").GetComponent<Text>();
        _heroByConfigID2 = transform.Find("Viewport/Content/obj" + Length + "/HeroByConfigID2").GetComponent<Text>();
        _heroByConfigID3 = transform.Find("Viewport/Content/obj" + Length + "/HeroByConfigID3").GetComponent<Text>();
        _heroByConfigID4 = transform.Find("Viewport/Content/obj" + Length + "/HeroByConfigID4").GetComponent<Text>();
        _heroMessageConfigID = transform.Find("Viewport/Content/obj" + Length + "/HeroMessageConfigID").GetComponent<Text>();

        _heroID.gameObject.GetComponent<InputField>().text = "0";
        _heroQuality.value = 5;
        _ATKType.value = 0;
        _heroType.value = 0;
        _heroStarID.gameObject.GetComponent<InputField>().text = "1";
        _heroFighting.gameObject.GetComponent<InputField>().text = "0";
        _heroExponentBit.gameObject.GetComponent<InputField>().text = "0";
        _heroLevel.gameObject.GetComponent<InputField>().text = "1";
        _heroVitality.gameObject.GetComponent<InputField>().text = "0";
        _heroAttack.gameObject.GetComponent<InputField>().text = "0";
        _heroAttackSpeed.gameObject.GetComponent<InputField>().text = "0";
        _heroSkill.gameObject.GetComponent<InputField>().text = "0";
        _heroHitRate.gameObject.GetComponent<InputField>().text = "0";
        _heroDodge.gameObject.GetComponent<InputField>().text = "0";
        _heroCriticalStrike.gameObject.GetComponent<InputField>().text = "0";
        _heroTenacity.gameObject.GetComponent<InputField>().text = "0";
        _heroPierce.gameObject.GetComponent<InputField>().text = "0";
        _heroDefense.gameObject.GetComponent<InputField>().text = "0";
        _heroActGrow.gameObject.GetComponent<InputField>().text = "0";
        _heroVitalityGrow.gameObject.GetComponent<InputField>().text = "0";
        _heroActSpeedGrow.gameObject.GetComponent<InputField>().text = "0";
        _heroGrowCoefficient.gameObject.GetComponent<InputField>().text = "1";
        _heroActBreakLevel.gameObject.GetComponent<InputField>().text = "1";
        _heroVitalityBreakLevel.gameObject.GetComponent<InputField>().text = "1";
        _heroBaseStrikeDamage.gameObject.GetComponent<InputField>().text = "1";
        _heroTowerActFrequency.gameObject.GetComponent<InputField>().text = "0";
        _heroSkillConfigID.gameObject.GetComponent<InputField>().text = "0";
        _heroExclusiveEquipID.gameObject.GetComponent<InputField>().text = "0";
        _heroByConfigID1.gameObject.GetComponent<InputField>().text = "0";
        _heroByConfigID2.gameObject.GetComponent<InputField>().text = "0";
        _heroByConfigID3.gameObject.GetComponent<InputField>().text = "0";
        _heroByConfigID4.gameObject.GetComponent<InputField>().text = "0";
        _heroMessageConfigID.gameObject.GetComponent<InputField>().text = "0";

    }

    public void Del(int ID)
    {
        if(ID==0)
        {
            return;
        }
        Destroy(transform.Find("Viewport/Content/obj"+ID).gameObject);
        Destroy(transform.Find("TipTitleX/Viewport/Content/obj" + ID).gameObject);

        for (int i = ID + 1; i <= Length;i++)
        {
            transform.Find("TipTitleX/Viewport/Content/obj" + i + "/Operation/Del").GetComponent<DelAssist>().ID = i - 1;
            transform.Find("Viewport/Content/obj" + i).name = "obj" + ( i- 1);
            transform.Find("TipTitleX/Viewport/Content/obj" + i).name = "obj" + (i - 1);
            heroData[ID] = heroData[i]; 

        }
        heroData.Remove(Length);
        print("集合长度=" + heroData.Count);
        Length -= 1;
        DataManage.HeroDataDel(ID);
        WindowControl.SetConsole("删除成功");
        //transform.parent.Find("Console/Text").GetComponent<Text>().text = "删除成功-----------------时间" + DateTime.Now.ToString();
    }

    public void OnDetail(int Id)
    {
        print(Id);
        if(Id>DataManage.HeroJsonData.Count)
        {
            WindowControl.SetConsole("跳转失败，该数据你还没有保存");
            return;
        }else
        {
            transform.parent.Find("Panel").GetComponent<UIDeploy>().OnOrSetToggle("BasicInformation",heroData[Id].ID);
        }
    }

    public void OnResource(int Id)
    {
        if (Id > DataManage.HeroJsonData.Count)
        {
            WindowControl.SetConsole("跳转失败，该数据你还没有保存");
            return;
        }
        else
        {
            transform.parent.Find("Panel").GetComponent<UIDeploy>().OnOrSetToggle("ResourceConfig", heroData[Id].ID);
        }
    }
}
