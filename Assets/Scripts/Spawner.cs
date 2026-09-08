using System.Collections;
using UnityEngine;

namespace EnemyGeneration
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private SpawnPointData[] _spawnPoints;

        [Space(10)]
        [SerializeField, Min(0)] private float _moveSpeed;
        [SerializeField, Min(0)] private float _spawnDelay;
        [SerializeField] private Vector3 _moveDirection;

        private Coroutine _spawnCoruntine;

        private void Start()
        {
            if (_spawnCoruntine == null)
                _spawnCoruntine = StartCoroutine(SpawnEnemies(_spawnDelay));
        }

        private IEnumerator SpawnEnemies(float delay)
        {
            var wait = new WaitForSeconds(delay);
            bool isWork = true;

            while (isWork)
            {
                yield return wait;

                SpawnPointData spawnData = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

                Enemy newEnemy = Instantiate(spawnData.Enemy, spawnData.Point.position, Quaternion.identity);

                newEnemy.Setup(spawnData.Target, _moveSpeed);
            }
        }
    }

    [System.Serializable]
    public class SpawnPointData
    {
        [SerializeField] private Transform _point;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Target _target;

        public Transform Point => _point;
        public Enemy Enemy => _enemy;
        public Target Target => _target;
    }
}
