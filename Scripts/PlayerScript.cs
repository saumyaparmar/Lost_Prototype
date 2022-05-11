using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float MovementSpeed;
    public FootSteps soundGenerator;
    public float footTimer;
    private Rigidbody rb;
    private bool isWalking = false;


    #region CAM VARIABLES
    public Camera Cam;
    private bool invertCamera;
    private float rotateX;
    private float maxLookAngle;
    public float mouseSensitivity;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 300; 
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        Cam = Camera.main;
        soundGenerator = GetComponent<FootSteps>();
        invertCamera = false;
        maxLookAngle = 80;
        Cam.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void FixedUpdate()
    {
        Move();
        CameraRotation();
    }
    private void Move()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 PlayerVelocity = new Vector3(hori, 0, ver);
        PlayerVelocity *= MovementSpeed * Time.deltaTime;
        PlayerVelocity = transform.TransformDirection(PlayerVelocity); //convert velocity in terms of world space
        var velocityChange = PlayerVelocity - rb.velocity;
        rb.AddForce(velocityChange, ForceMode.VelocityChange);

        if(PlayerVelocity.x>0||PlayerVelocity.x<0 || PlayerVelocity.y > 0 || PlayerVelocity.y < 0 || PlayerVelocity.z > 0 || PlayerVelocity.z < 0)
        {
            if(isWalking != true && PlayerCast.DistanceFromTarget>1)
            {
                PlayFootStepSound();
            }
            
        }
    }


    private void CameraRotation()
    {
        var rotateY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;

        if (!invertCamera)
        {
            rotateX -= mouseSensitivity * Input.GetAxis("Mouse Y");
        }
        else
        {
            // Inverted Y
            rotateX += mouseSensitivity * Input.GetAxis("Mouse Y");
        }

        // Clamp pitch between lookAngle
        rotateX = Mathf.Clamp(rotateX, -maxLookAngle, maxLookAngle);
        transform.localEulerAngles = new Vector3(0, rotateY, 0);
        Cam.transform.localEulerAngles = new Vector3(rotateX, 0, 0);
    }
    void PlayFootStepSound()
    {
        StartCoroutine("PlayStepSound",footTimer);
    }
    IEnumerator PlayStepSound(float timer)
        {
            var ran = Random.Range(0,4);
            soundGenerator.footStepsSource.clip = soundGenerator.footSteps[ran];
            soundGenerator.footStepsSource.Play();
            isWalking = true;
            yield return new WaitForSeconds(timer);
            isWalking = false;
        }
}
