using GameJam;
using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, ISpawnable, IDamageable
{
    [Header("Configurations"), Space]
    [SerializeField] private UnitData _data;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackCooldown;

    private int _health;
    private int _maxHealth;

    public Princess Target { get; private set; }
    public float Speed => _data.Speed;
    public int Damage => _damage;
    public int Health => _health;
    public float AttackCooldown => _attackCooldown;

    public event Action Died;

    private void Awake()
    {
        _maxHealth = _data.Health;
        _health = _maxHealth;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public void Init(Princess target)
    {
        Target = target;
    }

    public void IncreaseHealth(int addition)
    {
        _health += addition;
    }

    public void TakeDamage(int damage)
    {
        if (_health <= 0)
            return;

        _health -= damage;

        if (_health == 0)
        {
            Died?.Invoke();
            Die();
        }  
    }
}
