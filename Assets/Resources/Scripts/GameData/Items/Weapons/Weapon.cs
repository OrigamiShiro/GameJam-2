using UnityEngine;

namespace GameJam
{
    public abstract class Weapon : MonoBehaviour, ISpawnable, IPickable
    {
        public void SetScale()
        {
            var newScaleSize = 0.4f;

            transform.localScale = new Vector3(newScaleSize, newScaleSize, newScaleSize);
        }

        public void SetPosition()
        {
        }
    }
}