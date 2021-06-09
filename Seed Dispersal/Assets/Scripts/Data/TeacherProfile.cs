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
        public GameObject editDone;
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

