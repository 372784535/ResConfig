using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fetter : MonoBehaviour
{

    private int Length = 0;

    private InputField _HeroID;
    private InputField _FetterID;

    //private int NeedHeroIDLength = 1;
    private InputField _NeedHeroIDLength;
    private Transform _NeedHeroPlan;
    private InputField _Fetter_HeroId;
    private InputField _Fetter_NeedStars;
    private InputField _Fetter_NeedexponeniBit;

    //private int PropertyAddLength = 1;
    private InputField _PropertyAddLength;
    private Transform _PropertyAddPlan;
    private Dropdown _PropertyType;
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
        Init();
    }

    void Init()
    {
        if (!DataManage.FetterJsonData.IsArray)
        {
            return;
        }
        for (int i = 0; i < DataManage.FetterJsonData.Count; i++)
        {
            OnAdd();
            _HeroID =transform.Find("Viewport/Content/obj" + Length + "/HeroID").GetComponent<InputField>();
            _FetterID = transform.Find("Viewport/Content/obj" + Length + "/FetterID").GetComponent<InputField>();
            _NeedHeroIDLength = transform.Find("Viewport/Content/obj" + Length + "/NeedHeroIDLength").GetComponent<InputField>();
            _NeedHeroPlan = transform.Find("Viewport/Content/obj" + Length + "/NeedHeroPlan");
            _PropertyAddLength = transform.Find("Viewport/Content/obj" + Length + "/PropertyAddLength").GetComponent<InputField>();
            _PropertyAddPlan = transform.Find("Viewport/Content/obj" + Length + "/PropertyAddPlan");

            Fetters[Length].FrtterId = DataManage.FetterJsonData[i]["FrtterId"].ToInt32();
            Fetters[Length].HeroID = DataManage.FetterJsonData[i]["HeroID"].ToInt32();
            _NeedHeroIDLength.text = DataManage.FetterJsonData[i]["NeedHeroList"].Count.ToString();
            ChangNeedHeroPlan(Length);
            _PropertyAddLength.text = DataManage.FetterJsonData[i]["propertyAddList"].Count.ToString();
            ChangPropertyAddPlan(Length);
            Fetters[Length].IsJson = true;

            _HeroID.text = Fetters[Length].HeroID.ToString();
            _FetterID.text = Fetters[Length].FrtterId.ToString();
            for (int j = 0; j < _NeedHeroPlan.childCount;j++)
            {
                transform.Find("Viewport/Content/obj" + (i + 1) + "/NeedHeroPlan/Hero" + (j + 1) + "/HeroId").GetComponent<InputField>().text = DataManage.FetterJsonData[i]["NeedHeroList"][j]["HeroId"].ToString();
                transform.Find("Viewport/Content/obj" + (i + 1) + "/NeedHeroPlan/Hero" + (j + 1) + "/NeedStars").GetComponent<InputField>().text = DataManage.FetterJsonData[i]["NeedHeroList"][j]["NeedStars"].ToString();
                transform.Find("Viewport/Content/obj" + (i + 1) + "/NeedHeroPlan/Hero" + (j + 1) + "/NeedexponentBit").GetComponent<InputField>().text = DataManage.FetterJsonData[i]["NeedHeroList"][j]["NeedexponentBit"].ToString();
            }
            for (int j = 0; j < _PropertyAddPlan.childCount;j++)
            {
                transform.Find("Viewport/Content/obj" + (i + 1) + "/PropertyAddPlan/Property" + (j + 1) + "/PropertyType").GetComponent<Dropdown>().value = DataManage.FetterJsonData[i]["propertyAddList"][j]["PropertyType"].ToInt32();
                transform.Find("Viewport/Content/obj" + (i + 1) + "/PropertyAddPlan/Property" + (j + 1) + "/Property").GetComponent<InputField>().text = DataManage.FetterJsonData[i]["propertyAddList"][j]["PropertyAdd"].ToString();
            }

        }
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
        Fetters[Length] = (c_frtter);
        transform.Find("Viewport/Content/obj" + Length + "/HeroID").GetComponent<InputField>().text="0";
        transform.Find("Viewport/Content/obj" + Length + "/FetterID").GetComponent<InputField>().text = "0";
        transform.Find("Viewport/Content/obj" + Length + "/NeedHeroIDLength").GetComponent<InputField>().text = "1";
        transform.Find("Viewport/Content/obj" + Length + "/PropertyAddLength").GetComponent<InputField>().text = "1";
    }

    public void Save(int ID)
    {
        _HeroID = transform.Find("Viewport/Content/obj" + ID + "/HeroID").GetComponent<InputField>();
        _FetterID = transform.Find("Viewport/Content/obj" + ID + "/FetterID").GetComponent<InputField>();
        _NeedHeroPlan = transform.Find("Viewport/Content/obj" + ID + "/NeedHeroPlan");
        _PropertyAddPlan = transform.Find("Viewport/Content/obj" + ID + "/PropertyAddPlan");
        try
        {
            Fetters[ID].HeroID = int.Parse(_HeroID.text);
            Fetters[ID].FrtterId = int.Parse(_FetterID.text);
            for (int i = 0; i < _NeedHeroPlan.childCount; i++)
            {
                Fetters[ID].NeedHeroList.Add(transform.Find("Viewport/Content/obj" + ID + "/NeedHeroPlan/Hero"+(i+1)));
            }
            for (int i = 0; i < _PropertyAddPlan.childCount; i++)
            {
                Fetters[ID].PropertyAddList.Add(transform.Find("Viewport/Content/obj" + ID + "/PropertyAddPlan/Property" + (i + 1)));
            }
        }
        catch (Exception ex)
        {
            // 错误处理代码
            WindowControl.SetConsole("保存失败，你填写的数据类型不对,详细：" + ex.Message);
            //transform.parent.Find("Console/Text").GetComponent<Text>().text = "保存失败，你填写的数据类型不对,详细："+ex.Message+"--------------时间："+DateTime.Now.ToString();
            return;
        }

        if (DataManage.SaveFetterData(Fetters, ID))
        {
            Fetters[ID].IsJson = true;
        }
        Fetters[ID].NeedHeroList.Clear();
        Fetters[ID].PropertyAddList.Clear();
        //transform.parent.Find("Console/Text").GetComponent<Text>().text = "保存成功-----------------时间"+DateTime.Now.ToString();

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
            transform.Find("TipTitleX/Viewport/Content/obj" + i ).GetComponent<CommonAssist>().ID = i - 1;
            transform.Find("Viewport/Content/obj" + i).GetComponent<CommonAssist>().ID = i - 1;
            transform.Find("Viewport/Content/obj" + i).name = "obj" + (i - 1);
            transform.Find("TipTitleX/Viewport/Content/obj" + i).name = "obj" + (i - 1);
            Fetters[ID] = Fetters[i];

        }
        Fetters.Remove(Length);
        print("集合长度=" + Fetters.Count);
        Length -= 1;
        DataManage.DelFetterData(ID);
        WindowControl.SetConsole("删除成功");
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
