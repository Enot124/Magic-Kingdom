using UnityEngine;

public class EarthBullet : Bullet
{
   [SerializeField] private ParticleSystem _particle;
   protected override void OnCollisionEnter2D(Collision2D other)
   {
      Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 1.5f, enemyLayer);
      for (var i = 0; i < enemies.Length; i++)
      {
         if (enemies[i].gameObject.TryGetComponent<Enemy>(out Enemy enemy))
         {
            enemy.TakeDamage(damage);
            enemy.stateEnemy.DamageEnemy("Earth");
         }
      }
      Instantiate(_particle, transform.position, Quaternion.identity);
      Destroy(this.gameObject);
   }
}
