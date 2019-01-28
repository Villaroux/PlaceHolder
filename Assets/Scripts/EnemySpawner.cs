using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public EnemySpawn[] enemySpawns;

    public GameObject TopBoundingBox;
    public GameObject BottomBoundingBox;

    public int spawnsThisWave;
    public int wavesThisGame;

    private void Awake()
    {
        NormalizeSpawnChances();
    }
    private void Start()
    {
        StartCoroutine(SpawnsPerWave());
    }
    void NormalizeSpawnChances()
    {
        float spawnChanceSum = 0.0f;

        foreach (var enemySpawn in enemySpawns)
        {
            spawnChanceSum += enemySpawn.spawnChance;
        }

        foreach (var enemySpawn in enemySpawns)
        {
            enemySpawn.spawnChance /= spawnChanceSum;
        }
    }

    void Spawn()
    {
        float rando = Random.value;

        for (int i = 0; i < enemySpawns.Length; i++)
        {
            float currPer = 0.0f;
            int currI = i;
            for (; i > 0; i--)
            {
                currPer += enemySpawns[i].spawnChance;
            }

            i = currI;

            if (rando < currPer)
            {
                Instantiate(enemySpawns[i].EnemyPreFab,
                    new Vector3(
                        transform.position.x,
                        Random.Range(BottomBoundingBox.transform.position.y, TopBoundingBox.transform.position.y),
                        transform.position.z), Quaternion.identity);
                return;
            }
        }
    }

    IEnumerator NumberOfWaves()
    {
        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < wavesThisGame; i++)
        {
            //SpawnsPerWave(10);
        }
    }
    IEnumerator SpawnsPerWave()
    {
        for (int i = 0; i < spawnsThisWave + 1; i++)
        {
            Spawn();
            yield return new WaitForSeconds(1.0f);
        }
    }
}
