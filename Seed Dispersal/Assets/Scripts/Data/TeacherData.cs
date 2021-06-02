using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherData
{
    private string userName;
    private string password;
    private List<StudentData> studentList;
    public string UserName { get => userName; set => userName = value; }
    public string PassWord { get => password; set => password = value; }

    public List<StudentData> StudentList { get => studentList; set => studentList = value;}

    public void Initialize()
    {
    }

}
