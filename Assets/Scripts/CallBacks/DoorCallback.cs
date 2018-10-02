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

