using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch{
    public class flower : MonoBehaviour
{
    public GameObject pollen;
    public GameObject bee;

    private Gameplay Game;
    private string flowerstate = "unpolinated with pollen";

    // Start is called before the first frame update
    void Start()
    {
        Game = GameObject.FindObjectOfType<Gameplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pollinate(){
        if(Vector3.Distance(bee.transform.position, this.transform.position) < 0.01f){
            if(flowerstate == "unpolinated with pollen"){
                if(Game.haspollen == true){
                    flowerstate = "pollinated no pollen";
                } else{
                    Game.haspollen = true;
                    flowerstate = "no pollen";
                }
            } else if(flowerstate == "no pollen" && Game.haspollen == true){
                flowerstate = "pollinated no pollen";
            }
        }
    }

}
}
