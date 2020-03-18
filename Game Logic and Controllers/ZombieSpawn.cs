using System.Collections.Generic;
using UnityEngine;
public class ZombieSpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> zombieSpawnList;
    [SerializeField]
    private float zombieSpawnTimer;
    private void Awake()
    {
        zombieSpawnTimer = 2f;
    }
    void Update()
    {
        zombieSpawnTimer -= Time.deltaTime;
        if (zombieSpawnTimer <= 0)
        {
            SpawnZombie();
        }
    }
    private void SpawnZombie()
    {
        zombieSpawnTimer = 2f;
        Instantiate(zombieSpawnList[Random.Range(0, zombieSpawnList.Count)], transform);
    }
}