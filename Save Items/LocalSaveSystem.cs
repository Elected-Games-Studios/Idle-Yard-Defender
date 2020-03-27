using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;

public class LocalSaveSystem : MonoBehaviour
{
    public static void Save<T>(T objectToSave)
    {
        string path = Application.persistentDataPath + "/saves/";
        Directory.CreateDirectory(path);
        BinaryFormatter formatter = new BinaryFormatter();
        //using puts something memory but once it's done it dumps it.
        using (FileStream filestream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(filestream, objectToSave);
        }
    }
    //returns a generic loaded set of objects... 
    public static T Load<T>()
    {
        string path = Application.persistentDataPath + "/saves/";
        BinaryFormatter formatter = new BinaryFormatter();
        //this auto fills in the nulls as a default value for that type if it doesnt find any there!
        T returnValue = default(T);
        //using puts something memory but once it's done it frees it up and dumps it.
        using (FileStream filestream = new FileStream(path, FileMode.Open))
        {
            returnValue = (T)formatter.Deserialize(filestream);
        }
        return returnValue;
    }

    public static bool SaveExists()
    {
        string path = Application.persistentDataPath + "/saves/";
        return File.Exists(path);
    }
    //for whatever reason you may want to you can delete the entire save directory and make a brand new one...  so yea..  this is smart.
    public static void SeriousllyDeleteAllSaveFiles()
    {
        string path = Application.persistentDataPath + "/saves/";
        DirectoryInfo directory = new DirectoryInfo(path);
        directory.Delete();
        Directory.CreateDirectory(path);

    }
}
