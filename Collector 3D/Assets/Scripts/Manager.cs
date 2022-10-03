using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    private int level;

    private void Awake()
    {
        level = PlayerPrefs.GetInt("Level", 1);
        levelText.text = "Level " + level.ToString();
        if (level != SceneManager.GetActiveScene().buildIndex + 1)
        {
            LoadScene();
        }
    }

    public void ReStartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 1) + 1);
        LoadScene();
    }

    public void LoadScene()
    {
        if (level >= 10)
        {
            int randInt = Random.Range(0, 10);
            SceneManager.LoadScene(randInt);
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
