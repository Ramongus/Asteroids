using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ScoreConfiguration", menuName = "ScriptableObjects/ScoreConfiguration", order = 0)]
    public class ScoreConfigurationSO : ScriptableObject
    {
        [SerializeField] private int smallAsteroidScore;
        [SerializeField] private int mediumAsteroidScore;
        [SerializeField] private int bigAsteroidScore;

        public int SmallAsteroidScore => smallAsteroidScore;
        public int MediumAsteroidScore => mediumAsteroidScore;
        public int BigAsteroidScore => bigAsteroidScore;
    }
}