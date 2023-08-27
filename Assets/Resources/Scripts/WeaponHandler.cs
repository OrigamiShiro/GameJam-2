using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WeaponHandler : MonoBehaviour
{
    public UnityEvent OnDurabilityChanged = new();
    public UnityEvent OnBroken = new();
    [SerializeField] private WeaponScr weapon;
    [SerializeField] private float attackSpeed;
    [SerializeField] private int maxDurability;
    [SerializeField] private int durability;
    private void Awake()
    {
        if(weapon != null)
        {
            attackSpeed = weapon.AttackSpeed;
            maxDurability = weapon.Durability;
            durability = maxDurability;
        }
    }

    public void StartAttack()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        yield return null;
    }
    public void TestAttack(int damage)
    {
        Durability -= damage;
    }
    public int Durability
    {
        get => durability;
        set
        {
            durability = value;
            if(durability <= 0)
            {
                OnBroken.Invoke();
                durability = 0;
            }
            OnDurabilityChanged.Invoke();
        }
    }
    public float MaxDurability => maxDurability;
}