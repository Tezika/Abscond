using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Letter : MonoBehaviour
{
    public string letter;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    private void Start ()
    {
		
	}
	
	// Update is called once per frame
	private void Update ()
    {
		
	}
}
