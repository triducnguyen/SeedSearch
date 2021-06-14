using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StudentData
{
    [SerializeField] private string firstName;
    [SerializeField] private string lastName;
    [SerializeField] private string firstPrompt;
    [SerializeField] private string secondPrompt;
    [SerializeField] private string thirdPrompt;

    public string FirstName { get => firstName; set => firstName = value; }
    public string LastName { get => lastName; set => lastName = value; }
    public string FirstPrompt { get => firstPrompt; set => firstPrompt = value; }
    public string SecondPrompt { get => secondPrompt; set => secondPrompt = value; }
    public string ThirdPrompt { get => thirdPrompt; set => thirdPrompt = value; }
}
