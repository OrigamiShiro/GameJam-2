using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private UnitData _data;
        [SerializeField] private Transform itemPos;
        public UnitData Data => _data;
        private Weapon _weapon;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var isPrincess = other.gameObject.TryGetComponent<Princess>(out var princess);
            var isWeapon = other.gameObject.TryGetComponent<Weapon>(out var weapon);

            if (isPrincess && _weapon != null)
                TransferWeapon(princess, _weapon);
            else if (isWeapon)
                ApplyWeapon(weapon);
        }

        private void ApplyWeapon(Weapon weapon)
        {
            _weapon = weapon;
            weapon.transform.SetParent(itemPos);
            weapon.SetCenter();
        }

        private void TransferWeapon(Princess target, Weapon weapon)
        {
            target.ApplyWeapon(weapon);
            Destroy(weapon.gameObject);
            _weapon = null;
        }
        
        private void FixedUpdate()
        {
            MovementLogic();
        }

        private void MovementLogic()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            transform.Translate(movement * _data.moveSpeed * Time.fixedDeltaTime);
        }
    }
}
