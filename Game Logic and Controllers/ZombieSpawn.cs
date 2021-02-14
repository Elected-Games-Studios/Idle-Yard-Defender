using System.Collections.Generic;
using UnityEngine;
public class ZombieSpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> zombieSpawnList;
    [SerializeField]
    public float zombieSpawnTimer = 1f;
    void Update()
    {
        zombieSpawnTimer -= Time.deltaTime;
        if (zombieSpawnTimer <= 0.7f)
        {
            zombieSpawnTimer = 1f;
            SpawnZombie();
        }
    }
    private void SpawnZombie()
    {
        Vector3 newSpawnPos = transform.position + new Vector3(Random.Range(-5, 5), 0, 0);
        int x = Random.Range(0, 90);
        if (x <= 1)
            Instantiate(zombieSpawnList[0], newSpawnPos, transform.rotation);
        else if (x >= 2 && x < 5)
            Instantiate(zombieSpawnList[1], newSpawnPos, transform.rotation);
        else if (x >= 5 && x < 12)
            Instantiate(zombieSpawnList[2], newSpawnPos, transform.rotation);
        else if (x >= 12 && x < 22)
            Instantiate(zombieSpawnList[3], newSpawnPos, transform.rotation);
        else if (x >= 22 && x < 34)
            Instantiate(zombieSpawnList[4], newSpawnPos, transform.rotation);
        else if (x >= 34)
            Instantiate(zombieSpawnList[5], newSpawnPos, transform.rotation);
    }
}