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
        [SerializeField] private int currentAnimation;
        public List<GameObject> animations;
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

        private void OnDisable()
        {
            foreach(GameObject obj in animations)
            {
                obj.GetComponent<Animator>().SetBool("ZoomIn", true);
                obj.SetActive(false);
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

        public void CurrentStep(int step)
        {
            currentAnimation = step;
        }

        public void Step(float wait)
        {
            StartCoroutine(narrator(wait));
        }

        public void ShowDescription()
        {
            description.text = steps[currentAnimation].description;
        }


        public IEnumerator narrator(float wait)
        {
            Debug.Log(currentAnimation);

            animations[currentAnimation].SetActive(true);
            Animator anim = animations[currentAnimation].GetComponent<Animator>();
            anim.SetBool("ZoomOut", true);

            yield return new WaitForSeconds(wait);

            anim.SetBool("ZoomIn", true);
            yield return new WaitForSeconds(2f);
            animations[currentAnimation].SetActive(false);

            if (currentAnimation == currentStep && currentStep != 5)
            {
                currentStep++;
                gameprogress();
                steps[currentStep].IsUnlocked = true;
                GameObject inSceneObj = gameObject.transform.Find(steps[currentStep].name).gameObject;
                inSceneObj.SetActive(true);
                description.text = "";
            }
        }

        public GameObject tapToMoveBee, secondtaptomovebee, seedDisperse, badger, seed, rose;
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
                //seedDisperse.SetActive(true);
            }else if (currentStep == 3){
                badger.SetActive(true);
            }else if (currentStep == 4){
                seedDisperse.SetActive(true);
            }else if (currentStep == 5){
                //cm5.SetActive(true);
                seed.SetActive(false);
                rose.SetActive(true);
            }
        }
    }
}
