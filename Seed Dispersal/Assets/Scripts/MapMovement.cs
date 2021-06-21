using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMovement : MonoBehaviour
{
    bool mapDown = true;
    public bool[] setOn = new bool[5];
    bool test = false;
    public Button mapSpriteUp;
    public Button mapSpriteDown;
    bool vocabDown = true;
    public Button vocabSpriteDown;
    public Button vocabSpriteUp;

    void Start()
    {
        //mapSpriteUp.gameObject.SetActive(false);
        //vocabSpriteUp.gameObject.SetActive(false);
    }

    public void MapController()
    {
        if(mapDown == true && vocabDown == true)
        {
            mapSpriteDown.gameObject.SetActive(false);
            mapSpriteUp.gameObject.SetActive(true);
            // if(test == true)
            // {
            //     step1.gameObject.SetActive(true);
            // }
            mapDown = false;
        }
        else if(mapDown == false)
        {
            mapSpriteDown.gameObject.SetActive(true);
            mapSpriteUp.gameObject.SetActive(false);
            mapDown = true;
        }
    }
    public void VocabController()
    {
        if(vocabDown == true && mapDown == true)
        {
            vocabSpriteDown.gameObject.SetActive(false);
            vocabSpriteUp.gameObject.SetActive(true);
            vocabDown = false;
        }
        else if(vocabDown == false)
        {
            vocabSpriteDown.gameObject.SetActive(true);
            vocabSpriteUp.gameObject.SetActive(false);
            vocabDown = true;
        }
    }
}
