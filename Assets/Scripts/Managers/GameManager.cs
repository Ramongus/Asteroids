using Enums;
using Events;
using Factories;
using Managers;
using Repositories;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Waves settings")]
    [SerializeField] private int initialAsteroids = 4;
    [SerializeField] private int extraAsteroidsPerWave = 2;
    
    [Header("Score settings")]
    [SerializeField] private ScoreUI scoreUI;
    [SerializeField] private int smallAsteroidScore = 3;
    [SerializeField] private int mediumAsteroidScore = 2;
    [SerializeField] private int bigAsteroidScore = 1;
    
    private int _currentWave = 0;
    private int _currentScore = 0;

    private void Start()
    {
        SpawnAsteroids();
        SpawnPlayer();
        PlayerEvents.OnPlayerDeath += OnPlayerDeath;
        AsteroidsRepository.Instance.OnNoMoreAsteroids += NextWave;
        AsteroidsEvents.OnAsteroidDestroyed += OnAsteroidDestroyed;
        scoreUI.UpdateScore(_currentScore);
    }

    private void OnDestroy()
    {
        PlayerEvents.OnPlayerDeath -= OnPlayerDeath;
        AsteroidsRepository.Instance.OnNoMoreAsteroids -= NextWave;
        AsteroidsEvents.OnAsteroidDestroyed -= OnAsteroidDestroyed;
    }

    private void SpawnPlayer()
    {
        PlayerFactory.Instance.CreatePlayer();
    }

    private void OnPlayerDeath()
    {
        Debug.Log("Player died,  Imma respawn him");
    }

    private void OnAsteroidDestroyed(AsteroidsSize asteroidsSize)
    {
        switch (asteroidsSize)
        {
            case AsteroidsSize.Small:
                _currentScore += smallAsteroidScore;
                break;
            case AsteroidsSize.Medium:
                _currentScore += mediumAsteroidScore;
                break;
            case AsteroidsSize.Big:
                _currentScore += bigAsteroidScore;
                break;
        }
        scoreUI.UpdateScore(_currentScore);
    }

    private void SpawnAsteroids()
    {
        for (int i = 0; i < initialAsteroids + extraAsteroidsPerWave * _currentWave; i++)
        {
            var asteroid = AsteroidsFactory.Instance.CreateAsteroid(AsteroidsSize.Big);
            asteroid.transform.position = WorldBoundsManager.Instance.RandomWorldEdgePosition();
        }
    }

    private void NextWave()
    {
        Debug.Log("Next wave!");
        _currentWave++;
        SpawnAsteroids();
    }
}

