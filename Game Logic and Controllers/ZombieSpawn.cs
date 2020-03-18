using System.Collections.Generic;
using UnityEngine;
public class ZombieSpawn : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> spawnList;
    [SerializeField]
    protected float zombieSpawnTimer;
    protected void Awake()
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
        Instantiate(spawnList[Random.Range(0, spawnList.Count)], transform);
    }
}