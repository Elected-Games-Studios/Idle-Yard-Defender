using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;

public static class LocalSaveSystem
{
    private static string[] tempLoad;

    #region SaveStuff

    public static byte[] SaveParse() //Kyles string appending logic for the save; returns the blob to send to google
    {
        var tempSave = "";
        tempSave += DataBaseManager.SaveSenderTurrets();
        tempSave += '#';
        //tempSAve += DataBaseManager.SaveSenderZombies();
        //tempSave += '#';
        //tempSave += DataBaseManager.SaveSenderHouse();
        //tempSave += '#';
        tempSave += Convert.ToString(DataBaseManager.cash);
        tempSave += '#';
        tempSave += Convert.ToString(DataBaseManager.crypto);
        tempSave += '#';
        tempSave += Convert.ToString(DataBaseManager.LastUpdate);
        // do the local file saving here and then pack it to google. 
        return Encoding.UTF8.GetBytes(tempSave);
    }

    public static bool SaveExists() //check if your file path contains your named file
    {
        var path = Application.persistentDataPath + "/saves/";
        return File.Exists(path);
    }

    public static void SeriousllyDeleteAllSaveFiles() //for whatever reason you may have you can delete the entire save directory and make a brand new one... care.
    {
        var path = Application.persistentDataPath + "/saves/";
        var directory = new DirectoryInfo(path);
        directory.Delete();
        Directory.CreateDirectory(path);
    }

    public static void Save <T>(T objectToSave)
    {
        var path = Application.persistentDataPath + "/saves/";
        Directory.CreateDirectory(path);
        var formatter = new BinaryFormatter();
        //using puts something memory but once it's done it dumps it.
        using var filestream = new FileStream(path, FileMode.Create);
        //objectToSave should be cast right here as the saveparse method return.. 
        formatter.Serialize(filestream, objectToSave);
    }

    #endregion

    #region LoadStuff

    public static T Load<T>()
    {
        var path = Application.persistentDataPath + "/saves/";
        var formatter = new BinaryFormatter();
        //this auto fills in the nulls as a default value for that type if it doesnt find any there!
        var returnValue = default(T);
        //using puts something memory but once it's done it frees it up and dumps it.
        using (var filestream = new FileStream(path, FileMode.Open))
        {
            returnValue = (T) formatter.Deserialize(filestream);
        }

        return returnValue;
    }

    public static void LoadSplit(byte[] loadData) //take googles blob and unpack it
    {
        var Loadstr = Encoding.UTF8.GetString(loadData);
        tempLoad = Loadstr.Split('#');
        if (tempLoad.Length > 0)
        {
            DataBaseManager.LoadSaveTurrets(tempLoad[0]);
            //DataBaseManager.LoadSaveZombies(tempLoad[x]);
            //DataBaseManager.LoadSaveHouse(tempLoad[x]);
            DataBaseManager.cash = Convert.ToInt64(tempLoad[1]);
            DataBaseManager.crypto = Convert.ToInt64(tempLoad[2]);
            DataBaseManager.LastUpdate = Convert.ToDateTime(tempLoad[3]);
        }
    }

    #endregion
}
