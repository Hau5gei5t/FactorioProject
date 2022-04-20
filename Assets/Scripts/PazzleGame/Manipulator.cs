using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
    [SerializeField] int input;
    [SerializeField] int output;
    [SerializeField] int X;
    [SerializeField] int Y;
    [SerializeField] int id;
    [SerializeField] int IDItem;
    [SerializeField] ItemSettings item;

    private void Start()
    {
        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            
            switch (id)
            {
                case 6:
                    StartCoroutine(Wait());
                    collision.transform.Translate(new Vector3(10f, 0));
                    break;
                case 7:
                    StartCoroutine(Wait());
                    collision.transform.Translate(new Vector3(0, 10f));
                    break;
                case 8:
                    StartCoroutine(Wait());
                    collision.transform.Translate(new Vector3(0, -10f));
                    break;
                case 9:
                    StartCoroutine(Wait());
                    collision.transform.Translate(new Vector3(-10f, 0));
                    break;
            }
        }
    }
    public void SetXYID(int x, int y, int id)
    {
        this.X = x;
        this.Y = y;
        this.id = id;
    }
}
