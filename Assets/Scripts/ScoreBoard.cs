using System;
using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public TMP_Text PlanetScoreText;
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

    void Start()
    {
        PlanetScoreText.gameObject.SetActive(false);
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
        StartCoroutine(ShowPlanetScore(count));
    }

    IEnumerator ShowPlanetScore(int count)
    {
        PlanetScoreText.gameObject.SetActive(true);
        PlanetScoreText.text = string.Format("+{0}", count);
        yield return new WaitForSeconds(1);
        PlanetScoreText.gameObject.SetActive(false);
    }

    void SetScores()
    {
        if(highScore < score)
            highScore = score;

        HighScoreText.text = string.Format("High Score: {0}", highScore);
        var scoreText = string.Format("Score: {0}", score);
        GameScoreText.text = scoreText;
        FinalScoreText.text = scoreText;
    }
}
