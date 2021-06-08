using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace SeedSearch
{
    public class TeacherProfile : MonoBehaviour
    {
        public Text UserName;
        public Text Name;

        [Header("Edit Name")]
        public TMP_InputField editNameField;
        public Button editButton;

        [SerializeField] private TeacherData teacherProfile;
        // Start is called before the first frame update

        void OnEnable()
        {
            teacherProfile = SaveManager.Instance.teacherProfile;
            Initialize();
        }

        void Initialize()
        {
            UserName.text = teacherProfile.UserName;
            if(teacherProfile.Name == null)
                Name.text = teacherProfile.UserName;
            else
                Name.text = teacherProfile.Name;
        }

    }
}

