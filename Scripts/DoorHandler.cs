using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] bool bDoorOpen = false;
    [SerializeField] int pos = 1;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Started overlapping with player.");
            DoorSystem sys = collision.gameObject.GetComponent<DoorSystem>();
            if (sys != null)
            {
                if (sys.CheckDoorKey(pos)) OpenDoor();
            }
        }
    }

    void OpenDoor()
    {
        Debug.Log("Opening the door.");       
        animator.SetBool("bOpen",true);
    }

    void CloseDoor()
    {
        Debug.Log("Closing the door.");
    }

    void SetbDoorOpen(bool val)
    {
        bDoorOpen = val;
    }
    
}
