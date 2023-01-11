using UnityEngine;

public class WaterBullet : Bullet
{
   protected AudioSource audioSource;

   private void Start()
   {
      audioSource = GetComponent<AudioSource>();
   }

   protected override void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
      {
         enemy.TakeDamage(damage);
         enemy.stateEnemy.DamageEnemy("Water");
         if (!enemy.isSlow)
            enemy.isSlow = true;
      }
      Destroy(this.gameObject);
   }
}
