using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SeedSearch
{
    public class SecondMapUI : MonoBehaviour
    {
        [SerializeField] private List<Vocabulary> vocabularies;

        private void OnEnable()
        {
            vocabularies = Gamemanager.Instance.secondMapVocabulariesData;
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
