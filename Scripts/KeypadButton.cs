using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadButton : MonoBehaviour
{
    public GameObject KeypadUI;
    public Animation MasterDoor;
    public Text passCode;
    private int count = 0; 
    // Start is called before the first frame update
    void Start()
    {
        passCode.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && KeypadUI.activeInHierarchy)
        {
            passCode.text = "";
            KeypadScript.maxvalue = 0;
        }
        if(passCode.text == "1402" && count == 0)
        {
            MasterDoor.Play("Open");
            count = 1;
        }
    }
    /*public void Pressed()
    {
        KeypadUI.SetActive(true);
        Time.timeScale = 0f;
        passCode.text = "";
    }*/
}
