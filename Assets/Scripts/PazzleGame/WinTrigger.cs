using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    private ItemSettings item;
    private int count;
    [SerializeField] private int needCount;
    [SerializeField] private int needID;
    private void Update()
    {
        if (count == needCount)
        {
            popup.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            //Debug.LogError("Tag");
            item = collision.GetComponent<ItemSettings>();
            if (item.GetID() == needID)
            {
                //Debug.LogError("ID");
                count++;
                Destroy(collision.gameObject);
            }
        }
    }
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level1"))
            SceneManager.LoadScene(3);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2"))
            SceneManager.LoadScene(4);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level3"))
            SceneManager.LoadScene(0);
    }
}
