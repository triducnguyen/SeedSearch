using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMovement : MonoBehaviour
{
    public GameObject mapUp;
    public GameObject vocabUp;
    public GameObject mapDown;
    public GameObject vocabDown;

    void Start()
    {
        mapUp.SetActive(false);
        vocabUp.SetActive(false);
    }

    public void MapController1()
    {
        mapUp.SetActive(true);
        mapDown.SetActive(false);
    }

    public void MapController2()
    {
        mapUp.SetActive(false);
        mapDown.SetActive(true);
    }
    public void VocabController1()
    {
        vocabUp.SetActive(true);
        vocabDown.SetActive(false);
    }
    public void VocabController2()
    {
        vocabUp.SetActive(false);
        vocabDown.SetActive(true);
    }
}
