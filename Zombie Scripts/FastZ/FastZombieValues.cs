using UnityEngine;
public class FastZombieValues: ZombieValues
{
    protected FastZombieMovement movement;
    private Animator animator;
    public void Awake()
    {
        movement = GetComponent<FastZombieMovement>();
        animator = GetComponent<Animator>();
        //GetComponent<Audios>();
        //GetComponent<Particles>();
        MaxHealth = 5;
        currentHealth = MaxHealth;
        zombieLevel = 1;
        zombieValue = 20;
    }
    public override void TakeDamage(long damage)
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
    private void HandleZombieDeath()
    {
        Vector3 newSpawnPos = transform.position + new Vector3(0, 1, 0);
        isDead = true;
        //play death sound
        //tell score and cash
        movement.moveSpeed = 0f;
        animator.SetTrigger("isDead");
        YardUIManager.instance.AddCash(zombieValue);
        Instantiate(_coinPrefab, newSpawnPos, transform.rotation);
        Destroy(gameObject, 1);
    }
}
