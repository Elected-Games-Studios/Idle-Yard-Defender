using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[Serializable]
public class StatsToSave 
{
    public static int ActiveYard;
    public static long Cash;
    public static long Crypto;
    public static string TurretString;
    public static string SaveString;
    private CashManager cashManager;

    public string StringsToSave()
    {
        TurretString = DataBaseManager.SaveSenderTurrets();
        string CashString = Convert.ToString(Cash);
        string SaveString = CashString; //add a turret string back in here 
        return SaveString;
    }
    /*public static void LoadStats()
    {
        LocalSaveEngine.LoadPlayer();
        Cash = Convert.ToInt64(Cash);
        DataBaseManager.LoadSaveTurrets(TurretString);
    }*/
}
