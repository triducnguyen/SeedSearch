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
        public TMP_Text[] displayTexts;
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
            if(j < prompts.Length)
                prompts[j].SetActive(true);
        }

        public void onNext()
        {
            switch (currentPrompt)
            {
                case 0:        
                    SaveManager.Instance.studentProfile.FirstPrompt = prompts[currentPrompt].GetComponent<TMP_InputField>().text;
                    break;
                case 1:
                    SaveManager.Instance.studentProfile.SecondPrompt = prompts[currentPrompt].GetComponent<TMP_InputField>().text;
                    break;
                case 2:
                    SaveManager.Instance.studentProfile.ThirdPrompt = prompts[currentPrompt].GetComponent<TMP_InputField>().text;
                    displayTexts[0].text = SaveManager.Instance.studentProfile.FirstPrompt;
                    displayTexts[1].text = SaveManager.Instance.studentProfile.SecondPrompt;
                    displayTexts[2].text = SaveManager.Instance.studentProfile.ThirdPrompt;
                    break;
            }
            currentPrompt++;
            ActivePrompt(currentPrompt);

        }
    }
}