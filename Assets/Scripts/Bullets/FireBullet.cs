using UnityEngine;

public class FireBullet : Bullet
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
         enemy.fireCounter = 3;
         enemy.fireDamage = damage / 2;
         enemy.stateEnemy.DamageEnemy("Fire");
      }
      Destroy(this.gameObject);
   }
}
