using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour {

    /*
     This script can be added onto any object on which you can drag another object.
     Make sure it has a Collider2D component with "IsTrigger" set.
         */

    public GameObject correctObject;
    private Callback[] callback;
    
    // Use this for initialization
	void Start () {
        callback = GetComponents<Callback>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != correctObject)
            return;
        foreach (Callback x in callback)
            x.Invoke();
    }
}
