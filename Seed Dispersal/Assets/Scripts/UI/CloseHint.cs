using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch
{
    public class CloseHint : MonoBehaviour
    {
        public void CloseHintButton()
        {
            this.gameObject.SetActive(false);
        }

        public void OpenHintButton()
        {
            this.gameObject.SetActive(true);
        }
    }
}

