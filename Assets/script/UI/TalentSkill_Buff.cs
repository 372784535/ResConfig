using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentSkill_Buff : MonoBehaviour {
    public int Length = 0;
    public Dictionary<int, C_TalentSkill_Buff> talentSkill_Buff = new Dictionary<int, C_TalentSkill_Buff>();

    private InputField _Id;
    private Dropdown _Type;
    private Dropdown _IsDispel;
    private Dropdown _IsSuperposition;
    private InputField _TimeDuration;
    private InputField _Explain;

    private Transform BaseTalentSkill_Buff;
	// Use this for initialization
	void Start () {
        BaseTalentSkill_Buff = transform.Find("Scroll/Viewport/Type");
        Init();
	}

    void Init()
    {
        if (!DataManage.TalentSkill_BuffJsonData.IsArray)
        {
            return;
        }
        for (int i = 0; i < DataManage.TalentSkill_BuffJsonData.Count; i++)
        {
            Add();
            _Id = transform.Find("Scroll/Viewport/Content/obj" + Length + "/Id").GetComponent<InputField>();
            _Type = transform.Find("Scroll/Viewport/Content/obj" + Length + "/Type").GetComponent<Dropdown>();
            _IsDispel = transform.Find("Scroll/Viewport/Content/obj" + Length + "/IsDispel").GetComponent<Dropdown>();
            _IsSuperposition = transform.Find("Scroll/Viewport/Content/obj" + Length + "/IsSuperposition").GetComponent<Dropdown>();
            _TimeDuration = transform.Find("Scroll/Viewport/Content/obj" + Length+ "/TimeDuration").GetComponent<InputField>();
            _Explain = transform.Find("Scroll/Viewport/Content/obj" + Length + "/Explain").GetComponent<InputField>();

            talentSkill_Buff[Length].Id = DataManage.TalentSkill_BuffJsonData[i]["Id"].ToInt32();
            talentSkill_Buff[Length].Type = DataManage.TalentSkill_BuffJsonData[i]["Type"].ToInt32();
            talentSkill_Buff[Length].IsDispel = DataManage.TalentSkill_BuffJsonData[i]["IsDispel"].ToInt32();
            talentSkill_Buff[Length].IsSuperposition = DataManage.TalentSkill_BuffJsonData[i]["IsSuperposition"].ToInt32();
            talentSkill_Buff[Length].TimeDuration = DataManage.TalentSkill_BuffJsonData[i]["TimeDuration"].ToInt32();
            talentSkill_Buff[Length].Explain = DataManage.TalentSkill_BuffJsonData[i]["Explain"].ToString();
            talentSkill_Buff[Length].IsJson = true;

            _Id.text = talentSkill_Buff[Length].Id.ToString();
            _Type.value = talentSkill_Buff[Length].Type;
            _IsDispel.value = talentSkill_Buff[Length].IsDispel;
            _IsSuperposition.value = talentSkill_Buff[Length].IsSuperposition;
            _TimeDuration.text = talentSkill_Buff[Length].TimeDuration.ToString();
            _Explain.text = talentSkill_Buff[Length].Explain;

        }
    }
	
    public void Add()
    {
        Length += 1;
        GameObject BaseTalentSkill_BuffObj = Instantiate(BaseTalentSkill_Buff.gameObject, BaseTalentSkill_Buff.parent.Find("Content"));
        BaseTalentSkill_BuffObj.name = "obj" + Length;
        BaseTalentSkill_BuffObj.GetComponent<CommonAssist>().ID = Length;
        C_TalentSkill_Buff talentSkill_Buffobj = new C_TalentSkill_Buff();
        talentSkill_Buff[Length] = talentSkill_Buffobj;
    }

    public void Del(int ID)
    {
        if (ID == 0)
        {
            return;
        }
        Destroy(transform.Find("Scroll/Viewport/Content/obj" + ID).gameObject);

        for (int i = ID + 1; i <= Length; i++)
        {
            transform.Find("Scroll/Viewport/Content/obj" + i).GetComponent<CommonAssist>().ID = i - 1;
            transform.Find("Scroll/Viewport/Content/obj" + i).name = "obj" + (i - 1);
            talentSkill_Buff[ID] = talentSkill_Buff[i];

        }
        talentSkill_Buff.Remove(Length);
        print("集合长度=" + talentSkill_Buff.Count);
        Length -= 1;
        DataManage.DelTalentSkill_BuffData(ID);
        WindowControl.SetConsole("删除成功");
    }

    public void Save(int ID)
    {
        _Id = transform.Find("Scroll/Viewport/Content/obj" + ID + "/Id").GetComponent<InputField>();
        _Type = transform.Find("Scroll/Viewport/Content/obj" + ID + "/Type").GetComponent<Dropdown>();
        _IsDispel = transform.Find("Scroll/Viewport/Content/obj" + ID + "/IsDispel").GetComponent<Dropdown>();
        _IsSuperposition = transform.Find("Scroll/Viewport/Content/obj" + ID + "/IsSuperposition").GetComponent<Dropdown>();
        _TimeDuration = transform.Find("Scroll/Viewport/Content/obj" + ID + "/TimeDuration").GetComponent<InputField>();
        _Explain = transform.Find("Scroll/Viewport/Content/obj" + ID + "/Explain").GetComponent<InputField>();


        try
        {
            talentSkill_Buff[ID].Id = int.Parse(_Id.text);
            talentSkill_Buff[ID].Type = _Type.value;
            talentSkill_Buff[ID].IsSuperposition = _IsSuperposition.value;
            talentSkill_Buff[ID].TimeDuration = int.Parse(_TimeDuration.text);
            talentSkill_Buff[ID].Explain = _Explain.text;
         
        }
        catch (Exception ex)
        {
            WindowControl.SetConsole("输入类型不对，详细：" + ex);
            return;
        }

        if (DataManage.SavetalentSkill_Buff(talentSkill_Buff, ID))
        {
            talentSkill_Buff[ID].IsJson = true;
        }


    }

	// Update is called once per frame
	void Update () {
		
	}
}
