using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class john_gamemanager : MonoBehaviour
{
    public GameObject wateringcan;
    public GameObject wateringcanhome;
    public GameObject wateringcancheckpoint;
    private string canstate;
    public GameObject waterincan;
    [SerializeField] private float smooth;
    // Start is called before the first frame update
    void Start()
    {
        wateringcanhome.transform.position = wateringcan.transform.position;
        waterincan.SetActive(false);
        canstate = "water";
        movewateringcan();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canstate == "water")
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if (selection.CompareTag("wateringcan"))
                {
                    canstate = "tipping";
                }
            }
        }
        if(canstate == "tipping"){
            wateringcan.transform.rotation = Quaternion.Slerp(wateringcan.transform.rotation, wateringcancheckpoint.transform.rotation, Time.deltaTime * smooth);
            if(wateringcan.transform.rotation == wateringcancheckpoint.transform.rotation){
                canstate = "tipped";
                waterincan.SetActive(true);
            }
        }
        
    }

    public void movewateringcan(){
        if(canstate == "water"){
            wateringcan.transform.position = wateringcancheckpoint.transform.position;
        } else if(canstate == "return"){
            wateringcan.transform.position = wateringcanhome.transform.position;
            wateringcan.transform.rotation = wateringcanhome.transform.rotation;
        } else{ Debug.Log("Cannot perform action of watering can");}
    }
}
