using GameJam;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    [SerializeField] private Offset _currentOffset;
    [SerializeField] private Player _followTarget;

    private void FixedUpdate()
    {
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        Vector3 targetPosition = _followTarget.transform.position + _currentOffset.Value;

        transform.position = targetPosition;
    }
}

[System.Serializable]
public class Offset
{
    public Vector3 Value;
}