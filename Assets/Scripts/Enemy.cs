using UnityEngine;

namespace EnemyGeneration
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        private float _moveSpeed;
        private Vector3 _moveDirection;

        public void Setup(Vector3 direction, float speed)
        {
            _moveDirection = direction.normalized;
            _moveSpeed = speed;
        }

        private void Update()
        {
            transform.position += _moveDirection * _moveSpeed * Time.deltaTime;
        }
    }
}
