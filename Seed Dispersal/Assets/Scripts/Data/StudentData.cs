using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StudentData
{
    [SerializeField] private List<float> times;
    [SerializeField] private List<float> overalltimes;
    [SerializeField] private string firstName;
    [SerializeField] private string lastName;
    [SerializeField] private string firstPrompt;
    [SerializeField] private string secondPrompt;
    [SerializeField] private string thirdPrompt;
    [SerializeField] private List<string> answers = new List<string>();
    [SerializeField] private int[] levelprogress = new int[] {1, 0, 0};

    public List<float> OverallTimes { get => overalltimes; set => overalltimes = value; }
    public List<float> Times { get => times; set => times = value; }
    public string FirstName { get => firstName; set => firstName = value; }
    public string LastName { get => lastName; set => lastName = value; }
    public string FirstPrompt { get => firstPrompt; set => firstPrompt = value; }
    public string SecondPrompt { get => secondPrompt; set => secondPrompt = value; }
    public string ThirdPrompt { get => thirdPrompt; set => thirdPrompt = value; }
    public List<string> Answers { get => answers; set => answers = value; }
    public int[] Levelprogress { get => levelprogress; set => levelprogress = value; }
}
