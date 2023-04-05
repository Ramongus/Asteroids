using Interfaces;
using UnityEngine;

namespace MonoBehaviours.PlayerMovementBehaviours
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ClassicPlayerMovementBehaviour : MonoBehaviour, IPlayerMovementBehaviour
    {
        [SerializeField] private float rotationSpeed = 90f;
        [SerializeField] private float thrustersForce = 10f;
        [SerializeField] private float maxVelocity = 10f;
        
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void UpdateMovement(Vector3 direction)
        {
            MoveForward(direction);
            Rotate(direction);
        }

        private void MoveForward(Vector3 direction)
        {
            if (direction.y > 0)
            {
                _rigidbody2D.AddForce(transform.right * thrustersForce);
            }
            ClampVelocity();
        }

        private void ClampVelocity()
        {
            var velocity = _rigidbody2D.velocity;
            if (velocity.magnitude > maxVelocity)
            {
                _rigidbody2D.velocity = velocity.normalized * maxVelocity;
            }
        }

        private void Rotate(Vector3 direction)
        {
            if (direction.x > 0f)
            {
                _rigidbody2D.angularVelocity = rotationSpeed * -1;
            }
            else if (direction.x < 0f)
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