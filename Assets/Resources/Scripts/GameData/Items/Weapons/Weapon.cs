using UnityEngine;

namespace GameJam
{
    public abstract class Weapon : MonoBehaviour, ISpawnable, IPickable
    {
        [SerializeField] private WeaponData _data;

        private int _damage;

        public int Damage => _damage;
        public WeaponData Data => _data;

        private void Start()
        {
            _damage = _data.Damage;
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