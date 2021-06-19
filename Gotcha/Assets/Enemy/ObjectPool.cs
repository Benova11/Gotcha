using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject ram;
    [SerializeField] GameObject startingTile;
    [SerializeField] float spwanTimer = 1f;
    void Start()
    {
        StartCoroutine(SpwanEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpwanEnemy()
    {
        while (true)
        {
            Instantiate(ram, startingTile.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spwanTimer);
        }
    }
}
