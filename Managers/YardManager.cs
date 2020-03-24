using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class YardManager : MonoBehaviour
{
    public static YardManager instance;
    public static int ActiveYard { get; private set; } // maybe don't need this.. 
    public long cash { get; private set; }
    public long crypto { get; private set; }

    [SerializeField]
    private Canvas uiCanavs;
    public Text text;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DataBaseManager.Starter();
        text = uiCanavs.GetComponent<Text>();
    }
    public void Update()
    {
        text.text = cash.ToString();
    }

    public void AddCash(long cashValue)
    {
        //on enemy death get enemy value and add to cash
        cash += cashValue;
    }
}
