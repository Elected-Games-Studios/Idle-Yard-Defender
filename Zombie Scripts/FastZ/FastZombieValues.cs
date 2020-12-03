﻿using UnityEngine;
public class FastZombieValues: ZombieValues
{
    public void Awake()
    {
        //GetComponent<Audios>();
        //GetComponent<Particles>();
        MaxHealth = 5;
        currentHealth = MaxHealth;
        zombieLevel = 1;
        zombieValue = 20;
    }
    public override void TakeDamage(long damage)
    {
        if (currentHealth <= 0)
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
        //any fast zombie death stuff specific to fast zombies
    }
}
