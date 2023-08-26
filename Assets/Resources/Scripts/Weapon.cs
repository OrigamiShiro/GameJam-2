using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private int durability;
    public float Speed => speed;
    public int Durability => durability;
} 