using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abs.Utils;

namespace Abs.Callbacks
{
    public class InstantiateCallback : Callback
    {
        public GameObject prefab;

        public Transform instantiateTrans;

        private void Awake()
        {
            if (this.prefab == null)
            {
                Debugger.Exception("Please assign the prefab to this prefab field");
            }

            if (this.instantiateTrans == null)
            {
                Debugger.Exception("Please assign the transform to this field");
            }
        }

        public override void Invoke()
        {
            base.Invoke();
            Instantiate(this.prefab, this.instantiateTrans.transform.position, Quaternion.identity);
        }
    }
}

