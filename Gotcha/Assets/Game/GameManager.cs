using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    Bank bank;
    [SerializeField] TextMeshProUGUI balanceLabel;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
        bank.OnBalanceChanged += SetBalanceLabel;
        SetBalanceLabel();
    }

    void Update()
    {
        
    }

    public void EndGame()
    {
        ReloadScene();
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetBalanceLabel()
    {
        balanceLabel.text = "Gold: " + bank.CurrentBalance;
    }
}
