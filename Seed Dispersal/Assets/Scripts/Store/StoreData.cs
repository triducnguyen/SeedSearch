using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SeedSearch
{
    public class StoreData : MonoBehaviour
    {
        [SerializeField] private StudentData studentData;
        [SerializeField] private int currentPrompt = 0;
        public GameObject[] prompts;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void ActivePrompt(int j)
        {
            foreach (GameObject obj in prompts)
                obj.SetActive(false);
            prompts[j].SetActive(true);
        }

        public void onNext()
        {
            currentPrompt++;

        }
    }
}