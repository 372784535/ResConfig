using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDeploy : MonoBehaviour {
    private Toggle HeroDateBtn;
    private Toggle BasicInformationBtn;
    private Toggle StarGrowBtn;
    private Toggle SkillConfigBtn;
    private Toggle TowerDefenseSkillBtn;
    private Toggle CombatSkillsBtn;
    private Toggle TalentSkillsBtn;
    private Toggle AwakeningSkills;
    private Toggle FetterBtn;
    private Toggle TalentSkill_BuffBtn;
    private Toggle TalentStoneConditionBtn;
    private Toggle BreakGrowBtn;
    private Toggle FightSkillBtn;

    private Transform HeroData;
    private Transform BasicInformation;
    private Transform StarGrow;
    private Transform SkillConfig;
    private Transform Fetter;
    private Transform TalentSkill_Buff;
    private Transform TalentSkill;
    private Transform TalentStoneCondition;
    private Transform TowerDefenseSkill;
    private Transform BreakGrow;
    private Transform FightSkill;
    private Transform ResourceConfig;
    // Use this for initialization
    void Start () {
        HeroDateBtn = transform.Find("HeroDateBtn").GetComponent<Toggle>();
        BasicInformationBtn = transform.Find("BasicInformationBtn").GetComponent<Toggle>();
        StarGrowBtn = transform.Find("StarGrowBtn").GetComponent<Toggle>();
        SkillConfigBtn = transform.Find("SkillConfigBtn").GetComponent<Toggle>();
        TowerDefenseSkillBtn = transform.Find("TowerDefenseSkillBtn").GetComponent<Toggle>();
        TalentSkillsBtn = transform.Find("TalentSkillsBtn").GetComponent<Toggle>();
        AwakeningSkills = transform.Find("AwakeningSkills").GetComponent<Toggle>();
        FetterBtn = transform.Find("FetterBtn").GetComponent<Toggle>();
        TalentSkill_BuffBtn = transform.Find("TalentSkill_BuffBtn").GetComponent<Toggle>();
        TalentStoneConditionBtn = transform.Find("TalentStoneConditionBtn").GetComponent<Toggle>();
        BreakGrowBtn = transform.Find("BreakGrowBtn").GetComponent<Toggle>();
        FightSkillBtn = transform.Find("FightSkillBtn").GetComponent<Toggle>();

        HeroData = transform.parent.Find("HeroData");
        BasicInformation = transform.parent.Find("BasicInformation");
        StarGrow =transform.parent.Find("StarGrow");
        SkillConfig = transform.parent.Find("SkillConfig");
        Fetter = transform.parent.Find("Fetter");
        TalentSkill_Buff = transform.parent.Find("TalentSkill_Buff");
        TalentSkill = transform.parent.Find("TalentSkill");
        TalentStoneCondition = transform.parent.Find("TalentStoneCondition");
        TowerDefenseSkill = transform.parent.Find("TowerDefenseSkill");
        BreakGrow = transform.parent.Find("BreakGrow");
        FightSkill = transform.parent.Find("FightSkill");
        ResourceConfig = transform.parent.Find("ResourceConfig");
    }
	
	// Update is called once per frame
	void Update () {
        //gameObject.GetComponent<Scrollbar>().value ;
	}

    public void onChangValue()
    {
        transform.parent.Find("HeroData/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value=transform.parent.Find("HeroData/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("HeroData/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("HeroData/Scrollbar Horizontal").GetComponent<Scrollbar>().value;
        transform.parent.Find("SkillConfig/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value = transform.parent.Find("SkillConfig/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("SkillConfig/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("SkillConfig/Scrollbar Horizontal").GetComponent<Scrollbar>().value;
        transform.parent.Find("Fetter/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value = transform.parent.Find("Fetter/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("Fetter/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("Fetter/Scrollbar Horizontal").GetComponent<Scrollbar>().value;
        transform.parent.Find("TalentStoneCondition/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value = transform.parent.Find("TalentStoneCondition/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("TalentStoneCondition/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("TalentStoneCondition/Scrollbar Horizontal").GetComponent<Scrollbar>().value;
        transform.parent.Find("TowerDefenseSkill/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value = transform.parent.Find("TowerDefenseSkill/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("TowerDefenseSkill/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("TowerDefenseSkill/Scrollbar Horizontal").GetComponent<Scrollbar>().value;
        transform.parent.Find("FightSkill/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value = transform.parent.Find("FightSkill/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("FightSkill/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("FightSkill/Scrollbar Horizontal").GetComponent<Scrollbar>().value;
    }

    public void onReChangValue()
    {
        transform.parent.Find("HeroData/Scrollbar Vertical").GetComponent<Scrollbar>().value= transform.parent.Find("HeroData/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("HeroData/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("HeroData/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value;
        transform.parent.Find("SkillConfig/Scrollbar Vertical").GetComponent<Scrollbar>().value = transform.parent.Find("SkillConfig/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("SkillConfig/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("SkillConfig/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value;
        transform.parent.Find("Fetter/Scrollbar Vertical").GetComponent<Scrollbar>().value = transform.parent.Find("Fetter/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("Fetter/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("Fetter/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value;
        transform.parent.Find("TalentStoneCondition/Scrollbar Vertical").GetComponent<Scrollbar>().value = transform.parent.Find("TalentStoneCondition/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("TalentStoneCondition/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("TalentStoneCondition/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value;
        transform.parent.Find("TowerDefenseSkill/Scrollbar Vertical").GetComponent<Scrollbar>().value = transform.parent.Find("TowerDefenseSkill/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("TowerDefenseSkill/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("TowerDefenseSkill/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value;
        transform.parent.Find("FightSkill/Scrollbar Vertical").GetComponent<Scrollbar>().value = transform.parent.Find("FightSkill/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("FightSkill/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("FightSkill/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value;
    }
    public void OnToggle()
    {
        OnOrSetToggle();
    }


    public void OnOrSetToggle(string target="",int ID=-1)
    {
        if(target=="")
        {
            HeroData.gameObject.SetActive(HeroDateBtn.isOn);
            BasicInformation.gameObject.SetActive(BasicInformationBtn.isOn);
            StarGrow.gameObject.SetActive(StarGrowBtn.isOn);
            SkillConfig.gameObject.SetActive(SkillConfigBtn.isOn);
            Fetter.gameObject.SetActive(FetterBtn.isOn);
            TalentSkill_Buff.gameObject.SetActive(TalentSkill_BuffBtn.isOn);
            TalentSkill.gameObject.SetActive(TalentSkillsBtn.isOn);
            TalentStoneCondition.gameObject.SetActive(TalentStoneConditionBtn.isOn);
            TowerDefenseSkill.gameObject.SetActive(TowerDefenseSkillBtn.isOn);
            BreakGrow.gameObject.SetActive(BreakGrowBtn.isOn);
            FightSkill.gameObject.SetActive(FightSkillBtn.isOn);
            ResourceConfig.gameObject.SetActive(false);
        }
        else
        {
            switch (target)
            {
                case "HeroData":
                    
                    for (int i = 0;i < transform.GetComponentsInChildren<Toggle>().Length;i++)
                    {
                        if (transform.GetComponentsInChildren<Toggle>()[i].gameObject.name == "HeroData")
                        {
                            transform.GetComponentsInChildren<Toggle>()[i].isOn = true;
                        }else
                        {
                            transform.GetComponentsInChildren<Toggle>()[i].isOn = false;
                        }
                    }
                    OnOrSetToggle();
                    break;
                case "BasicInformation":
                    for (int i = 0; i < transform.GetComponentsInChildren<Toggle>().Length; i++)
                    {
                        if (transform.GetComponentsInChildren<Toggle>()[i].gameObject.name == "BasicInformationBtn")
                        {
                            transform.GetComponentsInChildren<Toggle>()[i].isOn = true;
                        }
                        else
                        {
                            transform.GetComponentsInChildren<Toggle>()[i].isOn = false;
                        }
                    }
                    OnOrSetToggle("");
                    BasicInformation.GetComponent<BasicInformation>().SearchInit(ID);
                    //WindowControl.SetConsole("基本信息存在，赶快修改并保存。*_*");
                    break;
                case "StarGrow":
                    for (int i = 0; i < transform.GetComponentsInChildren<Toggle>().Length; i++)
                    {
                        if (transform.GetComponentsInChildren<Toggle>()[i].gameObject.name == "StarGrow")
                        {
                            transform.GetComponentsInChildren<Toggle>()[i].isOn = true;
                        }
                        else
                        {
                            transform.GetComponentsInChildren<Toggle>()[i].isOn = false;
                        }
                    }
                    OnOrSetToggle();
                    break;
                case "ResourceConfig":
                    for (int i = 0; i < transform.GetComponentsInChildren<Toggle>().Length; i++)
                    {
                        transform.GetComponentsInChildren<Toggle>()[i].isOn = false;
                    }
                    this.HeroData.gameObject.SetActive(false);
                    ResourceConfig.gameObject.SetActive(true);
                    ResourceConfig.gameObject.GetComponent<ResourceConfig>().InitHero(ID);
                    break;
            }
        }
    }

}
