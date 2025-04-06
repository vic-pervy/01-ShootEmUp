using System;
using ShootEmUp;
using UnityEngine;

namespace Player.Agents
{
    [RequireComponent(typeof(MoveComponent), typeof(WeaponComponent))]
    public class InputPlayerAgent : MonoBehaviour
    {
        [SerializeField]
        private InputManager inputManager;
        [SerializeField]
        private MoveComponent moveComponent;
        [SerializeField]
        private WeaponComponent weaponComponent;

        private void OnValidate()
        {
            this.moveComponent = GetComponent<MoveComponent>();
            this.weaponComponent = GetComponent<WeaponComponent>();
        }

        private void OnEnable()
        {
            this.inputManager.onMove += OnMoveDirection;
            this.inputManager.onFire += OnFire;
        }

        private void OnDisable()
        {
            this.inputManager.onMove -= OnMoveDirection;
            this.inputManager.onFire -= OnFire;
        }

        public void OnMoveDirection(Vector2 moveDirection)
        {
            this.moveComponent.MoveDirection(moveDirection);
        }

        public void OnFire(bool obj)
        {
            var position = this.weaponComponent.Position;
            var velocity = Vector3.up;
                
            this.weaponComponent.Fire(position, velocity);
        }
    }
}