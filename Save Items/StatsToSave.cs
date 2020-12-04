using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[Serializable]
public static class StatsToSave 
{
    public static int ActiveYard;
    public static long Cash;
    public static long Crypto;
    public static string TurretString;
    public static string SaveString;

    public static string StringsToSave()
    {
        //Cash = CashManager.instance.Cash;
        TurretString = DataBaseManager.SaveSenderTurrets();
        string CashString = Convert.ToString(Cash);
        string SaveString = CashString; //add a turret string back in here 
        return SaveString;
    }
    public static void LoadStats()
    {
        LocalSaveEngine.LoadPlayer();
        StatsToSave stats = LocalSaveEngine.LoadPlayer();
        CashManager.instance.Cash = Convert.ToInt64(stats.Cash);
        DataBaseManager.LoadSaveTurrets(stats.TurretString);
    }
}
