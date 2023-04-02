using System;
using UnityEngine;

namespace MonoBehaviours
{
    public class PlayerInputs : MonoBehaviour
    {
        private GameInputs _gameInputs;

        private void Awake()
        {
            _gameInputs = new GameInputs();
            _gameInputs.Enable();
        }

        public Vector3 GetMovementVector()
        {
            return _gameInputs.Player.Movement.ReadValue<Vector2>().normalized;
        }
    }
}