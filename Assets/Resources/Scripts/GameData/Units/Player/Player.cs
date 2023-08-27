using System;
using UnityEngine;

namespace GameJam
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private UnitData _data;
        [SerializeField] private Transform _itemContainer;
        
        private float _speed;
        private int _health;
        private int _maxHealth;

        public Weapon Weapon { get; private set; }
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

        public void ApplyWeapon(Weapon weapon)
        {
            Weapon = weapon;
            weapon.transform.SetParent(_itemContainer);
            weapon.GetPicked();
        }

        public void TransferWeapon(Princess target, Weapon weapon)
        {
            target.ApplyWeapon(weapon);
            Destroy(weapon.gameObject);
            Weapon = null;
        }

        private void Die()
        {
            gameObject.SetActive(false);
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
            {
                Died?.Invoke();
                Die();
            }
        }
    }
}
