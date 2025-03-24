using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        public GameObject[] listeners;

        private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (var listener in listeners)
                    listener.GetComponent<IInputListener>().OnFire(true);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                foreach (var listener in listeners)
                    listener.GetComponent<IInputListener>().OnMoveDirection(new Vector2(-1, 0));
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                foreach (var listener in listeners)
                    listener.GetComponent<IInputListener>().OnMoveDirection(new Vector2(1, 0));
            }
            else
            {
                foreach (var listener in listeners)
                    listener.GetComponent<IInputListener>().OnMoveDirection(Vector2.zero);
            }
        }
        /*
        private void FixedUpdate()
        {
            this.character.GetComponent<MoveComponent>().MoveByRigidbodyVelocity(new Vector2(this.HorizontalDirection, 0) * Time.fixedDeltaTime);
        }*/
    }
}