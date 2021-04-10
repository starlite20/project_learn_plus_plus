using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Displays the information slide for the Augmented Reality Learning Scene
public class infoDisplay : MonoBehaviour
{
    public Animator infoTransition;
    public GameObject infoButton;

    public AudioSource buttonAudioSource;
    public AudioClip buttonAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        infoButton.SetActive(false);
    }

    public void onInfoClicked()
    {
        //Play sound
        buttonAudioSource.PlayOneShot(buttonAudioClip);
        infoButton.SetActive(true);
    }

    public void onInfoClosed()
    {
        buttonAudioSource.PlayOneShot(buttonAudioClip);
        infoTransition.SetTrigger("CLOSEinfo");
        StartCoroutine(playCloseAnimation());
    }

    IEnumerator playCloseAnimation()
    {
        yield return new WaitForSeconds(2f);
        infoButton.SetActive(false);
    }
}
