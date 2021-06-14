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
    // Start is called before the first frame update
    void Start()
    {
        //SaveManager.Instance.LoadStudentData(newStudent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //John Add
    public void startHintTimer(string currentSection){
        section = currentSection;
        starttime = Time.deltaTime;
        StartCoroutine(Hinttimer());
    }
    public void endtimer(){
        endtime = Time.deltaTime;
        overalltime = endtime - starttime;
        times.Add(overalltime);
    }
    private string section;
    public float wait;
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
        
        inloop = true;
        while (inloop){
            for(int i = 0; i < times.Count; i++){
                if(i >= times.Count){ inloop = false;}
                if(times[i] > median * 1.5 || times[i] < median * 0.5){
                    times.RemoveAt(i);
                    break;
                }
            }
        }
        
        while(times.Count > timerstorecount){
            times.RemoveAt(0);
        }


        //SaveManager.Instance.SaveStudentFile(newStudent);
           
    }
    private float median;
    public void loadtimes(){
        //insert load function
        wait = times.Average();
    }
}
