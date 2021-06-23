using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch
{
    [System.Serializable]
    public class Vocabulary
    {
        public string name;
        public GameObject button;
        [SerializeField] private bool isUnlocked;
        public bool IsUnlocked { get => isUnlocked; set => isUnlocked = value; }

    }
}