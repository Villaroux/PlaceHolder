using UnityEngine;
[CreateAssetMenu(fileName ="EnemySpawnData")]
public class EnemySpawn : ScriptableObject
{
    public GameObject EnemyPreFab;
    public float spawnChance;
}
