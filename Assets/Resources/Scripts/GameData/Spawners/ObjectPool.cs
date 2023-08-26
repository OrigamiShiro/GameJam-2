using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour
    where T : MonoBehaviour, ISpawnable
{
    [Header("Object Pool"), Space]
    [SerializeField] private Transform _poolContainer;
    [SerializeField] private int _spawnAmount;

    private List<T> _pool = new List<T>();

    public List<T> PooledObjects => _pool;

    protected void Initialize(List<T> prefab)
    {
        for (int index = 0; index < _spawnAmount; index++)
        {
            T spawned = Instantiate(prefab[Random.Range(0, prefab.Count)], _poolContainer);

            spawned.gameObject.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObjectInPool(out T result)
    {
        result = _pool.FirstOrDefault(poolObject => poolObject.gameObject.activeSelf == false);

        return result != null;
    }

    protected void ResetPool()
    {
        foreach (var item in _pool.ToList())
        {
            _pool.Remove(item);
            Destroy(item.gameObject);
        }            
    }
}
