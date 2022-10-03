using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;

    void Start()
    {
        int level = PlayerPrefs.GetInt("Level", 1);
        levelText.text = "Level "+ level.ToString();
    }



    public void ReStartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
