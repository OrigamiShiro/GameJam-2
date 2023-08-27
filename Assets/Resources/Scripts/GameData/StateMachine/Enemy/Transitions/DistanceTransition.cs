using UnityEngine;
using GameJam;

public class DistanceTransition : Transition
{
    [SerializeField] private float _distanceFromPlayer;

    private Transform _targetPosition;

    private void Awake()
    {
        _targetPosition = FindObjectOfType<Princess>().transform;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _targetPosition.position) < _distanceFromPlayer)
            NeedTransit = true;
    }
}
