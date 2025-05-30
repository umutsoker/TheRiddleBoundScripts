using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int spawnCount = 3;
    public Transform[] spawnPoints;
    public Transform player;

    private bool hasSpawned = false;

    void Start()
    {
        // 25 saniye sonra SpawnEnemies fonksiyonunu çağır
        StartCoroutine(SpawnAfterDelay(4f));
    }

    IEnumerator SpawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        if (hasSpawned) return; // Tekrar spawn olmasın
        hasSpawned = true;

        if (enemyPrefab == null || spawnPoints.Length == 0 || player == null)
        {
            Debug.LogError("❌ Lütfen prefab, spawn point ve player alanlarını atayın!");
            return;
        }

        for (int i = 0; i < spawnCount; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            EnemyAI ai = enemy.GetComponent<EnemyAI>();
            if (ai != null)
            {
                ai.SetTarget(player); // Player'ı hedef olarak ata
            }
        }

        Debug.Log("✅ Düşmanlar spawn edildi.");
    }
}
