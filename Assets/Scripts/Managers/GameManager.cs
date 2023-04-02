using Factories;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int initialAsteroids = 4;
    [SerializeField] private int extraAsteroidsPerWave = 2;
    
    private int _currentWave = 0;

    private void Start()
    {
        SpawnAsteroids();
    }

    private void SpawnAsteroids()
    {
        for (int i = 0; i < initialAsteroids + extraAsteroidsPerWave * _currentWave; i++)
        {
            var asteroid = AsteroidsFactory.Instance.CreateAsteroid();
            asteroid.transform.position = Random.insideUnitCircle * 5f;
        }
    }
}

