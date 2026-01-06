using System;

using UnityEditor;
using UnityEngine;

public class StudyScore : MonoBehaviour
{
    public static event Action onScoreUp;
    public static event Action onScoreDown;

    public static event Action<int, bool> onScore;

    private int score;


    private void Start()
    {
        onScoreUp += ScoreUp;
        onScoreDown += ScoreDown;

        onScore += ScoreUpDown;
    }

    void ScoreUp()
    {
        score++;
    }

    void ScoreDown()
    {
        score--;
    }

    void ScoreUpDown(int score, bool ishit)
    {
        if (ishit)
            this.score += score;
        else
            this.score -= score;

    }

    public static void TriggerScore()
    {
        onScoreUp?.Invoke();
    }
}
