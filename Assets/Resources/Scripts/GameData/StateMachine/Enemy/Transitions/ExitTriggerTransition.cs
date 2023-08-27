using GameJam;
using UnityEngine;

public class ExitTriggerTransition : Transition
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Princess>(out Princess target))
            NeedTransit = true;
    }
}
