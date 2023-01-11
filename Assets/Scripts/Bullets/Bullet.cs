using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
   private float _speed = 10f;
   internal Transform target;
   internal int damage;
   [SerializeField] protected LayerMask enemyLayer;

   private void Update()
   {
      if (target == null)
      {
         Destroy(this.gameObject);
      }
      else
      {
         transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
      }
   }

   protected abstract void OnCollisionEnter2D(Collision2D other);
}
