﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelAssist : MonoBehaviour {
    public int ID;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnDel()
    {
        WindowControl.OpenDelTip(ID,"HeroData");
    }
    public void OnSave()
    {
        GameObject.Find("Canvas/HeroData").GetComponent<HeroData>().Save(ID);
    }
    public void OnDetail()
    {
        GameObject.Find("Canvas/HeroData").GetComponent<HeroData>().OnDetail(ID);
    }
    public void OnResource()
    {
        GameObject.Find("Canvas/HeroData").GetComponent<HeroData>().OnResource(ID);
    }
}
