using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using System.Linq;

namespace SeedSearch{
public class Gamemanager : MonoBehaviour
{
    [System.NonSerialized] public StudentData currentStudent;
    [SerializeField] private List<float> times;
    [SerializeField] private List<float> alltimes;
    [SerializeField] private List<float> sortedtimes;
   
    public float timescalar;
    private float starttime;
    private float endtime;
    private float overalltime;

    public Animator fillscreenwithcoloranimator;

    private float clock = 0;
    public float overtime;
    
    [Header("TimerTesting")]
    public List<float> DUMMY; 

    void Awake(){
        loadtimes();
    }
    void Start()
    {
        //currentStudent = SaveManager.Instance.studentProfile;
        
        hintObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        if(clock - starttime > overtime * 60){
            fillscreenwithcoloranimator.SetBool("Fillscreenwithcolor", true);
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
    }
    public void endtimer(){
        //endtime = Time.deltaTime;
        endtime = clock;
        overalltime = endtime - starttime;
        times.Add(overalltime);
        alltimes.Add(overalltime);
        Debug.Log("end time: " + endtime + " And overall time: " + overalltime);
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
        if(times.Count > timerstorecount / 4){
            
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

        currentStudent.Times =  times;
        currentStudent.Times = alltimes;
        SaveManager.Instance.SaveStudentFile(currentStudent); 
    }
    [SerializeField] private float median;
    public void loadtimes(){
        Debug.Log("Loading");
        //SaveManager.Instance.LoadStudentData(currentStudent);
        currentStudent = SaveManager.Instance.LoadStudentData(SaveManager.Instance.studentProfile);
        times = currentStudent.Times;
        alltimes = currentStudent.OverallTimes;

        if(times == null){
            times.Add(1);
            alltimes.Add(1);
        }

        /*float[] passarray = new float[DUMMY.Count];
        DUMMY.CopyTo(passarray);
        times = passarray.ToList();
        float[] passarray2 = new float[DUMMY.Count];
        DUMMY.CopyTo(passarray2);
        alltimes = passarray2.ToList();*/
        
        avg = times.Average();
        wait = avg * 2;

        
    }
}
}
