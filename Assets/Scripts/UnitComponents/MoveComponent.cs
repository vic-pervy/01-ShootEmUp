using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private new Rigidbody2D rigidbody2D;

        [SerializeField]
        private float speed = 5.0f;
        
        private Vector2 velocity;
        
        public void MoveDirection(Vector2 direction)
        {
            velocity = direction;
        }

        public void MoveToPoint(Vector2 point)
        {
            
        }

        private void FixedUpdate()
        {
            var nextPosition = this.rigidbody2D.position + velocity * (Time.fixedDeltaTime * this.speed);
            this.rigidbody2D.MovePosition(nextPosition);
        }
    }
}