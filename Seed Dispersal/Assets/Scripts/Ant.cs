using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SeedSearch{
public class Ant : MonoBehaviour

{   
    private Vector3 anttarget = new Vector3(0, 0, 0);
    private int antI = 0;

    private John_gamemanager_Path02 gamemanager;

    [SerializeField] private GameObject antseed;
    private bool holdseed = true;
    private int droprate = 15;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindObjectOfType<John_gamemanager_Path02>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager.antsstart == true && anttarget == new Vector3(0, 0, 0)){
            anttarget = gamemanager.antwaypoints[antI].transform.position;
            this.transform.LookAt(anttarget);
        }
        if(this.transform.position != anttarget && anttarget != new Vector3(0, 0, 0)){
            gamemanager.antanim.SetBool("Walking", true);
            this.transform.position = Vector3.MoveTowards(this.transform.position, anttarget, gamemanager.antspeed * Time.deltaTime); 
        } else{
            if(anttarget != new Vector3(0, 0, 0)){
                dropseed();
                antI++;
                anttarget = gamemanager.antwaypoints[antI].transform.position;
                this.transform.LookAt(anttarget);
            }else{
            gamemanager.antanim.SetBool("Walking", false);
            }
        }
        if(this.transform.position == gamemanager.antwaypoints[3].transform.position){
            this.gameObject.SetActive(false);
        }
    }
    
    
    void dropseed(){
        if(holdseed == true){
            if(Random.Range(0, 100) <= droprate){
                antseed.transform.parent = null;
                holdseed = false;
            } else{
                droprate = droprate * 2;
            }
        }
    }
    
}
}
