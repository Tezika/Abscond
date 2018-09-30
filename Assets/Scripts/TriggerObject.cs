using System.Collections;
using System.Collections.Generic;
using Abs.Utils;
using Abs.Callbacks;
using UnityEngine;
using Abs.Triggerable;

namespace Abs.Item
{
    public class TriggerObject : MonoBehaviour
    {

        /*
         This script can be added onto any object on which you can drag another object.
         Make sure it has a Collider2D component with "IsTrigger" set.
             */

        public GameObject correctObject;

        private Callback[] callbacks;

        // Use this for initialization
        void Start()
        {
            callbacks = GetComponents<Callback>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject != correctObject)
                return;
            var triggeree = other.gameObject.GetComponent<Triggeree>();
            if (triggeree != null )
            {
                triggeree.Triggered();
            }
            foreach (Callback x in callbacks)
                x.Invoke();
        }
    }

}
