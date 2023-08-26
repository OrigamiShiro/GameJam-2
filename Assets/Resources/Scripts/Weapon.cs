using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private int durability;
    public float AttackSpeed => attackSpeed;
    public int Durability => durability;
} 