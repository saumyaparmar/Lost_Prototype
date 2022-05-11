using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;
    public float timeMin = 0.01f;
    public float timeMax=0.2f;

    // Update is called once per frame
    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(Flickeringlight());
        }
    }
    IEnumerator Flickeringlight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(timeMin, timeMax);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;//After the Above Line the rest of all will be executed which is beneath it.
        timeDelay = Random.Range(timeMin, timeMax);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }

}
