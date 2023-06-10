using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelScoreDisplayController : MonoBehaviour
{
    private ScoreManager scoreManager;
    private TextMeshProUGUI scoreText;
    private void Start()
    {
        scoreManager = ScoreManager.Instance;
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        scoreText.text = ScoreManager.Instance.CurrentScore.ToString();
    }
}
