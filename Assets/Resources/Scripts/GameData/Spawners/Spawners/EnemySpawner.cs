using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private float _spawnInterval;

    protected override float SetSpawnInterval()
    {
        return Random.Range(0, _spawnInterval);
    }
}
