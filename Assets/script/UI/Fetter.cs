using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fetter : MonoBehaviour
{

    private int Length = 0;

    private InputField _HeroID;
    private InputField _SkillID;

    //private int NeedHeroIDLength = 1;
    private InputField _NeedHeroIDLength;
    private Transform _NeedHeroPlan;
    private InputField _Fetter_HeroId;
    private InputField _Fetter_NeedStars;
    private InputField _Fetter_NeedexponeniBit;

    //private int PropertyAddLength = 1;
    private InputField _PropertyAddLength;
    private Transform _PropertyAddPlan;
    private InputField _PropertyType;
    private InputField _Property;

    public Dictionary<int, C_Frtter> Fetters = new Dictionary<int, C_Frtter>(); 

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
    void Start()
    {

    }

    public void OnAdd()
    {
        Length += 1;
        GameObject BasicInformationObj = Instantiate(BasicInformation.gameObject, BasicInformation.parent.Find("Content"));
        GameObject TipTitleObj = Instantiate(TipTitle.gameObject, TipTitle.parent.Find("Content"));
        BasicInformationObj.name = "obj" + Length;
        TipTitleObj.name = "obj" + Length;
        BasicInformationObj.GetComponent<CommonAssist>().ID=Length;
        TipTitleObj.GetComponent<CommonAssist>().ID = Length;
        transform.Find("Scrollbar Horizontal").GetComponent<Scrollbar>().value = 1;
        //------------数据处理------------------//
        C_Frtter c_frtter = new C_Frtter();
        //heroData[Length-1] = s_heroData;
        //heroData.Add(Length, c_heroData);
        Fetters[Length] = (c_frtter);
        //print("集合长度="+heroData.Count);
        transform.Find("Viewport/Content/obj" + Length + "/HeroID").GetComponent<InputField>().text="0";
        transform.Find("Viewport/Content/obj" + Length + "/FetterID").GetComponent<InputField>().text = "0";
        transform.Find("Viewport/Content/obj" + Length + "/NeedHeroIDLength").GetComponent<InputField>().text = "1";
        transform.Find("Viewport/Content/obj" + Length + "/PropertyAddLength").GetComponent<InputField>().text = "1";
    }

    public void ChangNeedHeroPlan(int Id)
    {
        _NeedHeroIDLength = transform.Find("Viewport/Content/obj" + Id+"/NeedHeroIDLength").GetComponent<InputField>();
        _NeedHeroPlan = transform.Find("Viewport/Content/obj" + Id + "/NeedHeroPlan");
        if(int.Parse(_NeedHeroIDLength.text)<=0||int.Parse(_NeedHeroIDLength.text)>3)
        {
            WindowControl.SetConsole("请输入正确的数量");
            return;
        }
        if (int.Parse(_NeedHeroIDLength.text) < _NeedHeroPlan.childCount)
        {
            for (int i = _NeedHeroPlan.childCount; i > int.Parse(_NeedHeroIDLength.text); i--)
            {
                Transform.Destroy(transform.Find("Viewport/Content/obj" + Id + "/NeedHeroPlan/Hero" + i).gameObject);
            }
        }
        else if (int.Parse(_NeedHeroIDLength.text)>_NeedHeroPlan.childCount)
        {
            while (int.Parse(_NeedHeroIDLength.text) !=_NeedHeroPlan.childCount )
            {
                Transform obj= Instantiate(transform.Find("Viewport/Content/obj" + Id + "/NeedHeroPlan/Hero" + _NeedHeroPlan.childCount),transform.Find("Viewport/Content/obj" + Id + "/NeedHeroPlan"));
                obj.name = "Hero" + _NeedHeroPlan.childCount;

            }
        }
    }

    public void ChangPropertyAddPlan(int Id)
    {
        print("ID="+Id);
        _PropertyAddLength= transform.Find("Viewport/Content/obj" + Id + "/PropertyAddLength").GetComponent<InputField>();
        _PropertyAddPlan = transform.Find("Viewport/Content/obj" + Id + "/PropertyAddPlan");
        if (int.Parse(_PropertyAddLength.text) <= 0||int.Parse(_PropertyAddLength.text)>5)
        {
            WindowControl.SetConsole("请输入正确的数量");
            return;
        }
        if (int.Parse(_PropertyAddLength.text) < _PropertyAddPlan.childCount)
        {
            for (int i = _PropertyAddPlan.childCount; i > int.Parse(_PropertyAddLength.text);i--)
            {
                Transform.Destroy(transform.Find("Viewport/Content/obj" + Id + "/PropertyAddPlan/Property" + i).gameObject);
            }
        }
        else if (int.Parse(_PropertyAddLength.text) > _PropertyAddPlan.childCount)
        {
            while (int.Parse(_PropertyAddLength.text) != _PropertyAddPlan.childCount)
            {
                Transform obj = Instantiate(transform.Find("Viewport/Content/obj" + Id + "/PropertyAddPlan/Property" + _PropertyAddPlan.childCount), transform.Find("Viewport/Content/obj" + Id + "/PropertyAddPlan"));
                obj.name = "Property" + _PropertyAddPlan.childCount;

            }
        }
    }
}
