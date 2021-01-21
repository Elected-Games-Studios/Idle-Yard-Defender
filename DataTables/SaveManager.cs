using System;
using System.Collections.Generic;

public static class SaveManager
{
    public static byte[] SaveParse()
    {
        string tempSave = new string();
        tempSave += DataBaseManager.SaveSenderTurrets();
        tempSave += '#';
        tempSave += Convert.ToString(CashManager.Cash);
        tempSave += '#';
        tempSave += Convert.ToString(CashManager.Crypto);
        return (Encoding.UTF8.GetBytes(tempSave));
    }
    public static void LoadSplit(string Loadstr)
    {
        string[] tempLoad = Loadstr.Split('#');
        DataBaseManager.LoadSaveTurrets(tempLoad[0]);
        CashManager.Cash = Convert.ToInt64(tempLoad[1]);
        CashManager.Crypto = Convert.ToInt64(tempLoad[2]);
    }
}