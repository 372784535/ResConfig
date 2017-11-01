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

    private Transform HeroData;
    private Transform BasicInformation;
    private Transform StarGrow;
	// Use this for initialization
	void Start () {
        HeroDateBtn = transform.Find("HeroDateBtn").GetComponent<Toggle>();
        BasicInformationBtn = transform.Find("BasicInformationBtn").GetComponent<Toggle>();
        StarGrowBtn = transform.Find("StarGrowBtn").GetComponent<Toggle>();
        SkillConfigBtn = transform.Find("SkillConfigBtn").GetComponent<Toggle>();
        TowerDefenseSkillBtn = transform.Find("TowerDefenseSkillBtn").GetComponent<Toggle>();
        CombatSkillsBtn = transform.Find("CombatSkillsBtn").GetComponent<Toggle>();
        TalentSkillsBtn = transform.Find("TalentSkillsBtn").GetComponent<Toggle>();
        AwakeningSkills = transform.Find("AwakeningSkills").GetComponent<Toggle>();
        FetterBtn = transform.Find("FetterBtn").GetComponent<Toggle>();

        HeroData = transform.parent.Find("HeroData");
        BasicInformation = transform.parent.Find("BasicInformation");
        StarGrow =transform.parent.Find("StarGrow");
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

    }

    public void onReChangValue()
    {
        transform.parent.Find("HeroData/Scrollbar Vertical").GetComponent<Scrollbar>().value= transform.parent.Find("HeroData/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("HeroData/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("HeroData/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value;
        transform.parent.Find("SkillConfig/Scrollbar Vertical").GetComponent<Scrollbar>().value = transform.parent.Find("SkillConfig/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("SkillConfig/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("SkillConfig/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value;
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
            }
        }
    }

}
