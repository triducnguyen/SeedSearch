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
        void Start()
        {

        }

        void UpdateStudentDataPath() => StudentPath = string.Format("{0}/{1}/{2}.data", Application.persistentDataPath, "student", studentProfile.UserName);
        void UpdateTeacherDataPath() => TeacherPath = string.Format("{0}/{1}/{2}/{3}.data", Application.persistentDataPath, "teacher", teacherProfile.UserName,teacherProfile.PassWord);

        //Create and save Student data
        public void SaveStudentFile(StudentData student)
        {
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
            //Override the same file if the file exist
            if (File.Exists(TeacherPath))
                File.Delete(TeacherPath);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(TeacherPath, FileMode.Create);

            formatter.Serialize(stream, teacher);
            stream.Close();
        }

        public StudentData LoadStudentData(StudentData student)
        {
            string path = string.Format("{0}/{1}/{2}.data", Application.persistentDataPath, "student", student.UserName);
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                StudentData data = formatter.Deserialize(stream) as StudentData;

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
            string path = string.Format("{0}/{1}/{2}/{3}.data", Application.persistentDataPath, "teacher", teacher.UserName,teacher.PassWord);
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                TeacherData data = formatter.Deserialize(stream) as TeacherData;

                return data;
            }
            else
            {
                Debug.LogError("Save teacher file not found in " + path);
                return null;
            }
        }
    }
}
