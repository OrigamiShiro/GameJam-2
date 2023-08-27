using UnityEngine;

public class MovementInput : MonoBehaviour
{
    protected bool _isActive;

    public bool IsActive => _isActive;

    public void Activate()
    {
        _isActive = true;
    }

    public void Deactivate()
    {
        _isActive = false;
    }
}
