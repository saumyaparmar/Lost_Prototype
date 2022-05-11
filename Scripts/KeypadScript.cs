using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeypadScript : MonoBehaviour
{
    public static int maxvalue;
    public Text passCode;
    // Start is called before the first frame update
    void Start()
    {
        passCode.text = "";
        maxvalue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            passCode.text = "";
            maxvalue = 0;
        }

    }
    public void getNumber()
    {
        if(maxvalue<4)
        {
            passCode.text += name;
            maxvalue++;
        }
    }
    /*public void clear()
    {
        passCode.text = "";
        maxvalue = 0;
    }*/
}
