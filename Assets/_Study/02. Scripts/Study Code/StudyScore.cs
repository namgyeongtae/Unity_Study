using System;
using UnityEngine;

public class StudyScore : MonoBehaviour
{
    public static event Action onScoreUp;
    public static event Action onScoreDown;

    public static Action<int, bool> onScore;

    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        onScoreUp += ScoreUp;
        onScoreDown += ScoreDown;

        onScore += ScoreUpDown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ScoreUpDown(int score, bool isUp)
    {
        if (isUp)
            this.score += score;
        else
            this.score -= score;
    }
    

    private void ScoreUp()
    {
        score++;
    }

    private void ScoreDown()
    {
        score--;
    }

    public static void TriggerScore()
    {
        onScoreUp?.Invoke();
    }
}
