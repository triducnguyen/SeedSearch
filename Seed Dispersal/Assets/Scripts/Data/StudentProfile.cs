using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SeedSearch
{
    public class StudentProfile : MonoBehaviour
    {
        public StudentData student;
        public TMP_Text firstPrompt;
        public TMP_Text secondPrompt;
        public TMP_Text thirdPrompt;
        public TMP_Text answer;
        // Start is called before the first frame update
        private void Start()
        {

        }
        private void OnEnable()
        {

        }

        // Update is called once per frame
        void Update()
        {
            firstPrompt.text = student.FirstPrompt;
            secondPrompt.text = student.SecondPrompt;
            thirdPrompt.text = student.ThirdPrompt;
            answer.text = "Attemps: " + student.Answers.Count;
        }
    }
}
