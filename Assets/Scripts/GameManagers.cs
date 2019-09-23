using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagers : MonoBehaviour
{
    public GameManagers gameManagers;
    public GameObject gameOverPanel;
    public Transform playerpos;
    public TextMeshProUGUI ScoreText, CoinText, ScoreTextGO, CoinTextGo;
    public static int coinAmmount;

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = playerpos.transform.position.z.ToString("0");
        CoinText.text = coinAmmount.ToString("0");
    }

    bool GameEnded = false;
    public float RestartDelay = 2f;

    public void EndGame()
    {
        GameEnded = true;
        Debug.Log("Game Over");
        DisplayGameOverPanel();
    }

    private void Start()
    {
        //playerpos = GameObject.FindGameObjectWithTag("Player");
        gameOverPanel.SetActive(false);
        coinAmmount = 0;
        CoinText.text = coinAmmount.ToString("0");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void GoToHome()
    {
        SceneManager.LoadScene("Main");
    }

    void DisplayGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        ScoreTextGO.text = ScoreText.text;
        CoinTextGo.text = CoinText.text;

    }
}
