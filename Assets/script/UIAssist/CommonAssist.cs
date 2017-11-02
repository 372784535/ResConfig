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
}
