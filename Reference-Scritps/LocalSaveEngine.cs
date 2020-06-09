using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class LocalSaveEngine
{
    public static void SavePlayer()
    {
        string path = Application.persistentDataPath + "/Player-Data-Stats.dat";
        FileStream stream = new FileStream(path, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(stream, StatsToSave.StringsToSave());
        stream.Close();
    }
    public static void LoadPlayer()
    {
        StatsToSave stats = new StatsToSave();
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player-Data-Stats.dat";
        FileStream filestream = new FileStream(path, FileMode.Open, FileAccess.Read);
        if (File.Exists(path))
        {
            try
            {
                using (filestream)
                {
                    stats = (StatsToSave)formatter.Deserialize(filestream);
                    //CashManager.instance.Cash = stats.Cash;
                }
            }
            catch
            {
                Debug.Log("Saving error has occured");
            }
        }
    }
}
