﻿using System.Collections;
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

        [Header("Notification")]
        public GameObject notification;

        [Header("Profile")]
        public GameObject teacherProfile;
        public GameObject playMode;

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
            userName.text = "";
            password.text = "";
            Debug.Log(loginType);
        }

        public void TeacherLogin()
        {
            loginType = LoginType.Teacher;
            teacherLogin.SetActive(true);
            studentLogin.SetActive(false);
            firstName.text = "";
            lastName.text = "";
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
                        currentStudent.FirstName = firstName.text.ToLower();
                        currentStudent.LastName = lastName.text.ToLower();
                        if (SaveManager.Instance.ExistData(currentStudent))
                        {
                            SaveManager.Instance.studentProfile = SaveManager.Instance.LoadStudentData(currentStudent);
                            //SceneManager.LoadScene("StoreInput");
                            //SceneManager.LoadScene("LessonOne");
                            gameObject.SetActive(false);
                            playMode.SetActive(true);
                            firstName.text = "";
                            lastName.text = "";
                        }
                        else
                        {
                            notification.transform.GetChild(0).GetComponent<TMP_Text>().text = "Non-student exist";
                            Debug.Log("Non-student exist");
                            StartCoroutine(Notification());
                        }
                    }
                    break;
                case LoginType.Teacher:
                    if(userName.text != "" && password.text != "")
                    {
                        currentTeacher.UserName = userName.text.ToLower();
                        currentTeacher.PassWord = password.text;
                        if (SaveManager.Instance.ExistData(currentTeacher))
                        {
                            SaveManager.Instance.teacherProfile = SaveManager.Instance.LoadTeacherData(currentTeacher);
                            gameObject.SetActive(false);
                            teacherProfile.SetActive(true);
                            userName.text = "";
                            password.text = "";
                        }
                        else
                        {
                            notification.transform.GetChild(0).GetComponent<TMP_Text>().text = "Account non-exist";
                            Debug.Log("Account non-exist");
                            StartCoroutine(Notification());
                        }
                    }
                    
                    break;
                default:
                    break;
            }
        }
        #endregion


        public IEnumerator Notification()
        {
            notification.SetActive(true);
            yield return new WaitForSeconds(2f);
            notification.SetActive(false);
        }
    }
}