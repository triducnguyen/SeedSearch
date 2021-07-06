using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch
{
    public class VocabUI : MonoBehaviour
    {
        public List<GameObject> map;
        public List<GameObject> buttons;

        public void MoveToNextMap()
        {
            map[0].SetActive(false);
            map[1].SetActive(true);
        }

        public void ToMapOne()
        {
            buttons[0].SetActive(true);
            buttons[1].SetActive(false);
            map[0].SetActive(true);
            map[1].SetActive(false);
        }

        public void ToMapTwo()
        {
            buttons[0].SetActive(false);
            buttons[1].SetActive(true);
            map[0].SetActive(false);
            map[1].SetActive(true);
        }
    }
}

