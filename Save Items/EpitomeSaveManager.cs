using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class EpitomeSaveManager : MonoBehaviour
{
    private static EpitomeSaveManager instance;
    public static EpitomeSaveManager Instance
    {
        get
        {
            if (instance == null) 
            {
                instance = FindObjectOfType<EpitomeSaveManager>(); // if it doesnt exist find it
                if (instance == null)
                {
                    //if you can't find it make it 
                    instance = new GameObject("Spawned SaveManager", typeof(EpitomeSaveManager)).GetComponent<EpitomeSaveManager>();
                }
            }
            return instance; // is that
        }
        set
        {
            instance = value;
        }
    }

    [Header ("Logic")]
    [SerializeField] private string savefileName = "data.ss";
    [SerializeField] private bool loadOnStart = true;
    private EpitomeSS state;
    public EpitomeSS State { get => state; set => state = value; }
    private BinaryFormatter formatter;

    private void Start()
    {
        formatter = new BinaryFormatter();
        DontDestroyOnLoad(this.gameObject);

        if (loadOnStart)
            Load();
    }

    public void Save()
    {
        if(state == null)
            state = new EpitomeSS();
        Debug.Log(EpitomeSS.TurretString);
        state.LastSaveTime = DateTime.Now;
        var file = new FileStream(savefileName, FileMode.OpenOrCreate, FileAccess.Write);
        formatter.Serialize(file, state);
        file.Close();
    }

    public void Load()
    {
        try
        {
            var file = new FileStream(savefileName, FileMode.Open, FileAccess.Read);
            state = (EpitomeSS)formatter.Deserialize(file);
            file.Close();
        }
        catch
        {
            Debug.Log("No save file found, Creating a file!");
            Save();
        }
    }
}

