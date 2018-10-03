using System;
using UnityEngine;

namespace Abs.TriggerItems
{
    [Serializable]
    public class TriggerItem
    {
        [SerializeField]
        public GameObject triggerer { get; private set; }

        public virtual void Awake()
        {

        }

        public TriggerItem(GameObject triggerer)
        {
            this.triggerer = triggerer;
        }

        public virtual void Invoke()
        {
        }

#if UNITY_EDITOR
        public virtual void OnInspector() { }
#endif
    }

}
