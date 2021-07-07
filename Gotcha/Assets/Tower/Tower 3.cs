using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int buildCost = 75;
    [SerializeField] float buildDelay = 1f;
    public bool hasBuilt = false;

    void Start()
    {
        StartCoroutine(Build());    
    }

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if ( bank != null && bank.CurrentBalance >= buildCost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(buildCost);
            return true;
        }
        return false; 
    }

    IEnumerator Build()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach(Transform grandChild in child)
            {
                grandChild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach (Transform grandChild in child)
            {
                grandChild.gameObject.SetActive(true);
            }
        }
        yield return new WaitForSeconds(0.1f);
        hasBuilt = true;
    }
}
