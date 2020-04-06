using System;

[System.Serializable]
public class EpitomeSS
{
    CashManager cashMan;
    public long Cash
    {
        get => cashMan.Cash;
        set => Cash = value;
    }
    public long Crypto
    {
        get => cashMan.Crypto;
        set => Cash = value;
    }
    public DateTime LastSaveTime { get; set; }
    public string TurretString
    {
        get => DataBaseManager.SaveSenderTurrets();
        set => TurretString = value;
    }
}

 