using GameJam;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var isPrincess = other.gameObject.TryGetComponent<Princess>(out var princess);
        var isWeapon = other.gameObject.TryGetComponent<Weapon>(out var weapon);
        var isEnemy = other.gameObject.TryGetComponent<Enemy>(out var enemy);

        if (isPrincess && _player.Weapon != null)
            _player.TransferWeapon(princess, _player.Weapon);
        else if (isWeapon)
            _player.ApplyWeapon(weapon);
        else if (isEnemy)
            _player.TakeDamage(enemy.Damage);
    }
}
