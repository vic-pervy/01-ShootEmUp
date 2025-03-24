using UnityEngine;

namespace ShootEmUp
{
    internal static class BulletUtils
    {
        internal static void DealDamage(Bullet bullet, GameObject other)
        {
            if (IsSameTeam(bullet.gameObject, other))
            {
                return;
            }

            if (other.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(bullet.damage);
            }
        }

        public static bool IsSameTeam(GameObject bullet, GameObject other)
        {
            switch (bullet.gameObject.layer)
            {
                case (int)PhysicsLayer.PLAYER when other.layer == (int)PhysicsLayer.PLAYER_BULLET:
                case (int)PhysicsLayer.ENEMY when other.layer == (int)PhysicsLayer.ENEMY_BULLET:
                    return true;
                default:
                    return false;
            }
        }
    }
}