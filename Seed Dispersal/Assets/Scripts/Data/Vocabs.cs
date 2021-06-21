using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch
{
    [CreateAssetMenu(fileName = "Vocab",menuName ="Vocab/Data")]
    public class Vocabs : ScriptableObject
    {
        public string vocab;
        public string definition;
    }
}