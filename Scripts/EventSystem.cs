using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem current;
    // Start is called before the first frame update
    void Start()
    {
        current = this;
    }
    public event Action Interactable;

    internal void SetSelectedGameObject(GameObject gameObject)
    {
        throw new NotImplementedException();
    }
}
