using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject ram;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [SerializeField] [Range(0.1f,30f)] float spwanTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();    
    }

    void Start()
    {
        StartCoroutine(SpwanEnemy());
    }

    void Update()
    {
        
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(ram, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].gameObject.activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpwanEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(Mathf.Abs(spwanTimer));
        }
    }
}
