using System;
using System.Collections.Generic;
using MonoBehaviours;
using MonoBehaviours.GameEntities;

namespace Repositories
{
    public class AsteroidsRepository : SingletonMonoBehaviour<AsteroidsRepository>
    {
        private List<Asteroid> _asteroids = new List<Asteroid>();
        
        public Action OnNoMoreAsteroids;
        
        public void AddAsteroid(Asteroid asteroid)
        {
            _asteroids.Add(asteroid);
        }
        
        public void RemoveAsteroid(Asteroid asteroid)
        {
            _asteroids.Remove(asteroid);
            if (_asteroids.Count == 0)
            {
                OnNoMoreAsteroids?.Invoke();
            }
        }
    }
}