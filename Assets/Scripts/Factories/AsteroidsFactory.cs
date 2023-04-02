using UnityEngine;

namespace Factories
{
    public class AsteroidsFactory : MonoBehaviour
    {
        [SerializeField] private GameObject _asteroidPrefab;
        [SerializeField] private GameObject _asteroidContainer;
        
        public static AsteroidsFactory Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        public GameObject CreateAsteroid()
        {
            GameObject asteroid = Instantiate(_asteroidPrefab, _asteroidContainer.transform);
            return asteroid;
        }
    }
}
