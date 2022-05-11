using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BGSoundsHandler : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ObjectsWithBGSound = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject ob in ObjectsWithBGSound)
        {
            ob.GetComponent<AudioSource>().Play();
        }
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
