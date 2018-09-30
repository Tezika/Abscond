using Abs.Utils;
using UnityEngine;

namespace Abs.Callbacks
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ChangeSpriteCallback : Callback
    {
        public Sprite replaceSprite;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            if (this.replaceSprite == null)
            {
                Debugger.Exception("Please assign the sprite to this filed");
            }
            _spriteRenderer = this.GetComponent<SpriteRenderer>();
        }

        public override void Invoke()
        {
            base.Invoke();
            _spriteRenderer.sprite = this.replaceSprite;

        }
    }
}

