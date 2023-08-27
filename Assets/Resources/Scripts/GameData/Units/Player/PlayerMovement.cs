using GameJam;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    public void Move(Vector3 direction, float time)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        _spriteRenderer.flipX = horizontalInput < 0;
        
        _animator.SetFloat(AnimatorPlayerController.Params.Speed, Mathf.Abs(horizontalInput));
        transform.Translate(direction * _player.Speed * time);
    }

    private static class AnimatorPlayerController { public static class Params { public const string Speed = nameof(Speed); } }
}
