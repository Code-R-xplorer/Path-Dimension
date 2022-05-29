using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoaderUI : MonoBehaviour
{
    [SerializeField] private TMP_Text levelNum;

    [SerializeField] private int levelNumber;

    [SerializeField] private Button playButton;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameManager.Instance.currentLevel);
        Debug.Log(levelNumber);
        if (levelNumber > GameManager.Instance.currentLevel)
        {
            playButton.interactable = false;
        }
        else
        {
            playButton.interactable = true;
        }

        levelNum.text = "Level: " + levelNumber;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level_" + levelNumber, LoadSceneMode.Single);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
