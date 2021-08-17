using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SeedSearch
{
    public class John_gamemanager_Path02 : MonoBehaviour
    {
        private bool inputLock = false;
        private bool answeringQuestion = false;
        private bool antTriggered = false;
        private Coroutine previousCoroutine;
        [SerializeField] private int gamestate = 1;
        [Header("Bee")]
        public GameObject Bee;
        private Vector3 beetarget;
        [System.NonSerialized] public bool beeP = false;
        [System.NonSerialized] public bool beeF = false;
        [SerializeField] private float beesmooth;
        public GameObject beepollen;
        [SerializeField] private int pollencount = 0;
        public int numflowers;
        public GameObject firstseeds;
        public GameObject lastseeds;
        public GameObject tapflowericon;

        [Header("Indicator")]
        public GameObject indicator;

        [Header("Ant")]
        public GameObject ant;
        public Animator antanim;
        public float antspeed;
        public GameObject[] antwaypoints;
        [System.NonSerialized] public bool antsstart;

        [System.NonSerialized] public int numberfallenseeds = 0;
        [System.NonSerialized] public Transform antselect;
        private Vector3 anttarget;
        private bool seedbeendropped = false;
        public bool antsareup = true;
        private bool seedsareup = true;
        public GameObject[] ants;
        public GameObject[] seeds;

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
        
        public bool AnsweringQuestion { get => answeringQuestion; set => answeringQuestion = value; }
        public QuestionUI questionUI;

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
            antanim.SetBool("Walking", false);
            fairytarget = F0;
            fairynarration(1);
            firstseeds.SetActive(false);
            //anttarget = ant.transform.position;
            lastseeds.SetActive(false);

            SaveManager.Instance.LoadStudentData(currentStudent);
            currentStudent = SaveManager.Instance.studentProfile;
            Debug.Log(currentStudent.Levelprogress[0] + " " + currentStudent.Levelprogress[1] + " " + currentStudent.Levelprogress[2]);
        }

        private RaycastHit hit;
        void Update()
        {

            if (island.activeInHierarchy && gamestate < 2)
            {
                fairynarration(2);
            }
            if (!answeringQuestion)
            {
                if (Input.GetMouseButtonDown(0) && !inputLock)
                {
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        var selection = hit.transform;
                        if (selection.CompareTag("dandelionflower"))
                        {
                            beetarget = hit.point;
                            beeF = true;
                            Bee.transform.LookAt(beetarget);
                        }
                        if (antTriggered)
                        {
                            if (selection.CompareTag("Ant") && antsstart != true)
                            {
                                antselect = hit.transform;
                                anttarget = antselect.transform.position;
                            }
                            else if (selection.CompareTag("island") && antsstart != true && antselect != null)
                            {
                                indicator.SetActive(false);
                                anttarget = hit.point;
                                antselect.LookAt(anttarget);
                            }
                        }

                    }
                }
            }
            if (gamestate > 8 && gamestate < 12)
            {
                indicator.SetActive(true);
                indicator.transform.LookAt(player.transform);
            }

            if (numberfallenseeds == 1 && gamestate < 10)
            {
                indicator.SetActive(true);
                fairynarration(10);
            }
            else if (numberfallenseeds > 4 && gamestate < 11)
            {
                indicator.SetActive(false);
                fairynarration(11);
            }


            if (antselect != null && antselect.transform.position != anttarget)
            {
                antselect.transform.position = Vector3.MoveTowards(antselect.transform.position, anttarget, antspeed * Time.deltaTime);
            }


            if (antselect != null && Vector3.Distance(firstseeds.transform.position, antselect.position) < 0.1f)
            {
                antsstart = true;
            }


            if (ants[0].activeInHierarchy || ants[1].activeInHierarchy || ants[2].activeInHierarchy || ants[3].activeInHierarchy || ants[4].activeInHierarchy)
            {
                antsareup = true;
            }
            else
            {
                antsareup = false;
            }


            if ((seedbeendropped && antsareup == false) && (seeds[0].activeInHierarchy || seeds[1].activeInHierarchy || seeds[2].activeInHierarchy || seeds[3].activeInHierarchy || seeds[4].activeInHierarchy))
            {
                seedsareup = true;
            }
            else if (seedbeendropped && antsareup == false && !antTriggered)
            {
                seedsareup = false;
            }


            if (seedbeendropped == false && numberfallenseeds > 0 && antsareup == false)
            {
                seedbeendropped = true;
                fairynarration(12);
            }
            else if (seedsareup == false && gamestate == 12)
            {
                lastseeds.SetActive(true);
                castleactivate();
                fairynarration(13);
                fairytarget = F3;
            }


            if (beeF == true)
            {
                Bee.transform.position = Vector3.MoveTowards(Bee.transform.position, beetarget, beesmooth * Time.deltaTime);
                if (Bee.transform.position == beetarget)
                {
                    beeF = false;
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


            if (gamestate == 4)
            {
                fairytarget = F1;
            }
            else if (gamestate == 6)
            {
                fairytarget = F2;
            }

            fairysubtitles.transform.LookAt(player.transform.position);
        }

        public void beepollentoggle()
        {
            if (beeP == true)
            {
                beepollen.SetActive(true);
            }
            else
            {
                beepollen.SetActive(false);
            }
            pollencount++;
            if (numflowers <= pollencount && gamestate < 6)
            {
                firstseeds.SetActive(true);
                fairynarration(6);
                //antsstart = true;
                //antanim.SetBool("Walking", true);
            }
            else if (2f <= pollencount && gamestate < 5)
            {
                tapflowericon.SetActive(false);
                fairynarration(5);
            }
        }
        public void castleactivate()
        {
            castleanim.SetBool("CastleAnim", true);
        }

        IEnumerator Subtitle(float time)
        {
            inputLock = true;
            yield return new WaitForSeconds(time);
            if (gamestate == 2)
            {
                questionUI.OpenQuestion(4);
            }
            else if (gamestate == 6)
            {
                questionUI.OpenQuestion(5);
            }
            else if (gamestate == 7)
            {
                fairynarration(8);
            }
            else if (gamestate == 8)
            {
                questionUI.OpenQuestion(6);
            }
            else if(gamestate == 13)
            {
                fairynarration(14);
            }
            else if (gamestate == 14)
            {
                questionUI.OpenQuestion(7);
            }

            subtitle.text = "";
            fairytext.text = "";
            inputLock = false;

        }
        public StudentData currentStudent;
        IEnumerator endpath(){            
            yield return new WaitForSeconds(2f);
            Debug.Log("done waiting");
            SceneManager.LoadScene("Path03");
        }
        public void pushend(){
            Debug.Log("pushend");
            currentStudent.Levelprogress =  new int[] {2, 2, 1};
            Debug.Log(currentStudent.Levelprogress[0] + " " + currentStudent.Levelprogress[1] + " " + currentStudent.Levelprogress[2]);
            
            SaveManager.Instance.SaveStudentFile(currentStudent); 
            Debug.Log("Save successfull");
            StartCoroutine(endpath());
        }

        public void fairynarration(int instate)
        {
            gamestate = instate;
            if (gamestate == 1)
            {
                soundManager.PlayAudio("01_2");
                fairytext.text = o1seedfairy;
                subtitle.text = o1seedfairy;
                StartCoroutine(Subtitle(3f));
            }
            else if (gamestate == 2)
            {
                soundManager.PlayAudio("02_2");
                fairytext.text = o2seedfairy;
                subtitle.text = o2seedfairy;
                previousCoroutine = StartCoroutine(Subtitle(20f));
            }
            else if (gamestate == 3)
            {
                soundManager.PlayAudio("03_2");
                fairytext.text = o3seedfairy;
                subtitle.text = o3seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(15f));
            }
            else if (gamestate == 4)
            {
                soundManager.PlayAudio("04_2");
                fairytext.text = o4seedfairy;
                subtitle.text = o4seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(5f));
            }
            else if (gamestate == 5)
            {
                soundManager.PlayAudio("05_2");
                fairytext.text = o5seedfairy;
                subtitle.text = o5seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(17f));
            }
            else if (gamestate == 6)
            {
                soundManager.PlayAudio("06_2");
                fairytext.text = o6seedfairy;
                subtitle.text = o6seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(10f));
            }
            else if (gamestate == 7)
            {
                soundManager.PlayAudio("07_2");
                fairytext.text = o7seedfairy;
                subtitle.text = o7seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(18f));
            }
            else if (gamestate == 8)
            {
                soundManager.PlayAudio("08_2");
                fairytext.text = o8seedfairy;
                subtitle.text = o8seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(7f));
            }
            else if (gamestate == 9)
            {
                antTriggered = true;
                indicator.SetActive(true);
                soundManager.PlayAudio("09_2");
                fairytext.text = o9seedfairy;
                subtitle.text = o9seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(20f));
            }
            else if (gamestate == 10)
            {
                soundManager.PlayAudio("10_2");
                fairytext.text = o10seedfairy;
                subtitle.text = o10seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(3f));
            }
            else if (gamestate == 11)
            {
                soundManager.PlayAudio("11_2");
                fairytext.text = o11seedfairy;
                subtitle.text = o11seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(6f));
            }
            else if (gamestate == 12)
            {
                antTriggered = false;
                soundManager.PlayAudio("12_2");
                fairytext.text = o12seedfairy;
                subtitle.text = o12seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(7f));
            }
            else if (gamestate == 13)
            {
                soundManager.PlayAudio("13_2");
                fairytext.text = o13seedfairy;
                subtitle.text = o13seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(10f));
            }
            else if (gamestate == 14)
            {
                soundManager.PlayAudio("14_2");
                fairytext.text = o14seedfairy;
                subtitle.text = o14seedfairy;
                StopCoroutine(previousCoroutine);
                previousCoroutine = StartCoroutine(Subtitle(7f));
                StartCoroutine(endpath());
            }

        }
    }
}
