using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] Transform player;

    PlayerCollision playerCollision;

    private void Awake()
    {
        playerCollision = player.GetComponent<PlayerCollision>();
    }

    public void ResumeClickedFunction()
    {
        Debug.Log("Resume called in menu handler");
        playerCollision.ResumeGame();
    }

    public void OptionClickedFunction()
    {
        //Debug.Log("Option called in menu handler");
        //add code for options here.
    }

    public void QuitToMainBtnClicked()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Gameplay");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void QuitGameBtnClicked()
    {
        Application.Quit();
    }
}