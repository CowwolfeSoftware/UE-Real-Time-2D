using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void IncrementScore(int count)
    {
        score += count;
        Debug.Log("Score = " + score);
    }
}
