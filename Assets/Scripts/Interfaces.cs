using UnityEngine;

namespace ShootEmUp
{
    public interface IInputListener
    {
        public void OnMoveDirection(Vector2 moveDirection);
        public void OnFire(bool isFire);
    }
}