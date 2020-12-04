using UnityEngine;

public abstract class ZombieValues : MonoBehaviour

{
    //get zombie health values and do zombie dmg based on
    public Animator animator;
    public CashManager cashMan;
    public bool isDead = false;
    [SerializeField]
    protected GameObject _coinPrefab;

    public long MaxHealth { get; set; }
    public int zombieLevel { get; set; }
    public long zombieValue { get; set; } //cash value could set with a method call here
    public long currentHealth {get; set;}
    public virtual void Awake()
    {
        animator = GetComponent<Animator>();
        cashMan = FindObjectOfType<CashManager>();
        
    }

    public virtual void TakeDamage(long damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            ZombieDeath();
        }
            //play Particles.HurtParticle 
            //play Audios.HurtAudio
            //maybe trigger animator zombie hurt anim
    }


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
    }
}
