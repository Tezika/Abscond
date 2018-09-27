using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abs.Letter;
using Abs.Utils;

namespace Abs.Player
{
    public class Player : MonoBehaviour
    {
        private void Awake()
        {

        }

        // Use this for initialization
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            //use the mouse input firstly
            if (Input.GetMouseButtonDown(0))
            {
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var mousePos2D = new Vector2(mousePos.x, mousePos.y);
                var hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Letter")
                    {
                        var letter = hit.collider.gameObject.GetComponent<Letter.Letter>();
                        Destroy(letter.gameObject);
                    }
                }
            }
        }
    }
}

