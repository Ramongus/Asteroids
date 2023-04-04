using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "RespawnConfiguration", menuName = "ScriptableObjects/RespawnConfiguration", order = 0)]
    public class RespawnConfigurationSO : ScriptableObject
    {
        [SerializeField] private float gameOverDelay = 2f;
        [SerializeField] private float respawnDelay = 3f;
        
        public float GameOverDelay => gameOverDelay;
        public float RespawnDelay => respawnDelay;
    }
}