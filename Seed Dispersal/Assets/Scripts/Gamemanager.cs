using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using System.Linq;

public class Gamemanager : MonoBehaviour
{
    public StudentData studentProfile;
    private List<float> times;
    private List<float> sortedtimes;
   
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
        List<float> times = new List<float>();
        List<float> sortedtimes = new List<float>();
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
        //times.Add(overalltime);
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
        sortedtimes = times;
        sortedtimes.Sort();
        if(sortedtimes.Count % 2 == 0){
            median = sortedtimes[sortedtimes.Count/2];
        }else{
            median = sortedtimes[sortedtimes.Count/2 + 1];
        }
        if(times.Count > timerstorecount / 4){
            /*inloop = true;
            while (inloop){
                for(int i = 0; i < times.Count; i++){
                    if(i >= times.Count){ inloop = false;}
                    if(times[i] > median * 1.5 || times[i] < median * 0.5){
                        times.RemoveAt(i);
                        break;
                    }
                }
            }*/
            
            while(times.Count > timerstorecount){
                times.RemoveAt(0);
            }
        }


        //SaveManager.Instance.SaveStudentFile(newStudent);


        //comment below
        Debug.Log("Times" + times.ToArray());
        foreach(float time in times)
        {
            Debug.Log(time);
        }
        Debug.Log("sorted");
        foreach(float time in sortedtimes)
        {
            Debug.Log(time);
        }
        Debug.Log("average time" + avg);  
        Debug.Log("Median time" + median);  
    }
    private float median;
    public void loadtimes(){
        times = DUMMY; 

        //comment above
        Debug.Log("init Times");
        foreach(float time in times)
        {
            Debug.Log(time);
        }
        avg = times.Average();
        wait = avg * 2;
    }
}
