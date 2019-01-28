using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public EnemySpawn[] enemySpawns;

    public GameObject TopBoundingBox;
    public GameObject BottomBoundingBox;

    public int spawnsThisWave;
    public int wavesThisGame;

    bool IsWaveCompleted = false;

    bool IsWaveSpawningComplete = false;
    //Variable initialization and spawn rate normalization;
    private void Awake()
    {
        NormalizeSpawnChances();
    }
    //Starts round spawning
    private void Start()
    {
        StartCoroutine(NumberOfWaves());
    }
    //Next wave command
    private bool CheckForNextWave()
    {
        int numberOfSpawns = transform.childCount;
        
        if(numberOfSpawns > 0)
        {
            for (int i = 0; i < numberOfSpawns; i++)
            {
                Debug.Log("Checking: " + i);
                var child = transform.GetChild(i);

                if (child.gameObject.activeInHierarchy)
                {
                    Debug.Log("Found: " + i);
                    //Found 1 active enemy can't go to the next wave
                    return false;
                }
            }
            //Can go to the next wave
            return true;
        }
        return false;
    }
    //Spawn rate normalization method
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
    //Spawn Enemy Method
    void Spawn()
    {
        float rando = UnityEngine.Random.value;

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
                var spawned = Instantiate(enemySpawns[i].EnemyPreFab,
                    new Vector3(
                        transform.position.x,
                        UnityEngine.Random.Range(BottomBoundingBox.transform.position.y, TopBoundingBox.transform.position.y),
                        transform.position.z), Quaternion.identity);

                spawned.transform.parent = gameObject.transform;
                return;
            }
        }
    }
    //Coroutine for number of spawn waves
    IEnumerator NumberOfWaves()
    {

        for (int i = 0; i < wavesThisGame; i++)
        {
            IsWaveCompleted = false;
            StartCoroutine(SpawnsPerWave());
            yield return new WaitUntil(() => CheckForNextWave());
            Debug.Log("Next Wave");
        }
    }
    //Coroutine for number os spawned enemies per wave
    IEnumerator SpawnsPerWave()
    {
        for (int i = 0; i < spawnsThisWave + 1; i++)
        {
            Spawn();
            yield return new WaitForSeconds(1.0f);
        }
        IsWaveSpawningComplete = true;
    }
}
