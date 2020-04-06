using UnityEngine;
using System;
using System.Collections;

public class CashManager : MonoBehaviour
{
    public long Cash
    {
        get => EpitomeSS.Cash;
        set => Cash = value;
    }
    public long Crypto
    {
        get => EpitomeSS.Crypto;
        set => Crypto = value;
    }

    void Awake()
    {

    }
    public void AddCash(long value)
    {
        EpitomeSS.Cash += value;
        EpitomeSaveManager.Instance.Save();
        /*i could make this an event called SaveableEvent and anything that 
        subscribes to this could cause a save..  which would be more extensible*/
    }
}
