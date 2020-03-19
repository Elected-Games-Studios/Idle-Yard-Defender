using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class YardUIManager : MonoBehaviour
{
    public static YardUIManager instance;
    public int cash { get;private set; }
    public int superCash { get;private set; }
    [SerializeField]
    private Canvas uiCanavs;
    public Text text;
    public void Awake()
    {
        instance = this;
        text = uiCanavs.GetComponent<Text>();
    }
    public void Update()
    {
        text.text = cash.ToString();
    }

    public int AddCash(int cashValue)
    {
        //on enemy death get enemy value and add to cash
        cash += cashValue;
        return cash;
    }
}
