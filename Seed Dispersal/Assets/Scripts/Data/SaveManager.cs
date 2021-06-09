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

        void UpdateStudentDataPath(string studentName) => StudentPath = string.Format("{0}/{1}/{2}.student", Application.persistentDataPath, "student", studentName);
        void UpdateTeacherDataPath(string teacherName,string password) => TeacherPath = string.Format("{0}/{1}{2}{3}.data", Application.persistentDataPath, "teacher", teacherName,password);


        //Create and save Student data
        public void SaveStudentFile(StudentData student)
        {
            UpdateStudentDataPath(student.UserName);
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

        public StudentData LoadStudentData(StudentData student)
        {
            UpdateStudentDataPath(student.UserName);
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

        public bool ExistData(TeacherData data)
        {
            UpdateTeacherDataPath(data.UserName, data.PassWord);
            if (File.Exists(TeacherPath))
                return true;

            return false;
        }

        public bool ExistData(StudentData data)
        {
            UpdateStudentDataPath(data.UserName);
            if (File.Exists(StudentPath))
                return true;

            return false;
        }
    }
}
