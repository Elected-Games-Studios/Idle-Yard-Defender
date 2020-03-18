using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Zombie", menuName = "GameData/Enemies/Zombies/NormalZ")]
public class Zombie : ScriptableObject
{
    public GameObject normalZombiePrefab;
    public int maxHealth;
    public int currentHealth;
    public int lvl;
    public int zombieValue;
    public int moveSpeed;
    public enum Type { Normal, Fast, Tank, Magic, Bomb}
    public Type type = Type.Normal;
}
