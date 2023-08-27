using GameJam;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    public void Move(Vector3 direction, float time)
    {
        transform.Translate(direction * _player.Speed * time);
    }
}
