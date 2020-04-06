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
    private BinaryFormatter formatter;

    private void Start()
    {
        formatter = new BinaryFormatter();
        DontDestroyOnLoad(this.gameObject);

        if (loadOnStart)
            Load();
    }

    private void Save()
    {
        if(state == null)
            state = new EpitomeSS();
        state.LastSaveTime = DateTime.Now;
        var file = new FileStream(savefileName, FileMode.Create, FileAccess.Write);
        formatter.Serialize(file, state);
        file.Close();
    }

    private void Load()
    {
        var file = new FileStream(savefileName, FileMode.Open, FileAccess.Read);
        if(file != null)
        {
            state = (EpitomeSS)formatter.Deserialize(file);
            file.Close();
        }
        else
        {
            Debug.Log("No save file found...");
            Save();
        }
    }
}

