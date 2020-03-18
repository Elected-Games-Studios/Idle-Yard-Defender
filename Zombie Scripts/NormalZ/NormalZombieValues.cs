using System;
using UnityEngine;
public class NormalZombieValues : ZombieValues
{
    //contains health, cash value, 
    NormalZombieMovement movement;
    Animator animator;
    YardUIManager yardUIManager;
    public override void Awake()
    {
        movement = GetComponent<NormalZombieMovement>();
        animator = GetComponent<Animator>();
        //GetComponent<Audios>();
        //GetComponent<Particles>();
        MaxHealth = 20;
        currentHealth = MaxHealth;
        zombieLevel = 1;
        zombieValue = 10;
    }
    public override void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
            HandleZombieDeath();
        else
        {
            currentHealth -= damage;
        //play Particles.HurtParticle 
        //play Audios.HurtAudio
        //maybe trigger animator zombie hurt anim
        }
    }
        private void HandleZombieDeath()
    {
        //play death sound
        //tell score and cash
        movement.moveSpeed = 0f;
        animator.SetTrigger("isDead");
        yardUIManager.instance.AddCash(zombieValue);
        Instantiate(_coinPrefab, transform.position, transform.rotation);
        Destroy(gameObject, 1);
    }
}