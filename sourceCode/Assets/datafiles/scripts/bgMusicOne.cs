using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bgMusicOne : MonoBehaviour
{
    public void Awake()
    {
        //This code alone will work, but multiple copies of the 
        //BGM will reappear everytime the home-scene is loaded.
        //Therefore bgMUSICtwo code is applied.

        DontDestroyOnLoad(gameObject);
    }
}
