using UnityEngine;
using System;
using System.Collections;

public class CashManager : MonoBehaviour
{
    public Int64 cash
    {
        get => DataBaseManager.cash;
        set => cash = value;
    }
    public Int64 crypto
    {
        get => DataBaseManager.crypto;
        set => crypto = value;
    }
    public void AddCash(Int64 value)
    {
        DataBaseManager.cash += value;
        PlayServices.Instance.SaveData();
        /*i could make this an event called SaveableEvent and anything that 
        subscribes to this could cause a save..  which would be more extensible*/
    }
}
