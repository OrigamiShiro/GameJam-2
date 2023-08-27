using GameJam;
using UnityEngine;

public class AttackState : State
{
    private float _lastAttackTime;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _enemy.AttackCooldown;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Princess target)
    {

    }
}
