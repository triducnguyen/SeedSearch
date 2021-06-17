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
                StudentData data = studentList[i]; 
                newStudent.GetComponent<Button>().onClick.AddListener(() => OpenStudentProfile(data));
                newStudent.transform.GetChild(0).GetComponent<Text>().text = studentList[i].FirstName + " " + studentList[i].LastName;
                newStudent.transform.SetParent(StudentSlot.transform);

            }
        }

        public void OpenStudentProfile(StudentData data)
        {
            studentProfile.SetActive(true);
            studentProfile.GetComponent<StudentProfile>().student = data;
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

