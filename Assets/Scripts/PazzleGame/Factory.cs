using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    private ItemSettings item;
    private int count;
    [SerializeField]private int needCount;
    [SerializeField]private int needID;
    [SerializeField] GameObject result;
    IEnumerator Wait()
    {
        //Debug.LogError("wait");
        yield return new WaitForSecondsRealtime(50);
    }
    private void Update()
    {
        if (count == needCount)
        {
            count = 0;
            StartCoroutine(Wait());
            Instantiate(result, this.transform.position,Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            //Debug.LogError("Tag");
            item = collision.GetComponent<ItemSettings>();
            if(item.GetID() == needID)
            {
                //Debug.LogError("ID");
                count++;
                Destroy(collision.gameObject);
            }
        }
    }
}
