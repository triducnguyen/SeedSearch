using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch
{
    [System.Serializable]
    public class Step
    {
        public string name;
        public string description;
        [SerializeField]private bool isUnlocked;
        [SerializeField] private List<Vocabulary> vocabularies;
        public bool IsUnlocked { get => isUnlocked; set => isUnlocked = value; }
        public List<Vocabulary> Vocabularies { get => vocabularies; set => vocabularies = value; }
    }
}
