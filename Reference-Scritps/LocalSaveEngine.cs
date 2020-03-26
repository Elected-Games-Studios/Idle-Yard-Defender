using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class LocalSaveEngine
{
    public static void SavePlayer()
    {
        FileStream stream = new FileStream(Application.persistentDataPath + "/Player-Data-Stats.dat", FileMode.Create);
        //BinaryFormatter binaryFormatter = new BinaryFormatter();
        StreamWriter writer = new StreamWriter(stream);
        writer.Write(StatsToSave.StringsToSave());
        //binaryFormatter.Serialize(stream, StatsToSave.StringsToSave());
        stream.Close();
    }

    //public static StatsToSave LoadPlayer()
    //{
    //    string path = Application.persistentDataPath + "/Player-Data-Stats.dat";
    //    if (File.Exists(path))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream stream = new FileStream(path, FileMode.Open);
    //        SavedVariables data = formatter.Deserialize(stream) as SavedVariables;
    //        stream.Close();
    //        return data;
    //    }
    //    else
    //    {
    //        Debug.LogError("Save file not found in " + path);
    //        return null;
    //    }
    //}
}
