using UnityEngine;

public class SplashMag : Mag
{
   [SerializeField] private LayerMask _layerEnemy;
   protected override Transform GetTarget()
   {
      int enemyIndex = 0;
      Collider2D[] enemies = Physics2D.OverlapCircleAll(new Vector2(0, 0), 1000f, _layerEnemy);
      if (enemies.Length > 0)
      {
         enemyIndex = Random.Range(0, enemies.Length - 1);
         return enemies[enemyIndex].transform;
      }
      else return null;

   }
}
