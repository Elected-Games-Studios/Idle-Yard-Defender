using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalZombie : MonoBehaviour
{
    private int zombieValue;
    private int zombieLevel;

    void Awake() //get, set lvl and value
    {
        zombieValue = 50;
        zombieLevel = 1;
        //house lvl * yardprestigue * Multi's
    }
    //public void PayOnDeath(int zombieValue)
    //{
    //    zombieValue = zombieValue();
    //    //on death pass a message of value to player cash
    //}
}