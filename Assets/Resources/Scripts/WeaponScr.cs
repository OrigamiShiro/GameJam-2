using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScr", menuName = "ScriptableObjects/WeaponScr")]
public class WeaponScr : ScriptableObject
{
    [SerializeField] public float AttackSpeed { get; private set; }
    [SerializeField] public int Durability { get; private set; }
} 