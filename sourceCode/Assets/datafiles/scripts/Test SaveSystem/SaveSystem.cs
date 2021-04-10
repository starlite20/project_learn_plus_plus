using UnityEngine;
using System.IO; //for creating and opening files
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveFile (increee i)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.txt";
        FileStream stream = new FileStream(path,FileMode.Create);

        saveFile data = new saveFile(i);

        formatter.Serialize(stream,data);
        stream.Close();
    }

    public static saveFile LoadFile ()
    {
        string path = Application.persistentDataPath + "/player.txt";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            saveFile data = formatter.Deserialize(stream) as saveFile;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("NO FILE FOUND!" + path);
            return null;
        }
    }

}
