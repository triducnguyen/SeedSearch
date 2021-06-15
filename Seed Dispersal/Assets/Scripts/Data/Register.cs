using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SeedSearch
{
    public class Register : MonoBehaviour
    {
        public TMP_InputField userName;
        public TMP_InputField password;
        public TMP_InputField confirmPassWord;
        public Button createAccountButton;
        public GameObject Login;

        public void OnCreateAccount()
        {
            if (password.text == confirmPassWord.text && password.text != "" && userName.text != "")
            {
                TeacherData teacher = new TeacherData();
                teacher.UserName = userName.text;
                teacher.PassWord = password.text;
                if (!SaveManager.Instance.ExistData(teacher))
                {
                    SaveManager.Instance.SaveTeacherFile(teacher);
                    Login.SetActive(true);
                    gameObject.SetActive(false);
                    Debug.Log("account created");
                }
                
            }
            else
            {
                Debug.Log("Please fill all requirements");
            }

            
        }
    }
}
