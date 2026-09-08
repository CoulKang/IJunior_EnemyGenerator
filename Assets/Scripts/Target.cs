using UnityEngine;

namespace EnemyGeneration
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private Transform[] _wayPoints;
        [SerializeField] private float _moveSpeed;

        private int _index = 0;

        private void Update()
        {
            if (_index % _wayPoints.Length == 0)
                _index = 0;

            transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_index].position, _moveSpeed * Time.deltaTime);

            if (transform.position == _wayPoints[_index].position)
                _index++;
        }
    }
}
