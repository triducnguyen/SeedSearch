using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgerMovement : MonoBehaviour
{
    public float speed;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if(transform.position == target.position)
        {
            gameObject.SetActive(false);
        }
    }
}
