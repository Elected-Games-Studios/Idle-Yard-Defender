using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class LocalSaveEngine
{
    public static string SaveString;

    public static long Cash { get; set; } = YardManager.instance.cash;
    public static long Crypto { get; set; } = YardManager.instance.crypto;
    public static string TurretString { get; set; } = DataBaseManager.SaveSenderTurrets();
    public static string StringsToSave()
    {
        string CashString = Convert.ToString(Cash);
        string CryptoString = Convert.ToString(Crypto);
        string SaveString = CashString + CryptoString + TurretString;
        return SaveString;
    }
    public static void SavePlayer()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player-Data-Stats.json";
        FileStream stream = new FileStream(path, FileMode.Create);
        StreamWriter writer = new StreamWriter(stream);
        writer.Write(SaveString);
        stream.Close();
    }

    public static SavedVariables LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Player-Data-Stats.json";
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
