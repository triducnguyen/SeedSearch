using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace SeedSearch
{
    public class TeacherProfile : MonoBehaviour
    {
        [Header("Display")]
        public Text UserName;
        public Text Name;
        public GameObject StudentSlot;
        public GameObject Student;

        [Header("StudentProfile")]
        public GameObject studentProfile;

        [Header("Edit Name")]
        public TMP_InputField editNameField;
        public GameObject editDone;
        [SerializeField] private TeacherData teacherProfile;
        // Start is called before the first frame update

        void OnEnable()
        {
            SaveManager.Instance.teacherProfile.StudentList = SaveManager.Instance.GetStudents();
            teacherProfile = SaveManager.Instance.teacherProfile;
            Initialize();
        }

        private void OnDisable()
        {
            foreach(Transform child in StudentSlot.transform)
            {
                Destroy(child.gameObject);
            }
        }

        void Initialize()
        {
            UserName.text = teacherProfile.UserName;
            if(teacherProfile.Name == null)
                Name.text = teacherProfile.UserName;
            else
                Name.text = teacherProfile.Name;

            StudentListDisplay();
        }

        void StudentListDisplay()
        {
            List<StudentData> studentList = SaveManager.Instance.GetStudents();
            for(int i = 0; i < studentList.Count; i++)
            {
                GameObject newStudent = Instantiate(Student);
                StudentProfile studentScript = newStudent.AddComponent<StudentProfile>();
                studentScript.student = studentList[i];
                studentScript.firstPrompt = studentProfile.GetComponent<StudentProfile>().firstPrompt;
                studentScript.secondPrompt = studentProfile.GetComponent<StudentProfile>().secondPrompt;
                studentScript.thirdPrompt = studentProfile.GetComponent<StudentProfile>().thirdPrompt;

                studentScript.firstPrompt.text = studentList[i].FirstPrompt;
                studentScript.secondPrompt.text = studentList[i].SecondPrompt;
                studentScript.thirdPrompt.text = studentList[i].ThirdPrompt;

                newStudent.transform.GetChild(0).GetComponent<Text>().text = studentList[i].FirstName + " " + studentList[i].LastName;
                newStudent.transform.SetParent(StudentSlot.transform);
                newStudent.GetComponent<Button>().onClick.AddListener(OpenStudentProfile);

            }
        }

        public void OpenStudentProfile()
        {
            Debug.Log("hit");
            studentProfile.SetActive(true);
        }

        public void OnLogout()
        {
            SaveManager.Instance.SaveTeacherFile(SaveManager.Instance.teacherProfile);
        }

        public void OnEdit()
        {
            editNameField.gameObject.SetActive(true);
            editDone.SetActive(true);
        }

        public void OnDone()
        {
            editNameField.gameObject.SetActive(false);
            editDone.SetActive(false);
            Name.text = editNameField.text;
            SaveManager.Instance.teacherProfile.Name = editNameField.text;
        }



    }
}

