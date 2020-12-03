using System;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.XR;

public class TargetingComputerV2 : MonoBehaviour
    {
        public GameObject Target { get; private set; }
        private Queue<GameObject> _enemyQueue = new Queue<GameObject>();
        public bool targetAquired = false;
        private ZombieValues zombieValues;

        public void OnTriggerEnter(Collider co)
        {
            //if the object tagged enemy is not in the enemy Queue, add it.
            if (co.CompareTag("Enemy") && !_enemyQueue.Contains(co.gameObject))
            {
                _enemyQueue.Enqueue(co.gameObject);
                Target = _enemyQueue.Peek();
                zombieValues = Target.GetComponent<ZombieValues>();
                zombieValues.OnZDeath += HandleTargetDeath;
                targetAquired = true;
            }
        }
        private void HandleTargetDeath()
        {
            zombieValues.OnZDeath -= HandleTargetDeath;
            Target = _enemyQueue.Dequeue();
            targetAquired = false;
            if(_enemyQueue.Count != 0)
                Target = _enemyQueue.Peek(); 
        }

        public void OnTriggerExit(Collider co)
        {
            if (co.CompareTag("Enemy") && _enemyQueue.Contains(co.gameObject))
            {
                _enemyQueue.Dequeue();
                targetAquired = false;
                if (_enemyQueue.Count != 0) 
                {
                    Target = _enemyQueue.Peek(); 
                }
                else
                {
                    Target = null;
                }
            }
        }
    }
    