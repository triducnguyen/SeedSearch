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
        [SerializeField] private AnswerType answerType;

        public TMP_Text notification;

        private void Awake()
        {
            Gamemanager.Instance.currentScene = SceneManager.GetActiveScene().name;
            
        }
        private void OnEnable()
        {
            Gamemanager.Instance.currentStudent = SaveManager.Instance.studentProfile;
            Gamemanager.Instance.LoadTimes();
            Gamemanager.Instance.StartHintTimer("you hinted");
            StartCoroutine(Hint());

        }
        public void SelectCorrect(GameObject answer) {
            answerType = AnswerType.Correct;
            TMP_Text answerBox = answer.GetComponent<TMP_Text>();
            Debug.Log(answerBox.text);
            SaveAnswer(answerBox.text);
        }
        public void SelectIncorrect(GameObject answer)
        {
            answerType = AnswerType.Incorrect;
            TMP_Text answerBox = answer.GetComponent<TMP_Text>();
            Debug.Log(answerBox.text);
            SaveAnswer(answerBox.text);
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
                    Gamemanager.Instance.SaveTimes();
                    StartCoroutine(Notification());
                    break;
                case AnswerType.Incorrect:
                    if (SaveManager.Instance.studentProfile.Answers == null)
                    {
                        SaveManager.Instance.studentProfile.Answers = new List<string>();
                        SaveManager.Instance.studentProfile.Answers.Add(answer);
                    } else
                    SaveManager.Instance.studentProfile.Answers.Add(answer);
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

        public void HintButton()
        {
            GameObject hintPopup = GameObject.Find("HintPopup(Clone)");
            if(hintPopup != null)
            {
                Destroy(hintPopup);
            } else
            {
                Instantiate(Gamemanager.Instance.hintObject, this.gameObject.transform);
            }
            Debug.Log("hinted");
        }
    }
}
