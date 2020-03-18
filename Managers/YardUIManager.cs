using UnityEngine;
using System.Collections;
using Unity.UI;

public class YardUIManager : MonoBehaviour
{
    public int cash { get; private set; }
    public int superCash { get; private set; }
    [SerializeField]
    private Canvas uiCanavs;


    public int AddCash(int cashValue)
    {
        //on enemy death get enemy value and add to cash
        cashValue += cash;
        return cash;
    }
}
