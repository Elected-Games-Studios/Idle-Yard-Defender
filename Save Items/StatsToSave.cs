using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[Serializable]
public class StatsToSave : MonoBehaviour
{
    public static StatsToSave Instance;
    public int ActiveYard;
    public long Cash;
    public long Crypto;
    public string TurretString;
    public string SaveString;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public string StringsToSave()
    {
        Cash = CashManager.instance.Cash;
        TurretString = DataBaseManager.SaveSenderTurrets();
        string CashString = Convert.ToString(Cash);
        string SaveString = CashString + TurretString;
        return SaveString;
    }
}
