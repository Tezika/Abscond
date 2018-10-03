using Abs.Audio;
using UnityEngine;

namespace Abs.Callbacks
{
    public class SoundCallback : Callback
    {
        public AudioClip clip;

        private void Awake()
        {
        }

        public override void Invoke()
        {
            base.Invoke();
            if (clip != null)
            {
                AudioManager.instance.PlayAudio(clip);
            }
        }
    }
}

