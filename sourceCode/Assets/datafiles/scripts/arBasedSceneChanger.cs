using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For Scene Management
using UnityEngine.SceneManagement;

//For Virtual Button Support
using Vuforia;


//Helps in managing Scenes within the Augmented Reality Learning Zone
public class arBasedSceneChanger : MonoBehaviour, IVirtualButtonEventHandler
{
    public Animator transition;
    public AudioSource buttons;
    public AudioClip menuFX;

    VirtualButtonBehaviour virtualButtonBehaviorObj;

    // Start is called before the first frame update
    void Start()
    {
        virtualButtonBehaviorObj = GetComponentInChildren<VirtualButtonBehaviour>();
        virtualButtonBehaviorObj.RegisterEventHandler(this);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Virtual button pressed");
        startCaeserCipherScene();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Virtual button released");
    }

    public void startCaeserCipherScene()
    {
        StartCoroutine(LoadLevel("caeserCipherScene"));
    }

    IEnumerator LoadLevel (string levelName)
    {
        //Play animation and sound
        transition.SetTrigger("CloseAction");
        buttons.PlayOneShot(menuFX);

        //Waits for the animation to complete
        yield return new WaitForSeconds(1f);

        //Load the next scene
        SceneManager.LoadScene(levelName);
    }

}
