using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Abs.TriggerItems
{
    [Serializable]
    public class ChangeSpriteTriggerItem : TriggerItem
    {
        [SerializeField]
        public Sprite sprite;

        private SpriteRenderer _spriteRender;

        public ChangeSpriteTriggerItem(GameObject triggerer) : base(triggerer)
        {

        }

        public override void Awake()
        {
            base.Awake();
            _spriteRender = this.triggerer.GetComponent<SpriteRenderer>();
        }

        public override void Invoke()
        {
            base.Invoke();
            _spriteRender.sprite = this.sprite;
        }

#if UNITY_EDITOR
        public override void OnInspector()
        {
            base.OnInspector();
            this.sprite = (Sprite)EditorGUILayout.ObjectField("sprite", this.sprite, typeof(Sprite), true);
        }
#endif
    }
}
