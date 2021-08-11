using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace SeedSearch
{
    public class MultipleChoices : MonoBehaviour
    {
        private AnswerType answerType;
        private bool didAnswer = false;
        public bool DidAnswer { get => didAnswer; set => didAnswer = value; }
        public TMP_Text notification;
        public GameObject hint;
        private void Awake()
        {
            Gamemanager.Instance.currentScene = SceneManager.GetActiveScene().name;
            Gamemanager.Instance.hintObject = hint;
            
        }
        private void OnEnable()
        {
            Gamemanager.Instance.currentStudent = SaveManager.Instance.studentProfile;
            Gamemanager.Instance.LoadTimes();
            Gamemanager.Instance.StartHintTimer("you hinted");
            //StartCoroutine(Hint());

        }
        public void SelectCorrect(TMP_Text answer) {
            answerType = AnswerType.Correct;
            SaveAnswer(answer.text);
        }
        public void SelectIncorrect()
        {
            answerType = AnswerType.Incorrect;
            SaveAnswer();
        }


        public void SaveAnswer(string answer)
        {
            switch (answerType)
            {
                case AnswerType.Correct:
                    if(SaveManager.Instance.studentProfile.Answers == null)
                    {
                        SaveManager.Instance.studentProfile.Answers = new List<string>();
                        SaveManager.Instance.studentProfile.Answers.Add(answer);
                    } else
                        SaveManager.Instance.studentProfile.Answers.Add(answer);
                    didAnswer = true;
                    Gamemanager.Instance.EndTimer();
                    StartCoroutine(Notification());
                    break;
                case AnswerType.Incorrect:
                    StartCoroutine(Notification());
                    break;
            }
        }

        public void SaveAnswer()
        {
            switch (answerType)
            {
                case AnswerType.Correct:
                    didAnswer = true;
                    Gamemanager.Instance.EndTimer();
                    StartCoroutine(Notification());
                    break;
                case AnswerType.Incorrect:
                    StartCoroutine(Notification());
                    break;
            }
        }

        public IEnumerator Notification()
        {
            notification.gameObject.SetActive(true);
            switch (answerType)
            {
                case AnswerType.Correct:
                    notification.color = Color.green;
                    notification.text = "You got correct";
                    break;
                case AnswerType.Incorrect:
                    notification.color = Color.red;
                    notification.text = "Please try again";
                    break;
            }
                    yield return new WaitForSeconds(5);
                    notification.gameObject.SetActive(false);
        }

        public IEnumerator Hint()
        {
            yield return new WaitForSeconds(Gamemanager.Instance.wait);
            Instantiate(Gamemanager.Instance.hintSuggest, this.gameObject.transform);
        }

        public void MoveToNextQuestion(GameObject obj)
        {
            this.gameObject.SetActive(false);
            obj.SetActive(true);
        }

    }
}
