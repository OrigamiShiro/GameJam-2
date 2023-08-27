using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "Upgrade", menuName = "Data/Upgrades/UpgradeData", order = 1)]
    public class UpgradeData : ScriptableObject
    {
        [SerializeField] private string _cardName;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Sprite _effectIcon;
        [SerializeField] private UpgradeEffectData _upgradeEffect;

        public string CardName => _cardName;
        public string Description => _description;
        public Sprite Icon => _icon;
        public Sprite EffectIcon => _effectIcon;
        public UpgradeEffectData UpgradeEffect => _upgradeEffect;
    }
}