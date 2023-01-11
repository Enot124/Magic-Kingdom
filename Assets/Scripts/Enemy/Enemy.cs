using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public delegate void SendEnemyDie(Enemy enemy);
   public static event SendEnemyDie OnEnemyDied;
   internal int fireCounter;
   internal bool fireIsStart;
   internal bool isSlow;
   internal int fireDamage;
   internal StateEnemy stateEnemy;
   private float _startSpeed;
   [SerializeField] internal int health;
   [SerializeField] internal float speed;

   private void Awake()
   {
      _startSpeed = speed;
      health = (int)(health * GameManager.Instance.enemyHealthIndex);
      stateEnemy = GetComponent<StateEnemy>();
   }

   private void Update()
   {
      if (isSlow && _startSpeed == speed)
      {
         StartCoroutine(WaterSlow());
      }

      if (fireCounter != 0 && !fireIsStart)
      {
         StartCoroutine(FireDamage());
      }
   }

   internal void TakeDamage(int damage)
   {
      health -= damage;
      GlobalEventManager.SendEnemyHealthChanged();
      if (health <= 0)
         Die();
   }

   public virtual void Die()
   {
      OnEnemyDied(this);
      GlobalEventManager.SendEnemyDied();
      stateEnemy.DieEnemy();
      Destroy(this.gameObject);
   }

   internal IEnumerator FireDamage()
   {
      while (fireCounter != 0)
      {
         fireIsStart = true;
         stateEnemy.FireState(fireIsStart);
         TakeDamage(fireDamage);
         fireCounter--;
         yield return new WaitForSeconds(1);
      }
      fireIsStart = false;
      stateEnemy.FireState(fireIsStart);
   }

   internal IEnumerator WaterSlow()
   {
      stateEnemy.WaterState(isSlow);
      speed = _startSpeed / 1.5f;
      yield return new WaitForSeconds(5);
      speed = _startSpeed;
      isSlow = false;
      stateEnemy.WaterState(isSlow);
   }
}

