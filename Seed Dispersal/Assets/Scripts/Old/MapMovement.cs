using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SeedSearch
{

    public class MapMovement : MonoBehaviour
    {
        public GameObject mapUp;
        public GameObject vocabUp;
        public GameObject mapDown;
        public GameObject vocabDown;
        public GameObject definition;
        public GameObject suggestion;
        public GameObject suggestion2;

        void Start()
        {
            mapUp.SetActive(false);
            vocabUp.SetActive(false);
        }

        public void MapController1()
        {
            mapUp.SetActive(true);
            mapDown.SetActive(false);
            if (suggestion.activeSelf)
            {
                suggestion.SetActive(false);
            }
            if (vocabUp.activeSelf)
            {
                vocabUp.SetActive(false);
                vocabDown.SetActive(true);
            }
        }

        public void MapController2()
        {
            mapUp.SetActive(false);
            mapDown.SetActive(true);
            if (vocabUp.activeSelf)
            {
                vocabUp.SetActive(false);
                vocabDown.SetActive(true);
            }

        }
        public void VocabController1()
        {
            vocabUp.SetActive(true);
            vocabDown.SetActive(false);
            if (suggestion2.activeSelf)
            {
                suggestion2.SetActive(false);
            }
            if (mapUp.activeSelf)
            {
                mapUp.SetActive(false);
                mapDown.SetActive(true);
            }
        }

        public void VocabController2()
        {
            if (!Gamemanager.Instance.isDefinitionOn)
            {
                vocabUp.SetActive(false);
                vocabDown.SetActive(true);
                if (mapUp.activeSelf)
                {
                    mapUp.SetActive(false);
                    mapDown.SetActive(true);
                }
            } else
            {
                definition.SetActive(false);
                Gamemanager.Instance.isDefinitionOn = false;
            }
        }

        public void ActiveSuggestionTwo()
        {
            suggestion2.SetActive(true);
        }

        private void FixedUpdate()
        {
            if(Gamemanager.Instance.currentStep > 0)
            {
                foreach (Vocabulary vocab in Gamemanager.Instance.steps[Gamemanager.Instance.currentStep - 1].Vocabularies)
                {
                    if (!vocabUp.activeSelf && !vocab.Seen)
                    {
                        suggestion2.SetActive(true);
                    }

                }
            }

        }
    }
}
