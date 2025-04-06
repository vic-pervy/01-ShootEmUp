using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public sealed class EnemySpawnSystem : MonoBehaviour
    {
        [SerializeField]
        private EnemyPool enemyPool;
        
        private readonly HashSet<GameObject> activeEnemies = new();

        private IEnumerator Start()
        {
            while (true)
            {
                const float ENEMY_RESPAWN_COUNTDOWN_TIME = 1f;
                yield return new WaitForSeconds(ENEMY_RESPAWN_COUNTDOWN_TIME);
                if (this.enemyPool.TrySpawnEnemy(out var enemy))
                {
                    if (this.activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().hpEmpty += this.OnDestroyed;
                    }    
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (this.activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().hpEmpty -= this.OnDestroyed;

                this.enemyPool.UnspawnEnemy(enemy);
            }
        }

      
    }
}