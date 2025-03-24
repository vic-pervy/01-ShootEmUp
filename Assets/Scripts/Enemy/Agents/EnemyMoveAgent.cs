using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public bool IsReached
        {
            get { return this.isReached; }
        }

        [SerializeField] private MoveComponent moveComponent;

        private Vector2 destination;

        private bool isReached;

        public void SetDestination(Vector2 endPoint)
        {
            this.destination = endPoint;
            this.isReached = false;
        }

        private void FixedUpdate()
        {
            if (this.isReached)
            {
                return;
            }
            
            var vector = this.destination - (Vector2) this.transform.position;
            if (vector.magnitude <= 0.25f)
            {
                this.isReached = true;
                this.moveComponent.MoveDirection(Vector2.zero);
                return;
            }

            var n = vector.normalized;
            var magnitude = Math.Max(vector.magnitude, 1);
            this.moveComponent.MoveDirection(n * magnitude);
        }
    }
}