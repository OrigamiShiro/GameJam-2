using System;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "Unit", menuName = "Data/UnitData", order = 2)]
    [Serializable]
    public class UnitData : ScriptableObject
    {
        public float health;
        public float moveSpeed;
    }
}
