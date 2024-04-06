using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance { get; private set; } // For easy access from other scripts

    public GameObject pauseMenuPanel;
    public GameObject Controlpanel;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void SaveData()
    {
        PlayerPrefs.SetInt("PlayerCoins", LootSpawner.Instance.coinCount);
        PlayerPrefs.SetInt("PlayerGems", LootSpawner.Instance.gemCount);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        LootSpawner.Instance.coinCount = PlayerPrefs.GetInt("PlayerCoins", 0);
        LootSpawner.Instance.gemCount = PlayerPrefs.GetInt("PlayerGems", 0);
        LootSpawner.Instance.UpdateCoinUI();
        LootSpawner.Instance.UpdateGemUI();
    }
    public void TogglePause()
    {
        Controlpanel.SetActive(false);
        pauseMenuPanel.SetActive(true);

    }
    public void Toggleplay()
    {
        Controlpanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
    }
}
