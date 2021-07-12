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
        public List<TMP_Text> noteField;

        private int currentNote;

        private void Awake()
        {   
            if(SaveManager.Instance.studentProfile.FirstPrompt != null)
                noteField[0].text = SaveManager.Instance.studentProfile.FirstPrompt;
            if (SaveManager.Instance.studentProfile.SecondPrompt != null)
                noteField[1].text = SaveManager.Instance.studentProfile.SecondPrompt;
            if (SaveManager.Instance.studentProfile.ThirdPrompt != null)
                noteField[2].text = SaveManager.Instance.studentProfile.ThirdPrompt;
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
            noteField[currentNote].text = InputNote.GetComponent<TMP_InputField>().text;

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
    }
}
