using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzCamCollision : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float rayCastDist = 10.0f;

    /*
     * to create an array of two game objects tagged with puzzletag and swap when both have a value,
     * after the swap, set both of them to null again or maybe use a list and clear the list. 
    */

    void Start()
    {        
    }

    void Update()
    {
        //the movements of camera are in world space and not local
        if (Input.GetKeyDown(KeyCode.W))
        {
            cam.transform.position += transform.up * 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            cam.transform.position += transform.up * -0.1f;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            cam.transform.position += transform.right * 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            cam.transform.position += transform.right * -0.1f;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject obj;
            if (RaycastForObj(out obj))
            {
                //code for selecting an object and moving it.
            }
            else
            {
                Debug.Log("Didn't hit any object.");
            }
        }
    }

    bool RaycastForObj(out GameObject obj)
    {
        Vector3 origin = cam.transform.position;
        Vector3 end = cam.transform.position + cam.transform.forward.normalized * rayCastDist;
        Ray r = new Ray(origin, end - origin);

        Debug.DrawLine(origin, end, Color.red, 2.0f);
        RaycastHit hitRes;
        obj = null;
        if (Physics.Raycast(r,  out hitRes, rayCastDist))
        {            
            if (hitRes.transform.tag.ToLower() == "puzzletag")
            {
                obj = hitRes.transform.gameObject;
                return true;
            }
        }
        return false;
    }
}
