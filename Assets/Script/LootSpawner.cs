using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class LootSpawner : MonoBehaviour
{
    public static LootSpawner Instance { get; private set; }

    public GameObject coinPrefab;
    public GameObject gemPrefab;
    public Transform[] spawnPoints;

    public TextMeshProUGUI CoinsText;
    public TextMeshProUGUI GemsText;

    [HideInInspector]
    public int coinCount = 0;
    [HideInInspector]
    public int gemCount = 0;

    private List<GameObject> spawnedLoot = new List<GameObject>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerCoins")) // Check if there's save data
        {
            SaveLoadManager.Instance.LoadData();
        }
        SpawnLoot();

    }

    void SpawnLoot()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {

            if (Random.Range(0, 2) == 0)
            {
                SpawnItem(coinPrefab, spawnPoint);
            }
            else
            {
                SpawnItem(gemPrefab, spawnPoint);
            }
        }
    }

    void SpawnItem(GameObject prefab, Transform location)
    {
        GameObject loot = Instantiate(prefab, location.position, location.rotation);
        loot.tag = prefab == coinPrefab ? "Coins" : "Gems";
        spawnedLoot.Add(loot);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Coins") || hit.gameObject.CompareTag("Gems"))
        {
            GameObject collidedObject = hit.gameObject;
            if (spawnedLoot.Contains(collidedObject))
            {
                if (collidedObject.CompareTag("Coins"))
                {
                    coinCount++;
                    UpdateCoinUI();
                }
                else
                {
                    gemCount++;
                    UpdateGemUI();
                }

                spawnedLoot.Remove(collidedObject);
                Destroy(collidedObject);
                SaveLoadManager.Instance.SaveData();
            }
        }

    }
    public void UpdateCoinUI()
    {
        CoinsText.text = "" + coinCount;
    }

    public void UpdateGemUI()
    {
        GemsText.text = "" + gemCount;
    }
}
