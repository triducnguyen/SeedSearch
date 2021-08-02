using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch{
public class Acorn : MonoBehaviour
{
    private John_gamemanager_Path03 gamemanager;
    private float previousdistance  = 0;
    private float Distance;
    
    
    void Start()
    {
        gamemanager = GameObject.FindObjectOfType<John_gamemanager_Path03>();
    }

    // Update is called once per frame
    void Update()
    {
        //Distance = Vector3.Distance(this.transform.position, gamemanager.acornpoints[System.Array.IndexOf(gamemanager.acorns, this.gameObject)]);
    }
}}
