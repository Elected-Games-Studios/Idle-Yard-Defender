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
    //{
    //    string path = Application.persistentDataPath + "/Player-Data-Stats.json";
    //    if (File.Exists(path))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream stream = new FileStream(path, FileMode.Open);
    //        formatter.Deserialize(stream);
    //        stream.Close();
    //        return stream;
    //    }    public static T Load<T>()
    {
        string path = Application.persistentDataPath + "/saves/";
        BinaryFormatter formatter = new BinaryFormatter();
        //this auto fills in the nulls as a default value for that type if it doesnt find any there!
        StatsToSave returnValue = new StatsToSave();
        //using puts something memory but once it's done it frees it up and dumps it.
        FileStream filestream = new FileStream(path, FileMode.Open);
        returnValue = (StatsToSave)formatter.Deserialize(filestream);
        return returnValue;
        //else
        //{
        //    Debug.LogError("Save file not found in " + path);
        //    return null;
        //}
    }
}
