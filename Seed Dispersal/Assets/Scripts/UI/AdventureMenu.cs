using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdventureMenu : MonoBehaviour
{
    [SerializeField] public int[] levelstatus; // 0 if locked, 1 if incomplete, 2 if complete;


    [SerializeField] private List<GameObject> Check = new List<GameObject>();
    [SerializeField] private List<GameObject> unCheck = new List<GameObject>();
    [SerializeField] private List<GameObject> lockmode = new List<GameObject>();
    
    void Start()
    {
        foreach(int i in levelstatus){
            if(levelstatus[i] == 0){ //locked
                Check[i].SetActive(false);
                unCheck[i].SetActive(false);
                lockmode[i].SetActive(true);
            }else if(levelstatus[i] == 1){ // incomplete
                Check[i].SetActive(false);
                unCheck[i].SetActive(true);
                lockmode[i].SetActive(false);
            }else if(levelstatus[i] == 2){ // complete
                Check[i].SetActive(true);
                unCheck[i].SetActive(false);
                lockmode[i].SetActive(false);
            }else { Debug.Log("Adventure Menu level has incorrect status");}
        }
    }

    public void switchscene(string scene){
        SceneManager.LoadScene(scene);
    }
}
