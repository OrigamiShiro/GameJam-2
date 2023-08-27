using UnityEngine;

public class MoveState : State
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        Vector3 direction = (Target.transform.position - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * _enemy.Speed * Time.deltaTime;

        transform.position = newPosition;
    }
}
