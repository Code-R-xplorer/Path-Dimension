using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentLevel = 1;


    private void Awake()
    {
        Instance = this;
        if (!PlayerPrefs.HasKey("currentLevel"))
        {
            SaveCurrentLevel(currentLevel);
        }
        else
        {
            LoadCurrentLevel();
        }
        
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level_Selection")
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public event Action onToggleTiles;

    public void ToggleTiles()
    {
        if (onToggleTiles != null)
        {
            onToggleTiles();
        }
    }

    public void SaveCurrentLevel(int level)
    {
        if (level > currentLevel)
        {
            PlayerPrefs.SetInt("currentLevel", level);
            currentLevel = level;
        }
    }

    public void LoadCurrentLevel()
    {
        currentLevel = PlayerPrefs.GetInt("currentLevel");
    }
}
