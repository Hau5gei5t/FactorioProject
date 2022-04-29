using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameController : MonoBehaviour
{
    [SerializeField]GameObject pause;
    [SerializeField]GameObject menuButton;
    public void Resume()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        menuButton.SetActive(true);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
        menuButton.SetActive(false);
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
