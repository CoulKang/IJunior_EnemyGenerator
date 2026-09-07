using System.Collections;
using UnityEngine;

namespace EnemyGeneration
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Transform[] _spawnPoints;

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
            bool isWork = true;

            while (isWork)
            {
                yield return new WaitForSeconds(delay);

                Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

                Enemy newEnemy = Instantiate(_enemyPrefab, spawnPoint.position, Quaternion.identity);

                newEnemy.Setup(_moveDirection, _moveSpeed);
            }
        }
    }
}
