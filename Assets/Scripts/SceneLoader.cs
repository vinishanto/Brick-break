using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string Getlevel() {
        // PlayerPrefs.DeleteAll();
        if(PlayerPrefs.HasKey("level")) {
            return PlayerPrefs.GetString("level");
        } else {
            return "Level1";
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(Getlevel());
    }
}
