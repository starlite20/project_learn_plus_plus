using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//saveSystemOne focuses on managing the 'playerFile', a binary coded data file.
//It handles the process of generating, loading and wiping a playerFile.

public class saveSystemOne 
{
    public static void saveFile(playerOne player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "/playerFILE.txt";
        FileStream stream = new FileStream(savePath, FileMode.Create);

        playerFile playerData = new playerFile(player);
        formatter.Serialize(stream,playerData);
        stream.Close();
    }

    public static playerFile loadFile()
    {
        string savePath = Application.persistentDataPath + "/playerFILE.txt";
        
        if(File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.Open);
            playerFile playerData = formatter.Deserialize(stream) as playerFile;
            
            stream.Close();

            return playerData;
        }
        else
        {
            Debug.LogError("FILE NOT FOUND AT "+savePath);
            return null;
        }
    }

    public static void wipeFile()
    {
        string savePath = Application.persistentDataPath + "/playerFILE.txt";

        File.Delete (savePath);
        SceneManager.LoadScene("menuScene");
    }
}
