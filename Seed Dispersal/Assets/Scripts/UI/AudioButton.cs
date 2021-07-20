using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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