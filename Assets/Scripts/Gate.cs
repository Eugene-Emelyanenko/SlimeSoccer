using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Score score;
    [SerializeField] private PlayerController player;
    [SerializeField] private EnemyController enemy;
    public float timeToResetBallPos = 1f;
    public bool enemyGates = false;
    public bool playerGates = false;

    public static bool gameOver;

    private void Start()
    {
        gameOver = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball") && !gameOver)
        {
            if (playerGates)
            {
                score.IncreaseEnemyScore();
            }
            else if (enemyGates)
            {
                score.IncreasePlayerScore();
            }

            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(timeToResetBallPos);
        ball.ResetPosition();
        player.ResetPosition();
        enemy.ResetPosition();
    }
}
