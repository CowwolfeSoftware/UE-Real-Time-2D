using System;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public TMP_Text FinalScoreText;
    public TMP_Text GameScoreText;
    public TMP_Text HighScoreText;

    private int highScore;
    private int score;
    public static ScoreBoard Instance {get; private set;}
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ResetScore()
    {
        score = 0;
        SetScores();
    }

    public void IncrementScore(int count)
    {
        score += count;
        SetScores();
    }

    void SetScores()
    {
        if(highScore < score)
            highScore = score;

        HighScoreText.text = String.Format("High Score: {0}", highScore);
        var scoreText = String.Format("Score: {0}", score);
        GameScoreText.text = scoreText;
        FinalScoreText.text = scoreText;
    }
}
