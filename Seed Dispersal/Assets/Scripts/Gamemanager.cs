using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using System.Linq;

public class Gamemanager : MonoBehaviour
{
    public StudentData studentProfile;
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
    private bool Reloop = false;
    public void savetimes(){
        //sortedtimes = times;
        //List<float> sortedtimes = times.ToList();
        List<float> sortedtimes = times;
        //List<float> sortedtimes = new List<float>(times);
        sortedtimes.Sort();
        if(sortedtimes.Count % 2 == 0){
            median = sortedtimes[sortedtimes.Count/2];
        }else{
            median = sortedtimes[sortedtimes.Count/2 + 1];
        }
        if(times.Count > timerstorecount / 4){
            Reloop = true;
            Debug.Log("starting for loop");
            //while (Reloop){
                for(int i = 0; i < times.Count; i++){
                    if(times.Count > i){
                        if(times[i] > median * 1.5 || times[i] < median * 0.5){
                            times.RemoveAt(i);
                            Debug.Log("removing value " + times[i]);
                            Reloop = true;
                            i--;
                        }
                    } else{Debug.Log("EROR");}
                    //if(i >= times.Count){ inloop = false;}
                    Debug.Log(i);
                }
            //}
            
            
            /*while(times.Count > timerstorecount){
                times.RemoveAt(0);
            }*/
            
        }


        //SaveManager.Instance.SaveStudentFile(newStudent); 
    }
    [SerializeField] private float median;
    public void loadtimes(){
        //times = DUMMY;
        //List<float> times = DUMMY.ToList();
        List<float> times = DUMMY;
        //List<float> times = new List<float>(DUMMY); 

        //comment above
        
        avg = times.Average();
        wait = avg * 2;
    }
}
