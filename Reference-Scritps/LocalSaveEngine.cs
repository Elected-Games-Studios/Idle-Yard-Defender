using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class LocalSaveEngine
{
    public static void SavePlayer(LoadedVariables player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerData.stats";
        FileStream stream = new FileStream(path, FileMode.Create);
        Debug.Log("SavePlayer Filestream Opened");
        SavedVariables data = new SavedVariables(player);
        Debug.Log("Variable data created");
        formatter.Serialize(stream, data);
        Debug.Log("formatted stream");
        stream.Close();
        Debug.Log("SavePlayer Filestream Closed");
    }

    public static SavedVariables LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerData.stats";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SavedVariables data = formatter.Deserialize(stream) as SavedVariables;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
