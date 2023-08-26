using UnityEngine;

namespace GameJam
{
    public abstract class Weapon : MonoBehaviour, ISpawnable
    {
        public void SetCenter()
        {
            transform.position = transform.parent.position;
        }
    }
}