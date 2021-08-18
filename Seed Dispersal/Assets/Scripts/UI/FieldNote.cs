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
        public GameObject freeResponse;
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

        public void OnEditRespone()
        {
            noteField[currentNote].GetComponentInChildren<TMP_Text>().text = freeResponse.GetComponent<TMP_InputField>().text;

            foreach (Transform obj in gameObject.transform)
            {
                obj.gameObject.SetActive(false);
            }
            MainField.SetActive(true);
            if (currentNote == 0)
            {
                SaveManager.Instance.studentProfile.FirstPrompt = noteField[currentNote].GetComponentInChildren<TMP_Text>().text;
            }
            else if (currentNote == 1)
            {
                SaveManager.Instance.studentProfile.SecondPrompt = noteField[currentNote].GetComponentInChildren<TMP_Text>().text;
            }
            else if (currentNote == 2)
            {
                SaveManager.Instance.studentProfile.ThirdPrompt = noteField[currentNote].GetComponentInChildren<TMP_Text>().text;
            }
        }

        public void OnEdit()
        {
            noteField[currentNote].GetComponentInChildren<TMP_Text>().text = InputNote.GetComponent<TMP_InputField>().text;

            foreach (Transform obj in gameObject.transform)
            {
                obj.gameObject.SetActive(false);
            }
            MainField.SetActive(true);
            if(currentNote == 0)
            {
                SaveManager.Instance.studentProfile.FirstPrompt = noteField[currentNote].GetComponentInChildren<TMP_Text>().text;
            } else if(currentNote == 1)
            {
                SaveManager.Instance.studentProfile.SecondPrompt = noteField[currentNote].GetComponentInChildren<TMP_Text>().text;
            } else if(currentNote == 2)
            {
                SaveManager.Instance.studentProfile.ThirdPrompt = noteField[currentNote].GetComponentInChildren<TMP_Text>().text;
            }
        }

        public void CurrentNote(int currentNote)
        {
            this.currentNote = currentNote;
        }

        public void ShowDefinition(int index)
        {
            if(SaveManager.Instance.studentProfile.Definitions != null){
                SaveManager.Instance.studentProfile.Definitions[index] = 1;
            }
            
        }

        public void CompleteLevel(int index)
        {
            SaveManager.Instance.studentProfile.Levelprogress[index] = 2;
            SaveManager.Instance.SaveStudentFile(SaveManager.Instance.studentProfile);
            if(index < 2)
                SaveManager.Instance.studentProfile.Levelprogress[index + 1] = 1;

        }

        private void FixedUpdate()
        {
            if(SaveManager.Instance.studentProfile.Definitions != null){
                for (int i = 0; i < SaveManager.Instance.studentProfile.Definitions.Length; i++)
                {
                    if(SaveManager.Instance.studentProfile.Definitions[i]==1)
                        definitions[i].SetActive(true);
                }
                for (int j = 0; j < SaveManager.Instance.studentProfile.Levelprogress.Length; j++)
                {
                    if(SaveManager.Instance.studentProfile.Levelprogress[j] >= 1) 
                        noteField[j].SetActive(true);
                }     
            }
        }
    }
}
