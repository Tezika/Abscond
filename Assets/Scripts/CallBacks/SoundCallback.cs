using Abs.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Abs.Callbacks
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundCallback : Callback
    {
        public List<AudioClip> clips = new List<AudioClip>();

        private AudioSource _source;

        private void Awake()
        {
            _source = this.GetComponent<AudioSource>();
        }

        public override void Invoke()
        {
            base.Invoke();
            for (int i = 0; i < this.clips.Count; i++)
            {
                Debugger.Log("Play the sound:" + this.clips[i].name);

                _source.PlayOneShot(this.clips[i]);
            }
        }
    }
}

