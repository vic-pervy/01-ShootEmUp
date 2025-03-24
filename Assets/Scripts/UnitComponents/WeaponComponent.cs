using UnityEngine;

namespace ShootEmUp
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;
        
        [SerializeField]
        private Transform firePoint;

        private bool _fireRequired;
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
            _bulletSystem = FindObjectOfType<BulletSystem>();
        }

        public void Fire(Vector2 startPosition, Vector2 direction)
        {
            _fireRequired = true;
            this.startPosition = startPosition;
            this.direction = direction;
        }
        
        private void FixedUpdate()
        {
            if (this._fireRequired)
            {
                this.OnFlyBullet();
                this._fireRequired = false;
            }
        }

        private void OnFlyBullet()
        {
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                physicsLayer = (int) this._bulletConfig.physicsLayer,
                color = this._bulletConfig.color,
                damage = this._bulletConfig.damage,
                position = startPosition,
                velocity = direction * this._bulletConfig.speed
            });
        }
    }
}