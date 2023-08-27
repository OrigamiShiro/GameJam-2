using GameJam;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Weapon>(out Weapon weapon))
        {
            _enemy.TakeDamage(weapon.Damage);
        }
    }
}
