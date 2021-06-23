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
                GameObject inSceneObj = gameObject.transform.Find(obj.name).gameObject;
                if (inSceneObj != null)
                {
                    if (obj.IsUnlocked)
                    {
                        inSceneObj.SetActive(true);
                    }
                    else
                    {
                        inSceneObj.SetActive(false);
                    }
                }
                   
            }

        }
    }
}
