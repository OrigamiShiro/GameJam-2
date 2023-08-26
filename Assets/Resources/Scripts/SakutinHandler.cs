using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SakutinHandler : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent OnGameOver = new();
    public UnityEvent OnHpChanged = new();
    public UnityEvent OnHealed = new();
    public UnityEvent OnAttacked = new();
    [Header("Stats")]
    [SerializeField] private Sakutin sakutin;
    [SerializeField] private float speed;
    [SerializeField] private float changeCooldown;
    [SerializeField] private int hp;
    [SerializeField] private int maxHp;
    [Header("UI Images")]
    [SerializeField] private Image hpBar;
    [SerializeField] private Image durabilityBar;
    [Header("Directions")]
    [SerializeField] private Vector3[] directions;
    private Animator anim;
    private WeaponHandler weapon;
    private Vector3 direction;

    private void Awake()
    {
        if(sakutin != null)
        {
            maxHp = sakutin.Hp;
            hp = maxHp;
            speed = sakutin.Speed;
        }
        anim = GetComponent<Animator>();
        StartCoroutine(ChangeDirection());
        OnHpChanged.AddListener(() => { hpBar.fillAmount = (float)hp / maxHp; });
        OnHpChanged.Invoke();
        weapon = GetComponent<WeaponHandler>();
        weapon.OnDurabilityChanged.AddListener(() =>
        {
            if(weapon != null)
            {
                durabilityBar.fillAmount = weapon.Durability / weapon.MaxDurability;
            }
        });
        weapon.OnDurabilityChanged.Invoke();
        weapon.OnBroken.AddListener(() => 
        {
            weapon = null; 
            durabilityBar.fillAmount = 0f;
        });
    }


    private IEnumerator ChangeDirection()
    {
        while(true)
        {
            yield return new WaitForSeconds(changeCooldown);
            direction = directions[Random.Range(0, directions.Length)];
        }
    }
    private void Update()
    {
        if(direction.normalized != Vector3.zero)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }
    public void OffRight()
    {
        anim.SetBool("Right", false);
    }
    public void OffLeft()
    {
        anim.SetBool("Left", false);
    }
    public void SetWeapon(WeaponHandler weapon)
    {
        this.weapon = weapon;
        this.weapon.OnDurabilityChanged.AddListener(() => 
        {
            durabilityBar.fillAmount = this.weapon.Durability / this.weapon.MaxDurability;
        });
        this.weapon.OnDurabilityChanged.Invoke();
        this.weapon.OnBroken.AddListener(() => { this.weapon = null; });
        this.weapon.StartAttack();
    }
    public void Attack(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            OnGameOver.Invoke();
            hp = 0;
        }
        OnHpChanged.Invoke();
        OnAttacked.Invoke();
    }
    public void Heal(int heal)
    {
        hp += heal;
        if(hp >= maxHp)
        {
            hp = maxHp;
        }
        OnHpChanged.Invoke();
        OnHealed.Invoke();
    }
}
