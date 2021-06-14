using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StudentData
{
    [SerializeField] private string userName;
    [SerializeField] private string password;
    [SerializeField] private string times;

    [SerializeField] private string firstPrompt;
    [SerializeField] private string secondPrompt;
    [SerializeField] private string thirdPrompt;

    public string UserName { get => userName; set => userName = value; }
    public string PassWord { get => password; set => password = value; }
    public string Times { get => times; set => times = value; }
    public string FirstPrompt { get => firstPrompt; set => firstPrompt = value; }
    public string SecondPrompt { get => secondPrompt; set => secondPrompt = value; }
    public string ThirdPrompt { get => thirdPrompt; set => thirdPrompt = value; }
}
