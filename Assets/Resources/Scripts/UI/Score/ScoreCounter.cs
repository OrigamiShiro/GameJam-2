using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private List<EnemySpawner> _spawners;

    private int _playerScore = 0;

    private void Start()
    {
        foreach (EnemySpawner spawner in _spawners)
        {
            foreach (Enemy enemy in spawner.PooledObjects)
            {
                enemy.Died += OnEnemyDeath;
            }
        }
    }

    private void OnDisable()
    {
        foreach (EnemySpawner spawner in _spawners)
        {
            foreach (Enemy enemy in spawner.PooledObjects)
                enemy.Died -= OnEnemyDeath;
        }
    }

    private void Update()
    {
        _score.text = _playerScore.ToString();
    }

    private void ResetScore()
    {
        _playerScore = 0;
    }

    private void OnEnemyDeath()
    {
        _playerScore++;
    }
}
