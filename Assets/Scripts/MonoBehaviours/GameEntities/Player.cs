using System;
using Events;
using Factories;
using Interfaces;
using UnityEngine;

namespace MonoBehaviours.GameEntities
{
    [RequireComponent(typeof(IPlayerMovementBehaviour), typeof(IWeapon))]
    public class Player : MonoBehaviour, IDamageableByAsteroids
    {
        private IPlayerMovementBehaviour _playerMovementBehaviour;
        private IWeapon _weapon;
        private Vector3 _playerMovementDirection;

        private void Awake()
        {
            _playerMovementBehaviour = GetComponent<IPlayerMovementBehaviour>();
            _weapon = GetComponent<IWeapon>();
        }
        
        private void Start()
        {
            PlayerInputs.Instance.OnShootButtonPressed += UseWeapon;
        }

        private void OnDestroy()
        {
            PlayerInputs.Instance.OnShootButtonPressed -= UseWeapon;
        }


        private void Update()
        {
            _playerMovementDirection = PlayerInputs.Instance.GetMovementVector();
        }

        private void FixedUpdate()
        {
            _playerMovementBehaviour.UpdateMovement(_playerMovementDirection);
        }

        public void TakeDamage()
        {
            Die();
        }

        private void UseWeapon()
        {
            _weapon.Use();
        }

        private void Die()
        {
            Destroy(gameObject);
            PlayerEvents.OnPlayerDeath?.Invoke();
        }
    }
}