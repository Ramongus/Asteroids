using System;
using Enums;
using Managers;
using UnityEngine;

namespace Factories
{
    public class AsteroidsFactory : SingletonMonoBehaviour<AsteroidsFactory>
    {
        [SerializeField] private GameObject _asteroidSmallSizePrefab;
        [SerializeField] private GameObject _asteroidMediumSizePrefab;
        [SerializeField] private GameObject _asteroidBigSizePrefab;
        [SerializeField] private GameObject _asteroidContainer;

        public GameObject CreateAsteroid(AsteroidsSize size)
        {
            GameObject asteroid = null;
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
            return asteroid;
        }
    }
}
