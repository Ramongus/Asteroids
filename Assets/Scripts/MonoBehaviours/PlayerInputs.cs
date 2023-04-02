using System;
using Factories;
using UnityEngine;

namespace MonoBehaviours
{
    public class PlayerInputs : SingletonMonoBehaviour<PlayerInputs>
    {
        private GameInputs _gameInputs;

        protected override void Awake()
        {
            base.Awake();
            _gameInputs = new GameInputs();
            _gameInputs.Enable();
        }

        public Vector3 GetMovementVector()
        {
            return _gameInputs.Player.Movement.ReadValue<Vector2>().normalized;
        }
    }
}