using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SeedSearch
{
    public class StudentProfile : MonoBehaviour
    {
        public StudentData student;
        public GameObject content;
        public TMP_Text studentName;
        public TMP_Text firstPrompt;
        public TMP_Text secondPrompt;
        public TMP_Text thirdPrompt;
        public GameObject answer;
        private bool initalized = false;
        // Start is called before the first frame update
        private void Start()
        {

        }
        private void InitializeDuration()
        {
            if (student.Times.Count > 0)
            {
                int count = 1;
                foreach (float i in student.Times)
                {
                    GameObject newAnswer = Instantiate(answer);
                    newAnswer.transform.SetParent(content.transform);
                    newAnswer.GetComponent<TMP_Text>().text = "Duration for question " + count + " : " + i;
                    count++;
                }
            }
            initalized = true;
            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            studentName.text = student.FirstName + " " + student.LastName;
            firstPrompt.text = "Student First Note: " + student.FirstPrompt;
            secondPrompt.text = "Student Second Note: " + student.SecondPrompt;
            thirdPrompt.text = "Student Third Note: " + student.ThirdPrompt;
            //answer.text = "Attemps: " + student.Answers.Count;
            if(!initalized)
                InitializeDuration();
        }
    }
}
