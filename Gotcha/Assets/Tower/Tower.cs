using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int buildCost = 75;

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
}
