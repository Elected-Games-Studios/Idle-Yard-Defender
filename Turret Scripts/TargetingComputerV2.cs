using UnityEngine;
using System.Collections.Generic;
    public class TargetingComputerV2 : MonoBehaviour
    {
        public GameObject Target { get; private set; }
        private Queue<GameObject> _enemyQueue = new Queue<GameObject>();
        public bool targetAquired = false;
        
    }
    