using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGrowAssist : MonoBehaviour {

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
        WindowControl.OpenDelTip(ID, "StarGrow");
    }
    public void OnSave()
    {
        GameObject.Find("Canvas/StarGrow").GetComponent<StarGrow>().Save(ID);
    }
    public void OnDetail()
    {
        GameObject.Find("Canvas/HeroData").GetComponent<HeroData>().OnDetail(ID);
    }
}
