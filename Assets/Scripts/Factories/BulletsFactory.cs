using UnityEngine;

namespace Factories
{
    public class BulletsFactory : SingletonMonoBehaviour<BulletsFactory>
    {
        [SerializeField] private GameObject _playerBulletPrefab;
        
        public GameObject CreatePlayerBullet(Quaternion rotation, Vector3 position)
        {
            var bullet = Instantiate(_playerBulletPrefab, position, rotation);
            return bullet;
        }
    }
}