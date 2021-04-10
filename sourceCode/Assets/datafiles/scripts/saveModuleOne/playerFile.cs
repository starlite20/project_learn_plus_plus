using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//The playerFile helps store the basic user data.
//This file is updated only when a new playerFile is generated.

[System.Serializable]
public class playerFile 
{
    public string userName;

    public playerFile (playerOne player)
    {
        userName = player.getUserName();
    }
}
