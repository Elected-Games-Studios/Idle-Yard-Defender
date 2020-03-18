using UnityEngine;

public abstract class ZombieValues : MonoBehaviour

{
    //get zombie health values and do zombie dmg based on
    [SerializeField]
    protected GameObject _coinPrefab;
    public int MaxHealth { get; set; }
    public int zombieLevel { get; set; }
    public int zombieValue { get; set; } //cash value could set with a method call here
    protected int currentHealth;

    public virtual void Awake()
    {

    }
    public abstract void TakeDamage(int damage);
}
