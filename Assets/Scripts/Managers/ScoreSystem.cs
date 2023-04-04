using Enums;
using ScriptableObjects;
using UI;

public class ScoreSystem
{
    private readonly ScoreUI _scoreUI;
    private readonly ScoreConfigurationSO _scoreConfiguration;
    private int _currentScore;

    public ScoreSystem(ScoreUI scoreUI, ScoreConfigurationSO scoreConfiguration)
    {
        _currentScore = 0;
        _scoreUI = scoreUI;
        _scoreUI.UpdateScore(_currentScore);
        _scoreConfiguration = scoreConfiguration;
    }

    public void UpdateScore(AsteroidsSize asteroidsSize)
    {
        switch (asteroidsSize)
        {
            case AsteroidsSize.Small:
                _currentScore += _scoreConfiguration.SmallAsteroidScore;
                break;
            case AsteroidsSize.Medium:
                _currentScore += _scoreConfiguration.MediumAsteroidScore;
                break;
            case AsteroidsSize.Big:
                _currentScore += _scoreConfiguration.BigAsteroidScore;
                break;
        }
        _scoreUI.UpdateScore(_currentScore);
    }
}