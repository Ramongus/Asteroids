using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreLabel;
        
        public void UpdateScore(int currentScore)
        {
            scoreLabel.text = currentScore.ToString();
        }
    }
}