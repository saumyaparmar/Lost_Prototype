using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrips : MonoBehaviour
{
    [SerializeField,Range(2f,10f)] 
    private float waitingTime;

    private bool bWaiting = false;
    private AudioSource[] audios;
    private AudioSource currentAudio = new AudioSource();
    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponents<AudioSource>();
        if (Time.realtimeSinceStartup > 2)
        {
            PlayRandomSound();
        }
    }

    void PlayRandomSound()
    {
        //print("Playing sound");
        currentAudio = audios[Random.Range(0, audios.Length)];
        currentAudio.Play();
    }
    IEnumerator WaitingRoutine() 
    {
        //print("Waiting for some time");
        bWaiting = true;
        yield return new WaitForSeconds(Random.Range(2f,waitingTime));
        bWaiting = false;
        PlayRandomSound();
    }

    private void Update()
    {
        if (!currentAudio.isPlaying && !bWaiting)
        {
            StartCoroutine("WaitingRoutine");
        }
    }
}
