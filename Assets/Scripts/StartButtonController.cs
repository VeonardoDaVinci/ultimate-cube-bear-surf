using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;
    void Start()
    {
        if(LevelManager.Instance.CurrentLevelIndex == -1)
        {
            buttonText.text = "Start";
        }
        else
        {
            buttonText.text = "Next Level";
        }
    }

    public void StartButtonAction()
    {
        LevelManager.Instance.LoadNextLevel();
    }
}
