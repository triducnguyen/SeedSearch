using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    private float[] alltimes;
    public float timescalar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //John Add
    public void startHintTimer(string currentSection){
        section = currentSection;
        StartCoroutine(Hinttimer());
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
}
