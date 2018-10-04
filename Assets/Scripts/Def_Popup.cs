using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Def_Popup : MonoBehaviour {

    public GameObject popup;

    public GameObject title;
    public GameObject def;

    public string Title;
    [TextArea(3, 10)]
    public string Def;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showPopup()
    {
        title.GetComponent<TextMeshPro>().SetText(Title);
        def.GetComponent<TextMeshPro>().SetText(Def);
        popup.SetActive(true);
    }

    public void closePopup()
    {
        popup.SetActive(false);
    }
}
