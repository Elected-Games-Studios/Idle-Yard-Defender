using System.Collections.Generic;
using UnityEngine;
public class TargetingComputer : MonoBehaviour
{
    public GameObject Target { get;  private set; }
    private Queue<GameObject> _enemyQueue = new Queue<GameObject>();
    public bool targetAquired = false;
    public bool targetIsDead = false;

    public void Update()
    {
        if (Target != null)
        {
            targetAquired = true;
            targetIsDead = Target.GetComponent<ZombieValues>().isDead;
        }
        if (targetIsDead == true)
        {
            targetAquired = false;
            MaintainQueue();
        }
        else
        {
            targetAquired = false;
            MaintainQueue();
        }
    }
    private void MaintainQueue()
    {
        if (Target != null && _enemyQueue.Count != 0)
        {
            targetAquired = (true);
        }
        while (Target == null && _enemyQueue.Count != 0)
        {
            _enemyQueue.Dequeue();
            if (_enemyQueue.Count != 0)
            {
                Target = _enemyQueue.Peek();
            }
        }

    }
    public void OnTriggerEnter(Collider co)
    {
        //if the object tagged enemy is not in the enemy Queue, add it.
        if (co.CompareTag("Enemy") && !_enemyQueue.Contains(co.gameObject))
        {
            _enemyQueue.Enqueue(co.gameObject);
            if(Target == null)
            {
                Target = _enemyQueue.Peek();
            }
        }
    }
    public void OnTriggerExit(Collider co)
    {
        if (co.CompareTag("Enemy") && _enemyQueue.Contains(co.gameObject))
        {
            _enemyQueue.Dequeue();
            if (_enemyQueue.Count!=0)
            {
                Target = _enemyQueue.Peek();
            }
        }
    }
}