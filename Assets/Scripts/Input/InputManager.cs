using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        public Action<Vector2> onMove;
        public Action<bool> onFire;

        private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // foreach (var listener in listeners)
                //     listener.GetComponent<IInputListener>().OnFire(true);
                this.onFire?.Invoke(true);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                // foreach (var listener in listeners)
                //     listener.GetComponent<IInputListener>().OnMoveDirection(new Vector2(-1, 0));
                this.onMove?.Invoke(Vector2.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                // foreach (var listener in listeners)
                //     listener.GetComponent<IInputListener>().OnMoveDirection(new Vector2(1, 0));
                this.onMove?.Invoke(Vector2.right);
            }
            else
            {
                // foreach (var listener in listeners)
                //     listener.GetComponent<IInputListener>().OnMoveDirection(Vector2.zero);
                this.onMove?.Invoke(Vector2.zero);
            }
        }
        /*
        private void FixedUpdate()
        {
            this.character.GetComponent<MoveComponent>().MoveByRigidbodyVelocity(new Vector2(this.HorizontalDirection, 0) * Time.fixedDeltaTime);
        }*/
    }
}