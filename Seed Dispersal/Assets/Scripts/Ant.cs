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
    [SerializeField] private float droprate = 0f;
    private float droprateincrease = 50f;
    private bool antsstart;
    public Animator antanim;

    [System.NonSerialized] public Transform ant;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindObjectOfType<John_gamemanager_Path02>();
        gamemanager.antanim.SetBool("Walking", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager.antselect == this.transform && gamemanager.antsstart == true){
            holdseed = true;
            antsstart = true;
            antseed.SetActive(true);
            gamemanager.antselect = null;
            gamemanager.antsstart = false;
            this.GetComponent<BoxCollider>().enabled = false;
        } 
        
        if(!antsstart){
            if(gamemanager.antselect == this.transform && gamemanager.anttarget != this.transform.position){
                antanim.SetBool("Walking", true);
            }else{
                antanim.SetBool("Walking", false);
            }
        }

        if(antsstart){
            anttarget = gamemanager.antwaypoints[antI].transform.position;
            this.transform.LookAt(anttarget);
        
            if(this.transform.position != anttarget && anttarget != new Vector3(0, 0, 0)){
                antanim.SetBool("Walking", true);
                this.transform.position = Vector3.MoveTowards(this.transform.position, anttarget, gamemanager.antspeed * Time.deltaTime); 
            } else{
                if(anttarget != new Vector3(0, 0, 0)){
                    //dropseed();
                    antI++;
                    anttarget = gamemanager.antwaypoints[antI].transform.position;
                    this.transform.LookAt(anttarget);
                }else{
                antanim.SetBool("Walking", false);
                }
            }
            if(this.transform.position == gamemanager.antwaypoints[3].transform.position){
                this.gameObject.SetActive(false);
            }
        }
        
    }
    private int i;
    void FixedUpdate(){
        if(antsstart == true && holdseed == true){
            if(i == 0){
                dropseed();
                i++;
            }else{
                i++;
                if(i == 100){
                    i = 0;
                }
            }
        }
    }
    
    
    void dropseed(){
        if(holdseed == true){
            //if(Random.Range(0, 100) <= droprate){
            if(droprate >= 100f){
                antseed.transform.parent = null;
                holdseed = false;
                gamemanager.numberfallenseeds++;
            } else{
                droprate = droprate + Random.Range(1f, droprateincrease);
            }
        }
    }
    
}
}
