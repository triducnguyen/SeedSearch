﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StudentData", menuName ="StudentData/Data")]
public class StudentData : ScriptableObject
{
    [SerializeField] private string userName;
    [SerializeField] private string password;

    public string UserName { get => userName; set => userName = value; }
    public string PassWord { get => password; set => password = value; }
}
