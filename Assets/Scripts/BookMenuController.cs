using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BookMenuController : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject arrow;
    [SerializeField] bool isOpen = false;
    [SerializeField] int ID;
    [SerializeField] GameObject page;
    [SerializeField] static bool ispageShow;
    public void OpenButton()
    {
        if (!isOpen)
        {
            arrow.transform.Rotate(0, 0, -90);
            for (var i = 0; i < buttons.Length; i++) buttons[i].SetActive(true);
            isOpen = !isOpen;
        }
        else
        {
            arrow.transform.Rotate(0, 0, 90);
            for (var i = 0; i < buttons.Length; i++) buttons[i].SetActive(false);
            isOpen = !isOpen;
        }
    }
    public void ContentButton()
    {
        switch (ID)
        {
            case 1:
                page.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
