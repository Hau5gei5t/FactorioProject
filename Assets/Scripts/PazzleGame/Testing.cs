using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class Testing : MonoBehaviour
{
    [SerializeField] List<GameObject> listItems;
    
    MyGrid grid;
    [SerializeField] int x;
    [SerializeField] int y;
    [SerializeField] float CS;
    [SerializeField] Vector3 originPosition;
    [SerializeField] GameObject test;
    [SerializeField] int ID;
    [SerializeField] Belt[] belts;
    [SerializeField] Manipulator[] manipulators;
    private void Start()
    {
        grid = new MyGrid(12, 9, 5f, new Vector3(-42f, -22.5f));

    }
    public void SetID(int value)
    {
        ID = value;
        Debug.Log("ID Changed");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            grid.GetXY(UtilsClass.GetMouseWorldPosition(), out x, out y);
            Instantiate(listItems[4], grid.GetWorldPosition(x, y) + new Vector3(CS,CS)*.5f,
                Quaternion.Euler(0, 0, (4) * 90));
        }
            if (Input.GetKeyDown(KeyCode.R))
        {
            if((ID - 1 >=0 && ID - 1<= 3) || (ID-1 >= 5 && ID-1 <= 8)) 
            {
                Debug.LogWarning("R");
                switch (ID - 1)
                {
                    case 3:
                        ID = 1;
                        break;
                    case 0:
                        ID += 1;
                        break;
                    case 1:
                        ID += 1;
                        break;
                    case 2:
                        ID += 1;
                        break;
                    case 5:
                        ID += 1;
                        break;
                    case 6:
                        ID += 1;
                        break;
                    case 7:
                        ID += 1;
                        break;
                    case 8:
                        ID = 6;
                        break;

                }
            }
        }
        grid.GetXY(UtilsClass.GetMouseWorldPosition(), out x, out y);
        if (x < 12 && x >= 0 && y >= 0 && y < 9)
        {
            if (Input.GetMouseButtonDown(0))
            {
                grid.GetXY(UtilsClass.GetMouseWorldPosition(), out x, out y);
                grid.SetValue(UtilsClass.GetMouseWorldPosition(), ID);
                if (grid.IsChanged())
                {
                    listItems[ID - 1].name = x + "_" + y;
                    if (ID - 1 >= 0 && ID - 1 <= 3) belts[ID - 1].SetXYID(x, y, ID);
                    if (ID - 1 >= 5 && ID - 1 <= 8) manipulators[ID - 1 - 5].SetXYID(x, y, ID);
                    Instantiate(listItems[ID - 1], grid.GetWorldPosition(x, y) + new Vector3(CS, CS) * .5f, 
                        Quaternion.Euler(0,0,(ID-1)*90));
                    
                }

            }
            if (Input.GetMouseButtonDown(1))
            {
                grid.GetXY(UtilsClass.GetMouseWorldPosition(), out x, out y);
                grid.SetValue(UtilsClass.GetMouseWorldPosition(), 0);
                if (true)
                {
                    listItems[ID - 1].name = x + "_" + y + "(Clone)";
                    Destroy(GameObject.Find(listItems[ID - 1].name).gameObject);
                }

            }

        }
    }
}
