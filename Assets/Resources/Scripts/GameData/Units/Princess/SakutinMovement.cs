using System.Collections;
using UnityEngine;

namespace GameJam
{
    public class SakutinMovement : MonoBehaviour
    {
        [SerializeField] private UnitData sakutin;
        [SerializeField] private float directionChangeDelay;
        [SerializeField] private Vector3[] directions;
        private Vector3 direction;

        private void Awake()
        {
            StartCoroutine(ChangeDirection());
        }
        private IEnumerator ChangeDirection()
        {
            while (true)
            {
                direction = directions[Random.Range(0, directions.Length)];
                yield return new WaitForSeconds(directionChangeDelay);
            }
        }
        private void FixedUpdate()
        {
            MovementLogic();
        }

        private void MovementLogic()
        {
            if (direction.normalized != Vector3.zero)
            {
                transform.Translate(direction.normalized * sakutin.Speed * Time.deltaTime);
            }
        }
    }
}

