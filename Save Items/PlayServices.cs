using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine.SocialPlatforms;

//Handles checking playerprefs for game specific data, calling the local or cloud save and handling that to its end.
//builds playgames platform for you
//signs you in
//initializes ads
public class PlayServices : MonoBehaviour
{
    public static PlayServices Instance { get; private set; }
    string GameDataToString() => LocalSaveSystem.SaveParse();
    const string SAVE_NAME = "IdleYardDefenders";
    bool isSaving;
    bool isCloudDataLoaded = false;

    private void Awake()
    {
        isCloudDataLoaded = false;
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        if (!PlayerPrefs.HasKey(SAVE_NAME))
            PlayerPrefs.SetString(SAVE_NAME, "0");

        if (!PlayerPrefs.HasKey("IsFirstTime"))
            PlayerPrefs.SetInt("IsFirstTime", 1);

        PlayGamesClientConfiguration.Builder builder = new PlayGamesClientConfiguration.Builder().EnableSavedGames();
        PlayGamesPlatform.InitializeInstance(builder.Build());
        PlayGamesPlatform.Activate();
        SignIn();
        //GetComponent<AdManager>().Indestructable();
    }
    
    private void SignIn() // attempt login to google or default to local, load data.
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Google Sign-In has succeeded");
            }
            else
            {
                Debug.Log("Google Sign-In Failed");
            }
            LoadData();
        });
    }

    #region Saved Games

    public void SaveData() //This Saves the game. handling local save or cloud.
    {
        //save local any time you try to save, attempt cloud save too
        LocalSaveSystem.LocalSave(GameDataToString());
        if (Social.localUser.authenticated)
        {
            isSaving = true;
            ((PlayGamesPlatform) Social.Active).SavedGame.OpenWithAutomaticConflictResolution(SAVE_NAME,
                DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLongestPlaytime, OnSavedGameOpened);
        }
    }

    public void LoadData()
    {
        if (Social.Active.localUser.authenticated)
        {
            isSaving = false;
            ((PlayGamesPlatform) Social.Active).SavedGame.OpenWithAutomaticConflictResolution(SAVE_NAME,
                DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLongestPlaytime, OnSavedGameOpened);
        }
        else
        {
            //local load
            LocalSaveSystem.LoadSplit(LocalSaveSystem.Load());
        }
    }

    private void OnSavedGameOpened(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            if (!isSaving)
            {
                LoadGame(game);
            }
            else
            {
                SaveGame(game);
            }
        }
        else
        {
            if (!isSaving)
            {
                LocalSaveSystem.LoadSplit(LocalSaveSystem.Load());
            }
            else
            {
                LocalSaveSystem.LocalSave(GameDataToString());
            }
        }
    }

    private void ResolveConflict(IConflictResolver resolver, ISavedGameMetadata original, byte[] originalData,
        ISavedGameMetadata unmerged, byte[] unmergedData)
    {
        if (originalData == null)
            resolver.ChooseMetadata(unmerged);
        else if (unmergedData == null)
            resolver.ChooseMetadata(original);
        else
        {
            //decoding byte data into string
            string originalStr = Encoding.ASCII.GetString(originalData);
            string unmergedStr = Encoding.ASCII.GetString(unmergedData);

            //parsing
            int originalNum = int.Parse(originalStr);
            int unmergedNum = int.Parse(unmergedStr);

            //if original score is greater than unmerged
            if (originalNum > unmergedNum)
            {
                resolver.ChooseMetadata(original);
                return;
            }
            //else (unmerged score is greater than original)
            else if (unmergedNum > originalNum)
            {
                resolver.ChooseMetadata(unmerged);
                return;
            }

            //if return doesn't get called, original and unmerged are identical
            //we can keep either one
            resolver.ChooseMetadata(original);
        }
    }

    private void LoadGame(ISavedGameMetadata game)
    {
        ((PlayGamesPlatform) Social.Active).SavedGame.ReadBinaryData(game, OnSavedGameDataRead);
    }

    private void SaveGame(ISavedGameMetadata game)
    {
        string stringToSave = GameDataToString();

        PlayerPrefs.SetString(SAVE_NAME, stringToSave);

        byte[] dataToSave = Encoding.ASCII.GetBytes(stringToSave);

        SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().Build();
        ((PlayGamesPlatform) Social.Active).SavedGame.CommitUpdate(game, update, dataToSave,
            OnSavedGameDataWritten);
    }

    private void OnSavedGameDataRead(SavedGameRequestStatus status, byte[] savedData)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            if (savedData != null)
            {
                string cloudDataString = Encoding.ASCII.GetString(savedData);

                if (cloudDataString != "")
                {
                    LocalSaveSystem.LoadSplit(savedData);
                    isCloudDataLoaded = true;
                }
                else
                {
                    LocalSaveSystem.LoadSplit(LocalSaveSystem.Load());
                }
            }
            else
            {
                LocalSaveSystem.LoadSplit(LocalSaveSystem.Load());
            }
        }
    }

    private void OnSavedGameDataWritten(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
    }

    #endregion /Saved Games

    #region Achievements

    public void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100, (bool success) => { });
    }

    public void IncrementAchievement(string id, int stepsToIncrement)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });
    }

    #endregion /Achievements
}