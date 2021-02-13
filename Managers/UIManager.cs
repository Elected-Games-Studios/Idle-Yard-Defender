using System;
using UnityEngine;
using System.Collections;
using UnityEditorInternal;
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
}
