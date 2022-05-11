using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenuHandler : MonoBehaviour
{
   [Header("Volume Settings")]
   [SerializeField] private TMP_Text volumeTextValue = null;
   [SerializeField] private Slider volumeSlider = null;
   [SerializeField] private int defaultVolume = 50;

    public GameObject PlayButton;
    public GameObject Mainscreen;
    public GameObject CreditScreen;
    public GameObject loadingInterface;
    public GameObject Volume;
    public GameObject Options;
 
   /* public GameObject ShowCursor;*/
  /*  public GameObject Cursor;*/

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(PlayButton);
        Mainscreen.SetActive(true);
        CreditScreen.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        /*  if (Input.GetKey("up"))
          {
              EventSystem.current.SetSelectedGameObject(this.gameObject);
          }

          if (Input.GetKey("down"))
          {
              EventSystem.current.SetSelectedGameObject(this.gameObject);
          }
*/
          if(Input.GetKey(KeyCode.Escape) && !Mainscreen.activeInHierarchy)
          {

              Mainscreen.SetActive(true);
           /*   Cursor.SetActive(false);*/
        CreditScreen.SetActive(false);
        Volume.SetActive(false);
        }
    }
    
    public void SetVolume(float volume)
    {
      AudioListener.volume = volume;
      volumeTextValue.text = volume.ToString("0");
    }

    public void VolumeApply()
    {
      PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
      //Show Prompt
      //StartCoroutine(ConfirmationBox());
    }

    public void ResetButton(string MenuType)
    {
     if (MenuType == "Audio")
     {
      AudioListener.volume = defaultVolume;
      volumeSlider.value = defaultVolume;
      volumeTextValue.text = defaultVolume.ToString("0");
      VolumeApply();
     }
    }

    /*public IEnumerator ConfirmationBox()
    {
      confirmationPrompt.SetActive(true);
      yield return new WaitForSeconds(2);
      confirmationPrompt.SetActive(false);  
    }*/
   
    public void exitGame()
    {
      Application.Quit();
    }
    public void playGame()
    {
        SceneManager.LoadSceneAsync("LoadingScreen");
    }
    public void Credits()
    {
        Mainscreen.SetActive(false);
        CreditScreen.SetActive(true);
    }
}
