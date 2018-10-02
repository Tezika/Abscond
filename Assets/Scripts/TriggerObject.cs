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

        public bool destroyAfterTriggered;

        private Callback[] _callbacks;

        private Draggable _cachedDraggable;

        private void Awake()
        {
            _cachedDraggable = null;
        }

        // Use this for initialization
        void Start()
        {
            _callbacks = GetComponents<Callback>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            if (_cachedDraggable != null && !_cachedDraggable.beingDragged)
            {
                this.Trigger(_cachedDraggable.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject != correctObject)
                return;

            _cachedDraggable = other.gameObject.GetComponent<Draggable>();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject != correctObject)
                return;

            _cachedDraggable = null;
        }

        private void Trigger(GameObject triggerObject)
        {

            var triggeree = triggerObject.GetComponent<Triggeree>();
            if (triggeree != null)
            {
                triggeree.Triggered();
            }

            foreach (Callback x in _callbacks)
                x.Invoke();

            if (this.destroyAfterTriggered)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
