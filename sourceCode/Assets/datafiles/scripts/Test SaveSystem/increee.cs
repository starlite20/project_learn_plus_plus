using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class increee : MonoBehaviour
{
    public int val=0;
    public GameObject textt;

    // Update is called once per frame
    public void incremval()
    {
        val+=10;
        textt.GetComponent<Text>().text = val.ToString();
    }

    public void savedetails()
    {
        SaveSystem.SaveFile(this);
    }

    public void loaddetails()
    {
        saveFile data = SaveSystem.LoadFile();

        val = data.valueee;
        textt.GetComponent<Text>().text = val.ToString();
    }
}
