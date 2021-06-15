using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using System.Linq;

public class Gamemanager : MonoBehaviour
{
    [System.NonSerialized] public StudentData studentProfile;
    [SerializeField] private List<float> times;
    [SerializeField] private List<float> sortedtimes;
   
    public float timescalar;
    private float starttime;
    private float endtime;
    private float overalltime;

    public Animator fillscreenwithcoloranimator;
    
    [Header("TimerTesting")]
    public List<float> DUMMY; 

    // Start is called before the first frame update
    void Start()
    {
        //SaveManager.Instance.LoadStudentData(newStudent);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(endtime - starttime > 10*60){
            fillscreenwithcoloranimator.SetBool("Fillscreenwithcolor", true);
        }
    }

    //John Add
    public void startHintTimer(string currentSection){
        section = currentSection;
        starttime = Time.deltaTime;
        StartCoroutine(Hinttimer());
        Debug.Log("start time: " + starttime);
    }
    public void endtimer(){
        endtime = Time.deltaTime;
        overalltime = endtime - starttime;
        times.Add(overalltime);
        Debug.Log("end time: " + endtime + " And overall time: " + overalltime);
    }
    private string section;
    public float wait;
    public float avg;
    public GameObject hintObject;
    public Text hint;
    IEnumerator Hinttimer(){
        yield return new WaitForSeconds(wait);
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


        //SaveManager.Instance.SaveStudentFile(newStudent); 
    }
    [SerializeField] private float median;
    public void loadtimes(){
        Debug.Log("Loading");
        
        float[] passarray = new float[DUMMY.Count];
        DUMMY.CopyTo(passarray);
        times = passarray.ToList();
        

        //comment above
        
        avg = times.Average();
        wait = avg * 2;
    }
}
