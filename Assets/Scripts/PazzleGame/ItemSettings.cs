using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemSettings : MonoBehaviour
{
    Testing bs;
    [SerializeField] int ID;
    private void Awake()
    {
        bs = GameObject.Find("test").GetComponent<Testing>();
    }
    private void SetIDB(int ID)
    {
        bs.SetID(ID);
    }
    public int GetID()
    {
        return ID;
    }

}
