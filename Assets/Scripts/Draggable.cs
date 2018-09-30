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
        //float x = Input.mousePosition.x;
        //float y = Input.mousePosition.y;
        //float z = 0;

        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = new Vector3(point.x, point.y, 0);

        //Debug.Log("x: " + point.x + "   y: " + point.y + "   z: " + point.z);
    }
}
