using UnityEngine;
public class FastZombieHealth : ZombieValues
{
    [SerializeField]
    protected int maxHealth = 6;
    protected FastZombieMovement movement;
    private Animator animator;
    protected void Awake()
    {
        //GetComponent<Audios>();
        //GetComponent<Particles>();
        movement = GetComponent<FastZombieMovement>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public override void TakeDamage(long damage)
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
        Destroy(gameObject, 2f);
    }
}
