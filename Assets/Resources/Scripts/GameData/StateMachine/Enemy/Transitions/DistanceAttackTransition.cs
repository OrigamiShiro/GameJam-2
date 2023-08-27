using UnityEngine;

public class DistanceAttackTransition : Transition
{
    [SerializeField] private float _distanceFromPlayer;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) > _distanceFromPlayer)
            NeedTransit = true;
    }
}
