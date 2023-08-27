using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "Potion", menuName = "Data/PotionData", order = 2)]
    public class PotionData : ScriptableObject
    {
        [SerializeField] private float _value;

        public float Value => _value;
    }
}
