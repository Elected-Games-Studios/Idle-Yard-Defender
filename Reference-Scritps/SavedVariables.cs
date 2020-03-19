using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedVariables
{
    public int highScoreSaved;
    public int zombiesKilledSaved;
    public int normalKilledSaved;
    public int fastKilledSaved;
    public int tankKilledSaved;
    public int fireKilledSaved;
    public int magicKilledSaved;
    public int moneyKilledSaved;
    public int moneySpentSaved;
    public int gamesPlayedSaved;

    public SavedVariables (LoadedVariables data)
    {
        highScoreSaved = data.highScore;
        zombiesKilledSaved = data.zombiesKilled;
        normalKilledSaved = data.normalKilled;
        fastKilledSaved = data.fastKilled;
        tankKilledSaved = data.tankKilled;
        fireKilledSaved = data.fireKilled;
        magicKilledSaved = data.magicKilled;
        moneyKilledSaved = data.moneyKilled;
        moneySpentSaved = data.moneySpent;
        gamesPlayedSaved = data.gamesPlayed;
    }
}
