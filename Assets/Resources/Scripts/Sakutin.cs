using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Sakutin", fileName = "Sakutin")]
class Sakutin : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private int hp;
    public float Speed => speed;
    public int Hp => hp;
}