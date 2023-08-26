using GameJam;
using UnityEngine;

public class SceneRoot : MonoBehaviour
{
    [Header("Scene configurations")]
    [SerializeField] private Player _player;
    [SerializeField] private WeaponSpawner _weaponsSpawner;

    private void Start()
    {
        _weaponsSpawner.Init();
    }
}