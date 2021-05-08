using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //public EpitomeSS saveState;
    [SerializeField] private Canvas uiCanavs;
    public Text text;
    public void Awake()
    {
        text = uiCanavs.GetComponent<Text>();
    }
    public void Update()
    {
        text.text = DataBaseManager.cash.ToString();
    }

    public void CallSave()
    {
        LocalSaveSystem.LocalSave(LocalSaveSystem.SaveParse());
    }
}
