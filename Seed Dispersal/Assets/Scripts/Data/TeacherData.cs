using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SeedSearch
{
    [System.Serializable]
    public class TeacherData 
    {
        [SerializeField]private string userName;
        [SerializeField] private string password;
        [SerializeField] private string name;
        [SerializeField] private List<StudentData> studentList;
        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public List<StudentData> StudentList { get => studentList; set => studentList = value; }

        public void Initialize()
        {
        }

    }
}
