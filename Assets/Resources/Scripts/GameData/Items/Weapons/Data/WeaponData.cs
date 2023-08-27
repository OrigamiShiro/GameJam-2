using System;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Data/Weapons/WeaponData", order = 1)]
    public class WeaponData : ScriptableObject
    {
        [field: SerializeField, Range(0, 40)] public int Damage { get; private set; }
    }
}
