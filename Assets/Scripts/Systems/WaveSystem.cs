using Enums;
using Factories;
using Managers;
using ScriptableObjects;

namespace Systems
{
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
}