using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public void QuitApp()
    {
        //Debug.Log("QuitAPP");
        Application.Quit();
    }
    public void GoToSelectLevels()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToGuide()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToBook()
    {
        SceneManager.LoadScene(3);
    }
}
