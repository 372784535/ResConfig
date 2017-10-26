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
    private Text _heroByConfigID;
    private Text _heroMessageConfigID;

    Dictionary<int, C_HeroData> heroData = new Dictionary<int, C_HeroData>();

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
        Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init()
    {
        //print("dddd" + DataManage.Data.ToJson());
        if (!DataManage.Data.IsArray)
        {
            return;
        }
        for (int i = 0; i < DataManage.Data.Count;i++)
        {
            OnAdd();
            _heroID = transform.Find("Viewport/Content/obj" + Length + "/HeroID").GetComponent<Text>();
            _heroQuality = transform.Find("Viewport/Content/obj" + Length + "/HeroQuality").GetComponent<Dropdown>();
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
            _heroByConfigID = transform.Find("Viewport/Content/obj" + Length + "/HeroByConfigID").GetComponent<Text>();
            _heroMessageConfigID = transform.Find("Viewport/Content/obj" + Length + "/HeroMessageConfigID").GetComponent<Text>();

            heroData[Length].ID = DataManage.Data[i]["Id"].ToInt32();
            heroData[Length].StarID = DataManage.Data[i]["StarID"].ToInt32();
            heroData[Length].Quality =(C_HeroData.HeroQuality)DataManage.Data[i]["Quality"].ToInt32();
            heroData[Length].Type =(C_HeroData.HeroType)DataManage.Data[i]["Type"].ToInt32();
            heroData[Length].Fighting = DataManage.Data[i]["Fighting"].ToInt32();
            heroData[Length].ExponentBit =DataManage.Data[i]["ExponentBit"].ToInt32();
            heroData[Length].Level = DataManage.Data[i]["Level"].ToInt32();
            heroData[Length].Vitality = DataManage.Data[i]["Vitality"].ToInt32();
            heroData[Length].Attack = DataManage.Data[i]["Attack"].ToInt32();
            heroData[Length].AttackSpeed = DataManage.Data[i]["AttackSpeed"].ToInt32();
            heroData[Length].Skill = DataManage.Data[i]["Skill"].ToInt32();
            heroData[Length].HitRate = DataManage.Data[i]["HitRate"].ToInt32();
            heroData[Length].Dodge = DataManage.Data[i]["Dodge"].ToInt32();
            heroData[Length].CriticalStrike = DataManage.Data[i]["CriticalStrike"].ToInt32();
            heroData[Length].Tenacity = DataManage.Data[i]["Tenacity"].ToInt32();
            heroData[Length].Pierce = DataManage.Data[i]["Pierce"].ToInt32();
            heroData[Length].Defense = DataManage.Data[i]["Defense"].ToInt32();
            heroData[Length].ActGrow = DataManage.Data[i]["ActGrow"].ToInt32();
            heroData[Length].VitalityGrow = DataManage.Data[i]["VitalityGrow"].ToInt32();
            heroData[Length].ActSpeedGrow = DataManage.Data[i]["ActSpeedGrow"].ToInt32();
            heroData[Length].GrowCoefficient = DataManage.Data[i]["GrowCoefficient"].ToInt32();
            heroData[Length].ActBreakLevel = DataManage.Data[i]["ActBreakLevel"].ToInt32();
            heroData[Length].VitalityBreakLevel = DataManage.Data[i]["VitalityBreakLevel"].ToInt32();
            heroData[Length].BaseStrikeDamage = DataManage.Data[i]["BaseStrikeDamage"].ToInt32();
            heroData[Length].TowerActFrequency = DataManage.Data[i]["TowerActFrequency"].ToInt32();
            heroData[Length].SkillConfigID = DataManage.Data[i]["SkillConfigID"].ToInt32();
            heroData[Length].ExclusiveEquipID = DataManage.Data[i]["ExclusiveEquipID"].ToInt32();
            heroData[Length].ByConfigID = DataManage.Data[i]["ByConfigID"].ToInt32();
            heroData[Length].MessageConfigID = DataManage.Data[i]["MessageConfigID"].ToInt32();
            heroData[Length].IsJson = true;

            _heroID.gameObject.GetComponent<InputField>().text= heroData[Length].ID.ToString();
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
            _heroExclusiveEquipID.gameObject.GetComponent<InputField>().text = heroData[Length].ID.ToString();
            _heroByConfigID.gameObject.GetComponent<InputField>().text = heroData[Length].ByConfigID.ToString();
            _heroMessageConfigID.gameObject.GetComponent<InputField>().text = heroData[Length].MessageConfigID.ToString();
        }
    }

    public void Save(int ID)
    {
        _heroID = transform.Find("Viewport/Content/obj" + ID+"/HeroID").GetComponent<Text>();
        _heroQuality = transform.Find("Viewport/Content/obj" + ID + "/HeroQuality").GetComponent<Dropdown>();
        _heroType = transform.Find("Viewport/Content/obj" + ID + "/HeroType").GetComponent<Dropdown>();
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
        _heroByConfigID = transform.Find("Viewport/Content/obj" + ID + "/HeroByConfigID").GetComponent<Text>();
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
            heroData[ID].ByConfigID = int.Parse(_heroByConfigID.text);
            heroData[ID].MessageConfigID = int.Parse(_heroMessageConfigID.text);
        }
        catch (Exception ex)
        {
            // 错误处理代码
            WindowControl.SetConsole("保存失败，你填写的数据类型不对,详细：" + ex.Message);
            //transform.parent.Find("Console/Text").GetComponent<Text>().text = "保存失败，你填写的数据类型不对,详细："+ex.Message+"--------------时间："+DateTime.Now.ToString();
            return;
        }

        if (DataManage.HeroDataWriting(heroData, ID))
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
        c_heroData.init();
        //heroData[Length-1] = s_heroData;
        heroData[Length]=(c_heroData);
        //print("集合长度="+heroData.Count);
        _heroID = transform.Find("Viewport/Content/obj" + Length + "/HeroID").GetComponent<Text>();
        _heroQuality = transform.Find("Viewport/Content/obj" + Length + "/HeroQuality").GetComponent<Dropdown>();
        _heroType = transform.Find("Viewport/Content/obj" + Length + "/HeroType").GetComponent<Dropdown>();
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
        _heroByConfigID = transform.Find("Viewport/Content/obj" + Length + "/HeroByConfigID").GetComponent<Text>();
        _heroMessageConfigID = transform.Find("Viewport/Content/obj" + Length + "/HeroMessageConfigID").GetComponent<Text>();

        _heroID.gameObject.GetComponent<InputField>().text = "0";
        _heroQuality.value = 5;
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
        _heroByConfigID.gameObject.GetComponent<InputField>().text = "0";
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
}
