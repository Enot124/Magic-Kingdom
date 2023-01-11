using UnityEngine;
using UnityEngine.SceneManagement;

namespace YG
{
   public class SaveData : MonoBehaviour
   {
      [SerializeField] private CoinCounter _coinCounter;

      private void OnEnable()
      {
         GlobalEventManager.OnGameEnded += EndGame;
         GlobalEventManager.OnGameWon += WonGame;
      }

      private void OnDisable()
      {
         GlobalEventManager.OnGameEnded -= EndGame;
         GlobalEventManager.OnGameWon -= WonGame;
      }

      private void EndGame() => SaveCoins();

      private void WonGame()
      {
         SaveLevels();
         EndGame();
      }

      private void SaveCoins()
      {
         YandexGame.savesData.coins += _coinCounter.currentCoin;
         YandexGame.SaveProgress();
      }

      private void SaveLevels()
      {
         if (YandexGame.savesData.levelsOpened < 3)
            YandexGame.savesData.levelsOpened = SceneManager.GetActiveScene().buildIndex;
      }
   }
}