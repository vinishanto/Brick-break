using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int brickCount = 0;

    private void Awake()
    {   
        instance = this;
        Application.targetFrameRate = 60;
    }

    public void next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetString("level", SceneManager.GetActiveScene().name);
    }

    public void restart()
    {
        SceneManager.LoadScene("Intro");
    }

    public void RestartSelf()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
