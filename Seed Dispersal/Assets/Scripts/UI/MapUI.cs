using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SeedSearch
{
    public class MapUI : MonoBehaviour
    {
        [SerializeField] private List<Step> steps;
        [SerializeField] private int currentStep;
        public List<AudioClip> narrators;
        public TMP_Text description;
        private void OnEnable()
        {
            steps = Gamemanager.Instance.steps;
            foreach (Step obj in steps)
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
        public void UnlockVocab(string vocab)
        {
            foreach(Vocabulary vob in Gamemanager.Instance.firstMapVocabulariesData)
            {
                if(vob.name == vocab)
                {
                    vob.IsUnlocked = true;
                }
            }
            foreach (Vocabulary vob in Gamemanager.Instance.secondMapVocabulariesData)
            {
                if (vob.name == vocab)
                {
                    vob.IsUnlocked = true;
                }
            }
        }

        public void Step(float wait)
        {
            StartCoroutine(narrator(wait));
        }

        public void ShowDescription()
        {
            description.text = steps[currentStep].description;
        }

        public void PlayNarrator()
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = narrators[currentStep];
            audioSource.Play();
        }

        public IEnumerator narrator(float wait)
        {
            yield return new WaitForSeconds(wait);
            currentStep++;
            gameprogress();
            steps[currentStep].IsUnlocked = true;
            GameObject inSceneObj = gameObject.transform.Find(steps[currentStep].name).gameObject;
            inSceneObj.SetActive(true);
            description.text = "";
        }

        public GameObject tapToMoveBee, secondtaptomovebee, seedDisperse, badger, cm5, seed, rose;
        void Start(){
            gameprogress();
        }
        private void gameprogress(){
            if(currentStep == 0){
                tapToMoveBee.SetActive(true);
                secondtaptomovebee.SetActive(false);
            }else if(currentStep == 1){
                tapToMoveBee.SetActive(false);
                secondtaptomovebee.SetActive(true);
            }else if(currentStep == 2){
                secondtaptomovebee.SetActive(false);
                seedDisperse.SetActive(true);
            }else if (currentStep == 3){
                badger.SetActive(true);
            }else if (currentStep == 4){
                seed.SetActive(true);
                //badger.SetActive(true);
            }else if (currentStep == 5){
                //cm5.SetActive(true);
                seed.SetActive(false);
                rose.SetActive(true);
            }
        }
    }
}
