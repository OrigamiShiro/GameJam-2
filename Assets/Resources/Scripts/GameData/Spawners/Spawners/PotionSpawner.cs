using UnityEngine;

namespace GameJam
{
    public class PotionSpawner : Spawner<Potion>
    {
        [SerializeField] private float _spawnInterval = 3f;

        protected override float SetSpawnInterval()
        {
            return Random.Range(0, _spawnInterval);
        }
    }
}
