using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "WavesConfiguration", menuName = "ScriptableObjects/WavesConfiguration", order = 0)]
    public class WavesConfigurationSO : ScriptableObject
    {
        [SerializeField] private int firstWaveAsteroidsCount = 4;
        [SerializeField] private int extraAsteroidsPerWave = 2;
        
        public int FirstWaveAsteroidsCount => firstWaveAsteroidsCount;
        public int ExtraAsteroidsPerWave => extraAsteroidsPerWave;
    }
}