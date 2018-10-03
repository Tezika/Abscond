using UnityEditor;
using UnityEngine;

namespace Abs.Item
{
    [CustomEditor(typeof(TriggerObject))]
    public class TriggerObjectEditor : Editor
    {
        private TriggerObject _triggerObject;

        private void OnEnable()
        {
            var trigger = this.target as TriggerObject;
            if (trigger != null)
            {
                _triggerObject = trigger;
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Trigger Pairs:");
            if (GUILayout.Button("+"))
            {
                this.AddPair();
            }
            EditorGUILayout.EndHorizontal();
            this.DisplayPairs();
            if (GUI.changed)
            {
                EditorUtility.SetDirty(this._triggerObject);
            }
        }

        private void AddPair()
        {
            var newPair = new TriggerPair(_triggerObject.gameObject);
            _triggerObject.pairs.Add(newPair);
        }

        private void RemovePair(TriggerPair pair)
        {
            _triggerObject.pairs.Remove(pair);
        }

        private void DisplayPairs()
        {
            for (int i = _triggerObject.pairs.Count - 1; i >= 0; i--)
            {
                EditorGUILayout.BeginHorizontal();
                var pair = _triggerObject.pairs[i];
                if (GUILayout.Button("X"))
                {
                    this.RemovePair(pair);
                    continue;
                }
                if (pair != null)
                {
                    pair.OnInspector();
                }      
                EditorGUILayout.EndHorizontal();
            }
        }
    }

}
