using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : ObjectPool<T>
    where T : MonoBehaviour, ISpawnable
{
    [SerializeField] private Transform spawnPointsContainer;
    [SerializeField] private List<T> _spawnablePrefab;

    private Coroutine _spawning;
    private Transform[] _spawns;

    protected abstract float SetSpawnInterval();

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(SetSpawnInterval());

            if (TryGetObjectInPool(out T spawnedObject))
                SetSpawnable(spawnedObject);
        }
    }

    private void CreateSpawn(ref Transform[] spawns, Transform _spawnPoints)
    {
        spawns = new Transform[_spawnPoints.childCount];

        for (int index = 0; index < _spawnPoints.childCount; index++)
            spawns[index] = _spawnPoints.GetChild(index);
    }

    private void SetSpawnable(T spawnable)
    {
        spawnable.gameObject.SetActive(true);
        spawnable.transform.position = RandomSpawnPosition();
    }

    private Vector3 RandomSpawnPosition()
    {
        var randomSpawn = Random.Range(0, _spawns.Length);
        var spawnPosition = new Vector3(
            _spawns[randomSpawn].transform.position.x,
            _spawns[randomSpawn].transform.position.y, 
            _spawns[randomSpawn].transform.position.z);

        return spawnPosition;
    }

    private void StartSpawn()
    {
        _spawning = StartCoroutine(SpawnObjects());
    }

    public void Init()
    {
        CreateSpawn(ref _spawns, spawnPointsContainer);
        Initialize(_spawnablePrefab);
        StartSpawn();
    }

    public void StopSpawn()
    {
        if (_spawning != null)
            StopCoroutine(_spawning);
    }

    public void ResetEnemyPool()
    {
        ResetPool();
    }
}
