using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataSave
{
    public static void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/data.hleb";

        FileStream stream = new FileStream(path, FileMode.Create);

        Data data = new Data();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Data LoadData()
    {
        string path = Application.persistentDataPath + "/data.hleb";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            Data data =  formatter.Deserialize(stream) as Data;


            stream.Close();
            return data;
            
        }
        else
        {
            Debug.Log("save file not found");
            return null;
        }
    }

}
