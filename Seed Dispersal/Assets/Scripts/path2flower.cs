using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch{
public class path2flower : MonoBehaviour
{
    public GameObject pollen;
    private string flowerstate = "unpollinated";
    private John_gamemanager_Path02 gamemanager;
    public GameObject bee;
    private float Distance = 0.1f;
    void Start(){
        gamemanager = GameObject.FindObjectOfType<John_gamemanager_Path02>();
        
    }
    void Update(){
        if(flowerstate == "unpollinated"){
            if(Vector3.Distance(pollen.transform.position + new Vector3(0, 0.05f, 0), bee.transform.position) <= Distance){
                if(gamemanager.beeF == false){
                    if(gamemanager.beeP == false){
                        gamemanager.beeP = true;
                    }else{
                        gamemanager.beeP = false;
                    }
                    gamemanager.beepollentoggle();
                    flowerstate = "pollinated";
                    pollen.SetActive(false);
                }
            }
        }
    }
    /*void OnTriggerEnter(Collider other){
        if(gamemanager.beeF == false && flowerstate == "unpollinated"){
            if(gamemanager.beeP == false){
                gamemanager.beeP = true;
                gamemanager.beepollentoggle();
            }else{
                gamemanager.beeP = false;
                gamemanager.beepollentoggle();
            }
            flowerstate = "pollinated";
            pollen.SetActive(false);
        }
    }*/
}
}
