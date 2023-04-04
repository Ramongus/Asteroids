using Events;
using Factories;
using Interfaces;
using UnityEngine;

namespace MonoBehaviours.GameEntities
{
    [RequireComponent(typeof(IPlayerMovementBehaviour))]
    public class Player : MonoBehaviour, IDamageableByAsteroids
    {
        [SerializeField] private Transform bulletSpawnPoint;
        
        private IPlayerMovementBehaviour _playerMovementBehaviour;

        private void Awake()
        {
            _playerMovementBehaviour = GetComponent<IPlayerMovementBehaviour>();
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
            _playerMovementBehaviour.Update();
        }

        public void TakeDamage()
        {
            Die();
        }

        private void Shoot()
        {
            BulletsFactory.Instance.CreatePlayerBullet(transform.rotation, bulletSpawnPoint.position);
        }

        private void Die()
        {
            Destroy(gameObject);
            PlayerEvents.OnPlayerDeath?.Invoke();
        }
    }
}