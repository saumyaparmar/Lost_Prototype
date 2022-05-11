using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCast : MonoBehaviour
{
    public static float DistanceFromTarget;
    public float ToTarget;
    public static float DistanceOfCamFromTarget;
    public float CamToTarget;
    public static RaycastHit hit;
    public static RaycastHit hitCam;
    public GameObject Camera;
    public GameObject Dot;
    private bool SceneEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad> 11 && SceneEnded == false)
        {
            Dot.SetActive(true);
            GetComponent<PlayerScript>().enabled = true;
            GetComponent<PlayerCollision>().enabled = true;
            SceneEnded = true;
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit))
        {
            ToTarget = hit.distance;
            DistanceFromTarget = ToTarget;
            //Debug.Log(DistanceFromTarget);
            //Debug.Log(hit.collider);
        }
        if (Physics.Raycast(Camera.transform.position, Camera.transform.TransformDirection(Vector3.forward), out hitCam))
        {
            CamToTarget = hitCam.distance;
            DistanceOfCamFromTarget = CamToTarget;
        }
    }
}
