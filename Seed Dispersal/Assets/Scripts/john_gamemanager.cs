using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class john_gamemanager : MonoBehaviour
{
    [Header("Watering can")]
    public GameObject wateringcan;
    public GameObject wateringcanhome;
    public GameObject wateringcancheckpoint;
    private string canstate;
    public GameObject waterincan;
    [SerializeField] private float smooth;

    [Header("Dandelion")]
    public GameObject dandelionseed;
    [SerializeField] private float dandelionspeed;
    [SerializeField] private float dandelionseedflyheight;
    private string seedstate;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        wateringcanhome.transform.position = wateringcan.transform.position;
        waterincan.SetActive(false);
        canstate = "return";
        seedstate = " ";
        dandelionseed.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if (selection.CompareTag("wateringcan"))
                {
                    if(canstate == "water"){
                        canstate = "tipping";
                    } else if(canstate == "tipped"){
                        canstate = "return";
                        waterincan.SetActive(false);
                        movewateringcan();
                    } else if(canstate == "return"){
                        canstate = "water";
                        waterincan.SetActive(false);
                        movewateringcan();
                    }
                }
                else if(selection.CompareTag("dandelionflower") && seedstate == " "){
                    dandelionseed.SetActive(true);
                    seedstate = "idle";
                }else if(selection.CompareTag("island") && dandelionseed.activeInHierarchy){
                    seedstate = "fly";
                    target = hit.point;
                }
            }
        }
        if(canstate == "tipping"){
            waterincan.SetActive(true);
            wateringcan.transform.rotation = Quaternion.Slerp(wateringcan.transform.rotation, wateringcancheckpoint.transform.rotation, Time.deltaTime * smooth);
            if(wateringcan.transform.rotation == wateringcancheckpoint.transform.rotation){
                canstate = "tipped";
                waterincan.SetActive(true);
            }
        }
        if(seedstate == "fly"){
            dandelionseed.transform.position = Vector3.MoveTowards(dandelionseed.transform.position, target + new Vector3(0, dandelionseedflyheight, 0), dandelionspeed * Time.deltaTime);
            if(dandelionseed.transform.position == target + new Vector3(0, dandelionseedflyheight, 0)){
                seedstate = "drop";
            }
        }else if(seedstate == "drop"){
            dandelionseed.transform.position = Vector3.MoveTowards(dandelionseed.transform.position, target, 0.5f * dandelionspeed * Time.deltaTime);
            if(dandelionseed.transform.position == target){
                seedstate = "plant";
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
