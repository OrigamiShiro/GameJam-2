using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public static class DataContainer
    {
        private static Player _player => Object.FindObjectOfType<Player>();
        public static UnitData PlayerData { get; private set; }

        public static void SavePlayerData()
        {
            PlayerData = _player.Data;
        }

    }
}
