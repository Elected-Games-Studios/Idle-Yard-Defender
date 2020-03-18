using UnityEngine;

public abstract class ZombieHealth : MonoBehaviour

{
   //get zombie health values and do zombie dmg based on
    public abstract void TakeDamage(int damage);
}
