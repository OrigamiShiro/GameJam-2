using UnityEngine;

public class DistanceMoveTransition : Transition
{
    [SerializeField] private float _distanceFromTarget;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _distanceFromTarget)
            NeedTransit = true;
    }
}
