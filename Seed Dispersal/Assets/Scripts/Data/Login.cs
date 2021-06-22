using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

namespace SeedSearch
{
    public class Login : MonoBehaviour
    { 

        [SerializeField] private LoginType loginType;
        [SerializeField] private StudentData currentStudent;
        [SerializeField] private TeacherData currentTeacher;
        public LoginType LoginType { get => loginType;}

        [Header("LoginType")]
        public GameObject typeSelection;
        public GameObject teacherLogin;
        public GameObject studentLogin;

        [Header("Teacher Login Input")]
        public TMP_InputField userName;
        public TMP_InputField password;

        [Header("Student Login Input")]
        public TMP_InputField firstName;
        public TMP_InputField lastName;

        [Header("Profile")]
        public GameObject profile;

        private void Awake()
        {
            Debug.Log(Directory.GetFiles(Application.persistentDataPath, "*.data"));
            currentTeacher = SaveManager.Instance.teacherProfile;
            loginType = LoginType.Teacher;
            typeSelection.SetActive(true);
            teacherLogin.SetActive(true);
            studentLogin.SetActive(false);
        }

        #region LoginUI
        public void StudentLogin()
        {
            loginType = LoginType.Student;
            teacherLogin.SetActive(false);
            studentLogin.SetActive(true);
            Debug.Log(loginType);
        }

        public void TeacherLogin()
        {
            loginType = LoginType.Teacher;
            teacherLogin.SetActive(true);
            studentLogin.SetActive(false);
            Debug.Log(loginType);
        }
        #endregion

        #region LoginHandler
        public void OnLogin()
        {
            switch (loginType)
            {
                case LoginType.Student:
                    if(firstName.text != "" && lastName.text != "")
                    {
                        currentStudent.FirstName = firstName.text;
                        currentStudent.LastName = lastName.text;
                        if (SaveManager.Instance.ExistData(currentStudent))
                        {
                            SaveManager.Instance.studentProfile = SaveManager.Instance.LoadStudentData(currentStudent);
                            //SceneManager.LoadScene("StoreInput");
                            SceneManager.LoadScene("LessonOne");
                            firstName.text = "";
                            lastName.text = "";
                        }
                        else
                        {
                            Debug.Log("Non-student exist");
                        }
                    }
                    break;
                case LoginType.Teacher:
                    if(userName.text != "" && password.text != "")
                    {
                        currentTeacher.UserName = userName.text;
                        currentTeacher.PassWord = password.text;
                        if (SaveManager.Instance.ExistData(currentTeacher))
                        {
                            SaveManager.Instance.teacherProfile = SaveManager.Instance.LoadTeacherData(currentTeacher);
                            gameObject.SetActive(false);
                            profile.SetActive(true);
                            userName.text = "";
                            password.text = "";
                        }
                        else
                        {
                            Debug.Log("Account non-exist");
                        }
                    }
                    
                    break;
                default:
                    break;
            }
        }
        #endregion
    }

}