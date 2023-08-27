using System;
using UnityEngine;

namespace GameJam
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private UnitData _data;
        [SerializeField] private Transform _itemPos;

        private Weapon _weapon;
        private float _speed;
        private int _health;
        private int _maxHealth;

        public UnitData Data => _data;
        public float Speed => _speed;
        public int CurrentHealth => _health;

        public event Action Died;

        private void Awake()
        {
            _speed = _data.Speed;
            _maxHealth = _data.Health;
            _health = _maxHealth;
        }

        private void OnTriggerEnter(Collider other)
        {
            var isPrincess = other.gameObject.TryGetComponent<Princess>(out var princess);
            var isWeapon = other.gameObject.TryGetComponent<Weapon>(out var weapon);
            var isEnemy = other.gameObject.TryGetComponent<Enemy>(out var enemy);

            if (isPrincess && _weapon != null)
                TransferWeapon(princess, _weapon);
            else if (isWeapon)
                ApplyWeapon(weapon);
            else if (isEnemy)
            {
                TakeDamage(enemy.Damage);
            }
        }

        private void ApplyWeapon(Weapon weapon)
        {
            _weapon = weapon;
            weapon.transform.SetParent(_itemPos);
            weapon.GetPicked();
        }

        private void TransferWeapon(Princess target, Weapon weapon)
        {
            target.ApplyWeapon(weapon);
            Destroy(weapon.gameObject);
            _weapon = null;
        }

        public void IncreaseHealth(int addition)
        {
            _maxHealth += addition;
        }

        public void IncreaseSpeed(float addition)
        {
            _speed += addition;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
                return;

            _health -= damage;

            if (_health <= 0)
                Died?.Invoke();
        }

        public void Die()
        {
            gameObject.SetActive(false);
        }
    }
}
