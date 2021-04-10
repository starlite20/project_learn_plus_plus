using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Maintains the Loading Screen Functionalities
public class loadingScreen : MonoBehaviour
{
    public GameObject loadScreen;
    public Slider slider;
    public Text loadPercentage;

    int loadingPercentValue;

    static int levelLoaderFlag = 0;
    static string levelName;

    public static void loadingActivator(string levelNameObtained)
    {
        levelLoaderFlag = 1;
        levelName = levelNameObtained;
    }

    public void loadingLevel (string levelNameObtained)
    {
        StartCoroutine(LoadAsynchronously(levelNameObtained));
    }

    void Start()
    {
        loadScreen.SetActive(false);
    }

    void Update()
    {
        if( levelLoaderFlag == 1 )
        {
            levelLoaderFlag = 0;
            loadingLevel (levelName);
        }
    }

    IEnumerator LoadAsynchronously (string levelNameObtained)
    {
        //Gets current status of the loading operation
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelNameObtained);

        loadScreen.SetActive(true);

        //Until scene is loaded, the progress is updated in this loop
        while(!operation.isDone)
        {
            //Unity displays progress value between 0 and 0.9,
            //therefore we convert it to 0 to 1
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            loadingPercentValue = (int)(progress * 100f);
            loadPercentage.text = loadingPercentValue + "%";

            //Waits till the next scene loads
            yield return null;
        }
    }
}
