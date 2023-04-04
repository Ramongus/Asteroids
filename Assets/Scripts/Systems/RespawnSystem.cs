using System.Collections;
using Managers;
using ScriptableObjects;
using UI;
using UnityEngine;

namespace Systems
{
    public class RespawnSystem
    {
        private readonly RespawnUI _respawnUI;
        private readonly RespawnConfigurationSO _respawnConfiguration;

        public RespawnSystem(RespawnUI respawnUI, RespawnConfigurationSO respawnConfiguration)
        {
            _respawnUI = respawnUI;
            _respawnConfiguration = respawnConfiguration;
        }

        public IEnumerator StartRespawnTimer()
        {
            _respawnUI.UpdateLabel("Game Over");
        
            _respawnUI.Enable();
        
            var gameOverTimer = _respawnConfiguration.GameOverDelay;
            while (gameOverTimer > 0)
            {
                yield return new WaitForSeconds(1);
                gameOverTimer--;
            }
        
            var countDownTimer = _respawnConfiguration.RespawnDelay;
            _respawnUI.UpdateLabel(countDownTimer.ToString());
        
            while (countDownTimer > 0)
            {
                yield return new WaitForSeconds(1);
                countDownTimer--;
                _respawnUI.UpdateLabel(countDownTimer.ToString());
            }
            _respawnUI.Disable();
            MySceneManager.Instance.RestartScene();
            yield return null;
        }
    }
}