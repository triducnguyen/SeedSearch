using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SeedSearch
{
    public class FieldNote : MonoBehaviour
    {
        public GameObject MainField;
        public GameObject InputNote;
        public List<GameObject> noteField;
        public List<GameObject> definitions;
        private int currentNote;
        private bool initialized = false;

        private void Awake()
        {   
            if(SaveManager.Instance.studentProfile.FirstPrompt != null)
                noteField[0].GetComponentInChildren<TMP_Text>().text = SaveManager.Instance.studentProfile.FirstPrompt;
            if (SaveManager.Instance.studentProfile.SecondPrompt != null)
                noteField[1].GetComponentInChildren<TMP_Text>().text = SaveManager.Instance.studentProfile.SecondPrompt;
            if (SaveManager.Instance.studentProfile.ThirdPrompt != null)
                noteField[2].GetComponentInChildren<TMP_Text>().text = SaveManager.Instance.studentProfile.ThirdPrompt;
            initialized = true;
        }

        public void OnNote()
        {
            foreach(Transform obj in gameObject.transform)
            {
                obj.gameObject.SetActive(false);
            }
            InputNote.SetActive(true);
        }

        public void OnEdit()
        {
            noteField[currentNote].GetComponentInChildren<TMP_Text>().text = InputNote.GetComponent<TMP_InputField>().text;

            foreach (Transform obj in gameObject.transform)
            {
                obj.gameObject.SetActive(false);
            }
            MainField.SetActive(true);
        }

        public void CurrentNote(int currentNote)
        {
            this.currentNote = currentNote;
        }

        private void FixedUpdate()
        {
            if (initialized)
            {
                for (int i = 0; i < SaveManager.Instance.studentProfile.Answers.Count; i++)
                {
                    definitions[i].SetActive(true);
                }
                for (int j = 0; j < SaveManager.Instance.studentProfile.Levelprogress.Length; j++)
                {
                    if(SaveManager.Instance.studentProfile.Levelprogress[j] == 1) 
                        noteField[j].SetActive(true);
                }
                initialized = false;
            }
            
            
        }
    }
}