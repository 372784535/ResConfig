using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKillConfigAssist : MonoBehaviour {

    public int ID;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnDel()
    {
        WindowControl.OpenDelTip(ID, "SkillConfig");
    }
    public void OnSave()
    {
        GameObject.Find("Canvas/SkillConfig").GetComponent<SkillConfig>().Save(ID);
    }
}
