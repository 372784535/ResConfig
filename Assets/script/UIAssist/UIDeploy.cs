using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDeploy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.GetComponent<Scrollbar>().value ;
	}

    public void onChangValue()
    {
        transform.parent.Find("HeroData/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value=transform.parent.Find("HeroData/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("HeroData/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("HeroData/Scrollbar Horizontal").GetComponent<Scrollbar>().value;

    }

    public void onReChangValue()
    {
        transform.parent.Find("HeroData/Scrollbar Vertical").GetComponent<Scrollbar>().value= transform.parent.Find("HeroData/TipTitleY/Scrollbar Vertical").GetComponent<Scrollbar>().value;
        transform.parent.Find("HeroData/Scrollbar Horizontal").GetComponent<Scrollbar>().value = transform.parent.Find("HeroData/TipTitleX/Scrollbar Horizontal").GetComponent<Scrollbar>().value;
    }

}
