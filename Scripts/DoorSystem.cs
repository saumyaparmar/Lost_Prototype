using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DoorSystem : MonoBehaviour
{
    [SerializeField] int doorkeys = 0;


    public bool CheckDoorKey(int pos)
    {
        return (((1 << pos) & doorkeys) != 0);
    }

    public void UpdateDoorKey(int pos)
    {
        doorkeys |= (1 << pos);
        Debug.Log(System.Convert.ToString(doorkeys,2));
    }

    public void ClearDoorKey(int pos)
    {
        doorkeys &= ~(1<<pos);
        Debug.Log(System.Convert.ToString(doorkeys, 2));
    }

    public void ClearAllDoorKey()
    {
        doorkeys = 0;
    }
}