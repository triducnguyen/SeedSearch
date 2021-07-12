using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch
{
    public class ToggleButton : MonoBehaviour
    {
        
        public void Toggle(GameObject obj)
        {
            this.gameObject.SetActive(false);
            obj.SetActive(true);
        }
    }
}

