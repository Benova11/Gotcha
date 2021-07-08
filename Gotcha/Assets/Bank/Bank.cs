using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;

    GameManager gameManager;

    public int CurrentBalance { get { return currentBalance; } }

    public delegate void BalanceChanged();
    public event BalanceChanged OnBalanceChanged;

    void Awake()
    {
        currentBalance = startingBalance;
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Deposite(int amountToDeposit)
    {
        currentBalance += Mathf.Abs(amountToDeposit);
        OnBalanceChanged();
    }

    public void Withdraw(int amountToWithdraw)
    {
        currentBalance -= Mathf.Abs(amountToWithdraw);

        if (currentBalance < 0)
        {
            gameManager.LostGame();
        }
        else
        {
            OnBalanceChanged();
        }
    }
}

