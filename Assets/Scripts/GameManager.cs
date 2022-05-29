using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public event Action onToggleTiles;

    public void ToggleTiles()
    {
        if (onToggleTiles != null)
        {
            onToggleTiles();
        }
    }
}
