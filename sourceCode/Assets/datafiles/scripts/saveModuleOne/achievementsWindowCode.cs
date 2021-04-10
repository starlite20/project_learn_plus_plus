using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achievementsWindowCode : MonoBehaviour
{
    public GameObject achievementsWindow;

    public AudioSource buttonAudioSource;
    public AudioClip buttonAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        achievementsWindow.SetActive(false);
    }

    public void openAchievementsWindow()
    {
        //Play sound
        buttonAudioSource.PlayOneShot(buttonAudioClip);

        achievementsWindow.SetActive(true);
    }

    public void closeAchievementsWindow()
    {
        //Play sound
        buttonAudioSource.PlayOneShot(buttonAudioClip);
        
        achievementsWindow.SetActive(false);
    }
}
