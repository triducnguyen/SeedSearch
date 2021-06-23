using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenLocator : MonoBehaviour
{
    public Transform bee, beeMadeIt;
    public GameObject pollen;
    void Update()
    {
        if(bee.transform == beeMadeIt.transform)
        {
            pollen.gameObject.SetActive(true);
        }
    }
}
