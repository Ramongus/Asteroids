using System;
using Enums;
using Managers;
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

        public Asteroid CreateAsteroid(AsteroidsSize size)
        {
            Asteroid asteroid = null;
            switch (size)
            {
                case AsteroidsSize.Small:
                {
                    asteroid = Instantiate(_asteroidSmallSizePrefab, _asteroidContainer.transform);
                    break;
                }
                case AsteroidsSize.Medium:
                {
                    asteroid = Instantiate(_asteroidMediumSizePrefab, _asteroidContainer.transform);
                    break;
                }
                case AsteroidsSize.Big:
                {
                    asteroid = Instantiate(_asteroidBigSizePrefab, _asteroidContainer.transform);
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
    }
}
