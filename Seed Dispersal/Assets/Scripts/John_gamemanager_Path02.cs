using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SeedSearch{
public class John_gamemanager_Path02 : MonoBehaviour
{
    private int gamestate = 1;
    [Header("Bee")]
    public GameObject Bee;
    [SerializeField] private float beesmooth;

    [Header("Castle")]
    public Animator castleanim;

    [Header("Fairy")]
    public GameObject fairy;
    [SerializeField] private GameObject F0, F1, F2, F3;
    private GameObject fairytarget;
    [SerializeField] private float fairyspeed;
    public Animator faryanim;

    [Header("Fairy Speaking")]
    public GameObject fairysubtitles;
    public GameObject island;
    public Text fairytext;
    public GameObject player;
    public Text subtitle;

    private SoundManager soundManager;
    
    private string o1seedfairy = "Welcome back, Adventurer! Thanks for your help, but we’re still in trouble!";
    private string o2seedfairy = "We’ve got a problem! As you can see, this path doesn’t have many flowers. The insects of this path seem to have gotten all confused! They don’t remember how to pollinate and disperse our seeds! But look, luckily we’ve got a few pretty little flowers right here! This one is fully bloomed and ready to be pollinated. Do you know what pollination is?";
    private string o3seedfairy = "Yes, pollination is the process of moving pollen from one flower to another! And look, there is a pollinator, on its way to do so! Bees are great pollinators, but he looks a little confused. Let’s help him fly through the process of pollination, so he remembers how it’s done!";
    private string o4seedfairy = "Oh wonderful, see? Now the flower has been pollinated! It’s important that we teach these bees what to do.";
    private string o5seedfairy = "Looks like our bee is getting back on track with the pollinating, thanks to you! But it might still be a little confused! Let’s make sure it knows what it’s doing. Guide the bee to the flowers with pollen, so that he may collect some. Then, show him the way to a flower that needs pollinating, so that all of these flowers may receive their pollen!";
    private string o6seedfairy = "Wonderful! All these flowers can now produce their seeds because they have been pollinated! Now that you’ve flown our bees through this process, do you know what happens when insects visit a plant every day?";
    private string o7seedfairy = "That’s right! The bee will pollinate your flower, and once it does, it produces seeds! And now that it’s producing seeds, you know what that means! It’s time for dispersal! Insects aren’t just good at pollination, but also very good at dispersing seeds. Like these ants down here. Where are they going? Let’s follow them!";
    private string o8seedfairy = "Hmm, see what I mean? We need to teach these ants the proper way of dispersing seeds! Do you remember what seed dispersal is?";
    private string o9seedfairy = "That’s right! Seed Dispersal is the process of moving seeds from one place to another! Ants are one type of insect that disperse seeds. They collect them for food, and along their journey, drop some seeds on the way! These ants seem like they’re a little confused, tap on this ant to get his attention, then direct him to the pile of seeds.";
    private string o10seedfairy = "There, he seems to be catching on! Show the rest how it’s done!";
    private string o11seedfairy = "Now they’ve all got their seeds! Looks like we need to direct them back to their anthill. It’s over there, past that tree trunk!";
    private string o12seedfairy = "The ants are dropping some seeds! Can you find all the seeds the ants dropped? Get up nice and close to them, so that we can see!";
    private string o13seedfairy = "Great! These seeds are properly dispersed! And since they also have good conditions, they can grow big and beautiful! It looks like it’s already working! Look at the Flower Kingdom!";
    private string o14seedfairy = "Excellent work Adventurer! You are making our kingdom thrive again! But there’s still more work to be done! I will see you next time!";

    // Start is called before the first frame update
    void Start()
    {
        soundManager = SoundManager.Instance;
        castleanim.SetBool("CastleAnim", false);
        faryanim.SetBool("wave", false);
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
                }*/
            }
        }
        
        if(fairy.transform.position != fairytarget.transform.position){
            faryanim.SetBool("wave", false);
            fairy.transform.position = Vector3.MoveTowards(fairy.transform.position, fairytarget.transform.position, fairyspeed * Time.deltaTime); 
        } else{
            faryanim.SetBool("wave", true);
        }

        fairysubtitles.transform.LookAt(player.transform.position);
    }
    

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
            else if(gamestate == 3){
            soundManager.PlayAudio("03");
            fairytext.text = o3seedfairy;
                subtitle.text = o3seedfairy;
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
            else if(gamestate == 8){
            soundManager.PlayAudio("08");
            fairytext.text = o8seedfairy;
                subtitle.text = o8seedfairy;
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
            else if(gamestate == 11){
            soundManager.PlayAudio("11");
            fairytext.text = o11seedfairy;
                subtitle.text = o11seedfairy;
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
        
    }
}
}
