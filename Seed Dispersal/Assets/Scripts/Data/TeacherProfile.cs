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
                Student.transform.GetChild(0).GetComponent<Text>().text = studentList[i].FirstName + " " + studentList[i].LastName;
                Instantiate(Student.transform, StudentSlot.transform);
            }
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

