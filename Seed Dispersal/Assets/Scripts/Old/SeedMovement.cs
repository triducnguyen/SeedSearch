using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedMovement : MonoBehaviour
{
    public float speed;
    public Transform target, target1, target2, target3, target4, target5, target6;
    // Start is called before the first frame update
    void Start()
    {
        target.position = target1.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if(transform.position == target1.position)
        {
            target.position = target2.position;
        }
        else if(transform.position == target2.position)
        {
            target.position = target3.position;
        }
        else if(transform.position == target3.position)
        {
            target.position = target4.position;
        }
        else if(transform.position == target4.position)
        {
            target.position = target5.position;
        }
        else if(transform.position == target5.position)
        {
            target.position = target6.position;
        }
    }
}
