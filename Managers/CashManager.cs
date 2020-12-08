using UnityEngine;
using System;
using System.Collections;

public class CashManager : MonoBehaviour
{
    //private StatsToSave statsToSave;
    

    public long Cash
    {
        get => StatsToSave.Cash;
        set => Cash = value;
    }
    public long Crypto
    {
        get => StatsToSave.Crypto;
        set => Crypto = value;
    }
    public void AddCash(long value)
    {
        StatsToSave.Cash += value;
        LocalSaveEngine.SavePlayer();
        /*i could make this an event called SaveableEvent and anything that 
        subscribes to this could cause a save..  which would be more extensible*/
    }
}
