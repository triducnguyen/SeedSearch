using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startmenu : MonoBehaviour
{
    [SerializeField] GameObject beware;
    [SerializeField] GameObject parental;
    void Start()
    {
        StartCoroutine(warnings(6f));
    }
    IEnumerator warnings(float time){
        while(1 == 1){
            beware.SetActive(true);
            parental.SetActive(false);
            yield return new WaitForSeconds(time);
            beware.SetActive(false);
            parental.SetActive(true);
            yield return new WaitForSeconds(time);
        }
    }

    public void startgame(){
        SceneManager.LoadScene("UI");
    }
}
