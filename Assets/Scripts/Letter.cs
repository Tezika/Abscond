﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abs.Letter
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Letter : MonoBehaviour
    {
        public string letter;

        private SpriteRenderer _spriteRenderer;

        public void OnClicked()
        {
            //Destroy this letter, add one into the inventory.

        }

        private void Awake()
        {
            _spriteRenderer = this.GetComponent<SpriteRenderer>();
        }

        // Use this for initialization
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}

