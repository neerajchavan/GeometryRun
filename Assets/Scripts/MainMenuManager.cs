using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager mainMenuManager;
    [SerializeField] private int money,hiScore;
    public TextMeshProUGUI moneyText,hiScoreText;
    public int CurrentRunnerID = 0;


    void Awake()
    {
        mainMenuManager = this;
        UpdateUI();
    }
  
    public void AddMoney(int amount)
    {
        money += amount;
        UpdateUI();
    }

    public void ReduceMoney(int amount)
    {
        money -= amount;
        UpdateUI();
    }

    public bool RequestMoney(int amount)
    {
        if (amount <= money)
        {
            return true;
        }

        return false;
    }

    public int GetMoneyInfo()
    {
        return money;
    }

    public void SetMoneyInfro(int amount)
    {
        money = amount;
        UpdateUI();
    }

    public int GetHiScoreInfo()
    {
        return hiScore;
    }

    public void SetHiScoreInfro(int hiScorePara)
    {
        hiScore = hiScorePara;
        UpdateUI();
    }

    void UpdateUI()
    {
        moneyText.text = money.ToString("0");
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
