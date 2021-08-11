using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SeedSearch
{
    public class John_gamemanager_Path03 : MonoBehaviour
    {
        [SerializeField] private int gamestate = 1;
        public float proximitydistance;

        private bool inputLock = false;
        public bool AnsweringQuestion = false;
        private Coroutine previousCoroutine;

        [Header("Sub Activities")]
        private string activity;
        [SerializeField] private GameObject shadehitbox;
        [SerializeField] private float shadehitboxradius;
        private int onbadisland = 0;
        [SerializeField] private GameObject DDrydirt, Dwetdirt, Cwetdirt, Swetdirt;
        private int activitiesincomplete = 3;

        [Header("Badger")]
        public GameObject badger;
        [SerializeField] private GameObject[] badgerpoints;
        public GameObject[] acornpoints;
        public GameObject[] acorns;
        public GameObject[] acornnotifs;
        private string[] acornstate;
        private Vector3 badgertarget;
        private int badgerstate = 2;
        public Animator badgeranim;
        private int B = 0;
        [SerializeField] float badgerspeed;
        private Vector3 badgerplayerpos;
        [SerializeField] private GameObject badmesh;
        private SkinnedMeshRenderer meshofbad;

        [Header("Watering can")]
        public GameObject wateringcan;
        public GameObject wateringcanhome;
        public GameObject wateringcancheckpoint;
        private string canstate;
        public GameObject waterincan;
        public GameObject watercantext;
        [SerializeField] private float smooth;
        [Header("Indication")]
        public GameObject indicator;
        public GameObject waterCanIndicator;

        [Header("Fairy Speaking")]
        public GameObject fairysubtitles;
        public GameObject island;
        public Text fairytext;
        public GameObject player;
        public Text subtitle;
        [Header("Questions")]
        public QuestionUI questionUI;
        public QuestionUI reviewQuestionUI;
        private SoundManager soundManager;


        [Header("Castle")]
        public Animator castleanim;

        [Header("Fairy")]
        public GameObject fairy;
        [SerializeField] private GameObject[] F;
        private GameObject fairytarget;
        [SerializeField] private float fairyspeed;
        public Animator faryanim;

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
            canstate = "return";
            fairytarget = F[0];
            fairynarration(1);
            acornstate = new string[acorns.Length];
            for (int i = 0; i < acorns.Length; i++)
            {
                acorns[i].SetActive(false);
            }
            shadehitboxradius = (shadehitbox.transform.localScale.x / 2) * island.transform.localScale.x;

        }

        private RaycastHit hit;
        void Update()
        {
            if (island.activeInHierarchy && gamestate < 2)
            {
                fairynarration(2);
                fairytarget = F[1];
                meshofbad = badmesh.GetComponent<SkinnedMeshRenderer>();
                meshofbad.enabled = false;
                watercantext.SetActive(false);
            }
            if (gamestate == 2 && Vector3.Distance(F[1].transform.position, player.transform.position) <= proximitydistance)
            {
                fairynarration(3);
            }
            if (!AnsweringQuestion)
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
                            else if (canstate == "return" && activity == "Dry")
                            {
                                canstate = "water";
                                waterCanIndicator.SetActive(true);
                                //waterCanIndicator.transform.position = wateringcancheckpoint.transform.position + new Vector3(0f, 0.1f, 0f);
                                waterCanIndicator.transform.LookAt(player.transform.position);
                                waterincan.SetActive(false);
                                movewateringcan();
                            }
                        }
                        if (selection.CompareTag("badger") && meshofbad.enabled == true)
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
                        
                        //acorn split section to start (10)
                        if (gamestate >= 9 && gamestate != 10 && gamestate != 11 && gamestate != 13 && gamestate != 15)
                        {
                            if (selection.CompareTag("AcornS"))
                            {
                                if (!Swetdirt.activeInHierarchy)
                                {
                                    activity = "Shade";
                                    toggleacornnotifs(activity);
                                    fairynarration(10);
                                }
                            }
                            if (selection.CompareTag("AcornC"))
                            {
                                if (!Cwetdirt.activeInHierarchy)
                                {
                                    activity = "Cement";
                                    toggleacornnotifs(activity);
                                    fairynarration(10);
                                }
                            }
                            if (selection.CompareTag("AcornD"))
                            {
                                if (!Dwetdirt.activeInHierarchy)
                                {
                                    activity = "Dry";
                                    toggleacornnotifs(activity);
                                    fairynarration(10);
                                }
                            }
                        }
                        else if (gamestate == 11)
                        {
                            if (selection.CompareTag("island"))
                            {
                                acorns[0].transform.position = hit.point;
                                onbadisland = 1; //island plantable
                            }
                            else if (selection.CompareTag("badisland"))
                            {
                                acorns[0].transform.position = hit.point;
                                onbadisland = 2; //island notplantable
                            }
                        }
                        else if (gamestate == 13)
                        {
                            if (selection.CompareTag("island"))
                            {
                                acorns[1].transform.position = hit.point;
                                onbadisland = 1; //island plantable
                            }
                            else if (selection.CompareTag("badisland"))
                            {
                                acorns[1].transform.position = hit.point;
                                onbadisland = 2; //island notplantable
                            }
                        }

                    }
                }
                //reveal badger
                if (gamestate == 3 && meshofbad.enabled == false && Vector3.Distance(player.transform.position, badger.transform.position) <= proximitydistance)
                {
                    meshofbad.enabled = true;
                    for (int i = 0; i < acorns.Length; i++)
                    {
                        acorns[i].SetActive(true);
                    }
                    fairytarget = F[2];
                    fairynarration(4);
                }
                //badger
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
                        toggleacornnotifs("off");
                        fairynarration(6);
                        //uncomment below and comment out above for demo
                        //fairynarration(9);
                    }
                    if (B == 3)
                    {
                        acorns[2].transform.parent = null;
                        acorns[1].transform.parent = null;
                        acorns[0].transform.parent = null;
                    }
                }
                //drop acorns
                if (acorns[0].transform.parent == null || acorns[1].transform.parent == null || acorns[2].transform.parent == null
                && (acornstate[0] != "set" || acornstate[1] != "set" || acornstate[2] != "set"))
                {
                    for (int i = 0; i < acorns.Length; i++)
                    {
                        if (acornstate[i] != "set")
                        {
                            if (acorns[i].transform.position != acornpoints[i].transform.position)
                            {
                                acorns[i].transform.position = Vector3.MoveTowards(acorns[i].transform.position, acornpoints[i].transform.position, fairyspeed * Time.deltaTime);
                            }
                            else
                            {
                                acornstate[i] = "set";
                                acornnotifs[i].SetActive(true);
                            }
                        }
                    }
                }
                //subactivities
                if (activity == "Shade" && 11 == gamestate)
                { //acorn 0
                    if (Vector3.Distance(shadehitbox.transform.position, acorns[0].transform.position) > shadehitboxradius)
                    {
                        if (onbadisland == 1)
                        { //island plantable
                            fairynarration(12);
                            toggleacornnotifs("off");
                            Swetdirt.SetActive(true);
                            onbadisland = 0;
                            activitiesincomplete--;
                        }
                    }
                }
                else if (activity == "Cement" && 13 == gamestate)
                { // acorn 1
                    if (Vector3.Distance(shadehitbox.transform.position, acorns[1].transform.position) > shadehitboxradius)
                    {
                        if (onbadisland == 1)
                        { //island plantable
                            fairynarration(14);
                            toggleacornnotifs("off");
                            Cwetdirt.SetActive(true);
                            onbadisland = 0;
                            activitiesincomplete--;
                        }
                    }
                }
                else if (activity == "Dry" && 15 == gamestate)
                { // acorn 2
                    if (canstate == "tipped")
                    {
                        toggleacornnotifs("off");
                        DDrydirt.SetActive(false);
                        Dwetdirt.SetActive(true);
                        fairynarration(16);
                        onbadisland = 0;
                        activitiesincomplete--;
                    }
                }
                if (activitiesincomplete == 0 && gamestate <= 16)
                {
                    //StartCoroutine(Waitforaudiotofinish());
                    activitiesincomplete--;
                }
                if (gamestate == 10)
                {
                    fairytarget = F[3];
                }

                //watercan controller
                if (canstate == "tipped")
                {
                    canstate = "return";
                    waterincan.SetActive(false);
                    watercantext.SetActive(false);
                    movewateringcan();
                }
                if (canstate == "tipping")
                {
                    waterincan.SetActive(true);
                    wateringcan.transform.rotation = Quaternion.Slerp(wateringcan.transform.rotation, wateringcancheckpoint.transform.rotation, Time.deltaTime * smooth);
                    if (wateringcan.transform.rotation == wateringcancheckpoint.transform.rotation)
                    {
                        waterincan.SetActive(true);
                        castleactivate();
                        StartCoroutine(stopWatering());
                    }
                }
            }
            //fairy controller
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

        //castle animation 
        public void castleactivate()
        {
            castleanim.SetBool("CastleAnim", true);
        }
        //fairy subtitles clear
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
            else if (gamestate == 19)
            {
                reviewQuestionUI.OpenReviewQuestions();
            }
            fairytext.text = "";
            inputLock = false;
        }
        //watercan movement
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
        //toggles based on "toggle" value the arrows above each acorn
        private void toggleacornnotifs(string toggle)
        { //inputs: "on" "off" and each activity
            if (toggle == "on")
            {
                for (int i = 0; i < acornnotifs.Length; i++)
                {
                    acornnotifs[i].SetActive(true);
                }
            }
            else if (toggle == "off")
            {
                for (int i = 0; i < acornnotifs.Length; i++)
                {
                    acornnotifs[i].SetActive(false);
                }
            }
            else if (toggle == "Shade")
            {
                acornnotifs[0].SetActive(true);
                acornnotifs[1].SetActive(false);
                acornnotifs[2].SetActive(false);
            }
            else if (toggle == "Cement")
            {
                acornnotifs[0].SetActive(false);
                acornnotifs[1].SetActive(true);
                acornnotifs[2].SetActive(false);
            }
            else if (toggle == "Dry")
            {
                acornnotifs[0].SetActive(false);
                acornnotifs[1].SetActive(false);
                acornnotifs[2].SetActive(true);
            }
            else { Debug.Log("Incorrect toggle notifs command: " + toggle); }
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