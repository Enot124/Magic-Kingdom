using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      Enemy enemy = other.gameObject.GetComponent<Enemy>();
      enemy.Die();
      GlobalEventManager.SendGameEnded();
   }
}
