using Factories;
using Interfaces;
using UnityEngine;

namespace MonoBehaviours.Weapons
{
    public class ClassicWeapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private Transform bulletSpawnPoint;

        public void Use()
        {
            Shoot();
        }
        
        private void Shoot()
        {
            BulletsFactory.Instance.CreatePlayerBullet(transform.rotation, bulletSpawnPoint.position);
        }
    }
}