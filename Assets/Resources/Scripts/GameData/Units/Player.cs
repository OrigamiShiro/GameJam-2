using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private UnitData _data;
        public UnitData Data => _data;

        private void Awake()
        {
            if (DataContainer.PlayerData != null)
                _data = DataContainer.PlayerData;
        }
    }
}
