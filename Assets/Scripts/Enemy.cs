using UnityEngine;

namespace EnemyGeneration
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        private Target _target;
        private float _moveSpeed;

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _moveSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Target>() == false)
                return;

            Destroy(gameObject);
        }

        public void Setup(Target target, float speed)
        {
            _target = target;
            _moveSpeed = speed;
        }
    }
}
