using System;
using UnityEngine;
public class NormalZombieValues : ZombieValues
{
    NormalZombieMovement movement;
    public override void Awake()
    {
        base.Awake();
        movement = GetComponent<NormalZombieMovement>();
        //GetComponent<Audios>();
        //GetComponent<Particles>();
        MaxHealth = 10;
        currentHealth = MaxHealth;
        zombieLevel = 1;
        zombieValue = 10;
    }
    
    /*public override void TakeDamage(long damage)
    {
        if (currentHealth <= 0 && !isDead)
            HandleZombieDeath();
        else
        {
            currentHealth -= damage;
        //play Particles.HurtParticle 
        //play Audios.HurtAudio
        //maybe trigger animator zombie hurt anim
        }
    }
<<<<<<< HEAD
<<<<<<< Updated upstream
        public override void ZombieDeath()
        {
            // any normal zombie death stuff specific to normal zombies
        }
=======
        public void ZombieDeath()
        {
            Vector3 newSpawnPos = transform.position + new Vector3(0, 1, 0);
            //play death sound
            //tell score and cash
            gameObject.GetComponent<ZombieMovement>().moveSpeed = 0f;
            animator.SetTrigger("isDead");
            cashMan.AddCash(zombieValue);
            Instantiate(_coinPrefab, newSpawnPos, transform.rotation);
            Destroy(gameObject, 1); //return to pool
        }*/

}