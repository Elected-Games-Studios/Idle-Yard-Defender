using UnityEngine;
using System;
using System.Collections.Generic;

public class YardManager : MonoBehaviour
{
    public static YardManager instance;
    public static int ActiveYard { get; private set; } // maybe don't need this.. 
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DataBaseManager.Starter();
    }
}
