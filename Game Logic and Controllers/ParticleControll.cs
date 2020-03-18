using UnityEngine;
public class ParticleControll : MonoBehaviour
{
	public float speed;
	protected int damage;
	public float lifetime;
	AttackProcessor attackProcessor;
	public GameObject particleTarget;
	public GameObject muzzlePrefab;
	public GameObject hitPrefab;
	public AudioClip shotSFX;
	public AudioClip hitSFX;
	private void Awake()
	{
		attackProcessor = GetComponent<AttackProcessor>();
	}
	void Start()
	{
		//{
		//	GetComponent<AudioSource>().PlayOneShot(shotSFX);
		//}
	}

	public void Update()
	{
		lifetime -= Time.deltaTime;
		{
			if (lifetime <= 0)
			{
				MinigunShotPool.Instance.ReturnToPool(gameObject);
			}
		}
	}
	void FixedUpdate()
	{
		if (speed != 0 && particleTarget != null) // if you have a target fly and follow it, else, just fly foward. 
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
			transform.LookAt(particleTarget.transform);
		}
		else
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
	}
	void OnTriggerEnter(Collider co)
	{
		if (co.CompareTag("Enemy"))
		{
			co.GetComponent<ZombieHealth>().TakeDamage(damage);
			var hitP = Instantiate(hitPrefab, co.transform.position, co.transform.rotation);
			Destroy(hitP, 1);
			MinigunShotPool.Instance.ReturnToPool(gameObject);
		}
	}
	public void SpawnMuzzlePrefab()
	{
		var muzzleVFX = Instantiate(muzzlePrefab, transform.position, transform.rotation);
		Destroy(muzzleVFX, 1);
	}
	public void PassTarget(GameObject target) => particleTarget = target;
	public void passdamage(int STR) => damage = STR;
}