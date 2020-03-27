using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class LocalSaveEngine
{
    public static void SavePlayer()
    {
        string path = Application.persistentDataPath + "/Player-Data-Stats.json";
        FileStream stream = new FileStream(path, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(stream, StatsToSave.Instance.StringsToSave());
        stream.Close();
    }
    public static StatsToSave LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Player-Data-Stats.json";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream filestream = new FileStream(path, FileMode.Open);
            StatsToSave returnValue = new StatsToSave();
            returnValue = formatter.Deserialize(filestream) as StatsToSave;
            filestream.Close();
            return returnValue;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
