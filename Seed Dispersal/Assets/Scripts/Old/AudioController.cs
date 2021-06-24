using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : PlacementController
{
    public AudioClip firstClip;
    public AudioClip secondClip;
    public AudioClip thirdClip;
    public AudioClip fourthClip;
    public AudioClip fifthClip;
    public AudioClip sixthClip;
    public AudioClip seventhClip;
    public AudioClip eighthClip;
    public GameObject soundObject;
    public AudioSource audioSound;
    //bool firstClipStartBool = false;
    bool firstSoundPlayed = false;
    bool secondSoundPlayed = false;
    public GameObject startButton;
    public GameObject seedAppear;
    bool fourthClipPlayed = false;
    //bool seedHit = false;
    bool seedSoundRun = false;
    bool fifthClipPlayed = false;
    public GameObject seedDisperse;
    bool seedDisperseActiveOnce = false;
    public GameObject wind;
    public GameObject v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12;
    public bool seedSend;
    public GameObject seedWindSend;
    public GameObject textBox;
    public GameObject flowerIndicator;
    public GameObject tapToMoveBee;
    public GameObject secondtaptomovebee;
    public GameObject seed;
    public Transform finalSeedDestination;
    bool sixthSoundPlayed = false;
    bool seventhSoundPlayed = false;
    public GameObject rose;
    public GameObject cm1, cm2, cm3, cm4, cm5, cm6;
    bool eighthSoundPlayed = false;
    public GameObject restartButton;
    public GameObject badger;

    public int MapUIprogress;

    void Start()
    {
        audioSound = soundObject.GetComponent<AudioSource>();
        audioSound.clip = firstClip;
        //v1.SetActive(true);
        //v2.SetActive(true);
        tapToMoveBee.SetActive(false);
        secondtaptomovebee.SetActive(false);
    }
    void Update()
    {
        /*if(firstSoundPlayed == true)
        {
            if(!audioSound.isPlaying && secondSoundPlayed == false)
            {
                audioSound.clip = secondClip;
                audioSound.Play();
                secondSoundPlayed = true;
                StartCoroutine(Audio2());
                //v3.SetActive(true);
                //v4.SetActive(true);
                //v5.SetActive(true);
            }
            tapToMoveBee.SetActive(true);
        }
        if(!audioSound.isPlaying && secondSoundPlayed == true)
        {
            audioSound.Pause();
            //flowerIndicator.SetActive(true);
            tapToMoveBee.SetActive(false);
            secondtaptomovebee.SetActive(true);
        }
        if(seedAppear.activeInHierarchy && fourthClipPlayed == false)
        {
            tapToMoveBee.SetActive(false);
            secondtaptomovebee.SetActive(false);
            audioSound.clip = fourthClip;
            audioSound.Play();
            fourthClipPlayed = true;
            //v6.gameObject.SetActive(true);
            //v7.gameObject.SetActive(true);
            //step3Map.SetActive(true);
            StartCoroutine(Audio4());
        }
        if(fourthClipPlayed == true && fifthClipPlayed == false && !audioSound.isPlaying && seedDisperseActiveOnce == false)
        {
            seedDisperse.SetActive(true);
            seedDisperseActiveOnce = true;
        }
        if(fifthClipPlayed == true && !audioSound.isPlaying && seedSend == false)
        {
            seedWindSend.SetActive(true);
            badger.SetActive(true);
            seedSend = true;
        }
        if(seed.transform.position == finalSeedDestination.position && sixthSoundPlayed == false)
        {
            audioSound.clip = sixthClip;
            audioSound.Play();
            sixthSoundPlayed = true;
            cm5.SetActive(true);
            //v8.SetActive(true);
            //v9.SetActive(true);
            StartCoroutine(Audio6());
        }
        if(sixthSoundPlayed == true && !audioSound.isPlaying && seventhSoundPlayed == false)
        {
            audioSound.clip = seventhClip;
            audioSound.Play();
            seventhSoundPlayed = true;
            seed.SetActive(false);
            rose.SetActive(true);
            //v10.SetActive(true);
            //v11.SetActive(true);
            //v12.SetActive(true);
            StartCoroutine(Audio7());
        }
        if(seventhSoundPlayed == true && !audioSound.isPlaying && eighthSoundPlayed == false)
        {
            audioSound.clip = eighthClip;
            audioSound.Play();
            eighthSoundPlayed = true;
            seed.SetActive(false);
            StartCoroutine(Audio8());
        }*/

        if(firstSoundPlayed == true)
        {
            if(MapUIprogress == 0 && secondSoundPlayed == false)
            {
                audioSound.clip = secondClip;
                audioSound.Play();
                secondSoundPlayed = true;
                StartCoroutine(Audio2());
                //v3.SetActive(true);
                //v4.SetActive(true);
                //v5.SetActive(true);
            }
            tapToMoveBee.SetActive(true);
        }
        if(MapUIprogress == 1 && secondSoundPlayed == true)
        {
            audioSound.Pause();
            //flowerIndicator.SetActive(true);
            tapToMoveBee.SetActive(false);
            secondtaptomovebee.SetActive(true);
        }
        if(seedAppear.activeInHierarchy && fourthClipPlayed == false)
        {
            tapToMoveBee.SetActive(false);
            secondtaptomovebee.SetActive(false);
            audioSound.clip = fourthClip;
            audioSound.Play();
            fourthClipPlayed = true;
            //v6.gameObject.SetActive(true);
            //v7.gameObject.SetActive(true);
            //step3Map.SetActive(true);
            StartCoroutine(Audio4());
        }
        if(fourthClipPlayed == true && fifthClipPlayed == false && MapUIprogress == 2 && seedDisperseActiveOnce == false)
        {
            seedDisperse.SetActive(true);
            seedDisperseActiveOnce = true;
        }
        if(fifthClipPlayed == true && MapUIprogress == 3 && seedSend == false)
        {
            seedWindSend.SetActive(true);
            badger.SetActive(true);
            seedSend = true;
        }
        if(seed.transform.position == finalSeedDestination.position && sixthSoundPlayed == false)
        {
            audioSound.clip = sixthClip;
            audioSound.Play();
            sixthSoundPlayed = true;
            cm5.SetActive(true);
            //v8.SetActive(true);
            //v9.SetActive(true);
            StartCoroutine(Audio6());
        }
        if(sixthSoundPlayed == true && MapUIprogress == 4 && seventhSoundPlayed == false)
        {
            audioSound.clip = seventhClip;
            audioSound.Play();
            seventhSoundPlayed = true;
            seed.SetActive(false);
            rose.SetActive(true);
            //v10.SetActive(true);
            //v11.SetActive(true);
            //v12.SetActive(true);
            StartCoroutine(Audio7());
        }
        if(seventhSoundPlayed == true && MapUIprogress == 5 && eighthSoundPlayed == false)
        {
            audioSound.clip = eighthClip;
            audioSound.Play();
            eighthSoundPlayed = true;
            seed.SetActive(false);
            StartCoroutine(Audio8());
        }

        /*if(gamestate == "start"){
            tapToMoveBee.SetActive(true);
        } else if(gamestate == "Pollination 2"){
            tapToMoveBee.SetActive(false);
            secondtaptomovebee.SetActive(true);
        }*/
    }

    private string gamestate;

    public void inset(string info){
        gamestate = info;
    }
    public void BeginButtonPress()
    {
        audioSound.Play();
        startButton.gameObject.SetActive(false);
        firstSoundPlayed = true;
        StartCoroutine(Audio1());
        gamestate = "start";
    }
    public void NextIdea1Press()
    {
        audioSound.clip = thirdClip;
        audioSound.Play();
        nextIdea1.gameObject.SetActive(false);
        //flowerIndicator.SetActive(false);
        
        //step2.gameObject.SetActive(true);
        //mapStep2.SetActive(true);
        
        
        StartCoroutine(Audio3());
    }
    public void DisperseSeeds()
    {
        //map4.gameObject.SetActive(true);
        if(seedSoundRun == false)
        {
            
            //step3.gameObject.SetActive(true);
            //step3Map.SetActive(true);
            audioSound.clip = fifthClip;
            //map4.gameObject.SetActive(true);
            audioSound.Play();
            fifthClipPlayed = true;
            seedSoundRun = true;
            seedDisperse.SetActive(false);
            wind.SetActive(true);
            StartCoroutine(Audio5());
        }
        
    }
    IEnumerator Audio1()
    {
        yield return new WaitForSeconds(0);
        textBox.GetComponent<Text>().text = "All plants begin as a seed.";
        yield return new WaitForSeconds(2.9f);
        textBox.GetComponent<Text>().text = "A seed is the part of a plant that can grow to become a new plant.";
        yield return new WaitForSeconds(3.8f);
        textBox.GetComponent<Text>().text = "Like us humans, plants go through a life cycle, changing and growing as they get older.";
        yield return new WaitForSeconds(5.2f);
        textBox.GetComponent<Text>().text = "In order for these seeds to spread and new plants to grow, they depend on the forces of nature to move them around and for pollenation.";
        yield return new WaitForSeconds(8f);
        //textBox.GetComponent<Text>().text = "";
    }
    IEnumerator Audio2()
    {
        yield return new WaitForSeconds(0);
        cm1.SetActive(true);
        textBox.GetComponent<Text>().text = "Look over here, we have a meadow, full of diverse flowers.";
        yield return new WaitForSeconds(3.9f);
        textBox.GetComponent<Text>().text = "A lot of them are fully grown and producing pollen, a yellow powder inside of flowers.";
        yield return new WaitForSeconds(5.4f);
        textBox.GetComponent<Text>().text = "In order for these flowers to spread seeds, they undergo pollenation, which is the process of moving pollen from one flower to another.";
        yield return new WaitForSeconds(8.5f);
        textBox.GetComponent<Text>().text = "Any animal that moves pollen from one plant to another is known as a pollinator, the most common of which are bees.";
        yield return new WaitForSeconds(7.3f);
        textBox.GetComponent<Text>().text = "And here is one now! Let's follow the bee along its journey!";
        yield return new WaitForSeconds(4.1f);
        textBox.GetComponent<Text>().text = "";
    }
    IEnumerator Audio3()
    {
        yield return new WaitForSeconds(0);
        cm2.SetActive(true);
        textBox.GetComponent<Text>().text = "Past the meadow, there are more flowers in need of pollen.";
        yield return new WaitForSeconds(3f);
        textBox.GetComponent<Text>().text = "All the pollen is sticking to the little bee. ";
        yield return new WaitForSeconds(2.9f);
        textBox.GetComponent<Text>().text = "He is flying over here to pollinate these other flowers and as he does so, some of that pollen will come off and stay in our new flowers.";
        yield return new WaitForSeconds(7.8f);
        textBox.GetComponent<Text>().text = "Once these flowers are pollinated, they produce their seeds for dispersal.";
        yield return new WaitForSeconds(4.6f);
        textBox.GetComponent<Text>().text = "";
    }
    IEnumerator Audio4()
    {
        yield return new WaitForSeconds(0);
        cm3.SetActive(true);
        textBox.GetComponent<Text>().text = "Seed dispersal is the process of moving seeds from one place to another for new plants to grow.";
        yield return new WaitForSeconds(6.3f);
        textBox.GetComponent<Text>().text = "You can see that after our bee pollinates these flowers, they can now drop their seeds.";
        yield return new WaitForSeconds(4.8f);
        textBox.GetComponent<Text>().text = "From here, they disperse, or spread around.";
        yield return new WaitForSeconds(3.3f);
        textBox.GetComponent<Text>().text = "Seeds are covered in a hard outer shell to protect them during this process.";
        yield return new WaitForSeconds(4.8f);
        textBox.GetComponent<Text>().text = "";
    }
    IEnumerator Audio5()
    {
        yield return new WaitForSeconds(0);
        cm4.SetActive(true);
        textBox.GetComponent<Text>().text = "With our seeds lying on the ground here, they are scattered by different factors that will move them to where they are eventually planted.";
        yield return new WaitForSeconds(7.8f);
        textBox.GetComponent<Text>().text = "Animals, wind, and water all pick up and carry the little seeds to their new destinations.";
        yield return new WaitForSeconds(5.8f);
        textBox.GetComponent<Text>().text = "Like this seed here, it's started moving!";
        yield return new WaitForSeconds(3.1f);
        textBox.GetComponent<Text>().text = "It looks like it was picked up by the wind. Where is it being taken?";
        yield return new WaitForSeconds(4.3f);
        textBox.GetComponent<Text>().text = "";
    }
    IEnumerator Audio6()
    {
        yield return new WaitForSeconds(0);
        cm5.SetActive(true);
        textBox.GetComponent<Text>().text = "It seems like our seed has settled next to all these other new plants.";
        yield return new WaitForSeconds(4.1f);
        textBox.GetComponent<Text>().text = "It will germinate and begin to grow here on the soil.";
        yield return new WaitForSeconds(3.2f);
        textBox.GetComponent<Text>().text = "Next to the river it shall get plenty of water, and in the middle of this meadow it will get plenty of sunlight.";
        yield return new WaitForSeconds(7.2f);
    }
    IEnumerator Audio7()
    {
        yield return new WaitForSeconds(0);
        cm6.SetActive(true);
        textBox.GetComponent<Text>().text = "Plants need time to grow from little seeds.";
        yield return new WaitForSeconds(3.2f);
        textBox.GetComponent<Text>().text = "Let's speed this one along though, so you can see it.";
        yield return new WaitForSeconds(3.5f);
        textBox.GetComponent<Text>().text = "First, it sprouts roots that will absorb water from the ground.";
        yield return new WaitForSeconds(4.3f);
        textBox.GetComponent<Text>().text = "From there it grows its stem to help support it.";
        yield return new WaitForSeconds(3.4f);
        textBox.GetComponent<Text>().text = "Off of the stem will grow little leaves to collect sunlight.";
        yield return new WaitForSeconds(4.2f);
    }
    IEnumerator Audio8()
    {
        yield return new WaitForSeconds(0);
        seed.SetActive(false);
        textBox.GetComponent<Text>().text = "And then, it blooms.";
        yield return new WaitForSeconds(2.2f);
        textBox.GetComponent<Text>().text = "Here it sits, next to the other flowers of this meadow, ready for the cycle to continue.";
        yield return new WaitForSeconds(5.6f);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(4f);
        restartButton.SetActive(true);
    }
}
