using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using System.Linq;
 
using UnityEngine.SceneManagement;

namespace SeedSearch{
public class Gamemanager : MonoBehaviour
{
    [System.NonSerialized] public StudentData currentStudent;
    [SerializeField] private List<float> times = new List<float>(1);
    [SerializeField] private List<float> alltimes = new List<float>(1);
    [SerializeField] private List<float> sortedtimes;
    [SerializeField] private List<float> MT;
   
    public float timescalar;
    private float starttime;
    private float endtime;
    private float overalltime;

    public Animator fillscreenwithcoloranimator;
    public GameObject fillscreencolor;
    public GameObject stillther;

    private float clock = 0;
    public float overtime;
    
    [Header("TimerTesting")]
    public List<float> DUMMY; 
    public Text info;

    public InputField firstnameI;
    public InputField lastnameI;
    private string firstname;
    private string lastname;
    private string usercontinue;

    void Awake(){
        loadtimes();
    }
    void Start()
    {
        //currentStudent = SaveManager.Instance.studentProfile;
        //loadtimes();
        hintObject.SetActive(false);
        fillscreencolor.SetActive(false);
        stillther.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        if(clock - starttime > overtime * 60 && usercontinue == "after5"){
            fillscreencolor.SetActive(true);
            fillscreenwithcoloranimator.SetBool("Fillscreenwithcolor", true);
        } else if(clock - starttime > (overtime * 60)/2 && usercontinue == "below5"){
            stillther.SetActive(true);
        }
    }

    //John Add
    public void startHintTimer(string currentSection){
        section = currentSection;
        clock = 0;
        //starttime = Time.deltaTime;
        starttime = clock;
        StartCoroutine(Hinttimer());
        Debug.Log("start time at: " + starttime);
        usercontinue = "below5";
    }
    public void endtimer(){
        //endtime = Time.deltaTime;
        endtime = clock;
        overalltime = endtime - starttime;
        times.Add(overalltime);
        alltimes.Add(overalltime);
        Debug.Log("end time: " + endtime + " And overall time: " + overalltime);
        hintObject.SetActive(false);
        fillscreenwithcoloranimator.SetBool("Fillscreenwithcolor", false);
        savetimes();
    }
    private string section;
    public float wait;
    public float avg;
    public GameObject hintObject;
    public Text hint;
    IEnumerator Hinttimer(){
        yield return new WaitForSeconds(wait);
        Debug.Log("Hint now appearing" + wait);
        hintObject.SetActive(true);
        hint.text = section;
    }
    [SerializeField]
    private float timerstorecount;
    private bool inloop = false;
    public void savetimes(){
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
        SaveManager.Instance.SaveStudentFile(currentStudent); 
    }
    [SerializeField] private float median;
    public void loadtimes(){
        Debug.Log("Loading");
        //SaveManager.Instance.LoadStudentData(currentStudent);
        currentStudent = SaveManager.Instance.LoadStudentData(SaveManager.Instance.studentProfile);
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

    public void cleartimes(){
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
        loadtimes();
    }
    public void gotoquestions(){
        SceneManager.LoadScene("StoreInput");
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
