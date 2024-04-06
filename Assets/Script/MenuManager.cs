using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void NewGameScene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainScene");
    }


    public void QuitGame()
    {
        Application.Quit();
    }


}
