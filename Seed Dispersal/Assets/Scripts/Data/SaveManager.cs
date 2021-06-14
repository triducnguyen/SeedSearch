using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SeedSearch
{
    public class SaveManager : Singleton<SaveManager>
    {
        public StudentData studentProfile;
        public TeacherData teacherProfile;
        private string StudentPath;
        private string TeacherPath;
        // Start is called before the first frame update
        private void Awake()
        {
            base.Awake();
        }

        void UpdateStudentDataPath(string firstName,string lastName) => StudentPath = string.Format("{0}/{1}{2}{3}.student", Application.persistentDataPath, "student", firstName,lastName);
        void UpdateTeacherDataPath(string teacherName,string password) => TeacherPath = string.Format("{0}/{1}{2}{3}.data", Application.persistentDataPath, "teacher", teacherName,password);


        //Create and save Student data
        public void SaveStudentFile(StudentData student)
        {
            UpdateStudentDataPath(student.FirstName , student.LastName);
            //Override the same file if the file exist
            if (File.Exists(StudentPath))
                File.Delete(StudentPath);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(StudentPath, FileMode.Create);

            formatter.Serialize(stream,student);
            stream.Close();
        }

        //Create and save Teacher data
        public void SaveTeacherFile(TeacherData teacher)
        {
            UpdateTeacherDataPath(teacher.UserName, teacher.PassWord);
            //Override the same file if the file exist
            if (File.Exists(TeacherPath))
            {
                File.Delete(TeacherPath);
            }
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(TeacherPath, FileMode.Create);
            TeacherData data = new TeacherData();
            data = teacher;
            formatter.Serialize(stream, data);
            stream.Close();
        }

        //Get studentFile by Student data (username)
        public StudentData LoadStudentData(StudentData student)
        {
            UpdateStudentDataPath(student.FirstName, student.LastName);
            string path = StudentPath;
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                StudentData data = formatter.Deserialize(stream) as StudentData;
                stream.Close();
                return data;
            }
            else
            {
                Debug.LogError("Save student file not found in " + path);
                return null;
            }
        }

        //Get studentFile by path
        public StudentData LoadStudentData(string path)
        {
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                StudentData data = formatter.Deserialize(stream) as StudentData;
                stream.Close();
                return data;
            }
            else
            {
                Debug.LogError("Save student file not found in " + path);
                return null;
            }
        }


        public TeacherData LoadTeacherData(TeacherData teacher)
        {
            UpdateTeacherDataPath(teacher.UserName, teacher.PassWord);
            string path = TeacherPath;
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                TeacherData data = formatter.Deserialize(stream) as TeacherData;
                stream.Close();
                return data;
            }
            else
            {
                Debug.LogError("Save teacher file not found in " + path);
                return null;
            }
        }

        public List<StudentData> GetStudents()
        {
            string[] paths = Directory.GetFiles(Application.persistentDataPath, "*.student");
            List<StudentData> studentList = new List<StudentData>();
            foreach(string path in paths)
            {
                studentList.Add(LoadStudentData(path));
            }
            return studentList;
        }

        public bool ExistData(TeacherData data)
        {
            UpdateTeacherDataPath(data.UserName, data.PassWord);
            if (File.Exists(TeacherPath))
                return true;

            return false;
        }

        public bool ExistData(StudentData data)
        {
            UpdateStudentDataPath(data.FirstName, data.LastName);
            if (File.Exists(StudentPath))
                return true;

            return false;
        }
    }
}
