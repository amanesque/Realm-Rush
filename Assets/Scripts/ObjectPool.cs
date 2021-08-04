using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject enemy;
    [Range(0.1f, 30f)] public float spawnTimer;
    [Range(0f, 50f)] public int poolSize;

    private GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }

    private void EnableObjectsInPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if(!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            EnableObjectsInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
