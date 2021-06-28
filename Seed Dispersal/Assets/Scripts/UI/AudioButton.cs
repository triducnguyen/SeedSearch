using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch
{
    public class AudioButton : MonoBehaviour
    {        
        public void PlayAudio(string audio)
        {
            SoundManager.Instance.PlayAudio(audio);
        }
    }
}