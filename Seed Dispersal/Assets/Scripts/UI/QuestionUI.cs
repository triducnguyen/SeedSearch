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
        public GameObject noteUp;
        public GameObject noteDown;
        public GameObject questionsObj;
        public john_gamemanager manager;
        public John_gamemanager_Path02 manager2;
        public John_gamemanager_Path03 manager3;
        public void ToNextQuestion()
        {
            currentQuestion++;
            questions[currentQuestion - 1].SetActive(false);
            questions[currentQuestion].SetActive(true);
            noteUp.SetActive(true);
            noteDown.SetActive(false);
            fieldNote.SetActive(false);
            questionsObj.SetActive(false);
            this.gameObject.SetActive(true);
        }

        public void OpenReviewQuestions()
        {
            questionsObj.SetActive(false);
            this.gameObject.SetActive(true);
            fieldNote.SetActive(false);
            noteUp.SetActive(true);
            noteDown.SetActive(false);
        }

        public void OnEnable()
        {
            if (manager != null)
                manager.AnsweringQuestion = true;

            if (manager2 != null)
                manager2.AnsweringQuestion = true;

            if (manager3 != null)
                manager3.AnsweringQuestion = true;
        }

        public void OpenQuestion(int index)
        {
            if (manager != null)
            manager.AnsweringQuestion = true;

            if(manager2 != null)
            manager2.AnsweringQuestion = true;
            if(manager3 != null)
            manager3.AnsweringQuestion = true;

            noteUp.SetActive(true);
            noteDown.SetActive(false);
            fieldNote.SetActive(false);
            this.gameObject.SetActive(true);
            foreach (GameObject obj in questions)
            {
                obj.SetActive(false);
            }
            questions[index].SetActive(true);
        }

        public void TriggerNarration(int index)
        {
            manager.AnsweringQuestion = false;
            manager.fairynarration(index);
        }

        public void TriggerNarration2(int index)
        {
            manager2.AnsweringQuestion = false;
            manager2.fairynarration(index);
        }
        public void TriggerNarration3(int index)
        {
            manager3.AnsweringQuestion = false;
            manager3.fairynarration(index);
        }
    }
}
