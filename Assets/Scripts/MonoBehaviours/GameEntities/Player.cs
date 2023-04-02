using System;
using UnityEngine;

namespace MonoBehaviours.GameEntities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInputs playerInputs;
        [SerializeField] private float rotationSpeed = 90f;
        
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            var playerDirection = playerInputs.GetMovementVector();
            if (playerDirection.x > 0f)
            {
                _rigidbody2D.angularVelocity = rotationSpeed * -1;
            }
            else if (playerDirection.x < 0f)
            {
                _rigidbody2D.angularVelocity = rotationSpeed;
            }
            else
            {
                _rigidbody2D.angularVelocity = 0f;
            }
        }
    }
}