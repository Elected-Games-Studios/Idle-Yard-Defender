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
        DataBaseManager.Starter();
        text = uiCanavs.GetComponent<Text>();
    }
    public void Update()
    {
        text.text = DataBaseManager.cash.ToString();
    }
    public void AddTurret()
    {
        //button over turret..
        //click button that reads it's name and asks to unlock the corresponding turret
        var buttonName = gameObject.name;
        //activates turret
        //GameObject.SetActive(GameObject.Find("buttonName"));
        //saves 
        //deactivates button
    }
    public void CallSave()
    {
        LocalSaveSystem.LocalSave(LocalSaveSystem.SaveParse());
    }
}
