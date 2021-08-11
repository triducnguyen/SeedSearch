using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch
{
    public class SoundManager : Singleton<SoundManager>
    {
        public List<AudioClip> sounds;
        public AudioSource audioSource;
        //private void Awake()
        //{
        //    audioSource = GetComponent<AudioSource>();
        //}
        public void PlayAudio(string audio)
        {
            foreach(AudioClip clip in sounds)
            {
                if(clip.name == audio)
                {
                    audioSource = GetComponent<AudioSource>();
                    audioSource.clip = clip;
                    audioSource.Play();
                }
            }
        }


    }

}