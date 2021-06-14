using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public StudentData studentProfile;
    private List<float> times;
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
    public void savetimes(){
        while(times.Count > timerstorecount){
            times.Remove(times[0]);
        }
        //SaveManager.Instance.SaveStudentFile(newStudent);
           
    }
}
