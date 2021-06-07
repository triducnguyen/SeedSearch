﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

namespace SeedSearch
{
    public class Login : MonoBehaviour
    { 

        [SerializeField] private LoginType loginType;
        [SerializeField] private StudentData currentStudentProfile;
        [SerializeField] private TeacherData currentTeacher;
        public LoginType LoginType { get => loginType;}

        [Header("LoginType")]
        public GameObject typeSelection;
        public GameObject teacherLogin;
        public GameObject studentLogin;

        [Header("Login Input")]
        public TMP_InputField userName;
        public TMP_InputField password;

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
                    return;
                    break;
                case LoginType.Teacher:
                    if(userName.text != "" && password.text != "")
                    {
                        currentTeacher.UserName = userName.text;
                        currentTeacher.PassWord = password.text;
                        if (SaveManager.Instance.LoadTeacherData(currentTeacher) != null)
                        {
                            SaveManager.Instance.teacherProfile = currentTeacher;
                            UIMenu.Instance.ChangeMenu(profile);
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