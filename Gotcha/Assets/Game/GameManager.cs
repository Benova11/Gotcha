using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    Bank bank;
    [SerializeField] TextMeshProUGUI balanceLabel;
    [SerializeField] TextMeshProUGUI numOfTowersAvailable;
    [SerializeField] TextMeshProUGUI numOfEnemiesToWinText;
    [SerializeField] TextMeshProUGUI towerCost;
    
    [SerializeField] Text levelSuccess;
    [SerializeField] int numOfEnemiesToWin = 4;

    bool gameEnded = false;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
        bank.OnBalanceChanged += UpdateBalnces;
        SetBalanceLabel();
        SetNumOfAvailableTowers();
        numOfEnemiesToWinText.text = "Enemies: " + numOfEnemiesToWin.ToString();
        towerCost.text = Tower.GetBuildCost().ToString();
    }

    public void LostGame()
    {
        if (!gameEnded)
        {
            StartCoroutine(EndGame(false));
            Debug.Log("LostGame");
        }
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnEnemyDied()
    {
        numOfEnemiesToWin -= 1;
        if (numOfEnemiesToWin == 0)
        {
            numOfEnemiesToWinText.gameObject.SetActive(false);
            StartCoroutine(EndGame(true));
        }
        else
        {
            numOfEnemiesToWinText.text = "Enemies To Win: " + numOfEnemiesToWin.ToString();
        }
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

    IEnumerator EndGame (bool isSuccesfull)
    {
        gameEnded = true;
        Debug.Log("EndGame");
        if (!isSuccesfull)
        {
            levelSuccess.text = "Level Failed!";
        }
        levelSuccess.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        GoToMainMenu();
    }
}
