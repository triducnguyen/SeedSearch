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
        [SerializeField]private List<GameObject> durationObjects;
        private void InitializeDuration()
        {
            if (student.Times.Count > 0)
            {
                int count = 1;
                for(int i = 2;i < student.Times.Count;i++)
                {
                    GameObject newAnswer = Instantiate(answer);
                    newAnswer.transform.SetParent(content.transform);
                    newAnswer.GetComponent<TMP_Text>().text = "Duration for question " + count + " : " + student.Times[i];
                    durationObjects.Add(newAnswer);
                    count++;
                }
            }
            initalized = true;
            
        }

        public void NewProfile()
        {
            foreach(GameObject obj in durationObjects)
            {
                Destroy(obj);
            }
            durationObjects.Clear();
            initalized = false;
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
