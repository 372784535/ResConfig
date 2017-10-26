using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System;

public class BasicInformation : MonoBehaviour {
    int opIndex = -1;
    public C_HeroMessage heroMessage = new C_HeroMessage();

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


	// Use this for initialization
	void Start () {
        UIInit();
	}

    void UIInit()
    {
        HeroID = transform.Find("Top").GetComponent<InputField>();
        InfoId = transform.Find("InfoId").GetComponent<InputField>();
        Name = transform.Find("Name").GetComponent<InputField>();
        Nickname = transform.Find("Nickname").GetComponent<InputField>();
        Sex = transform.Find("Sex").GetComponent<Dropdown>();
        Camp = transform.Find("Camp").GetComponent<Dropdown>();
        StoryBG = transform.Find("StoryBG").GetComponent<InputField>();
        TowerDD = transform.Find("TowerDD").GetComponent<InputField>();
        FightD = transform.Find("FightD").GetComponent<InputField>();
        Tip = transform.Find("Top/Tip").GetComponent<Text>();

        DataDynamiticTest = transform.Find("DataDynamiticTest");
    }
	
    public bool SearchInit(long Id)
    {
        JsonData CorresJson = null;
        //--------------------检测信息数据-----------------
        if(DataManage.BasicInfoJsonData.IsArray)
        {
            for (int i = 0; i < DataManage.BasicInfoJsonData.Count;i++)
            {
                if(DataManage.BasicInfoJsonData[i]["InfoId"].ToInt64()==Id)
                {
                    CorresJson = DataManage.BasicInfoJsonData[i];
                    break;
                }
                if (DataManage.BasicInfoJsonData[i]["HeroId"].ToInt64() == Id)
                {
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
            Camp.value = CorresJson["Nickname"].ToInt32();
            StoryBG.text = CorresJson["Backstory"].ToString();
            TowerDD.text = CorresJson["TowerDefenceDefinite"].ToString();
            FightD.text = CorresJson["FightDefinite"].ToString();
        }
        //----------------------检测英雄数据---------------------
        if(DataManage.HeroJsonData.IsArray)
        {
            print("ID" + DataManage.HeroJsonData[0]["Id"].ToInt64());
            for (var i = 0; i < DataManage.HeroJsonData.Count;i++)
            {
                if(DataManage.HeroJsonData[i]["Id"].ToInt64()==Id)
                {
                    
                    if(CorresJson==null)
                    {
                        WindowControl.SetConsole("该ID基础信息没有，但是英雄数据存在，请尽快添加库中");
                        CorresJson = DataManage.HeroJsonData[i];
                    }
                    else
                    {
                        CorresJson = DataManage.HeroJsonData[i];                    
                    }
                    DataDynamiticTest.gameObject.SetActive(true);
                    break;

                }
                else if(CorresJson!=null)
                {
                    if(DataManage.HeroJsonData[i]["Id"].ToInt64()==CorresJson["HeroId"].ToInt64())
                    {
                        CorresJson = DataManage.HeroJsonData[i];
                        break;
                    }
                }

                if(i==DataManage.HeroJsonData.Count-1)
                {
                    if (CorresJson == null)
                    {
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
        //************
        return true;
    }

    public void OnBtnFind()
    {
        if(HeroID.text=="")
        {
            WindowControl.SetConsole("查找失败，请输入英雄Id");
            return;
        }
        try
        {
            if(!SearchInit(int.Parse(HeroID.text)))
            {
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
        heroMessage.Name = Name.text;
        heroMessage.Nickname = InfoId.text;
        heroMessage.Sex = Sex.value;
        heroMessage.Camp = (C_HeroMessage.CampType)Camp.value;
        heroMessage.Backstory = StoryBG.text;
        heroMessage.TowerDefenceDefinite = TowerDD.text;
        heroMessage.FightDefinite = FightD.text;

    }

}
