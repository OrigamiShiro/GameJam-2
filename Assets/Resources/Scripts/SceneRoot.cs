using GameJam;
using UnityEngine;

public class SceneRoot : MonoBehaviour
{
    [Header("Scene configurations"), Space]
    [SerializeField] private MovementInput _playerMovement;
    [SerializeField] private Princess _enemyTarget;
    [SerializeField] private EnemySpawner _enemySpawner;
    private Player _player;

    [Header("UI Screens"), Space]
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        _player = _playerMovement.GetComponent<Player>();
        _player.Died += OnPlayerDeath;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDeath;
    }

    private void Start()
    {
        _playerMovement.Activate();
        _enemySpawner.Init();

        foreach (Enemy enemy in _enemySpawner.PooledObjects)
            enemy.Init(_enemyTarget);
    }

    private void OnPlayerDeath()
    {
        _player.Die();
        _playerMovement.Deactivate();
        _enemySpawner.StopSpawn();
        _gameOverScreen.Open();
    }
}