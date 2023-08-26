using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class Princess : MonoBehaviour
    {
        [SerializeField] private UnitData _data;
        private BaseWeapon _weapon;

        public void ApplyWeapon(BaseWeapon weapon)
        {
            _weapon = weapon;
        }
    }
}
