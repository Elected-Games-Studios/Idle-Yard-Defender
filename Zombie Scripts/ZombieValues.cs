using UnityEngine;

public abstract class ZombieValues : MonoBehaviour

{
    //get zombie health values and do zombie dmg based on
    public bool isDead = false;
    [SerializeField]
    protected GameObject _coinPrefab;
    public long MaxHealth { get; set; }
    public int zombieLevel { get; set; }
    public long zombieValue { get; set; } //cash value could set with a method call here
    public long currentHealth {get; set;}
    public abstract void TakeDamage(long damage);
}
