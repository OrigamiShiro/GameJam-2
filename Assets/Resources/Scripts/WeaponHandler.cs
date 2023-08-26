using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WeaponHandler : MonoBehaviour
{
    public UnityEvent OnDurabilityChanged = new();
    public UnityEvent OnBroken = new();
    [SerializeField] private Weapon weapon;
    [SerializeField] private float speed;
    [SerializeField] private float maxDurability;
    [SerializeField] private float durability;
    private void Awake()
    {
        if(weapon != null)
        {
            speed = weapon.Speed;
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
    public float Durability
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