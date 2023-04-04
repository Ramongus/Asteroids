using Enums;
using Events;
using Factories;
using Repositories;
using ScriptableObjects;
using Systems;
using UI;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Countdown settings")]
        [SerializeField] private RespawnUI respawnUI;
        [SerializeField] private RespawnConfigurationSO respawnConfiguration;
    
        [Header("Waves settings")]
        [SerializeField] private WavesConfigurationSO wavesConfiguration;
    
        [Header("Score settings")]
        [SerializeField] private ScoreUI scoreUI;
        [SerializeField] private ScoreConfigurationSO scoreConfiguration;
    
        private ScoreSystem _scoreSystem;
        private WaveSystem _waveSystem;
        private RespawnSystem _respawnSystem;

        private void Awake()
        {
            _scoreSystem = new ScoreSystem(scoreUI, scoreConfiguration);
            _waveSystem = new WaveSystem(wavesConfiguration);
            _respawnSystem = new RespawnSystem(respawnUI, respawnConfiguration);
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
            StartCoroutine(_respawnSystem.StartRespawnTimer());
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
}