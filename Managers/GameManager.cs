﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] public GameObject[] turretArray = new GameObject[30];
    private string currentYard;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>(); // if it doesnt exist find it
                if (instance == null)
                {
                    //if you can't find it make it 
                    instance = new GameObject("Spawned YardManager", typeof(GameManager)).GetComponent<GameManager>();
                }
            }

            return instance; // is that
        }
        set { instance = value; }
    }

    public void Awake()
    {
        currentYard = SceneManager.GetActiveScene().name;
    }
    
    public void Start()
    {
        int intYard = Convert.ToInt32(currentYard);
        DontDestroyOnLoad(this.gameObject);
        PlayServices.Instance.LoadData(); // needs to happen for next line to work, coroutine?
        DataBaseManager.Starter();
        TurnOnActiveTurrets(DataBaseManager.activeTurretNum(intYard));
    }

    private void CompileTurretsList()
    {
        int i = 0;
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if (go.CompareTag("Turrets"))
            {
                turretArray [i] = go;
                i++;
            }
        }
    } // didn't get the list in order, serialized through unity to solve
    
    public void CheckTurretNum(int activeTurretNum) //this is to be called from a button 
    {
        int intYard = Convert.ToInt32(currentYard);
        DataBaseManager.activeTurretNum(intYard);
        Debug.Log("Number of Active turrets = " + activeTurretNum);
    }

    private void TurnOnActiveTurrets(int activeTurretNum) //hardcoded quick solution, delete later.
    {
        Debug.Log("Number of Active turrets = " + activeTurretNum);
        for (int i = 0; i < activeTurretNum; i++)
        {
            turretArray[i].SetActive(true);
        }
    }
}