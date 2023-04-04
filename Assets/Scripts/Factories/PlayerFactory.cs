using MonoBehaviours;
using UnityEngine;

namespace Factories
{
    public class PlayerFactory : SingletonMonoBehaviour<PlayerFactory>
    {
        [SerializeField] private GameObject _playerPrefab;
        
        public GameObject CreatePlayer()
        {
            return Instantiate(_playerPrefab);
        }
    }
}