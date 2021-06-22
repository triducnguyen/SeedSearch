using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SeedSearch
{
    public class FirstMapUI : MonoBehaviour
    {
        [SerializeField] private List<Vocabulary> vocabularies;

        private void OnEnable()
        {
            vocabularies = Gamemanager.Instance.firstMapVocabulariesData;
            foreach (Vocabulary obj in vocabularies)
            {
                if (obj.IsUnlocked)
                {
                    obj.button.SetActive(true);
                }
            }

        }
    }
}
