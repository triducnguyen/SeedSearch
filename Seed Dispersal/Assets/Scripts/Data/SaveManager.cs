using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace SeedSearch
{
    public class SaveManager : Singleton<SaveManager>
    {
        public StudentData studentProfile;
        private string jsonPath;

        // Start is called before the first frame update
        void Start()
        {

        }

        void UpdateDataPath() => jsonPath = string.Format("{0}/{1}.json", Application.persistentDataPath, studentProfile.UserName);
    }
}
