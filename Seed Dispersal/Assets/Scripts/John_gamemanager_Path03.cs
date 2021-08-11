using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SeedSearch
{
    public class John_gamemanager_Path03 : MonoBehaviour
    {
        private bool inputLock = false;
        [SerializeField] private int gamestate = 1;
        private bool answeringQuestion = false;
        public bool AnsweringQuestion { get => answeringQuestion; set => answeringQuestion = value; }
        [Header("Badger")]
        public GameObject badger;
        [SerializeField] private GameObject[] badgerpoints;
        public GameObject[] acornpoints;
        public GameObject[] acorns;
        private Vector3 badgertarget;
        private int badgerstate = 2;
        public Animator badgeranim;
        private int B = 0;
        [SerializeField] float badgerspeed;
        private Vector3 badgerplayerpos;

        [Header("Watering can")]
        public GameObject wateringcan;
        public GameObject wateringcanhome;
        public GameObject wateringcancheckpoint;
        private string canstate;
        public GameObject waterincan;
        [SerializeField] private float smooth;
        [Header("Indication")]
        public GameObject indicator;
        public GameObject waterCanIndicator;

        [Header("Castle")]
        public Animator castleanim;

        [Header("Fairy")]
        public GameObject fairy;
        [SerializeField] private GameObject[] F;
        private GameObject fairytarget;
        [SerializeField] private float fairyspeed;
        public Animator faryanim;

        [Header("Fairy Speaking")]
        public GameObject fairysubtitles;
        public GameObject island;
        public Text fairytext;
        public GameObject player;
        public Text subtitle;
        public QuestionUI questionUI;
        public QuestionUI reviewQuestionUI;

        private Coroutine previousCoroutine;
        private SoundManager soundManager;

        private string o1seedfairy = "Welcome back, Adventurer! You’ve been a big help so far! Now we just need to make sure that everyone is in the right place and that conditions are good here in the Flower Kingdom once more!";
        private string o2seedfairy = "This tree here is the home of a badger. Badgers and other animals are very good at dispersing seeds. Seeds get stuck in their fur as they move around, and at the same time, they are dropping off other seeds that may have already been stuck to them! We’ve got a little problem, though. The badger that lives here is missing! No one knows where it went, so It hasn’t been dispersing seeds. Let’s get a little closer and see if we can find some clues.";
        private string o3seedfairy = "Yes, look there are some tracks. Maybe if we follow them, they will lead us to the badger. Let’s see where it ran off to!";
        private string o4seedfairy = "Oh, there it is! It’s just taking a nice long nap! I think it’s slept long enough. Tap it awake.";
        private string o5seedfairy = "Look at all the seeds stuck to it! Those are acorns, which are seeds that grow entire trees! Our badger lives under a tree, no wonder it picked up so many of these! Now that it’s awake from its nap, it should be able to get back to its hole and disperse some seeds along the way. See, there it goes.";
        private string o6seedfairy = "Now that you’ve made it this far, you should know all three methods of seed dispersal! Can you tell me what they are?";
        private string o7seedfairy = "That’s right! Seeds are dispersed primarily by wind, insects, and animals!";
        private string o8seedfairy = "Great job! You’re making great progress, keep it up!";
        private string o9seedfairy = "Uh oh, looks like these seeds need some help. They’re trying their best to grow, but they might not have the best conditions! Can you help the three seeds to find good conditions so that they may grow?";
        private string o10seedfairy = "This plant isn’t growing, do you know what would help?";
        private string o11seedfairy = "That’s right, it’s stuck in the shade! Let’s move that out of the way!";
        private string o12seedfairy = "Perfect! Now it will get enough sunlight to grow big and beautiful!";
        private string o13seedfairy = "That’s right, this poor seed can’t spread its roots anywhere. Let’s move it to the soil! ";
        private string o14seedfairy = "Perfect! Now it will be able to spread its roots to grow big and beautiful!";
        private string o15seedfairy = "That’s a good call, this seed is so thirsty! Let’s give it a little water.";
        private string o16seedfairy = "Perfect! Now the seed has water so that it may grow up to be big and beautiful! ";
        private string o17seedfairy = "These seeds are all germinating nicely now! Just to make sure, do you know what a seed needs to germinate?";
        private string o18seedfairy = "Yes that’s right! Seeds need water and sunlight to germinate! You’re doing a great job. Here, follow me!";
        private string o19seedfairy = "You are doing an incredible job, Adventurer! Our kingdom is so beautiful, and the flowers are blooming so nicely! We are almost there! Let’s make sure you’ve taught all these seeds the proper way to make flowers bloom! Are you ready? Let’s go!";
        private string o20seedfairy = "You have done an incredible job, Adventurer! Look at our beautiful kingdom, so covered in pretty flowers! Thanks to you, we are thriving once again! You are an expert in seed dispersal and pollination. Great job Adventurer! I will see you later!";


        // Start is called before the first frame update
        void Start()
        {
            soundManager = SoundManager.Instance;
            castleanim.SetBool("CastleAnim", false);
            faryanim.SetBool("wave", false);

            fairytarget = F[0];
            fairynarration(1);

        }

        private RaycastHit hit;


        void Update()
        {

            if (island.activeInHierarchy && gamestate < 2)
            {
                fairynarration(2);
            }
            if (answeringQuestion)
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
                        if (selection.CompareTag("badger"))
                        {
                            if (badgerstate == 2 && B == 0)
                            {
                                StartCoroutine(badgerwakingup());
                            }
                            else if (badgerstate == 2)
                            {
                                StartCoroutine(badgerwakingup());
                                StopCoroutine(badgersleeps());
                                StartCoroutine(badgersleeps());
                            }

                        }

                    }
                }
            }
            badgeranim.SetInteger("Badger state", badgerstate);

            if (badgerstate == 1)
            {
                StopCoroutine(badgersleeps());
                if (badger.transform.position != badgertarget)
                {
                    badger.transform.position = Vector3.MoveTowards(badger.transform.position, badgertarget, badgerspeed * Time.deltaTime);
                }
                else if (B < 4)
                {
                    badgertarget = badgerpoints[B].transform.position;
                    badger.transform.LookAt(badgertarget);
                    B++;
                }
                else if (B >= 4)
                {
                    badgerstate = 2;
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

            if (fairy.transform.position != fairytarget.transform.position)
            {
                faryanim.SetBool("wave", false);
                fairy.transform.position = Vector3.MoveTowards(fairy.transform.position, fairytarget.transform.position, fairyspeed * Time.deltaTime);
            }
            else
            {
                faryanim.SetBool("wave", true);
            }


            fairysubtitles.transform.LookAt(player.transform.position);
        }


        public void castleactivate()
        {
            castleanim.SetBool("CastleAnim", true);
        }

        IEnumerator Subtitle(float time)
        {
            inputLock = true;
            yield return new WaitForSeconds(time);
            if (gamestate == 6)
            {
                questionUI.OpenQuestion(8);
            }
            else if (gamestate == 7)
            {
                questionUI.OpenQuestion(9);

            }
            else if (gamestate == 10)
            {
                questionUI.OpenQuestion(10);
            }
            else if (gamestate == 12)
            {
                questionUI.OpenQuestion(11);
            }
            else if (gamestate == 14)
            {
                questionUI.OpenQuestion(12);
            }
            else if (gamestate == 17)
            {
                questionUI.OpenQuestion(13);
            }
            else if(gamestate == 19)
            {
                reviewQuestionUI.OpenReviewQuestions();
            }
            fairytext.text = "";
            inputLock = false;
        }
        public void movewateringcan()
        {
            if (canstate == "water")
            {
                wateringcan.transform.position = wateringcancheckpoint.transform.position;
            }
            else if (canstate == "return")
            {
                wateringcan.transform.position = wateringcanhome.transform.position;
                wateringcan.transform.rotation = wateringcanhome.transform.rotation;
            }
            else { Debug.Log("Cannot perform action of watering can"); }
        }

        private IEnumerator stopWatering()
        {
            yield return new WaitForSeconds(5f);
            canstate = "tipped";
        }
        private IEnumerator badgersleeps()
        {
            yield return new WaitForSeconds(30f);
            badgerstate = 2;
        }
        private IEnumerator badgerwakingup()
        {
            badgerstate = 0;
            yield return new WaitForSeconds(2f);
            badgerplayerpos = player.transform.position;
            badgerplayerpos.y = badger.transform.position.y;
            badger.transform.LookAt(badgerplayerpos);
            yield return new WaitForSeconds(8f);
            if (B < 3)
            {
                badgerstate = 1;
                badgertarget = badgerpoints[B].transform.position;
                badger.transform.LookAt(badgertarget);
            }
        }
        public void fairynarration(int instate)
        {
            gamestate = instate;
            if (gamestate == 1)
            {
                soundManager.PlayAudio("01_3");
                fairytext.text = o1seedfairy;
                previousCoroutine = StartCoroutine(Subtitle(9f));
            }
            else if (gamestate == 2)
            {
                soundManager.PlayAudio("02_3");
                fairytext.text = o2seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(24f));
            }
            else if (gamestate == 3)
            {
                soundManager.PlayAudio("03_3");
                fairytext.text = o3seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(6f));
            }
            else if (gamestate == 4)
            {
                soundManager.PlayAudio("04_3");
                fairytext.text = o4seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(7f));
            }
            else if (gamestate == 5)
            {
                soundManager.PlayAudio("05_3");
                fairytext.text = o5seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(18f));
            }
            else if (gamestate == 6)
            {
                soundManager.PlayAudio("06_3");
                fairytext.text = o6seedfairy;             
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(6f));
            }
            else if (gamestate == 7)
            {
                soundManager.PlayAudio("07_3");
                fairytext.text = o7seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(5f));
            }
            else if (gamestate == 8)
            {
                soundManager.PlayAudio("08_3");
                fairytext.text = o8seedfairy;  
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(3f));
            }
            else if (gamestate == 9)
            {
                soundManager.PlayAudio("09_3");
                fairytext.text = o9seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(10f));
            }
            else if (gamestate == 10)
            {
                soundManager.PlayAudio("10_3");
                fairytext.text = o10seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(9f));
            }
            else if (gamestate == 11)
            {
                soundManager.PlayAudio("11_3");
                fairytext.text = o11seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(4f));
            }
            else if (gamestate == 12)
            {
                soundManager.PlayAudio("12_3");
                fairytext.text = o12seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(4f));
            }
            else if (gamestate == 13)
            {
                soundManager.PlayAudio("13_3");
                fairytext.text = o13seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(5f));
            }
            else if (gamestate == 14)
            {
                soundManager.PlayAudio("14_3");
                fairytext.text = o14seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(4f));
            }
            else if (gamestate == 15)
            {
                soundManager.PlayAudio("15_3");
                fairytext.text = o15seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(4f));
            }
            else if (gamestate == 16)
            {
                soundManager.PlayAudio("16_3");
                fairytext.text = o16seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(4f));
            }
            else if (gamestate == 17)
            {
                soundManager.PlayAudio("17_3");
                fairytext.text = o17seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(6f));
            }
            else if (gamestate == 18)
            {
                soundManager.PlayAudio("18_3");
                fairytext.text = o18seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(7f));
            }
            else if (gamestate == 19)
            {
                soundManager.PlayAudio("19_3");
                fairytext.text = o19seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(13f));
            }
            else if (gamestate == 20)
            {
                soundManager.PlayAudio("20_3");
                fairytext.text = o20seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(15f));
            }

        }
    }
}
