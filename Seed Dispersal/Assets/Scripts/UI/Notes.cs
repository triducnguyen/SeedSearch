using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch
{
    public class Notes : MonoBehaviour
    {
        public List<GameObject> notes;
        
        private void Awake()
        {
            if(SaveManager.Instance.studentProfile.Levelprogress.Length > 0)
                foreach(int i in SaveManager.Instance.studentProfile.Levelprogress)
                {
                    if(i > 0)
                    {
                        notes[i].SetActive(true);
                    }
                }
        }
    }
}