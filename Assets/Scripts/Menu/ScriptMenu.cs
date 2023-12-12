using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScriptMenu : MonoBehaviour
{
    public void Start()
    {
        if (PlayerPrefs.HasKey("ResolutionWidth") && PlayerPrefs.HasKey("ResolutionHeight"))
        {
            var resolutionWidth = PlayerPrefs.GetInt("ResolutionWidth");
            var resolutionHeight = PlayerPrefs.GetInt("ResolutionHeight");
            Screen.SetResolution(resolutionWidth, resolutionHeight, Screen.fullScreen);
        }
        
        if (PlayerPrefs.HasKey("FullScreen"))
        {
            bool isFullScreen = PlayerPrefs.GetInt("FullScreen") == 1;
            Screen.fullScreen = isFullScreen;
        }
        if (PlayerPrefs.HasKey("QualityIndex"))
        {
            int qualityIndex = PlayerPrefs.GetInt("QualityIndex");
            QualitySettings.SetQualityLevel(qualityIndex);
        }
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync(0);
        Player.Instance.setNewGame(true);

    }
    public void PlayMenu()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void LoadButton()
    {
        SceneManager.LoadSceneAsync(0);
        Player.Instance.Load();
    }
    public void Options()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void Back()
    {

        SceneManager.LoadSceneAsync(1);
    }
}