using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        // public delegate void FireHandler(GameObject enemy, Vector2 position, Vector2 direction);
        //
        // public event FireHandler OnFire;

        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField] private float countdown;

        private HitPointsComponent target;
        private float currentTime;

        public void SetTarget(GameObject target)
        {
            this.target = target.GetComponent<HitPointsComponent>();
        }

        public void Reset()
        {
            this.currentTime = this.countdown;
        }

        private void FixedUpdate()
        {
            if (!this.moveAgent.IsReached || !this.target)
            {
                return;
            }
            
            if (!this.target.IsHitPointsExists())
            {
                return;
            }

            this.currentTime -= Time.fixedDeltaTime;
            if (this.currentTime <= 0)
            {
                Fire();
                this.currentTime += this.countdown;
            }
        }

        private void Fire()
        {
            var startPosition = this.weaponComponent.Position;
            var vector = (Vector2) this.target.transform.position - startPosition;
            var direction = vector.normalized;
            //this.OnFire?.Invoke(this.gameObject, startPosition, direction);
            
            weaponComponent.Fire(startPosition, direction);
        }
    }
}