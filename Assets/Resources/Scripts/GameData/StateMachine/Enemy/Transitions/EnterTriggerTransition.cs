using GameJam;
using UnityEngine;

public class EnterTriggerTransition : Transition
{
    [SerializeField] private float _distanceFromTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Princess>(out Princess target))
            NeedTransit = true;
    }
}
