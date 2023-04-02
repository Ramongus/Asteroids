using Enums;
using Events;
using Factories;
using Managers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int initialAsteroids = 4;
    [SerializeField] private int extraAsteroidsPerWave = 2;
    
    private int _currentWave = 0;

    private void Start()
    {
        SpawnAsteroids();
        SpawnPlayer();
        PlayerEvents.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDestroy()
    {
        PlayerEvents.OnPlayerDeath -= OnPlayerDeath;
    }

    private void SpawnPlayer()
    {
        PlayerFactory.Instance.CreatePlayer();
    }

    private void OnPlayerDeath()
    {
        Debug.Log("Player died,  Imma respawn him");
    }

    private void SpawnAsteroids()
    {
        for (int i = 0; i < initialAsteroids + extraAsteroidsPerWave * _currentWave; i++)
        {
            var asteroid = AsteroidsFactory.Instance.CreateAsteroid(AsteroidsSize.Big);
            asteroid.transform.position = WorldBoundsManager.Instance.RandomWorldEdgePosition();
        }
    }
}

