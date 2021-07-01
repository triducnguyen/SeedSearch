using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SeedSearch
{
    public class CreateStudent : MonoBehaviour
    {
        public TMP_InputField firstName;
        public TMP_InputField lastName;
        public UIMenu uIMenu;
        public GameObject notification;

        private void OnEnable()
        {
            firstName.text = "";
            lastName.text = "";
        }

        public void OnCreate(GameObject obj)
        {
            StudentData newStudent = new StudentData();
            newStudent.FirstName = firstName.text.ToLower();
            newStudent.LastName = lastName.text.ToLower();
            if (!SaveManager.Instance.ExistData(newStudent) && newStudent.FirstName.Length > 1 && newStudent.LastName.Length > 1)
            {
                SaveManager.Instance.SaveStudentFile(newStudent);
                uIMenu.ChangeMenu(obj);
            }
            else
            {
                if (newStudent.FirstName.Length <= 1 || newStudent.LastName.Length <= 1)
                {
                    notification.transform.GetChild(0).GetComponent<TMP_Text>().text = "Student name should more than 1 character";
                    Debug.Log("student name should more than 1 character");
                    StartCoroutine(Notification());
                }
                else
                {
                    notification.transform.GetChild(0).GetComponent<TMP_Text>().text = "Student already exist";
                    Debug.Log("student already exist");
                    StartCoroutine(Notification());
                }
            }
        }

        public IEnumerator Notification()
        {
            notification.SetActive(true);
            yield return new WaitForSeconds(2f);
            notification.SetActive(false);
        }
    }
}
