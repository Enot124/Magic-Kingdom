using UnityEngine;

public class AirBullet : Bullet
{
   [SerializeField] private ParticleSystem _particle;

   protected override void OnCollisionEnter2D(Collision2D other)
   {
      Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 2f, enemyLayer);
      for (var i = 0; i < enemies.Length && i < 2; i++)
      {
         if (enemies[i].gameObject.TryGetComponent<Enemy>(out Enemy enemy))
         {
            enemy.TakeDamage(damage);
            enemy.stateEnemy.DamageEnemy("Air");
         }
      }
      Instantiate(_particle, transform.position, Quaternion.identity);
      Destroy(this.gameObject);
   }
}
