using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using JetBrains.Annotations;
using static StatsToSave;

public static class LocalSaveEngine
{
    private static StatsToSave statsToSave;
    public static string Sts;
    public static void SavePlayer()
    {
        var save = StringsToSave();
        string path = Application.persistentDataPath + "/Player-Data-Stats.dat";
        FileStream stream = new FileStream(path, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(stream, save);
        stream.Close();
    }
    /*public static void LoadPlayer()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player-Data-Stats.dat";
        FileStream filestream = new FileStream(path, FileMode.Open, FileAccess.Read);
        if (File.Exists(path))
        {
            try
            {
                using (filestream)
                {
                    string loadString;
                    (loadString) formatter.Deserialize(filestream);
                    CashManager.Cash = stats.Cash;
                }
            }
            catch
            {
                Debug.Log("Saving error has occured");
            }
        }
    }*/
    /*public static void SavePlayer(string saveString)
    {   //create binary file 
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath+"/player.sav",FileMode.Create);
        saveString = StringsToSave();
        //use Serialize - 
        bf.Serialize(stream, saveString);
        //close file stream
        stream.Close();
    }
    //load the file 
    public static int[] LoadPlayer() {
        //check the file exist
        if (File.Exists(Application.persistentDataPath + "/player.sav"))
        {
            //open binary file 
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Open);
            saveString = bf.Deserialize(stream) as PlayerData;
            //close file stream
            stream.Close();
            //return data from file
            return data.stats;
        }
        else {
            Debug.LogError("File don't exist!");
            return new int[5];
        }
    }*/
}
