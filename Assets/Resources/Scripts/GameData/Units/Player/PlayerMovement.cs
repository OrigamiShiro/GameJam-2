using GameJam;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player _player;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    public void Move(Vector3 direction, float time)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        _spriteRenderer.flipX = horizontalInput < 0;
        
        transform.Translate(direction * _player.Speed * time);
    }
}
