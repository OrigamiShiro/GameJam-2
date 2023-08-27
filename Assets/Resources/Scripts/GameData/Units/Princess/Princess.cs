using System;
using UnityEngine;

namespace GameJam
{
    public class Princess : MonoBehaviour, IDamageable
    {
        [SerializeField] private UnitData _data;

        private Weapon _weapon;
        private int _health;
        private int _maxHealth;

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

        public void ApplyWeapon(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
                return;

            _health -= damage;

            if (_health <= 0)
            {
                Died?.Invoke();
                Die();
            }
        }
    }
}
