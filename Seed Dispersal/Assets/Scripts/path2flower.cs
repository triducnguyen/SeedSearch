using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch{
public class path2flower : MonoBehaviour
{
    public GameObject pollen;
    private string flowerstate = "unpollinated";
    private John_gamemanager_Path02 gamemanager;
    void Start(){
        gamemanager = GameObject.FindObjectOfType<John_gamemanager_Path02>();
        
    }
    void OnTriggerEnter(Collider other){
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
    }
}
}
