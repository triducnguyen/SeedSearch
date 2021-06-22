using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch
{
    public class VocabUI : MonoBehaviour
    {
        public List<GameObject> map;

        public void MoveToNextMap()
        {
            map[0].SetActive(false);
            map[1].SetActive(true);
        }
    }
}

