using System;
[System.Serializable]
public static class StatsToSave 
{
    public static long Cash = YardManager.instance.cash;
    public static long Crypto = YardManager.instance.crypto;
    public static string TurretString = DataBaseManager.SaveSenderTurrets();
    public static string SaveString;
    public static string StringsToSave()
    {
        string CashString = Convert.ToString(Cash);
        string CryptoString = Convert.ToString(Crypto);
        string SaveString = CashString + CryptoString + TurretString;
        return SaveString;
    }
}
