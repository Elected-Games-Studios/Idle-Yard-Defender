using UnityEngine;
using System.Collections.Generic;
using System;

public class MinigunShotPool : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    public static MinigunShotPool Instance { get; private set; }
    private Queue<GameObject> bulletQueue = new Queue<GameObject>();

    private void Awake() => Instance = this;

    public GameObject Get()
    {
        if (bulletQueue.Count == 0)
            AddBullet(1);
        return bulletQueue.Dequeue();
    }

    private void AddBullet(int count)
    {
        var newBullet = Instantiate(bulletPrefab);
        newBullet.SetActive(false);
        bulletQueue.Enqueue(newBullet);
    }

    public void ReturnToPool(GameObject bulletToReturn)
    {
        bulletToReturn.SetActive(false);
        bulletQueue.Enqueue(bulletToReturn);
    }
}
