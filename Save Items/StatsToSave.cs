using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[Serializable]
public class StatsToSave 
{
    public static StatsToSave Instance;
    public int ActiveYard;
    public long Cash;
    public long Crypto;
    public string TurretString;
    public string SaveString;

    public string StringsToSave()
    {
        //Cash = CashManager.instance.Cash;
        TurretString = DataBaseManager.SaveSenderTurrets();
        string CashString = Convert.ToString(Cash);
        string SaveString = CashString; //add a turret string back in here 
        return SaveString;
    }
    public void LoadStats()
    {
        //LocalSaveEngine.LoadPlayer();
        //StatsToSave stats = LocalSaveEngine.LoadPlayer();
        //CashManager.instance.Cash = Convert.ToInt64(stats.Cash);
        //DataBaseManager.LoadSaveTurrets(stats.TurretString);
    }
}
