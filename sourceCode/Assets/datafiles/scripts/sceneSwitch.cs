using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Handles the Scene Switching Tasks
public class sceneSwitch : MonoBehaviour
{
    public Animator transition;
    public AudioSource buttons;
    public AudioClip menuFX;

    Scene currentScene;

    //Loads the Augmented Reality Learning Scene
    public void beginLearning()
    {
        StartCoroutine(LoadLevel("augmentedRealityScene"));
    }

    //Loads the Caeser Cipher Learning Page
    public void startCaeserCipher()
    {
        StartCoroutine(LoadLevel("caeserCipherScene"));
    }

    //Loads the Main Menu Scene
    public void menu()
    {
        StartCoroutine(LoadLevel("menuScene"));
    }

    //Loads Profile Details / Gamification Zone
    public void startProfile()
    {
        StartCoroutine(LoadLevel("profileScene"));
    }

    //Loads About Page
    public void startAbout()
    {
        StartCoroutine(LoadLevel("aboutScene"));
    }

    //Exits the Application
    public void exitApp()
    {
        //Play animation and sound
        transition.SetTrigger("CloseAction");
        buttons.PlayOneShot(menuFX);

        Application.Quit();
    }

    //Animation before and after loading the page
    IEnumerator LoadLevel (string levelName)
    {
        currentScene = SceneManager.GetActiveScene();

        //Play animation and sound
        transition.SetTrigger("CloseAction");
        buttons.PlayOneShot(menuFX);

        //Wait for the animation
        yield return new WaitForSeconds(1f);

        //Music should not be played during Learning process
        if(levelName == "augmentedRealityScene")
            bgMusicTwo.stopMusic();

        //Play the music if not in Learning Zone
        if(currentScene.name == "augmentedRealityScene")
            bgMusicTwo.playMusic();
        
        //Load the scene
        loadingScreen.loadingActivator(levelName);
    }
}
