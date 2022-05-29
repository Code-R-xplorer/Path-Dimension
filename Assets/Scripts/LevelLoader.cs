using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private int nextLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (nextLevel == 4)
            {
                GameManager.Instance.SaveCurrentLevel(nextLevel);
                SceneManager.LoadScene("Level_Selection");
            }
            else
            {
                GameManager.Instance.SaveCurrentLevel(nextLevel);
                SceneManager.LoadScene("Level_" + nextLevel);
            }
        }
    }
}
