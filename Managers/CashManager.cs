using UnityEngine;
using System.Collections;

public class CashManager : MonoBehaviour
{
    public long Cash;
    public long Crypto;
    void Awake()
    {

    }
    public void AddCash(long value)
    {
        Cash += value;
    }
}
