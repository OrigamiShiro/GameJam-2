using UnityEngine;

public class PlayerMovementInput : MovementInput
{
    [SerializeField] private PlayerMovement _movement;

    private void FixedUpdate()
    {
        if (IsActive == false)
            return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _movement.Move(movement, Time.fixedDeltaTime);
    }
}
