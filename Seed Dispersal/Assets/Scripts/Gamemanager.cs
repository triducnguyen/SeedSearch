using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using System.Linq;
 
using UnityEngine.SceneManagement;

namespace SeedSearch{
    public class Gamemanager : Singleton<Gamemanager>
    {
        [SerializeField] public StudentData currentStudent;
        [SerializeField] private List<float> times = new List<float>(1);
        [SerializeField] private List<float> alltimes = new List<float>(1);
        [SerializeField] private List<float> sortedtimes;
        [SerializeField] private List<float> MT;
        [SerializeField] private float timerstorecount;
        [SerializeField] private float median;

        private float starttime;
        private float endtime;
        private float overalltime;
        private float clock = 0;

        public float Clock { get => clock; }

        public float timescalar;
        public Animator fillscreenwithcoloranimator;
        public GameObject fillscreencolor;
        public GameObject stillther;
        public float overtime;

        private string usercontinue;
        public float wait;
        public float avg;

        [Header("Hint")]
        public GameObject hintObject;
        public GameObject hintSuggest;
        public Text hint;

        [Header("SceneName")]
        public string currentScene;

        [Header("Vocabularies")]
        public List<Vocabulary> firstMapVocabulariesData;
        public List<Vocabulary> secondMapVocabulariesData;
        public List<Vocabulary> VocabulariesData;
        public bool isDefinitionOn;

        [Header("Maps/Steps")]
        public List<Step> steps;
        private void Start()
        {
            currentScene = SceneManager.GetActiveScene().name;
            stillther.SetActive(false);
            fillscreencolor.SetActive(false);
        }


        // Update is called once per frame
        void Update()
        {
            if(currentScene != "UI") { 
                clock += Time.deltaTime;
                if(clock - starttime > overtime * 60 && usercontinue == "after5" && clock != 0){
                    fillscreencolor.SetActive(true);
                    fillscreenwithcoloranimator.SetBool("Fillscreenwithcolor", true && clock != 0);
                } else if(clock - starttime > (overtime * 60)/2 && usercontinue == "below5"){
                    //stillther.SetActive(true);
                }
            }
        }

        //John Add
    
        //Start Here
        public void StartHintTimer(string currentSection){
            clock = 0;
            //starttime = Time.deltaTime;
            starttime = clock;
            StartCoroutine(Hinttimer());
            Debug.Log("start time at: " + starttime);
            usercontinue = "below5";
        }

        //End Here
        public void EndTimer(){
            //endtime = Time.deltaTime;
            endtime = clock;
            overalltime = endtime - starttime;
            times.Add(overalltime);
            alltimes.Add(overalltime);
            Debug.Log("end time: " + endtime + " And overall time: " + overalltime);
            //hintObject.SetActive(false);
            //fillscreenwithcoloranimator.SetBool("Fillscreenwithcolor", false);
            SaveTimes();
        }

        IEnumerator Hinttimer(){
            yield return new WaitForSeconds(wait);
            Debug.Log("Hint now appearing" + wait);
            //hintObject.SetActive(true);
            //hint.text = section;
            
        }

        public void SaveTimes(){
            Debug.Log("saving");
            float[] passarray = new float[times.Count];
            times.CopyTo(passarray);
            sortedtimes = passarray.ToList();

            sortedtimes.Sort();
            if(sortedtimes.Count % 2 == 0){
                median = sortedtimes[sortedtimes.Count/2];
            }else{
                median = sortedtimes[sortedtimes.Count/2 + 1];
            }
            if(times.Count > timerstorecount / 2){
            
                for(int i = 0; i < sortedtimes.Count; i++){
                    if(sortedtimes[i] > median * 1.5 || sortedtimes[i] < median * 0.5){
                        times.Remove(sortedtimes[i]);
                        Debug.Log("removing value " + sortedtimes[i]);
                    }
                }

                while(times.Count > timerstorecount){
                    times.RemoveAt(0);
                }            
            }
            times.Remove(0);
            alltimes.Remove(0);

            avg = times.Average();
            wait = avg * 2;
        
            currentStudent.Times =  times;
            currentStudent.OverallTimes = alltimes;
            //SaveManager.Instance.SaveStudentFile(currentStudent); 
        }
        
        public void LoadTimes(){
            Debug.Log("Loading");
            //SaveManager.Instance.LoadStudentData(currentStudent);
            if(currentStudent.Times != null){
                times = currentStudent.Times;
                alltimes = currentStudent.OverallTimes;
            } else{
                times.Add(1f);
                alltimes.Add(1f);
            }       
            avg = times.Average();
            wait = avg * 2;   
        }

        public void ClearTimes(){
            /*float[] passarray = new float[times.Count];
            MT.CopyTo(passarray);
            times = passarray.ToList();
            alltimes = passarray.ToList();*/
            while(times.Count > 0){
                    times.RemoveAt(0);
            }while(alltimes.Count > 0){
                    alltimes.RemoveAt(0);
            }
            times.Add(1f);
            alltimes.Add(1f);
            currentStudent.Times =  times;
            currentStudent.OverallTimes = alltimes;
            SaveManager.Instance.SaveStudentFile(currentStudent); 
            LoadTimes();
        }

        public void Relog(){
            /*if(firstnameI.text == firstname && lastnameI.text == lastname){
                hintObject.SetActive(false);
            }*/
            if(usercontinue == "below5"){
                usercontinue = "after5";            
                stillther.SetActive(false);
            }else if(usercontinue == "after5"){
                usercontinue = "after10";
                fillscreencolor.SetActive(false);
            }else{
                Debug.Log("error with relog");
            }
        }
    }
}
