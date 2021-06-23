using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartApp()
    {
        SceneManager.LoadScene("LessonOne");
    }

    public void Experience2()
    {
        SceneManager.LoadScene("LessonTwo");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    // Update is called once per frame
}
