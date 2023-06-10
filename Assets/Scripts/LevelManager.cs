using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public int CurrentLevelIndex = -1;
    public int LevelCount = 2;
    public bool HasLost = false;
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

    public void LoadNextLevel()
    {
        CurrentLevelIndex++;
        CurrentLevelIndex%= LevelCount;
        HasLost= false;
        SceneManager.LoadScene("Level"+(CurrentLevelIndex+1));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
