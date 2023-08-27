using System.Collections;
using UnityEngine;

namespace GameJam
{
    public class SakutinMovement : MonoBehaviour
    {
        [SerializeField] private UnitData sakutin;
        [SerializeField] private float directionChangeDelay;
        [SerializeField] private Vector3[] directions;
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private Vector3 direction;

        private void Awake()
        {
            StartCoroutine(ChangeDirection());
        }

        private IEnumerator ChangeDirection()
        {
            while (true)
            {
                yield return new WaitForSeconds(directionChangeDelay);

                direction = directions[Random.Range(0, directions.Length)];
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
                _animator.SetFloat(AnimatorSakutinController.Params.Speed, Mathf.Abs(sakutin.Speed));
                transform.Translate(direction.normalized * sakutin.Speed * Time.deltaTime);

                if (direction.x < 0)
                {
                    _spriteRenderer.flipX = true;
                }
                else if (direction.x > 0)
                {
                    _spriteRenderer.flipX = false;
                }
            }
        }
    }

    static class AnimatorSakutinController { public static class Params { public const string Speed = nameof(Speed); } }
}

