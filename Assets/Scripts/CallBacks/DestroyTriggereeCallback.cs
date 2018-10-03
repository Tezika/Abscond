using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abs.Callbacks
{
    public class DestroyTriggereeCallback : Callback
    {

        public override void Invoke()
        {
            base.Invoke();
            if (this.triggerObject != null)
            {
                Destroy(this.triggerObject);
            }
        }
    }
}

