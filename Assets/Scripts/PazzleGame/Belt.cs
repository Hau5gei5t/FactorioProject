using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class Belt : MonoBehaviour
{
    [SerializeField] float speed = 100;
    [SerializeField] Vector3 direction;
    [SerializeField] Vector3 LastDirection;
    [SerializeField] bool isFull = false;
    [SerializeField] Testing testing = null;
    [SerializeField] int X;
    [SerializeField] int Y;
    [SerializeField] int id;
    [SerializeField] Vector3 position;

 
    private void Update()
    {
        switch (id)
        {
            case 1:
                if (MyGrid.gridArray[X + 1, Y] != 0) direction = new Vector2(5, 0);
                position = this.transform.position;
                break;
            case 2:
                if (MyGrid.gridArray[X, Y + 1] != 0) direction = new Vector2(0, 5);
                position = this.transform.position;
                break;
            case 3:
                if (MyGrid.gridArray[X - 1, Y] != 0) direction = new Vector2(-5, 0);
                position = this.transform.position;
                break;
            case 4:
                if (MyGrid.gridArray[X, Y - 1] != 0) direction = new Vector2(0, -5);
                position = this.transform.position;
                break;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        
        collision.transform.Translate(direction * speed * Time.fixedDeltaTime);
    }
    public void SetXYID(int x, int y,int id)
    {
        this.X = x;
        this.Y = y;
        this.id = id;
    }
}
