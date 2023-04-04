using Enums;
using Events;
using Factories;
using Interfaces;
using Repositories;
using UnityEngine;
using Utilities;

namespace MonoBehaviours.GameEntities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour, IDamageableByBullet
    {
        [SerializeField] private float minSpeed = 1f;
        [SerializeField] private float maxSpeed = 5f;
        [SerializeField] private float minRotationSpeed = 1f;
        [SerializeField] private float maxRotationSpeed = 5f;
        [SerializeField] private bool splitOnDestroy = true;
        [SerializeField] private int splitCount = 2;
        [SerializeField] private AsteroidsSize mySize;
        [SerializeField] private AsteroidsSize splitSize;
    
        private Vector3 _direction;
        private float _speed;
        private float _rotationSpeed;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _direction = VectorUtilities.RandomDirection2D();
            _speed = Random.Range(minSpeed, maxSpeed);
            _rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = _direction * _speed;
            _rigidbody.angularVelocity = _rotationSpeed;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out IDamageableByAsteroids damageable))
            {
                damageable.TakeDamage();
            }
        }

        public void TakeDamage()
        {
            Explode();
        }

        private void Explode()
        {
            if (splitOnDestroy)
            {
                for (int i = 0; i < splitCount; i++)
                {
                    var asteroid = AsteroidsFactory.Instance.CreateAsteroid(splitSize);
                    asteroid.transform.position = transform.position;
                }
            }
            AsteroidsRepository.Instance.RemoveAsteroid(this);
            AsteroidsEvents.OnAsteroidDestroyed?.Invoke(mySize);
            Destroy(gameObject);
        }
    }
}
