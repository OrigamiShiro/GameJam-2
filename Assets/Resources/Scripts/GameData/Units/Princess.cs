using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class Princess : MonoBehaviour
    {
        [SerializeField] private UnitData _data;
        private Weapon _weapon;

        public void ApplyWeapon(Weapon weapon)
        {
            _weapon = weapon;
        }
    }
}
