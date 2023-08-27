using GameJam;
using UnityEngine;

public class WeaponSpinner : MonoBehaviour
{
    [SerializeField] private Princess _rotationTarget;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _distance;

    private Vector2 _rotationCenter;
    private Transform _rotableObject;
    private float _angle;
    private float _rotationSpeed;

    private void Start()
    {
        _rotationSpeed = 4f;
        _rotableObject = _weapon.transform;
        _rotationCenter = _rotationTarget.transform.position;
    }

    private void FixedUpdate()
    {
        _angle += _rotationSpeed * Time.deltaTime;
        Vector2 position = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * _distance;

        Move(position);
    }

    public void Move(Vector2 direction)
    {
        _rotableObject.position = _rotationCenter + direction;
    }
}
