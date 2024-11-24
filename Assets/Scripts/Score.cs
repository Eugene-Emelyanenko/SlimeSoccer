using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text enemyScoreText;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject looseMenu;
    private int playerScore;
    private int enemyScore;
    void Start()
    {
        playerScore = 0;
        enemyScore = 0;
        playerScoreText.text = playerScore.ToString();
        enemyScoreText.text = enemyScore.ToString();
    }

    public void IncreasePlayerScore()
    {
        playerScore++;

        playerScoreText.text = playerScore.ToString();
    }
    
    public void IncreaseEnemyScore()
    {
        enemyScore++;

        enemyScoreText.text = enemyScore.ToString();
    }

    public void GameOver()
    {
        if (playerScore > enemyScore)
        {
            winMenu.SetActive(true);
        }
        else
        {
            looseMenu.SetActive(true);
        }
    }
}
