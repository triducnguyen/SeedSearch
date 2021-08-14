using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SeedSearch{
    public class john_gamemanager : MonoBehaviour
    {
        private int gamestate = 1;
        private bool inputLock = false;
        private bool planting = false;
        public bool AnsweringQuestion = false;
        private Coroutine previousCoroutine;
        [Header("Watering can")]
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
        public GameObject dandelionplantmini;
        public GameObject dandelionSeedLP;

        [Header("Indication")]
        public GameObject indicator;
        public GameObject waterCanIndicator;

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
        //public Text subtitle;

        [Header("Questions")]
        public QuestionUI questionUI;

        private SoundManager soundManager;
    
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
            soundManager = SoundManager.Instance;
            wateringcanhome.transform.position = wateringcan.transform.position;
            waterincan.SetActive(false);
            canstate = "return";
            seedstate = " ";
            dandelionseed.SetActive(false);
            castleanim.SetBool("CastleAnim", false);
            dandanim.SetBool("stopspinning", true);
            wind.SetActive(false);
            hole.SetActive(false);
            fairytarget = F0;
            fairynarration(1);
            indicator.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (island.activeInHierarchy && gamestate < 2){
                fairynarration(2);
            }
            if (!AnsweringQuestion)
            {
                if (Input.GetMouseButtonDown(0) && !inputLock)
                {
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        var selection = hit.transform;
                        if (selection.CompareTag("wateringcan") && seedstate == "plant")
                        {
                            if (canstate == "water")
                            {
                                waterCanIndicator.SetActive(false);
                                canstate = "tipping";
                            }
                            else if (canstate == "tipped")
                            {
                                waterCanIndicator.SetActive(false);
                                canstate = "return";
                                waterincan.SetActive(false);
                                movewateringcan();
                            }
                            else if (canstate == "return")
                            {
                                canstate = "water";
                                waterCanIndicator.SetActive(true);
                                waterCanIndicator.transform.position = wateringcancheckpoint.transform.position + new Vector3(0f, 0.1f, 0f);
                                waterCanIndicator.transform.LookAt(player.transform.position);
                                waterincan.SetActive(false);
                                movewateringcan();
                            }
                        }
                        else if (selection.CompareTag("dandelionflower") && seedstate == " ")
                        {
                            dandelionseed.SetActive(true);
                            seedstate = "idle";
                            wind.SetActive(true);
                            if (gamestate < 5)
                            {
                                fairynarration(5);
                            }
                            fairytarget = F1;
                        }
                        else if (selection.CompareTag("island") && dandelionseed.activeInHierarchy && !planting)
                        {
                            seedstate = "fly";
                            target = hit.point;
                        }
                    }
                }
                if (canstate == "tipped")
                {
                    canstate = "return";
                    waterincan.SetActive(false);
                    movewateringcan();
                }
                if (canstate == "tipping")
                {
                    waterincan.SetActive(true);
                    wateringcan.transform.rotation = Quaternion.Slerp(wateringcan.transform.rotation, wateringcancheckpoint.transform.rotation, Time.deltaTime * smooth);
                    if (wateringcan.transform.rotation == wateringcancheckpoint.transform.rotation)
                    {
                        canstate = "tipped";
                        waterincan.SetActive(true);
                        castleactivate();
                        if (gamestate < 10)
                        {
                            fairynarration(10);
                        }
                        StartCoroutine(stopWatering());
                    }
                }

                if (seedstate == "fly")
                {
                    dandanim.SetBool("stopspinning", false);
                    dandelionsprout.SetActive(false);
                    dandelionflower.SetActive(false);
                    dandelionsprout2.SetActive(false);
                    dandelionplantmini.SetActive(false);
                    hole.SetActive(false);
                    if (gamestate < 6)
                    {
                        fairynarration(6);
                    }
                    dandelionseed.transform.position = Vector3.MoveTowards(dandelionseed.transform.position, target + new Vector3(0, dandelionseedflyheight, 0), dandelionspeed * Time.deltaTime);
                    if (dandelionseed.transform.position == target + new Vector3(0, dandelionseedflyheight, 0))
                    {
                        seedstate = "drop";
                    }
                }
                else if (seedstate == "drop")
                {
                    dandelionseed.transform.position = Vector3.MoveTowards(dandelionseed.transform.position, target + new Vector3(0f, 0.02f,0f), 0.5f * dandelionspeed * Time.deltaTime);
                    if (dandelionseed.transform.position == target + new Vector3(0f, 0.02f, 0f))
                    {
                        seedstate = "plant";
                        wind.SetActive(false);
                        if (gamestate < 7)
                        {
                            fairynarration(7);
                        }
                        //dandelionflower.SetActive(false);
                        //hole.transform.position = dandelionseed.transform.position + new Vector3(0, 0.01f , 0);
                        fairytarget = F2;
                        dandanim.SetBool("stopspinning", true);
                    }
                }
                else if (seedstate == "plant")
                {
                    planting = true;
                    if (Input.GetMouseButtonDown(0) && !inputLock)
                    {
                        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit))
                        {
                            var selection = hit.transform;
                            if (selection.CompareTag("dandelionSeed"))
                            {
                                hole.SetActive(true);
                                dandelionflower.SetActive(false);
                                hole.transform.position = dandelionseed.transform.position + new Vector3(0, 0.01f, 0);
                                indicator.SetActive(true);
                                indicator.transform.position = dandelionseed.transform.position + new Vector3(0, 0.2f, 0);
                                indicator.transform.LookAt(player.transform.position);
                            }
                            else if (selection.CompareTag("hole"))
                            {
                                dandelionflower.SetActive(false);
                                indicator.SetActive(false);
                                if(gamestate < 13)
                                {
                                    fairynarration(13);
                                }
                                StartCoroutine(PlantGrow());
                            }
                        }
                    }
                }
            }

            if(fairy.transform.position != fairytarget.transform.position){
                fairy.transform.position = Vector3.MoveTowards(fairy.transform.position, fairytarget.transform.position, fairyspeed * Time.deltaTime); 
            }

            fairysubtitles.transform.LookAt(player.transform.position);
        }

        private IEnumerator PlantGrow()
        {
            inputLock = true;
            dandanim.SetBool("stopspinning", true);
            yield return new WaitForSeconds(5f);
            if (gamestate < 14)
            {
                fairynarration(14);
            }
            dandelionsprout2.SetActive(true);
            dandelionsprout.SetActive(false);
            yield return new WaitForSeconds(5f);
            if (gamestate < 15)
            {
                fairynarration(15);
            }
            dandelionplantmini.SetActive(true);
            dandelionsprout2.SetActive(false);
            yield return new WaitForSeconds(5f);
            if (gamestate < 16)
            {
                fairynarration(16);
            }
            dandelionplantmini.SetActive(false);
            dandelionflower.SetActive(true);            
            fairytarget = F3;
            yield return new WaitForSeconds(4f);
            if (gamestate < 17)
            {
                fairynarration(17);
            }
            yield return new WaitForSeconds(6f);
            if (gamestate < 18)
            {
                fairynarration(18);
            }
            yield return new WaitForSeconds(8f);
            planting = false;
            inputLock = false;
        }

        public void movewateringcan(){
            if(canstate == "water"){
                wateringcan.transform.position = wateringcancheckpoint.transform.position;         
            } else if(canstate == "return"){
                wateringcan.transform.position = wateringcanhome.transform.position;
                wateringcan.transform.rotation = wateringcanhome.transform.rotation;
            } else{ Debug.Log("Cannot perform action of watering can");}
        }

        private IEnumerator stopWatering()
        {
            yield return new WaitForSeconds(7f);
            canstate = "tipped";
        }

        public void castleactivate(){
            castleanim.SetBool("CastleAnim", true);
        }

        IEnumerator Subtitle(float time)
        {
            inputLock = true;
            yield return new WaitForSeconds(time);
            if(gamestate == 2)
            {
                questionUI.OpenQuestion(0);
            } else if(gamestate == 7)
            {
                questionUI.OpenQuestion(1);

            } else if(gamestate == 10)
            {
                questionUI.OpenQuestion(2);
            } else if(gamestate == 18)
            {
                questionUI.OpenQuestion(3);
            }
            //subtitle.text = "";
            fairytext.text = "";
            inputLock = false;
        }
        [System.NonSerialized] public StudentData currentStudent;
        IEnumerator endpath(){
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Path02");
            currentStudent = SaveManager.Instance.studentProfile;
            if(currentStudent.Levelprogress != null && 
            currentStudent.Levelprogress[0] != 0){
                
            }
        }

        public void fairynarration(int instate)
        {
            gamestate = instate;
            if (gamestate == 1)
            {
                soundManager.PlayAudio("01");
                fairytext.text = o1seedfairy;
                //subtitle.text = o1seedfairy;
                previousCoroutine = StartCoroutine(Subtitle(15f));
            }
            else if (gamestate == 2)
            {
                soundManager.PlayAudio("02");
                fairytext.text = o2seedfairy;
                //subtitle.text = o2seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(5f));
            }
            else if (gamestate == 4)
            {
                soundManager.PlayAudio("04");
                fairytext.text = o4seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(16f));
                indicator.SetActive(true);
                indicator.transform.position = dandelionSeedLP.transform.position + new Vector3(-0.01f, 0.7f, -0.01f);
                indicator.transform.LookAt(player.transform.position);
            }
            else if (gamestate == 5)
            {
                soundManager.PlayAudio("05");
                indicator.SetActive(false);
                fairytext.text = o5seedfairy;
                //subtitle.text = o5seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(14f));
                
            }
            else if (gamestate == 6)
            {
                soundManager.PlayAudio("06");
                fairytext.text = o6seedfairy;
                //subtitle.text = o6seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(7f));
            }
            else if (gamestate == 7)
            {
                soundManager.PlayAudio("07");
                indicator.SetActive(false);
                fairytext.text = o7seedfairy;
                //subtitle.text = o7seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(17f));
            }
            else if (gamestate == 9)
            {
                soundManager.PlayAudio("09");
                fairytext.text = o9seedfairy;
                //subtitle.text = o9seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(12f));
            }
            else if (gamestate == 10)
            {
                indicator.SetActive(true);
                indicator.transform.position = dandelionseed.transform.position + new Vector3(0, 0.2f, 0);
                indicator.transform.LookAt(player.transform.position);
                soundManager.PlayAudio("10");
                fairytext.text = o10seedfairy;
                //subtitle.text = o10seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(7f));
            }
            else if (gamestate == 12)
            {
                soundManager.PlayAudio("12");
                fairytext.text = o12seedfairy;
                //subtitle.text = o12seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(8f));
            }
            else if (gamestate == 13)
            {
                soundManager.PlayAudio("13");
                fairytext.text = o13seedfairy;
                //subtitle.text = o13seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(4f));
            }
            else if (gamestate == 14)
            {
                soundManager.PlayAudio("14");
                fairytext.text = o14seedfairy;
                //subtitle.text = o14seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(5f));
            }
            else if (gamestate == 15)
            {
                soundManager.PlayAudio("15");
                fairytext.text = o15seedfairy;
                //subtitle.text = o15seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(5f));
            }
            else if (gamestate == 16)
            {
                soundManager.PlayAudio("16");
                fairytext.text = o16seedfairy;
                //subtitle.text = o16seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(4f));
            }
            else if (gamestate == 17)
            {
                soundManager.PlayAudio("17");
                fairytext.text = o17seedfairy;
                //subtitle.text = o17seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(6f));
            }
            else if (gamestate == 18)
            {
                soundManager.PlayAudio("18");
                fairytext.text = o18seedfairy;
                //subtitle.text = o18seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(8f));
            }

        }

    }
}
