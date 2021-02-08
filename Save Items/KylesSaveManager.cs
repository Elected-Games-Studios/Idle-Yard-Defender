using System;
using System.Text;
public static class KylesSaveManager
{
    private static string[] tempLoad;
    //returns the blob to send to google
    public static byte[] SaveParse()
    {
        string tempSave = "";
        tempSave += DataBaseManager.SaveSenderTurrets();
        tempSave += '#';
        //tempSAve += DataBaseManager.SaveSenderZombies();
        //tempSave += '#';
        //tempSave += DataBaseManager.SaveSenderHouse();
        //tempSave += '#';
        tempSave += Convert.ToString(DataBaseManager.cash);
        tempSave += '#';
        tempSave += Convert.ToString(DataBaseManager.crypto);
        tempSave += '#';
        tempSave += Convert.ToString(DataBaseManager.LastUpdate);
        // do the local file saving here and then pack it to google. 
        return (Encoding.UTF8.GetBytes(tempSave));
    }
    
    public static void LoadSplit(byte[] loadData) //take googles blob and unpack it
    {
        string Loadstr = System.Text.Encoding.UTF8.GetString(loadData);
        tempLoad = Loadstr.Split('#');
        if (tempLoad.Length > 0)
        {
            DataBaseManager.LoadSaveTurrets(tempLoad[0]);
            //DataBaseManager.LoadSaveZombies(tempLoad[x]);
            //DataBaseManager.LoadSaveHouse(tempLoad[x]);
            DataBaseManager.cash = Convert.ToInt64(tempLoad[1]);
            DataBaseManager.crypto = Convert.ToInt64(tempLoad[2]);
            DataBaseManager.LastUpdate = Convert.ToDateTime(tempLoad[3]);
        }
    }
}