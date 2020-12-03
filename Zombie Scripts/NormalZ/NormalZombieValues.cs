using System;
using UnityEngine;
public class NormalZombieValues : ZombieValues
{
    public void Awake()
    {
        //GetComponent<Audios>();
        //GetComponent<Particles>();
        MaxHealth = 10;
        currentHealth = MaxHealth;
        zombieLevel = 1;
        zombieValue = 10;
    }
    public override void TakeDamage(long damage)
    {
        if (currentHealth <= 0 )
        {
            ZombieDeath();
        }
        else
        {
            currentHealth -= damage;
            //play Particles.HurtParticle 
            //play Audios.HurtAudio
            //maybe trigger animator zombie hurt anim
        }
    }
        public override void ZombieDeath()
        {
            // any normal zombie death stuff specific to normal zombies
        }
}