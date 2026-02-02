using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public List<GameObject> levelPrefabs; // Inspector'dan Level 1 ve Level 2 prefablarını buraya sürükleyin
    public Transform levelSpawnPoint;     // Levellerin oluşacağı nokta (Opsiyonel, boş bırakılırsa 0,0,0)

    private GameObject currentLevelObject;
    private int currentLevelIndex = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject); // Tek sahne mantığında gerekip gerekmediğine bakılmalı, şimdilik gerek yok
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SpawnLevel(currentLevelIndex);
    }

    public void NextLevel()
    {
        // Mevcut leveli yok et
        if (currentLevelObject != null)
        {
            Destroy(currentLevelObject);
        }

        // Indexi artır
        currentLevelIndex++;

        // Eğer son levelden sonraysa başa dön (veya oyun bitti ekranı)
        if (currentLevelIndex >= levelPrefabs.Count)
        {
            currentLevelIndex = 0; // Döngü
        }

        SpawnLevel(currentLevelIndex);
    }

    void SpawnLevel(int index)
    {
        if (levelPrefabs.Count == 0) return;

        Vector3 spawnPos = Vector3.zero;
        if (levelSpawnPoint != null)
        {
            spawnPos = levelSpawnPoint.position;
        }

        currentLevelObject = Instantiate(levelPrefabs[index], spawnPos, Quaternion.identity);
    }
}
