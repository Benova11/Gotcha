using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    Bank bank;
    [SerializeField] TextMeshProUGUI balanceLabel;
    [SerializeField] TextMeshProUGUI numOfTowersAvailable;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
        bank.OnBalanceChanged += UpdateBalnces;
        SetBalanceLabel();
        SetNumOfAvailableTowers();
    }

    public void EndGame()
    {
        ReloadScene();
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void UpdateBalnces()
    {
        SetBalanceLabel();
        SetNumOfAvailableTowers();
    }

    public void SetBalanceLabel()
    {
        balanceLabel.text = bank.CurrentBalance.ToString();
    }

    public void SetNumOfAvailableTowers()
    {
        numOfTowersAvailable.text = (bank.CurrentBalance / Tower.GetBuildCost()).ToString();
    }
}
