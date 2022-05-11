using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public GameObject loadingInterface;
    public Image loadingProgressBar;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    IEnumerator LoadingScreen()
    {
        float totalProgress=0;
        for(int i=0; i < scenesToLoad.Count; ++i)
        {
           while(!scenesToLoad[i].isDone)
            {
              totalProgress += scenesToLoad[i].progress;
              loadingProgressBar.fillAmount = totalProgress/scenesToLoad.Count;
              yield return null;

            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LoadingScreen")
        {
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Gameplay"));
            scenesToLoad.Add(SceneManager.LoadSceneAsync("MasterBedroom", LoadSceneMode.Additive));
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Walkway", LoadSceneMode.Additive));
            scenesToLoad.Add(SceneManager.LoadSceneAsync("GroundFloor", LoadSceneMode.Additive));
            StartCoroutine(LoadingScreen());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "IntroVideo")
        {
            Cursor.visible = false;
            if(Time.realtimeSinceStartup > 17)
            {
                SceneManager.LoadSceneAsync("MainMenu");
                Cursor.visible = true;
            }
        }
       

    }
}
