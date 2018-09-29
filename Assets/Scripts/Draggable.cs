using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {

    }

    void OnMouseDrag()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        float z = gameObject.transform.position.z;

        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(x, y, z));
        gameObject.transform.position = point;

        //Debug.Log("x: " + point.x + "   y: " + point.y + "   z: " + point.z);
    }
}
