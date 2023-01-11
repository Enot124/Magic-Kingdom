using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
   private int _point = 0;
   private Vector3 _target;
   private Rigidbody2D _rigidbody;
   private Enemy _enemy;
   [SerializeField] private Transform[] _movePoints;

   private void OnEnable()
   {
      GlobalEventManager.OnGameEnded += StopMove;
   }

   private void OnDisable()
   {
      GlobalEventManager.OnGameEnded -= StopMove;
   }

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody2D>();
      _enemy = this.gameObject.GetComponent<Enemy>();
   }

   private void Update()
   {
      Move();
   }

   private void Move()
   {
      _target = _movePoints[_point].position;
      transform.position = Vector3.MoveTowards(transform.position, _target, _enemy.speed * Time.deltaTime);
      if (transform.position == _target)
      {
         _point++;
      }
   }

   private void StopMove()
   {
      _enemy.speed = 0;
   }
}
