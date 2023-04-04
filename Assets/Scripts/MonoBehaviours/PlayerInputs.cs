using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MonoBehaviours
{
    public class PlayerInputs : SingletonMonoBehaviour<PlayerInputs>
    {
        private GameInputs _gameInputs;
        public Action OnShootButtonPressed;

        protected override void Awake()
        {
            base.Awake();
            _gameInputs = new GameInputs();
            _gameInputs.Enable();
            _gameInputs.Player.Shoot.performed += OnShoot;
        }

        private void OnShoot(InputAction.CallbackContext obj)
        {
            OnShootButtonPressed?.Invoke();
        }

        public Vector3 GetMovementVector()
        {
            return _gameInputs.Player.Movement.ReadValue<Vector2>().normalized;
        }
    }
}