using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WindowControl : MonoBehaviour {
    public int ID;
    public static string OpenType;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void OpenDelTip(int ID,string type)
    {
        OpenType = type;
        GameObject.Find("Canvas/WindowControl/DelTipWindow").SetActive(true);
        GameObject.Find("Canvas/WindowControl").GetComponent<WindowControl>().ID = ID;
    }

    public static void SetConsole(string meg)
    {
        GameObject.Find("Canvas/Console/Text").GetComponent<Text>().text=meg+"------------------时间："+DateTime.Now.ToString();
    }

    public void OnYes()
    {
        if(ID==0&&OpenType=="HeroData")
        {
            return;
        }
        switch (OpenType)
        {
            case "HeroData":
                GameObject.Find("Canvas/HeroData").GetComponent<HeroData>().Del(ID);
                transform.Find("DelTipWindow").gameObject.SetActive(false);
                break;
            case "BasicInformation":
                DataManage.DelHeroMessage(ID);
                transform.Find("DelTipWindow").gameObject.SetActive(false);
                transform.parent.Find("BasicInformation").GetComponent<BasicInformation>().RemoveUIData();
                break;
            case "StarGrow":
                GameObject.Find("Canvas/StarGrow").GetComponent<StarGrow>().Del(ID);
                transform.Find("DelTipWindow").gameObject.SetActive(false);
                break;
            case "SkillConfig":
                GameObject.Find("Canvas/SkillConfig").GetComponent<SkillConfig>().Del(ID);
                transform.Find("DelTipWindow").gameObject.SetActive(false);
                break;
        }

        
    }
    public void OnNo()
    {
        ID = 0;
        transform.Find("DelTipWindow").gameObject.SetActive(false);
    }
}
