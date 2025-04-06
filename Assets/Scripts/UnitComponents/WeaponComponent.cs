using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        BulletSystem bulletSystem;
        [FormerlySerializedAs("_bulletConfig")] [SerializeField] private BulletConfig bulletConfig;
        
        [SerializeField]
        private Transform firePoint;

        private bool fireRequired;
        Vector2 startPosition, direction;

        public Vector2 Position
        {
            get { return this.firePoint.position; }
        }

        public Quaternion Rotation
        {
            get { return this.firePoint.rotation; }
        }

        void Awake()
        {
            bulletSystem = FindObjectOfType<BulletSystem>();
        }

        public void Fire(Vector2 startPosition, Vector2 direction)
        {
            fireRequired = true;
            this.startPosition = startPosition;
            this.direction = direction;
        }
        
        private void FixedUpdate()
        {
            if (this.fireRequired)
            {
                this.OnFlyBullet();
                this.fireRequired = false;
            }
        }

        private void OnFlyBullet()
        {
            bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                physicsLayer = (int) this.bulletConfig.physicsLayer,
                color = this.bulletConfig.color,
                damage = this.bulletConfig.damage,
                position = startPosition,
                velocity = direction * this.bulletConfig.speed
            });
        }
    }
}