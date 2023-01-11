using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinCounter : MonoBehaviour
{
   internal int currentCoin;

   private void OnEnable()
   {
      GlobalEventManager.OnEnemyDied += AddCoin;
   }

   private void OnDisable()
   {
      GlobalEventManager.OnEnemyDied -= AddCoin;
   }

   private void AddCoin()
   {
      currentCoin += 5 * (SceneManager.GetActiveScene().buildIndex);
      Debug.Log(5 * SceneManager.GetActiveScene().buildIndex);
   }
}
