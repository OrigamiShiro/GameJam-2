using UnityEngine;

namespace GameJam
{
    public abstract class Weapon : MonoBehaviour, ISpawnable, IPickable
    {
        private void SetScale()
        {
            var newScaleSize = 0.4f;

            transform.localScale = new Vector3(newScaleSize, newScaleSize, newScaleSize);
        }

        public void GetPicked()
        {
            SetScale();
            transform.position = transform.parent.position;
        }
    }
}