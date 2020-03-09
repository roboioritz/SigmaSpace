using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveStats(SaveFile PlayerStats,int FileNum)
    {
        BinaryFormatter format = new BinaryFormatter();
        string path = Application.persistentDataPath + "/File" + FileNum + ".sigma";        
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        
        FileData data = new FileData(PlayerStats);

        format.Serialize(stream, data);
        stream.Close();
    }

    public static FileData LoadFile(int FileNum)
    {
        string path = Application.persistentDataPath + "/File" + FileNum + ".sigma";
        if (File.Exists(path))
        {            
            BinaryFormatter format = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            FileData data = format.Deserialize(stream) as FileData;
            Debug.Log(path);
            stream.Close();
            return data;            
        }
        else
        {                                  
            return null;
        }
    }
}
