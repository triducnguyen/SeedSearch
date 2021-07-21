using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SeedSearch{
public class John_gamemanager_Path02 : MonoBehaviour
{
    private int gamestate = 1;
    /*[Header("Watering can")]
    public GameObject wateringcan;
    public GameObject wateringcanhome;
    public GameObject wateringcancheckpoint;
    private string canstate;
    public GameObject waterincan;
    [SerializeField] private float smooth;

    [Header("Dandelion")]
    public Animator dandanim;
    public GameObject dandelionseed;
    [SerializeField] private float dandelionspeed;
    [SerializeField] private float dandelionseedflyheight;
    private string seedstate;
    private Vector3 target;
    public GameObject wind;
    public GameObject hole;
    public GameObject dandelionflower;
    public GameObject dandelionsprout;
    public GameObject dandelionsprout2;
    public GameObject dandelionplantmini;*/

    [Header("Castle")]
    public Animator castleanim;

    [Header("Fairy")]
    public GameObject fairy;
    [SerializeField] private GameObject F0, F1, F2, F3;
    private GameObject fairytarget;
    [SerializeField] private float fairyspeed;

    [Header("Fairy Speaking")]
    public GameObject fairysubtitles;
    public GameObject island;
    public Text fairytext;
    public GameObject player;
    public Text subtitle;

    private SoundManager soundManager;
    
    private string o1seedfairy = "";
    private string o2seedfairy = "";
    private string o4seedfairy = "";
    private string o5seedfairy = "";
    private string o6seedfairy = "";
    private string o7seedfairy = "";
    private string o9seedfairy = "";
    private string o10seedfairy = "";
    private string o12seedfairy = "";
    private string o13seedfairy = "";
    private string o14seedfairy = "";
    private string o15seedfairy = "";
    private string o16seedfairy = "";
    private string o17seedfairy = "";
    private string o18seedfairy = "";

    // Start is called before the first frame update
    void Start()
    {
        soundManager = SoundManager.Instance;
        /*wateringcanhome.transform.position = wateringcan.transform.position;
        waterincan.SetActive(false);
        canstate = "return";
        seedstate = " ";
        dandelionseed.SetActive(false);*/
        castleanim.SetBool("CastleAnim", false);
        /*dandanim.SetBool("stopspinning", true);
        wind.SetActive(false);
        hole.SetActive(false);*/
        fairytarget = F0;
        fairynarration(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(island.activeInHierarchy && gamestate < 2){
            fairynarration(2);
        }
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                /*if (selection.CompareTag("wateringcan") && seedstate == "plant")
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
                }*/
            }
        }
        /*if(canstate == "tipping"){
            waterincan.SetActive(true);
            wateringcan.transform.rotation = Quaternion.Slerp(wateringcan.transform.rotation, wateringcancheckpoint.transform.rotation, Time.deltaTime * smooth);
            if(wateringcan.transform.rotation == wateringcancheckpoint.transform.rotation){
                canstate = "tipped";
                waterincan.SetActive(true);
                castleactivate();
                StartCoroutine(PlantGrow());
            }
        }
        if(seedstate == "fly"){
            dandanim.SetBool("stopspinning", false);
            dandelionsprout.SetActive(false);
            dandelionflower.SetActive(false);
            dandelionsprout2.SetActive(false);
            dandelionplantmini.SetActive(false);
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
                dandanim.SetBool("stopspinning", true);
            }
        }*/
        if(fairy.transform.position != fairytarget.transform.position){
            fairy.transform.position = Vector3.MoveTowards(fairy.transform.position, fairytarget.transform.position, fairyspeed * Time.deltaTime); 
        }

        fairysubtitles.transform.LookAt(player.transform.position);
    }
    /*IEnumerator PlantGrow(){
            dandanim.SetBool("stopspinning", true);
            dandelionsprout2.SetActive(true);
            dandelionsprout.SetActive(false);
            yield return new WaitForSeconds(3);
            dandelionplantmini.SetActive(true);
            dandelionsprout2.SetActive(false);
            yield return new WaitForSeconds(3);
            dandelionplantmini.SetActive(false);
            dandelionflower.SetActive(true);  
            fairytarget = F3;          
        }*/

    /*public void movewateringcan(){
        if(canstate == "water"){
            wateringcan.transform.position = wateringcancheckpoint.transform.position;
        } else if(canstate == "return"){
            wateringcan.transform.position = wateringcanhome.transform.position;
            wateringcan.transform.rotation = wateringcanhome.transform.rotation;
        } else{ Debug.Log("Cannot perform action of watering can");}
    }*/

    public void castleactivate(){
        castleanim.SetBool("CastleAnim", true);
    }

    IEnumerator Subtitle()
        {
            yield return new WaitForSeconds(20f);
            subtitle.text = "";
            fairytext.text = "";
        }

    public void fairynarration(int instate){
        gamestate = instate;
        if(gamestate == 1){
            soundManager.PlayAudio("01");
            fairytext.text = o1seedfairy;
            subtitle.text = o1seedfairy;
            StartCoroutine(Subtitle());
        }else if(gamestate == 2){
            soundManager.PlayAudio("02");
            fairytext.text = o2seedfairy;
                subtitle.text = o2seedfairy;
                StartCoroutine(Subtitle());
            }
            else if(gamestate == 4){
            soundManager.PlayAudio("04");
            fairytext.text = o4seedfairy;
                subtitle.text = o4seedfairy;
                StartCoroutine(Subtitle());
            }
            else if(gamestate == 5){
            soundManager.PlayAudio("05");
            fairytext.text = o5seedfairy;
                subtitle.text = o5seedfairy;
                StartCoroutine(Subtitle());
            }
            else if(gamestate == 6){
            soundManager.PlayAudio("06");
            fairytext.text = o6seedfairy;
                subtitle.text = o6seedfairy;
                StartCoroutine(Subtitle());
            }
            else if(gamestate == 7){
            soundManager.PlayAudio("07");
            fairytext.text = o7seedfairy;
                subtitle.text = o7seedfairy;
                StartCoroutine(Subtitle());
            }
            else if(gamestate == 9){
            soundManager.PlayAudio("09");
            fairytext.text = o9seedfairy;
                subtitle.text = o9seedfairy;
                StartCoroutine(Subtitle());
            }
            else if(gamestate == 10){
            soundManager.PlayAudio("10");
            fairytext.text = o10seedfairy;
                subtitle.text = o10seedfairy;
                StartCoroutine(Subtitle());
            }
            else if(gamestate == 12){
            soundManager.PlayAudio("12");
            fairytext.text = o12seedfairy;
                subtitle.text = o12seedfairy;
                StartCoroutine(Subtitle());
            }
            else if(gamestate == 13){
            soundManager.PlayAudio("13");
            fairytext.text = o13seedfairy;
                subtitle.text = o13seedfairy;
                StartCoroutine(Subtitle());
            }
            else if(gamestate == 14){
            soundManager.PlayAudio("14");
            fairytext.text = o14seedfairy;
                subtitle.text = o14seedfairy;
                StartCoroutine(Subtitle());
            }
            else if(gamestate == 15){
            soundManager.PlayAudio("15");
            fairytext.text = o15seedfairy;
                subtitle.text = o15seedfairy;
                StartCoroutine(Subtitle());
            }
            else if(gamestate == 16){
            soundManager.PlayAudio("16");
            fairytext.text = o16seedfairy;
                subtitle.text = o16seedfairy;
                StartCoroutine(Subtitle());
            }
            else if(gamestate == 17){
            soundManager.PlayAudio("17");
            fairytext.text = o17seedfairy;
                subtitle.text = o17seedfairy;
                StartCoroutine(Subtitle());
            }
            else if(gamestate == 18){
            soundManager.PlayAudio("18");
            fairytext.text = o18seedfairy;
                subtitle.text = o18seedfairy;
                StartCoroutine(Subtitle());
            }
        
    }
}
}
