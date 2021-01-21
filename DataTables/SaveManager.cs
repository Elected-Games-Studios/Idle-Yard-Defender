using System;
using System.Text;
public static class SaveManager
{
    private static string[] tempLoad;
    //returns the blob to send to google
    public static byte[] SaveParse()
    {
        string tempSave = "";
        tempSave += DataBaseManager.SaveSenderTurrets();
        tempSave += '#';
        tempSave += Convert.ToString(DataBaseManager.cash);
        tempSave += '#';
        tempSave += Convert.ToString(DataBaseManager.crypto);
        tempSave += '#';
        tempSave += Convert.ToString(DataBaseManager.LastUpdate);
        return (Encoding.UTF8.GetBytes(tempSave));
    }
    //send this what google sends you, the blob.
    public static void LoadSplit(byte[] loadData)
    {
        string Loadstr = System.Text.Encoding.UTF8.GetString(loadData);
        tempLoad = Loadstr.Split('#');
        if (tempLoad.Length > 0)
        {
            DataBaseManager.LoadSaveTurrets(tempLoad[0]);
            DataBaseManager.cash = Convert.ToInt64(tempLoad[1]);
            DataBaseManager.crypto = Convert.ToInt64(tempLoad[2]);
            DataBaseManager.LastUpdate = Convert.ToDateTime(tempLoad[3]);
        }
    }
}