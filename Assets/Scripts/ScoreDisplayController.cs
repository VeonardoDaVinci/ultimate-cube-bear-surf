using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplayController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI allTimeScore;
    void Start()
    {
        currentScore.text = ScoreManager.Instance.CurrentScore.ToString();
        allTimeScore.text = ScoreManager.Instance.AllTimeScore.ToString();
    }
}
