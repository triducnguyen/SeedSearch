using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SeedSearch
{
    public class VocabButton : MonoBehaviour
    {
        public Vocabs vocab;

        public void Definition(GameObject obj)
        {
            Gamemanager.Instance.isDefinitionOn = true;
            foreach(Vocabulary vocabulary in Gamemanager.Instance.vocabulariesDataOne)
            {
                if(vocab.vocab == vocabulary.name)
                {
                    vocabulary.Seen = true;
                }
            }
            foreach (Vocabulary vocabulary in Gamemanager.Instance.vocabulariesDataTwo)
            {
                if (vocab.vocab == vocabulary.name)
                {
                    vocabulary.Seen = true;
                }
            }
            obj.SetActive(true);
            obj.transform.GetChild(0).GetComponent<TMP_Text>().text = vocab.definition;
        }
    }
}