using UnityEngine;
using System.Collections;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;
    public long Cash { get; set; } = 0;
    public long Crypto { get; set; }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void AddCash(long value)
    {
        Cash += value;
        LocalSaveEngine.SavePlayer();
    }
}
