using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch
{
    public class QuestionUI : MonoBehaviour
    {
        private int currentQuestion = 0;
        public List<GameObject> questions;
        public GameObject fieldNote;
        public void ToNextQuestion()
        {
            currentQuestion++;
            questions[currentQuestion - 1].SetActive(false);
            questions[currentQuestion].SetActive(true);
        }

        public void OnEnable()
        {
            fieldNote.SetActive(false);
            foreach(GameObject obj in questions)
            {
                obj.SetActive(false);
            }
            if(SaveManager.Instance.studentProfile.Answers.Count > 0)
            {
                questions[SaveManager.Instance.studentProfile.Answers.Count - 1].SetActive(true);
            }
            else
            {
                questions[0].SetActive(true);
            }
        }

        public void OpenQuestion(int index)
        {
            fieldNote.SetActive(false);
            this.gameObject.SetActive(true);
            foreach (GameObject obj in questions)
            {
                obj.SetActive(false);
            }
            questions[index].SetActive(true);
        }
    }
}
