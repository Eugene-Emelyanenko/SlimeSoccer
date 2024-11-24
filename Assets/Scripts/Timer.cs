using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Score score;
    
    public float startTime = 90f;
    public Text timerText;

    private float currentTime;
    private bool isTimerRunning = false;
    void Start()
    {
        currentTime = startTime;
        UpdateTimer();
        StartTimer();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;
            UpdateTimer();

            if (currentTime <= 0f)
            {
                TimerComplete();
            }
        }
    }

    private void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.text = timeString;
    }

    private void TimerComplete()
    {
        Debug.Log("Time out!");
        timerText.text = "00:00";
        isTimerRunning = false;
        
        score.GameOver();
        Gate.gameOver = true;
    }

    private void StartTimer()
    {
        isTimerRunning = true;
    }

    private void StopTimer()
    {
        isTimerRunning = false;
    }

    private void ResetTimer()
    {
        currentTime = startTime;
        UpdateTimer();
        isTimerRunning = false;
    }
}
