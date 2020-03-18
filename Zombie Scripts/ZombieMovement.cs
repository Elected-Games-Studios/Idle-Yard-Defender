using UnityEngine;
public abstract class ZombieMovement : MonoBehaviour
{
    public float moveSpeed;
    protected bool isAttacking = false;
    protected Animator _animator;
    protected virtual void Awake()
    {
        _animator=GetComponent<Animator>();
    }
    protected void Update()
    {
        if (isAttacking == false)
        {
            transform.Translate(Vector3.forward *moveSpeed* Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Barricade")
        {
            isAttacking = true;
            _animator.SetBool("isAttacking", true);
            //GetComponent<BarricadeHealth> hurt it if its there
        }
    }
}