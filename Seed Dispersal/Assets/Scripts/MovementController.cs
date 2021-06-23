using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : PlacementController
{
    // Start is called before the first frame update
    // public Transform target;
    // public float speed;
    public bool playBool;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(bogBool == true)
        // {
        //     float step = speed * Time.deltaTime;
        //     transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        // }
        // if(hitObject.transform.name.Contains("Capsule"))
        // {
        //     bogBool = true;
        // }
        // if(bogBool == true)
        // {
        //     float step = speed * Time.deltaTime;
        //     transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        // }
        
        
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        
        
        // if(transform.position == flyOverPosition.position)
        // {
        //     target.position = flower1.position;
        // }
    }
}
