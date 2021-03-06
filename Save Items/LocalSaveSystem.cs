﻿using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;

//handles packing local data and save/load of that data if need be.
public static class LocalSaveSystem
{
    private static string[] tempLoad;

    #region SaveStuff

    public static string SaveParse() //Kyles string appending logic for the save; returns string to send to google
    {
        string tempSave = "";
        tempSave += Convert.ToString(DataBaseManager.SaveSenderTurrets());
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
        return tempSave;
    }

    public static void LocalSave(string objectToSave)
    {
        //pass in SaveParse.tempSave on call
        byte[] dataToSave = Encoding.UTF8.GetBytes(objectToSave);
        var path = Application.persistentDataPath + "/testIdleYardSaves.dat";
        var formatter = new BinaryFormatter();
        using var filestream = new FileStream(path, FileMode.Create);
        formatter.Serialize(filestream, dataToSave);
        filestream.Close();
    }

    #endregion

    #region LoadStuff

    public static byte[] Load()
    {
        //saveExists catch
        var path = Application.persistentDataPath + "/testIdleYardSaves.dat";
        var formatter = new BinaryFormatter();
        //this auto fills in the nulls as a default value for that type if it doesnt find any there!
        byte[] returnValue;
        //using puts something memory but once it's done it frees it up and dumps it.
        using (var filestream = new FileStream(path, FileMode.Open))
        {
            returnValue = formatter.Deserialize(filestream) as byte[];
        }

        return returnValue;
    }

    public static void LoadSplit(byte[] loadData) //take googles blob and unpack it
    {
        var Loadstr = Encoding.UTF8.GetString(loadData);
        tempLoad = Loadstr.Split('#');
        if (tempLoad.Length > 0)
        {
            //DataBaseManager.LastUpdate = Convert.ToDateTime(tempLoad[0]);
            //DataBaseManager.LoadSaveZombies(tempLoad[x]);
            //DataBaseManager.LoadSaveHouse(tempLoad[x]);
            DataBaseManager.cash = Convert.ToInt64(tempLoad[1]);
            DataBaseManager.crypto = Convert.ToInt64(tempLoad[2]);
            DataBaseManager.LoadSaveTurrets(tempLoad[3]);
        }
        else DataBaseManager.Starter();
    }

    public static void
        SeriousllyDeleteAllSaveFiles() //for whatever reason you may have you can delete the entire save directory and make a brand new one... care.
    {
        var path = Application.persistentDataPath + "/saves/";
        var directory = new DirectoryInfo(path);
        directory.Delete();
        Directory.CreateDirectory(path);
    }

    public static bool SaveExists() //check if your file path contains your named file
    {
        var path = Application.persistentDataPath + "/testIdleYardSaves/";
        return File.Exists(path);
    }

    #endregion
}