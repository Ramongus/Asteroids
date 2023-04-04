using Events;
using Factories;
using UnityEngine;

namespace MonoBehaviours.GameEntities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 90f;
        [SerializeField] private float thrustersForce = 10f;
        [SerializeField] private float maxVelocity = 10f;
        [SerializeField] private Transform bulletSpawnPoint;
        
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            PlayerInputs.Instance.OnShootButtonPressed += Shoot;
        }
        
        private void OnDestroy()
        {
            PlayerInputs.Instance.OnShootButtonPressed -= Shoot;
        }

        private void Update()
        {
            MoveForward();
            Rotate();
        }

        private void MoveForward()
        {
            var playerDirection = PlayerInputs.Instance.GetMovementVector();
            if (playerDirection.y > 0)
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

        private void Rotate()
        {
            var playerDirection = PlayerInputs.Instance.GetMovementVector();
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

        private void Shoot()
        {
            BulletsFactory.Instance.CreatePlayerBullet(transform.rotation, bulletSpawnPoint.position);
        }

        public void Die()
        {
            Destroy(gameObject);
            PlayerEvents.OnPlayerDeath?.Invoke();
        }
    }
}