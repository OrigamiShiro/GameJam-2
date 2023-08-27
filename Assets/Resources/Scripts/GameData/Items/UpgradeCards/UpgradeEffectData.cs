using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "Effect", menuName = "Data/Upgrades/UpgradeEffect", order = 2)]
    public class UpgradeEffectData : ScriptableObject
    {
        public enum UpgradeId
        {
            SakutinSpeed,
            SakutinHealth,
            PlayerSpeed,
            PlayerHealth,
            WeaponRotationSpeed,
            WeaponStrength,
            WeaponDamage,
            SpawnInterval,
        }
        
        [SerializeField] private float _upgradeValue;
        [SerializeField] private UpgradeId _upgradeId;
        
        public float UpgradeValue => _upgradeValue;
        public UpgradeId UpgradeID => _upgradeId;

    }
}
