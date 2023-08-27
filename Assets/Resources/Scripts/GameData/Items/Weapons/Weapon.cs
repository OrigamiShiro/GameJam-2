using UnityEngine;

namespace GameJam
{
    public abstract class Weapon : MonoBehaviour, ISpawnable, IPickable
    {
        [SerializeField] private WeaponData _data;

        private int _damage;
        private int _durability;
        private float _attackSpeed;

        public int Damage => _damage;
        public int Durability => _durability;
        public float AttackSpeed => _attackSpeed;
        public WeaponData Data => _data;

        private void Start()
        {
            _damage = _data.Damage;
            _durability = _data.Durability;
            _attackSpeed = _data.AttackSpeed;
        }

        private void SetScale()
        {
            var newScaleSize = 0.4f;

            transform.localScale = new Vector3(newScaleSize, newScaleSize, newScaleSize);
        }

        public void GetPicked()
        {
            SetScale();
            transform.position = transform.parent.position;
        }
    }
}