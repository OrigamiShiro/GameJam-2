using GameJam;
using UnityEngine;

public class SceneRoot : MonoBehaviour
{
    [Header("Scene configurations"), Space]
    [SerializeField] private MovementInput _playerMovement;
    [SerializeField] private Princess _enemyTarget;

    [Header("Spawners configurations"), Space]
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private WeaponSpawner _weaponSpawner;
    [SerializeField] private PotionSpawner _potionSpawner;

    private Player _player;
    private State _enemyState;

    [Header("UI Screens"), Space]
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        _player = _playerMovement.GetComponent<Player>();
        _player.Died += OnPlayerDeath;
        _enemyTarget.Died += OnPlayerDeath;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDeath;
        _enemyTarget.Died -= OnPlayerDeath;
    }

    private void Start()
    {
        _playerMovement.Activate();
        _enemySpawner.Init();
        _weaponSpawner.Init();
        _potionSpawner.Init();

        foreach (Enemy enemy in _enemySpawner.PooledObjects)
        {
            _enemyState = enemy.GetComponent<State>();

            _enemyState.Activate();
            enemy.Init(_enemyTarget);
        }
    }

    private void OnPlayerDeath()
    {
        foreach (Enemy enemy in _enemySpawner.PooledObjects)
        {
            _enemyState = enemy.GetComponent<State>();
            _enemyState.Deactivate();
        }

        _playerMovement.Deactivate();
        _enemySpawner.StopSpawn();
        _weaponSpawner.StopSpawn();
        _potionSpawner.StopSpawn();
        _gameOverScreen.Open();
    }
}