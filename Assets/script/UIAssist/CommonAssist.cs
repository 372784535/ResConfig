using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonAssist : MonoBehaviour {
    public int ID;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnEndEditNeedHeroPlan()
    {
        transform.parent.parent.parent.GetComponent<Fetter>().ChangNeedHeroPlan(ID);
    }

    public void OnEndEditPropertyAddPlan()
    {
        transform.parent.parent.parent.GetComponent<Fetter>().ChangPropertyAddPlan(ID);
    }

    public void OnDel()
    {
        WindowControl.OpenDelTip(ID, "Fetter");
    }
    public void OnSave()
    {
        GameObject.Find("Canvas/Fetter").GetComponent<Fetter>().Save(ID);
    }
    public void TalentSkill_BuffDel()
    {
        WindowControl.OpenDelTip(ID, "TalentSkill_Buff");
    }

    public void TalentSkill_BuffSave()
    {
        GameObject.Find("Canvas/TalentSkill_Buff").GetComponent<TalentSkill_Buff>().Save(ID);
    }

    public void TalentSkillDel()
    {
        WindowControl.OpenDelTip(ID, "TalentSkill");
    }

    public void TalentSkillSave()
    {
        GameObject.Find("Canvas/TalentSkill").GetComponent<TalentSkill>().Save(ID);
    }

    public void TalentStoneConditionDel()
    {
        WindowControl.OpenDelTip(ID, "TalentStoneCondition");
    }

    public void TalentStoneConditionSave()
    {
        GameObject.Find("Canvas/TalentStoneCondition").GetComponent<TalentStoneCondition>().Save(ID);
    }
}
