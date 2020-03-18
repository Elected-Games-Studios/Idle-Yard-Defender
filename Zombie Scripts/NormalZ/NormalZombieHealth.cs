using System;
using UnityEngine;
public class NormalZombieHealth : ZombieHealth
{
    [SerializeField]
    protected GameObject _coinPrefab;
    public int maxHealth { get; set; }
    protected int currentHealth;
    protected NormalZombieMovement movement;
    private Animator animator;
    protected void Awake()
    {
        //GetComponent<Audios>();
        //GetComponent<Particles>();
        maxHealth = 20;
        movement = GetComponent<NormalZombieMovement>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
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
        Instantiate(_coinPrefab, transform);
        Destroy(gameObject, 1);
    }
}