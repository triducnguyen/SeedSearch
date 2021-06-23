using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeedSearch{
public class Gameplay : MonoBehaviour
{
    private flower Flower;
    private string gamestate;
    void Start()
    {
        Flower = GameObject.FindObjectOfType<flower>();
        gamestate = "start";

        gamestate = "Bee Pollination";

        
    }

    // Update is called once per frame
    void Update()
    {
        if(gamestate == "Bee Pollination"){
            beepollination();
        }
    }
    bool TryGetTouchPosition(out Vector2 touchPosition)
        {
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position;
                return true;
            }
            touchPosition = default;
            return false;
        }
    [Header("Bee")]    
    [SerializeField] private Vector3 beetarget;
    public GameObject Bee;
    public GameObject pollenobj;
    public float beestoppingdistance;
    public float beespeed;
    public string flowertag;
    private string beestate = "idol";
    public bool haspollen = false;
    private void beepollination(){
        if(Input.GetMouseButtonDown(0)){
            //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                Debug.Log(selection);
                if (selection.CompareTag(flowertag))
                {
                    beetarget = hit.point;
                    Debug.Log("hit flower");
                    beestate = "moving";
                }
            }
        }
        if(beestate == "moving" && Vector3.Distance(Bee.transform.position, beetarget) >= beestoppingdistance){
            float beestep = beespeed * Time.deltaTime;
            Bee.transform.LookAt(beetarget);
            Bee.transform.position = Vector3.MoveTowards(Bee.transform.position, beetarget, beestep);
            //Debug.Log("Moved");
        } else if (Vector3.Distance(Bee.transform.position, beetarget) < beestoppingdistance){
            beestate = "pollinating";
            Flower.pollinate();
        }
        if(haspollen == true && pollenobj.activeInHierarchy == false){
            pollenobj.SetActive(true);
        } else if(haspollen == false && pollenobj.activeInHierarchy == true){
            pollenobj.SetActive(false);
        }
    }
}
}
