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

    public event Action onToggleTiles;

    public void ToggleTiles()
    {
        if (onToggleTiles != null)
        {
            onToggleTiles();
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
