using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedVariables : MonoBehaviour
{
    public string SaveString;
    public long Cash;
    public long Crypto;
    public string TurretString { get; set; } = DataBaseManager.SaveSenderTurrets();
    public void Start()
    {
        Cash = YardManager.instance.cash;
        Crypto = YardManager.instance.crypto;
    }
    public string StringsToSave()
    {
        string CashString = Convert.ToString(Cash);
        string CryptoString = Convert.ToString(Crypto);
        string SaveString = CashString + CryptoString + TurretString;
        return SaveString;
    }
}