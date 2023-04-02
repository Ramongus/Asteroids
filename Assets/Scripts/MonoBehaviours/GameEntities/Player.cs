using System;
using UnityEngine;

namespace MonoBehaviours.GameEntities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInputs playerInputs;
        [SerializeField] private float rotationSpeed = 1f;
        
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Rotate();
            playerInputs.GetMovementVector();
        }

        private void Rotate()
        {
            var playerDirection = playerInputs.GetMovementVector();
            if (playerDirection.x > 0f)
            {
                _rigidbody2D.angularVelocity = rotationSpeed;
            }
            else if (playerDirection.x < 0f)
            {
                _rigidbody2D.angularVelocity = rotationSpeed * -1;
            }
        }
    }
}