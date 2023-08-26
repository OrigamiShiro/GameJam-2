using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour
    where T : MonoBehaviour
{
    [Header("Object Pool"), Space]
    [SerializeField] private Transform _poolContainer;
    [SerializeField] private int _spawnAmount;

    private List<T> _pool = new();

    protected void Initialize(T prefab)
    {
        for (int index = 0; index < _pool.Count; index++)
        {
            T spawned = Instantiate(prefab, _poolContainer);

            spawned.gameObject.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out T result)
    {
        T gameObject = _pool.FirstOrDefault(poolObject => poolObject.gameObject.activeSelf == false);

        result = gameObject;
        return result;
    }

    protected void ResetPool()
    {
        foreach (var item in _pool)
            _pool.Remove(item);
    }
}
