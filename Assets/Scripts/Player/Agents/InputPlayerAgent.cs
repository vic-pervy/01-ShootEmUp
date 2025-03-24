using ShootEmUp;
using UnityEngine;

namespace Player.Agents
{
    public class InputPlayerAgent : MonoBehaviour, IInputListener
    {
        public void OnMoveDirection(Vector2 moveDirection)
        {
            GetComponent<MoveComponent>().MoveDirection(moveDirection);
        }

        public void OnFire(bool obj)
        {
            var weapon = GetComponent<WeaponComponent>();
            var position = weapon.Position;
            var velocity = Vector3.up;
                
            weapon.Fire(position, velocity);
        }
    }
}