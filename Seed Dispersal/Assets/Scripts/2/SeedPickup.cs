using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch{
public class SeedPickup : MonoBehaviour
{
    private John_gamemanager_Path02 gamemanager;
    public GameObject antparent;
    
    void Start()
    {
        gamemanager = GameObject.FindObjectOfType<John_gamemanager_Path02>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.parent != antparent && gamemanager.antsareup == false){
            if(Vector3.Distance(gamemanager.player.transform.position, this.transform.position) <= gamemanager.intdistance){
                this.gameObject.SetActive(false);
                gamemanager.numberfallenseeds--;
            }
        }
    }
}}
