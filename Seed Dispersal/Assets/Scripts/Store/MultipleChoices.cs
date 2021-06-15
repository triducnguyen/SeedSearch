using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SeedSearch
{
    public class MultipleChoices : MonoBehaviour
    {
        [SerializeField] private AnswerType answerType;

        public TMP_Text answerA;
        public TMP_Text answerB;
        public TMP_Text answerC;
        public TMP_Text answerD;

        // Start is called before the first frame update
        void Start()
        {

        }

        public void SelectA() {
            answerType = AnswerType.A;
            SaveAnswer();
        }
        public void SelectB()
        {
            answerType = AnswerType.B;
            SaveAnswer();
        }
        public void SelectC()
        {
            answerType = AnswerType.C;
            SaveAnswer();
        }
        public void SelectD()
        {
            answerType = AnswerType.D;
            SaveAnswer();
        }

        public void SaveAnswer()
        {
            switch (answerType)
            {
                case AnswerType.A:
                    SaveManager.Instance.studentProfile.Answer1 = answerA.text;
                    break;
                case AnswerType.B:
                    SaveManager.Instance.studentProfile.Answer1 = answerB.text;
                    break;
                case AnswerType.C:
                    SaveManager.Instance.studentProfile.Answer1 = answerC.text;
                    break;
                case AnswerType.D:
                    SaveManager.Instance.studentProfile.Answer1 = answerD.text;
                    break;
            }
        }

    }
}
