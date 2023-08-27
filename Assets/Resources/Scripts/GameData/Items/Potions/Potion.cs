using UnityEngine;

namespace GameJam
{
    public class Potion : MonoBehaviour, ISpawnable, IPickable
    {
        [SerializeField] private PotionData _potionData;
        public float PotionValue => _potionData.Value;
        
        private void SetScale()
        {
            var newScaleSize = 0.6f;

            transform.localScale = new Vector3(newScaleSize, newScaleSize, newScaleSize);
        }
        
        public void GetPicked()
        {
            SetScale();
            transform.position = transform.parent.position;
        }
    }
}
