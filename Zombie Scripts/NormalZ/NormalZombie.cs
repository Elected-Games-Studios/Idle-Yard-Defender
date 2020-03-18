using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalZombie : MonoBehaviour
{
    public int zombieLevel { get => zombieLevel; private set => zombieLevel = 1; }
    public int zombieValue { get => zombieValue; private set => zombieValue = 10; } //cash value could set with a method call here
}