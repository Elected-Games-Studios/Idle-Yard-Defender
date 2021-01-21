using System;
using System.Collections.Generic;

public static class SaveManager
{
    public static byte[] SaveParse()
    {
        string tempSave = new string();
        tempSave += DataBaseManager.SaveSenderTurrets();
        tempSave += '#';
        tempSave += Convert.ToString(DataBaseManager.cash);
        tempSave += '#';
        tempSave += Convert.ToString(DataBaseManager.crypto);
        tempSave += '#';
        tempSave += Convert.ToString(DataBaseManager.LastUpdate);
        return (Encoding.UTF8.GetBytes(tempSave));
    }
    public static void LoadSplit(string Loadstr)
    {
        string[] tempLoad = Loadstr.Split('#');
        DataBaseManager.LoadSaveTurrets(tempLoad[0]);
        DataBaseManager.cash = Convert.ToInt64(tempLoad[1]);
        DataBaseManager.crypto = Convert.ToInt64(tempLoad[2]);
        DataBaseManager.LastUpdate = Convert.ToDateTime(tempLoad[3]);
    }
}