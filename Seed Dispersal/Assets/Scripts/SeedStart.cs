﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedStart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject seeds;
    public GameObject step2;
    private void OnTriggerEnter(Collider other)
    {
        seeds.SetActive(true);
        step2.SetActive(true);
    }
}
