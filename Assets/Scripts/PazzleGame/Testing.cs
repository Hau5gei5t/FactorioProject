using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class Testing : MonoBehaviour
{
    [SerializeField] List<GameObject> listItems;
    
    MyGrid grid;
    [SerializeField] GameObject grass;
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
        //for (var x = 0; x < 12; x++)
        //    for (var y = 0; y < 9; y++)
        //        Instantiate(grass, grid.GetWorldPosition(x, y) + new Vector3(CS, CS) * .5f,
        //                    Quaternion.Euler(0, 0, 0));
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level1")) 
        {
            for (var i = 0; i < 5; i++)
            {
                grid.SetValue(i, 4, 1);
                listItems[0].name = i + "_" + 4;
                belts[0].SetXYID(i, 4, 1);
                Instantiate(listItems[0], grid.GetWorldPosition(i, 4) + new Vector3(CS, CS) * .5f,
                            Quaternion.Euler(0, 0, (0) * 90));
            }
            for (var i = 8; i < 11; i++)
            {
                grid.SetValue(i, 4, 1);
                listItems[0].name = i + "_" + 4;
                belts[0].SetXYID(i, 4, 1);
                Instantiate(listItems[0], grid.GetWorldPosition(i, 4) + new Vector3(CS, CS) * .5f,
                            Quaternion.Euler(0, 0, (0) * 90));
            }
            
        };
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2"))
        {
            for (var i = 0; i < 5; i++)
            {
                grid.SetValue(i, 2, 1);
                listItems[0].name = i + "_" + 2;
                belts[0].SetXYID(i, 2, 1);
                Instantiate(listItems[0], grid.GetWorldPosition(i, 2) + new Vector3(CS, CS) * .5f,
                            Quaternion.Euler(0, 0, (0) * 90));
            }
            for (var i = 8; i < 11; i++)
            {
                grid.SetValue(i, 4, 1);
                listItems[0].name = i + "_" + 4;
                belts[0].SetXYID(i, 4, 1);
                Instantiate(listItems[0], grid.GetWorldPosition(i, 4) + new Vector3(CS, CS) * .5f,
                            Quaternion.Euler(0, 0, (0) * 90));

            }
            for (var i = 0; i < 7; i++)
            {
                grid.SetValue(i, 3, 11);
                grid.SetValue(i, 1, 11);
                listItems[0].name = i + "_" + 3;
                listItems[0].name = i + "_" + 1;
                belts[0].SetXYID(i, 3, 11);
                belts[0].SetXYID(i, 1, 11);
                Instantiate(listItems[10], grid.GetWorldPosition(i, 3) + new Vector3(CS, CS) * .5f,
                            Quaternion.Euler(0, 0, (0) * 90));
                Instantiate(listItems[10], grid.GetWorldPosition(i, 1) + new Vector3(CS, CS) * .5f,
                            Quaternion.Euler(0, 0, (0) * 90));
            }
        };

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
                    if(ID!=10 && ID!=11)
                    Instantiate(listItems[ID - 1], grid.GetWorldPosition(x, y) + new Vector3(CS, CS) * .5f, 
                        Quaternion.Euler(0,0,(ID-1)*90));
                    else
                    Instantiate(listItems[ID - 1], grid.GetWorldPosition(x, y) + new Vector3(CS, CS) * .5f,
                        Quaternion.Euler(0, 0, 0));

                }

            }
            if (Input.GetMouseButtonDown(1))
            {
                grid.GetXY(UtilsClass.GetMouseWorldPosition(), out x, out y);
                if(grid.GetArray()[x,y]!=11)
                    grid.SetValue(UtilsClass.GetMouseWorldPosition(), 0);
                if (true)
                {
                    listItems[ID - 1].name = x + "_" + y + "(Clone)";
                    if(GameObject.Find(x + "_" + y + "(Clone)") !=null)
                    Destroy(GameObject.Find(listItems[ID - 1].name).gameObject);
                }

            }

        }
    }
}
