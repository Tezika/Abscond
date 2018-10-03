using Abs.Item;
using Abs.Utils;
using UnityEngine;

namespace Abs.Callbacks
{
    [RequireComponent(typeof(TriggerObject))]
    public class Callback : MonoBehaviour
    {
        public GameObject triggerObject;

        public bool destroyedAfterCallback = false;

        private void Awake()
        {
            if (this.triggerObject == null)
            {
                Debugger.Exception("Please assign the trigger object to this.");
            }    
        }

        public virtual void Invoke()
        {
        }
    }

}
