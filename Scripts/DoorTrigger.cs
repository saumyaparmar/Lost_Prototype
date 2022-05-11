using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject Door;
    public Light Bathroomlight;
    private Animation anim;

    private AudioSource[] Audios;
    private AudioSource doorSound;
    //private AudioSource scaryEffect;

    /*
     * discarded for now
    [SerializeField]
    private GameObject horrorMessageTxt;
    */

    // Start is called before the first frame update
    void Start()
    {
        anim = Door.GetComponent<Animation>();
        anim.enabled = false;
        Audios = GetComponents<AudioSource>();
        //horrorMessageTxt.SetActive(false);
        foreach (AudioSource a in Audios)
        {
            if (a.clip.name == "doorslam")
            {
                doorSound = a;
            }
           /* else if (a.clip.name == "door_banging")
            {
                scaryEffect = a;
            }*/
        }
        //print("Audio Components found: "+Audios.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            //Debug.Log("Animate");
            anim.enabled = true;
            anim.Play("Close");
            GetComponent<BoxCollider>().enabled = false;
            //StartCoroutine("Flicker");
            doorSound.Play();            
        }
    }
    /*IEnumerator Flicker()
    {
        yield return new WaitForSeconds(1.5f);
        scaryEffect.Play();
        //old script for bathroom light, currently discarded
        /*
        //Bathroomlight.GetComponent<FlickeringLight>().enabled = true;
        Bathroomlight.enabled = false;
        GameObject par = Bathroomlight.gameObject.transform.parent.gameObject;
        //print("Parent name is "+par.name);
        Renderer rend = par.GetComponent<Renderer>();
        Material mat = rend.material;        
        //print("Material name is "+mat.name);
        mat.SetColor("_EmissionColor",new Color(0f,0f,0f));
        yield return new WaitForSeconds(1.5f);
        
        Bathroomlight.enabled = true;       
        Bathroomlight.color = new Color(1f,0f,0f);
        mat.SetColor("_EmissionColor", new Color(1f, 0f, 0f));
        horrorMessageTxt.SetActive(true);
        
    }*/
}
