using GameJam;
using UnityEngine;

public class SceneRoot : MonoBehaviour
{
    [Header("Spawners configurations")]
    [SerializeField] private Princess _enemyTarget;
    [SerializeField] private EnemySpawner _enemySpawner;

    private void Start()
    {
        _enemySpawner.Init();

        foreach (Enemy enemy in _enemySpawner.PooledObjects)
            enemy.Init(_enemyTarget);
    }
}