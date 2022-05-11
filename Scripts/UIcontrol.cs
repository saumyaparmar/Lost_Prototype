using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontrol : MonoBehaviour
{
    public GameObject[] UIElements;
    private void Start()
    {
        for(int i=0;i<UIElements.Length;i++)
        {
            UIElements[i].SetActive(false);
        }

    }
}
