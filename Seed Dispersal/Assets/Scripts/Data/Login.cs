using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace SeedSearch
{
    public class Login : MonoBehaviour
    { 

        [SerializeField] private LoginType loginType;
        [SerializeField] private StudentData currentStudentProfile;
        public LoginType LoginType { get => loginType;}

        [Header("Login Input")]
        public TMP_InputField userName;
        public TMP_InputField password;
        // Start is called before the first frame update
        void Start()
        {
        }

        public void StudentLogin()
        {
            loginType = LoginType.Student;
            Debug.Log(loginType);
        }

        public void TeacherLogin()
        {
            loginType = LoginType.Teacher;
            Debug.Log(loginType);
        }
    }

}