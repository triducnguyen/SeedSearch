using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace SeedSearch{
public class AdventureMenu : MonoBehaviour
{
    private StudentData currentStudent;
    [SerializeField] public int[] levelstatus; // 0 if locked, 1 if incomplete, 2 if complete;


    [SerializeField] private List<GameObject> Check = new List<GameObject>();
    [SerializeField] private List<GameObject> unCheck = new List<GameObject>();
    [SerializeField] private List<GameObject> lockmode = new List<GameObject>();

    [SerializeField] private List<string> levelscene = new List<string>();
    
    void Start()
    {
        SaveManager.Instance.LoadStudentData(currentStudent);
        if(currentStudent.Levelprogress != null){
            levelstatus = currentStudent.Levelprogress;
        }
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

    public void switchscene(int level){
        if(levelstatus[level] != 0){
            SceneManager.LoadScene(levelscene[level]);
        }else{
            Debug.Log("level is locked");
        }
    }

}
}
