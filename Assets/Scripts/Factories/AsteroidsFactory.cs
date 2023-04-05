using System;
using DefaultNamespace;
using Enums;
using MonoBehaviours;
using MonoBehaviours.GameEntities;
using Repositories;
using UnityEngine;

namespace Factories
{
    public class AsteroidsFactory : SingletonMonoBehaviour<AsteroidsFactory>
    {
        [SerializeField] private Asteroid _asteroidSmallSizePrefab;
        [SerializeField] private Asteroid _asteroidMediumSizePrefab;
        [SerializeField] private Asteroid _asteroidBigSizePrefab;
        [SerializeField] private GameObject _asteroidContainer;
        private ObjectPool<Asteroid> _smallAsteroidsPool;
        private ObjectPool<Asteroid> _mediumAsteroidsPool;
        private ObjectPool<Asteroid> _bigAsteroidsPool;

        private void Start()
        {
            _smallAsteroidsPool = new ObjectPool<Asteroid>(40, CreateSmallAsteroid);
            _mediumAsteroidsPool = new ObjectPool<Asteroid>(20, CreateMediumAsteroid);
            _bigAsteroidsPool = new ObjectPool<Asteroid>(10, CreateBigAsteroid);
        }

        public Asteroid CreateAsteroid(AsteroidsSize size)
        {
            Asteroid asteroid = null;
            switch (size)
            {
                case AsteroidsSize.Small:
                {
                    asteroid = _smallAsteroidsPool.GetObject();
                    break;
                }
                case AsteroidsSize.Medium:
                {
                    asteroid = _mediumAsteroidsPool.GetObject();
                    break;
                }
                case AsteroidsSize.Big:
                {
                    asteroid = _bigAsteroidsPool.GetObject();
                    break;
                }
                default:
                {
                    throw new Exception("No asteroid size found");
                }
            }
            AsteroidsRepository.Instance.AddAsteroid(asteroid);
            return asteroid;
        }

        private Asteroid CreateSmallAsteroid()
        {
            Asteroid asteroid = Instantiate(_asteroidSmallSizePrefab, _asteroidContainer.transform);
            return asteroid;
        }

        private Asteroid CreateMediumAsteroid()
        {
            Asteroid asteroid = Instantiate(_asteroidMediumSizePrefab, _asteroidContainer.transform);
            return asteroid;
        }

        private Asteroid CreateBigAsteroid()
        {
            Asteroid asteroid = Instantiate(_asteroidBigSizePrefab, _asteroidContainer.transform);
            return asteroid;
        }
    }
}
