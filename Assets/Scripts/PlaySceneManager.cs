using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaySceneManager : MonoBehaviour 
{
    public float limitTime = 60f;

    public Text scoreText;
    public Slider timeSlider;
    public ScoreDialog scoreDialog;

    float remainTime;

    string scoreBase = "SCORE : ";
    int score = 0;

    bool gameOver = false;
    bool timerOn = false;

    public void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = scoreBase + score;
    }

    public void StartTimer()
    {
        timerOn = true;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    void Awake()
    {
        remainTime = limitTime;
    }

    void Update()
    {
        if (!gameOver)
        {
            if (timerOn)
            {
                remainTime -= Time.deltaTime;
                timeSlider.value = remainTime / limitTime;
            }
            if (remainTime < 0f)
            {
                gameOver = true;
                scoreDialog.ShowDialog(score);
            }
        }
    }
}
