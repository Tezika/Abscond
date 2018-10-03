using Abs.Callbacks;
using UnityEngine;
using Abs.Triggerable;
using System.Collections.Generic;
using System.Linq;

namespace Abs.Item
{
    public class TriggerObject : MonoBehaviour
    {
        /*
         This script can be added onto any object on which you can drag another object.
         Make sure it has a Collider2D component with "IsTrigger" set.
             */
        private List<Callback> _callbacks;

        private Draggable _cachedDraggable;

        private void Awake()
        {
            _cachedDraggable = null;
            _callbacks = GetComponents<Callback>().ToList();
        }

        // Use this for initializatio

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
            var callback = _callbacks.Find(c => c.triggerObject == other.gameObject);

            if (callback == null)
            {
                return;
            }

            _cachedDraggable = other.gameObject.GetComponent<Draggable>();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var callback = _callbacks.Find(c => c.triggerObject == other.gameObject);

            if (callback == null)
            {
                return;
            }

            _cachedDraggable = null;
        }

        private void Trigger(GameObject triggerObject)
        {
            var destroyedAfterTriggered = false;
            foreach (var c in _callbacks)
            {
                if (c.triggerObject == triggerObject)
                {
                    c.Invoke();
                    if (!destroyedAfterTriggered && c.destroyedAfterCallback)
                    {
                        destroyedAfterTriggered = true;
                    }
                }
            }

            if (destroyedAfterTriggered)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
