using UnityEngine;

[System.Serializable]
public class LoadedVariables : MonoBehaviour
{
    public static LoadedVariables Instance;
    public int highScore;
    public int zombiesKilled;
    public int normalKilled;
    public int fastKilled;
    public int tankKilled;
    public int fireKilled;
    public int magicKilled;
    public int moneyKilled;
    public int moneySpent;
    public int gamesPlayed;

    private void Awake()
    {
        Instance = this;
        //LoadPlayer();
        DontDestroyOnLoad(gameObject);
    }
    public void SavePlayer()
    {
        LocalSaveEngine.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        SavedVariables data = LocalSaveEngine.LoadPlayer();

        highScore = data.highScoreSaved;
        zombiesKilled = data.zombiesKilledSaved;
        normalKilled = data.normalKilledSaved;
        fastKilled = data.fastKilledSaved;
        tankKilled = data.tankKilledSaved;
        fireKilled = data.fireKilledSaved;
        magicKilled = data.magicKilledSaved;
        moneyKilled = data.moneyKilledSaved;
        moneySpent = data.moneySpentSaved;
        gamesPlayed = data.gamesPlayedSaved;
    }
}
