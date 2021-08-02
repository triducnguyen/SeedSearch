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
        public john_gamemanager manager;
        public John_gamemanager_Path02 manager2;
        public void ToNextQuestion()
        {
            currentQuestion++;
            questions[currentQuestion - 1].SetActive(false);
            questions[currentQuestion].SetActive(true);
        }

        public void OnEnable()
        {
            manager.AnsweringQuestion = true;
        }

        public void OpenQuestion(int index)
        {
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
    }
}
