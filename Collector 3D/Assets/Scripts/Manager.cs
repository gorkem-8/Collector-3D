using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    private int level;
    private int newStart;

    private void Awake()
    {
        newStart = PlayerPrefs.GetInt("Started", 0); 
        level = PlayerPrefs.GetInt("Level", 1);
        levelText.text = "Level " + level.ToString();
        LoadCurrentScene();
    }

    public void ReStartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 1) + 1);
        LoadNextScene();
    }

    public void LoadCurrentScene()
    {
        if (level >= 10 && newStart==0)
        {
            int randInt = Random.Range(0, 10);
            SceneManager.LoadScene(randInt);
            PlayerPrefs.SetInt("Started", 1);
        }
        else if (level < 10 && newStart == 0)
        {
            SceneManager.LoadScene(level - 1);
            PlayerPrefs.SetInt("Started", 1);
        }
        else
            PlayerPrefs.SetInt("Started", 0);

    }

    public void LoadNextScene()
    {
        PlayerPrefs.SetInt("Started", 1);
        if (level >= 10)
        {
            int randInt = Random.Range(0, 10);
            SceneManager.LoadScene(randInt);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
