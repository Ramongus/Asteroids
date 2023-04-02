using Managers;
using UnityEngine;

namespace Factories
{
    public class AsteroidsFactory : SingletonMonoBehaviour<AsteroidsFactory>
    {
        [SerializeField] private GameObject _asteroidPrefab;
        [SerializeField] private GameObject _asteroidContainer;

        public GameObject CreateAsteroid()
        {
            GameObject asteroid = Instantiate(_asteroidPrefab, _asteroidContainer.transform);
            asteroid.transform.position = WorldBoundsManager.Instance.RandomWorldEdgePosition();
            return asteroid;
        }
    }
}
