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
            obj.SetActive(true);
            obj.transform.GetChild(0).GetComponent<TMP_Text>().text = vocab.definition;
        }
    }
}