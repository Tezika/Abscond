using Abs.Callbacks;
using UnityEngine;
using Abs.Triggerable;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

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

        private bool coroutineRunning = false;

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
                    Debug.Log("Show definition of object here.");
                    var def = triggerObject.GetComponent<Def_Popup>();
                    if (def != null)
                    {
                        if (coroutineRunning)
                            StopAllCoroutines();
                        def.transform.position = transform.position;
                        def.transform.position.Set(def.transform.position.x, def.transform.position.y + 10, def.transform.position.z);
                        StartCoroutine(showDef(def));
                    }
                    if (!destroyedAfterTriggered && c.destroyedAfterCallback)
                    {
                        destroyedAfterTriggered = true;
                    }
                }
                else
                {
                    
                }
            }

            if (destroyedAfterTriggered)
            {
                Destroy(this.gameObject);
            }
        }

        IEnumerator showDef(Def_Popup def)
        {
            coroutineRunning = true;
            def.showPopup();            
            yield return new WaitForSeconds(5); ;
            def.closePopup();
            coroutineRunning = false;
        }
    }

}
