using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField]
        private EnemyPositions enemyPositions;

        [SerializeField]
        private GameObject character;

        [SerializeField]
        private Transform worldTransform;

        [Header("Pool")]
        [SerializeField]
        private Transform container;

        [SerializeField]
        private GameObject prefab;

        private readonly Queue<GameObject> enemyPool = new();
        
        private void Awake()
        {
            const int POOL_SIZE = 7;
            for (var i = 0; i < POOL_SIZE; i++)
            {
                var enemy = Instantiate(this.prefab, this.container);
                this.enemyPool.Enqueue(enemy);
            }
        }

        public bool TrySpawnEnemy(out GameObject enemy)
        {
            if (!this.enemyPool.TryDequeue(out enemy))
            {
                return false;
            }

            enemy.transform.SetParent(this.worldTransform);

            var spawnPosition = this.enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            
            var attackPosition = this.enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().SetTarget(this.character);
            return true;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(this.container);
            this.enemyPool.Enqueue(enemy);
        }
    }
}