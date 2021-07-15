using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch
{
    public class QuestionUI : MonoBehaviour
    {
        private int currentQuestion = 0;
        public List<GameObject> questions;

        public void ToNextQuestion()
        {
            currentQuestion++;
            questions[currentQuestion - 1].SetActive(false);
            questions[currentQuestion].SetActive(true);
        }

        public void OnEnable()
        {
            foreach(GameObject obj in questions)
            {
                obj.SetActive(false);
            }
            questions[SaveManager.Instance.studentProfile.Answers.Count - 1].SetActive(true);
        }
    }
}
