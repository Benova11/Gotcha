using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;

    Bank bank;
    
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public bool RewardGold()
    {
        if (bank != null)
        {
            bank.Deposite(goldReward);
            return true;
        }
        return false;
    }

    public bool StealGold()
    {
        if (bank != null)
        {
            bank.Withdraw(goldPenalty);
            return true;
        }
        return false;
    }
}