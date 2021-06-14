using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SeedSearch
{
    public class CreateStudent : MonoBehaviour
    {
        public TMP_InputField username;
        public UIMenu uIMenu;

        public void OnCreate(GameObject obj)
        {
            StudentData newStudent = new StudentData();
            newStudent.UserName = username.text;
            if (!SaveManager.Instance.ExistData(newStudent) && newStudent.UserName.Length > 1)
            {
                SaveManager.Instance.SaveStudentFile(newStudent);
                uIMenu.ChangeMenu(obj);
            }
            else
            {
                if (newStudent.UserName.Length <= 1)
                    Debug.Log("student name should more than 1 character");
                else
                    Debug.Log("student already exist");
            }
        }
    }
}
