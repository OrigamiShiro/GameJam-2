using GameJam;
using UnityEngine;

public class WeaponSpawner : Spawner<Weapon>
{
    [SerializeField] private float _spawnInterval;

    protected override float SetSpawnInterval()
    {
        return Random.Range(0, _spawnInterval);
    }
}
