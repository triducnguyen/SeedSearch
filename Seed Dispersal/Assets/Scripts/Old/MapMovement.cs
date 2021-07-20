using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        private GameObject subtitle;
        private bool clicked = false;
        private float time;
        private string previousSub;
        private Coroutine previousCoroutine;
        private void Awake()
        {
            SoundManager.Instance.PlayAudio("01_TutorialIntro");
            subtitle = GameObject.Find("Subtitles");
            time = 18f;
            Subtitle("All plants begin as a seed. A seed is the part of a plant that can grow to become a new plant. " +
                "Like you humans, plants go through a life cycle,       changing and growing as they get older. " +
                "In order for these seeds to spread and new plants to grow, they depend on forces of nature to move " +
                "them around and for pollination.");
        }

        void Start()
        {
            mapUp.SetActive(false);
            vocabUp.SetActive(false);
        }

        #region MapMovement
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
        #endregion

        public void ActiveSuggestionTwo()
        {
            suggestion2.SetActive(true);
        }

        public void Subtitle(string sub)
        {
            if (clicked && Gamemanager.Instance.currentStep < 6)
            {
                StopCoroutine(previousCoroutine);
                Debug.Log("get in");
            }
            previousCoroutine = StartCoroutine(PlaySubtitle(sub));
        }

        public void SetTime(float variable)
        {
            time = variable;
        }

        IEnumerator PlaySubtitle(string sub)
        {
            clicked = true;
            Debug.Log(time);
            subtitle.SetActive(true);
            previousSub = sub;
            if (sub.Length > 400)
            {
                subtitle.GetComponent<TMP_Text>().text = sub.Substring(0, 150);
                yield return new WaitForSeconds(time / 3);

                subtitle.GetComponent<TMP_Text>().text = sub.Substring(150, 150);
                yield return new WaitForSeconds(time / 3);

                subtitle.GetComponent<TMP_Text>().text = sub.Substring(300, sub.Length - 300);
                yield return new WaitForSeconds(time / 3);
                subtitle.GetComponent<TMP_Text>().text = "";                
            }
            else if(sub.Length > 150)
            {
                subtitle.GetComponent<TMP_Text>().text = sub.Substring(0,150);
                yield return new WaitForSeconds(time/2);

                subtitle.GetComponent<TMP_Text>().text = sub.Substring(150, sub.Length - 150);
                yield return new WaitForSeconds(time/2);
                subtitle.GetComponent<TMP_Text>().text = "";
            }
            else
            {
                subtitle.GetComponent<TMP_Text>().text = sub;
                yield return new WaitForSeconds(time);
                subtitle.GetComponent<TMP_Text>().text = "";
            }
            clicked = false;
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
                if(Gamemanager.Instance.currentStep == 6 && Gamemanager.Instance.finished)
                {
                    Subtitle("And then, it blooms. Here it sits, next to the other flowers of this meadow, " +
                        "ready for the cycle to continue. Alright! Now that you’ve got your roots on Seed Dispersal " +
                        "and Pollination, we’re ready for your help!");
                    Gamemanager.Instance.finished = false;
                }
            }
            

        }
    }
}
