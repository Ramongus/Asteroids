using Enums;
using Events;
using Factories;
using Managers;
using Repositories;
using ScriptableObjects;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Waves settings")]
    [SerializeField] private WavesConfigurationSO wavesConfiguration;
    
    [Header("Score settings")]
    [SerializeField] private ScoreUI scoreUI;
    [SerializeField] private ScoreConfigurationSO scoreConfiguration;
    
    private int _currentWave = 0;
    private ScoreSystem _scoreSystem;
    private WaveSystem _waveSystem;

    private void Awake()
    {
        _scoreSystem = new ScoreSystem(scoreUI, scoreConfiguration);
        _waveSystem = new WaveSystem(wavesConfiguration);
    }

    private void Start()
    {
        SpawnPlayer();
        _waveSystem.AdvanceToNextWave();
        PlayerEvents.OnPlayerDeath += OnPlayerDeath;
        AsteroidsRepository.Instance.OnNoMoreAsteroids += NextWave;
        AsteroidsEvents.OnAsteroidDestroyed += OnAsteroidDestroyed;
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
        _scoreSystem.UpdateScore(asteroidsSize);
    }
    
    private void NextWave()
    {
        _waveSystem.AdvanceToNextWave();
    }
}

public class WaveSystem
{
    private int _currentWave;
    private readonly WavesConfigurationSO _wavesConfiguration;

    public WaveSystem(WavesConfigurationSO wavesConfiguration)
    {
        _wavesConfiguration = wavesConfiguration;
    }

    public void AdvanceToNextWave()
    {
        _currentWave++;
        for (int i = 0; i < _wavesConfiguration.FirstWaveAsteroidsCount + _wavesConfiguration.ExtraAsteroidsPerWave * (_currentWave - 1); i++)
        {
            var asteroid = AsteroidsFactory.Instance.CreateAsteroid(AsteroidsSize.Big);
            asteroid.transform.position = WorldBoundsManager.Instance.RandomWorldEdgePosition();
        }
    }
}