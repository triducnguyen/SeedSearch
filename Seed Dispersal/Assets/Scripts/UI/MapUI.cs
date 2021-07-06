using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
            for (int i = 1; i < steps.Count; i++)
            {
                GameObject inSceneObj = gameObject.transform.Find(steps[i].name).gameObject;
                if (inSceneObj != null)
                {
                    if (steps[i].IsUnlocked && CheckSeen(steps[i - 1]))
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
            Vocabulary vocabulary = new Vocabulary();
            foreach(Vocabulary vob in Gamemanager.Instance.vocabulariesDataOne)
            {
                if(vob.name == vocab)
                {
                    vob.IsUnlocked = true;
                    vocabulary = vob;
                }
            }
            foreach (Vocabulary vob in Gamemanager.Instance.vocabulariesDataTwo)
            {
                if (vob.name == vocab)
                {
                    vob.IsUnlocked = true;
                    vocabulary = vob;
                }
            }
            Gamemanager.Instance.steps[currentStep].Vocabularies.Add(vocabulary);

        }


        public void CurrentStep(int step)
        {
            currentAnimation = step;
            currentStep = step;
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
            Gamemanager.Instance.WaitToUnlockStep(wait, currentStep);
            Debug.Log(currentStep);

            animations[currentAnimation].SetActive(true);
            Animator anim = animations[currentAnimation].GetComponent<Animator>();
            anim.SetBool("ZoomOut", true);
            yield return new WaitForSeconds(2f);

            anim.SetBool("ZoomIn", true);
            yield return new WaitForSeconds(2f);
            animations[currentAnimation].SetActive(false);

            float remainTime = wait - 4f;
            yield return new WaitForSeconds(remainTime);
            description.text = "";

            //if (currentAnimation == currentStep && currentStep != 5)
            //{
            //    currentStep++;
            //    gameprogress();
            //    steps[currentStep].IsUnlocked = true;
            //    GameObject inSceneObj = gameObject.transform.Find(steps[currentStep].name).gameObject;
            //    inSceneObj.SetActive(true);
            //    description.text = "";
            //}
        }

        private void FixedUpdate()
        {
            for(int i = 1;i < steps.Count; i++)
            {
                GameObject inSceneObj = gameObject.transform.Find(steps[i].name).gameObject;
                if (inSceneObj != null)
                {
                    if (steps[i].IsUnlocked && CheckSeen(steps[i-1]))
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

        private bool CheckSeen(Step step)
        {
            foreach(Vocabulary vocab in step.Vocabularies)
            {
                if(vocab.Seen == false)
                {
                    return false;
                }
            }
            return true;
        }

        public GameObject lobbybutton, tapToMoveBee, secondtaptomovebee, seedDisperse, badger, seed, rose;
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
                //seedDisperse.SetActive(true);
            }else if (currentStep == 5){
                //cm5.SetActive(true);
                seed.SetActive(false);
                rose.SetActive(true);
                lobbybutton.SetActive(true);
            }
        }

        public void changescene(string desiredscene){
            SceneManager.LoadScene(desiredscene);
        }
    }
}
