using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text timeText;
    [SerializeField]
    Text gameOverText;
    [SerializeField]
    Text scoreText;

    float elapsedSeconds = 0;

    bool isGameRunning = false;

    const int PointsForAsteroid = 10;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "0";
        scoreText.text = "Score: 0";
        isGameRunning = true;
    }


    public void StopGameTimer()
    {
        isGameRunning = false;
        gameOverText.text = "Game Over";
    }

    public void AddPoints()
    {
        score += PointsForAsteroid;
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameRunning)
        {
            elapsedSeconds += Time.deltaTime;
            timeText.text = (Math.Round(elapsedSeconds, 2)).ToString();
        }
    }
}
