using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerCollision : MonoBehaviour
{

    public GameObject[] UIElements;
    public GameObject[] UIPickupElements;
    public GameObject[] DescriptiveElements;
    public TMP_Text ObjectText;

    [TextArea(3,10)]
    public string[] TextDescriptionElement;

    public Camera UICam;
    public GameObject Dot;

    int count,cnt =0,pickupScreen = 0;

    private DoorSystem sys;
    int Nam = -1;



    private void Start()
    {
        //at a time only one camera is required.
        UICam.gameObject.SetActive(false);
        UIElements[5].SetActive(false);
        sys = GetComponent<DoorSystem>();
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.SetCursor(cursorTexture, Vector2.zero,CursorMode.ForceSoftware);
    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && cnt==0 && !UICam.gameObject.activeInHierarchy && UIElements[5].activeInHierarchy == false) // Pause Game
        {
            
            PauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && cnt == 1 && UICam.gameObject.activeInHierarchy) //Resume Game
        {
            ResumeGame();
        }
        /*if (PlayerCast.hitCam.collider.gameObject.layer == 9)//Enable InteractionElements
        {
            if (PlayerCast.hitCam.distance < 1f)
            {
                //UIElements[0].SetActive(true);
                //UIElements[1].SetActive(true);
            }
        }
        if (PlayerCast.hitCam.collider.gameObject.layer != 9)//Disable InteractionElements
        {
           // UIElements[0].SetActive(false);
            //UIElements[1].SetActive(false);
        }*/

        //KEYPAD
        if(PlayerCast.hitCam.collider.gameObject.tag == "Keypad" && Input.GetKeyDown(KeyCode.E))//Keypad
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            UICam.gameObject.SetActive(true);
            UIElements[2].SetActive(true);
            this.gameObject.GetComponent<PlayerScript>().enabled = false;
            UIElements[6].SetActive(true);//Keypad
        }
        else if(UIElements[6].activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
        {
           
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            UICam.gameObject.SetActive(false);
            UIElements[2].SetActive(false);
            this.gameObject.GetComponent<PlayerScript>().enabled = true;
            UIElements[6].SetActive(false);//Keypad
        }



        if (PlayerCast.hitCam.collider.gameObject.tag == "Pickup") //Pickup Objects 
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                UIElements[2].SetActive(true); //set pause canvas true
                UIElements[4].SetActive(true); //Describe Object Canvas
                UIElements[5].SetActive(false); //set pause menu false
                for (int i = 0; i < UIPickupElements.Length; i++)
                {
                    if (UIPickupElements[i].name == PlayerCast.hitCam.collider.gameObject.name) //Check if it's the pickup element
                    {
                        Nam = i;
                        DescriptiveElements[i].SetActive(true);
                        ObjectText.text = TextDescriptionElement[i];
                        if (UIPickupElements[i].name == "Camera Device")
                        {
                            count = 1;
                        }
                        UIPickupElements[i].SetActive(false); //Destroy Picked Up Element
                    }
                    else
                    {
                        DescriptiveElements[i].SetActive(false);
                    }
                }
                this.gameObject.GetComponent<PlayerScript>().enabled = false;
                UICam.gameObject.SetActive(true); //Object Description Screen
                pickupScreen = 1;
            }
        }
        if (GetComponent<PlayerScript>().enabled == false && UIElements[4].gameObject.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && cnt == 0 && pickupScreen == 1)
            {
                DescriptiveElements[Nam].SetActive(false);
                Nam = -1;
                UIElements[2].SetActive(false); //Pause canvas close
                UIElements[4].SetActive(false); //Describe Object Close
                this.gameObject.GetComponent<PlayerScript>().enabled = true;
                UICam.gameObject.SetActive(false); //UICam is disabled

                /*if (count == 1)
                {
                    UIElements[3].SetActive(true);
                }*/
                pickupScreen = 0;
            }
        }

        /*if (PlayerCast.hitCam.collider != null && PlayerCast.hitCam.collider.gameObject.layer == 9)//Enable InteractionElements
        {
            if (PlayerCast.hitCam.distance < 1)
            {
                UIElements[0].SetActive(true);
                //UIElements[1].SetActive(true);
            }
        }
        if(PlayerCast.hitCam.collider !=null && PlayerCast.hitCam.collider.gameObject.layer != 9)//Disable InteractionElements
        {
            UIElements[0].SetActive(false);
            //UIElements[1].SetActive(false);
        }*/
    }
    
    public void PauseGame()
    {
        Dot.SetActive(false);
        this.gameObject.GetComponent<PlayerScript>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        UICam.gameObject.SetActive(true);
        UIElements[2].SetActive(true);//Pause Canvas
        /*if(count == 1)
        {
            UIElements[3].SetActive(false);
        }*/
        UIElements[4].SetActive(false);
        UIElements[5].SetActive(true);
        cnt = 1;
    }

    public void ResumeGame()
    {
        Dot.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        this.gameObject.GetComponent<PlayerScript>().enabled = true;
        UICam.gameObject.SetActive(false);
        /*if(count == 1)
        {
            UIElements[3].SetActive(true); //CameraRenderer
        }*/
        UIElements[2].SetActive(false);//Pause Canvas
        UIElements[5].SetActive(false);
        cnt = 0;
    }

    
}
