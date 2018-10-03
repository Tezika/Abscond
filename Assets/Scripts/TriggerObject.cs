using Abs.Callbacks;
using UnityEngine;
using Abs.Triggerable;
using System.Collections.Generic;
using Abs.TriggerItems;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Abs.Item
{
    [Serializable]
    public class TriggerPair
    {
        [SerializeField]
        public GameObject triggerObject;

        [SerializeField]
        public List<TriggerItem> items;

        [SerializeField,HideInInspector]
        public GameObject host;

        public TriggerPair(GameObject host)
        {
            this.host = host;
            this.items = new List<TriggerItem>();
        }

#if UNITY_EDITOR
        public void OnInspector()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Trigger Items");
            if (GUILayout.Button("+"))
            {
                this.AddNewItem();
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginVertical();
            this.DisplayItems();
            EditorGUILayout.EndVertical();
            if (GUI.changed)
            {
                EditorUtility.SetDirty(this.host);
            }
        }

        public void AddNewItem()
        {
            var newItem = new ChangeSpriteTriggerItem(this.host);
            this.items.Add(newItem);
        }

        public void RemoveItem(TriggerItem item)
        {
            this.items.Remove(item);
        }

        private void DisplayItems()
        {
            for (int i = items.Count - 1; i >= 0 ; i--)
            {
                EditorGUILayout.BeginHorizontal();
                if (this.items[i] != null)
                {
                    this.items[i].OnInspector();
                }
                if (GUILayout.Button("X"))
                {
                    this.RemoveItem(this.items[i]);
                }
                EditorGUILayout.EndHorizontal();
            }
        }
#endif
    }

    public class TriggerObject : MonoBehaviour
    {

        /*
         This script can be added onto any object on which you can drag another object.
         Make sure it has a Collider2D component with "IsTrigger" set.
             */
        public GameObject correctObject;

        public bool destroyAfterTriggered;

        [HideInInspector]
        public List<TriggerPair> pairs = new List<TriggerPair>();

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
