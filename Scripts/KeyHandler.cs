using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler : MonoBehaviour
{
    [SerializeField] int pos = 1;

    public int ReturnKeyPos()
    {
        return pos;
    }

    public void DisableCollision()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public void EnableCollision()
    {
        GetComponent<BoxCollider>().isTrigger = false;
    }
    
}
