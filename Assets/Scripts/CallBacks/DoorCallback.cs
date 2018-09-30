using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abs.Callbacks
{
    public class DoorCallback : Callback
    {

        public override void Invoke()
        {
            Debug.Log("Door invoke!!");
        }
    }
}

