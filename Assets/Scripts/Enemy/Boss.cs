using UnityEngine;

public class Boss : Enemy
{
   public override void Die()
   {
      Destroy(this.gameObject);
      stateEnemy.DieEnemy();
      GlobalEventManager.SendGameWon();
      GlobalEventManager.SendEnemyDied();
   }
}
