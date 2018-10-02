using UnityEngine;

namespace Abs.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        private AudioSource _source;

        private void Awake()
        {
            AudioManager.instance = this.gameObject.GetComponent<AudioManager>();
            _source = this.gameObject.GetComponent<AudioSource>();
        }

        public void PlayAudio(AudioClip audioClip)
        {
            if (_source != null)
            {
                _source.PlayOneShot(audioClip);
            }
        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}

