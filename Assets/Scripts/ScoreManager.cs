using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int CurrentScore = 0;
    public int AllTimeScore = 0;
    private int ScoreWhenAdded = 0;
    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AllTimeScore = PlayerPrefs.GetInt("score", 0);
    }

    public void AddScore(int score)
    {
        CurrentScore += score;
    }

    public void AddAllTimeScore()
    {
        AllTimeScore += CurrentScore - ScoreWhenAdded;
        ScoreWhenAdded = CurrentScore;
        PlayerPrefs.SetInt("score", AllTimeScore);
    }
}
