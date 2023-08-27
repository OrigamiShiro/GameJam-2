using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "Unit", menuName = "Data/UnitData", order = 2)]
    public class UnitData : ScriptableObject
    {
        [field: SerializeField, Range(0, 40)] public float Health { get; private set; }
        [field: SerializeField, Range(0, 20)] public float Speed { get; private set; }
    }
}
