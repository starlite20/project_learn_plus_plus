using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bgMusicTwo : MonoBehaviour
{
    public AudioSource myAudioSource;
    public static GameObject bgmObject;
    static int musicStatus;

    void Awake()
    {
        if(bgmObject)
        {
            //GameObject is a data type, whereas
            //gameObject refers to currently linked game object in unity.
            Destroy(gameObject);
            return;
        }

        musicStatus = 0;
        myAudioSource.Play();
        bgmObject = gameObject;
    }

    //Raises the Music Flag to Stop the music
    public static void stopMusic()
    {
        musicStatus = 1;
    }

    //Raises the Music Flag to Play the music
    public static void playMusic()
    {
        musicStatus = 0;
    }

    void Update()
    {
        if(musicStatus == 1)
        {
            myAudioSource.Stop();
            musicStatus = 2;
        }
        if(musicStatus == 0)
        {
            myAudioSource.Play();
            musicStatus=2;
        }
    }
}
