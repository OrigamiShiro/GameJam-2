using GameJam;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, ISpawnable
{
    [Header("Configurations"), Space]
    [SerializeField] private UnitData _data;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackCooldown;

    public Princess Target { get; private set; }
    public float Damage => _damage;
    public float Speed => _data.Speed;
    public float Health => _data.Health;
    public float AttackCooldown => _attackCooldown;

    public void Init(Princess target)
    {
        Target = target;
    }
}
