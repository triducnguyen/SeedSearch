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
    public GameObject wind;
    public GameObject hole;
    public GameObject dandelionflower;
    public GameObject dandelionsprout;

    [Header("Castle")]
    public Animator castleanim;

    [Header("Fairy")]
    public GameObject fairy;
    [SerializeField] private GameObject F0, F1, F2, F3;
    private GameObject fairytarget;
    [SerializeField] private float fairyspeed;

    [Header("Fairy Speaking")]
    private string o1seedfairy = "Hello there Adventurer! Looks like you’ve studied up! Are you ready to begin our search? We need to make sure the seeds are properly dispersed, germinated, and ready for pollination! Our Flower Kingdom will be covered in beautiful flowers once more! Come on, let’s go! ";
    private string o2seedfairy = "Well look what we have here, it’s a seed! Do you know what a seed is?";
    private string o4seedfairy = "That’s right, it’s the part of a plant that can grow into a new plant. There are flowers around here ready to drop seeds so that this can happen. But it looks like our seeds aren’t growing into new plants, which means we’ve got some forgetful seeds on our hands! Let’s try to help them out, shall we?";
    private string o5seedfairy = "Looks like this flower is covered in seeds! They are ready to be dispersed! That means they need to be moved from one place to another. There are three main ways seeds move around, and those are wind, insects, and animals.";
    private string o6seedfairy = "Wait, listen! I think some wind is blowing! Maybe it will pick up these seeds! Quick, follow them!";
    private string o7seedfairy = "Come here, get closer. Our seed here needs to remember how to become a flower. The process of a seed growing into a plant is known as germination. For our plant to germinate, first it needs good conditions. We need to make sure it has them! Do you know the best place for a seed to grow?";
    private string o9seedfairy = "That’s right! Our seed needs to grow on rich soil, where it can grow roots in the ground and have plenty of nutrients from the dirt. It also needs sunlight, and water to grow! Go ahead, water our little seed!";
    private string o10seedfairy = "Look! Now that our seed has the proper conditions, it is going to germinate! Do you remember what germination is?";
    private string o12seedfairy = "That’s right! Germination is the process by which a seed begins to grow into a plant! Let’s plant this seed and help it germinate!";
    private string o13seedfairy = "Great! Now the plant has rich soil for its new home.";
    private string o14seedfairy = "First, it grows roots to absorb nutrients and water in the soil.";
    private string o15seedfairy = "Then, it sprouts a little plant whose leaves will take in sunlight for food.";
    private string o16seedfairy = "Then, it gets older and even grows into a new big flower!";
    private string o17seedfairy = "Look at that! I think you’ve shown these confused seeds how to grow into a flower! And look!";
    private string o18seedfairy = "Our kingdom is already getting more beautiful! Thank you for your help, Adventurer! But still, there is more to be done! I’ll see you later!";

    // Start is called before the first frame update
    void Start()
    {
        wateringcanhome.transform.position = wateringcan.transform.position;
        waterincan.SetActive(false);
        canstate = "return";
        seedstate = " ";
        dandelionseed.SetActive(false);
        castleanim.SetBool("CastleAnim", false);
        wind.SetActive(false);
        hole.SetActive(false);
        fairytarget = F0;
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
                if (selection.CompareTag("wateringcan") && seedstate == "plant")
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
                    wind.SetActive(true);
                    fairytarget = F1;
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
                dandelionflower.SetActive(true);
                dandelionsprout.SetActive(false);
                fairytarget = F3;
                castleactivate();
            }
        }
        if(seedstate == "fly"){
            dandelionsprout.SetActive(false);
            dandelionflower.SetActive(false);
            hole.SetActive(false);
            dandelionseed.transform.position = Vector3.MoveTowards(dandelionseed.transform.position, target + new Vector3(0, dandelionseedflyheight, 0), dandelionspeed * Time.deltaTime);
            if(dandelionseed.transform.position == target + new Vector3(0, dandelionseedflyheight, 0)){
                seedstate = "drop";
            }
        }else if(seedstate == "drop"){
            dandelionseed.transform.position = Vector3.MoveTowards(dandelionseed.transform.position, target, 0.5f * dandelionspeed * Time.deltaTime);
            if(dandelionseed.transform.position == target){
                seedstate = "plant";
                wind.SetActive(false);
                hole.SetActive(true);
                dandelionflower.SetActive(false);
                hole.transform.position = dandelionseed.transform.position + new Vector3(0, 0.01f , 0);
                fairytarget = F2;
                dandelionsprout.SetActive(true);
            }
        }
        if(fairy.transform.position != fairytarget.transform.position){
            fairy.transform.position = Vector3.MoveTowards(fairy.transform.position, fairytarget.transform.position, fairyspeed * Time.deltaTime); 
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

    public void castleactivate(){
        castleanim.SetBool("CastleAnim", true);
    }
    
}
