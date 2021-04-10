using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class profilePlayerData : MonoBehaviour
{
    public GameObject welcomeObject;

    // Start is called before the first frame update
    void Start()
    {
        playerFile data = saveSystemOne.loadFile();
        welcomeObject.GetComponent<Text>().text = (data.userName);
    }

    public void eraseData()
    {
        saveSystemOne.wipeFile(); 
    }
}
