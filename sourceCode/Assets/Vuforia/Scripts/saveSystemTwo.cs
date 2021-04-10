using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//saveSystemTwo focuses on managing the 'timeFile', a binary coded data file.
//It handles the process of generating, loading and wiping a timeFile.

public class saveSystemTwo 
{
    public static void saveFileTwo(monitorActivity MA)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "/timeFILE.txt";
        FileStream stream = new FileStream(savePath, FileMode.Create);

        timeFile timeData = new timeFile(MA);
        formatter.Serialize(stream,timeData);
        stream.Close();
    }

    public static timeFile loadFileTwo()
    {
        string savePath = Application.persistentDataPath + "/timeFILE.txt";
        
        if(File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.Open);

            timeFile timeData = formatter.Deserialize(stream) as timeFile;
            stream.Close();

            return timeData;
        }
        else
        {
            Debug.LogError("File not found at "+savePath);
            return null;
        }
    }

    public static void wipeFileTwo()
    {
        string savePath = Application.persistentDataPath + "/timeFILE.txt";

        File.Delete (savePath);
        SceneManager.LoadScene("menuScene");
    }
}
