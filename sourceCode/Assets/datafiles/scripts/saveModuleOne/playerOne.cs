using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerOne : MonoBehaviour
{
    public static string username = "Null";
    public GameObject input, output;
    public GameObject nameWindow, nameDisp;

    public Animator nameWindowTransition;

    public AudioSource buttonAudioSource;
    public AudioClip buttonAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        nameWindow.SetActive(false);
        nameDisp.SetActive(false);

        if( saveSystemOne.loadFile() == null )
        {
            nameWindow.SetActive(true);
        }
        else
        {
            playerFile data = saveSystemOne.loadFile();
            output.GetComponent<Text>().text = "hi " + (data.userName);

            nameDisp.SetActive(true);
        }
        
    }

    public void copyUserName() //as data is static
    {
        username = input.GetComponent<Text>().text;
    }

    public string getUserName() //passing the value as it is static
    {
        return username;
    }
    
    public void onSubmitClicked()
    {
        //Play sound
        buttonAudioSource.PlayOneShot(buttonAudioClip);

        copyUserName();
        nameWindowTransition.SetTrigger("CLOSEname");
        StartCoroutine(closeNameWindow());

        saveSystemOne.saveFile(this);
        
        playerFile data = saveSystemOne.loadFile();
        output.GetComponent<Text>().text = "hi" + (data.userName) +"!";
    }
    
    IEnumerator closeNameWindow()
    {
        yield return new WaitForSeconds(2f);
        nameWindow.SetActive(false);
    }
}
