using UnityEngine;


public abstract class Mag : MonoBehaviour
{
   private int _attack;
   private float _cooldown;
   private bool _canAttack = true;
   private AudioSource _audio;
   private CustomizeMag _customize;
   private Animator _animator;
   private VisualMag _visual;
   internal int maxMergeLevel = 4;
   internal int mergeLevel = 1;
   protected Enemy targetEnemy;
   [SerializeField] private int _startDamage;
   [SerializeField] private float _attackSpeed;
   [SerializeField] private Bullet _bullet;
   [SerializeField] private Transform _attackPoint;
   [SerializeField] internal string element;

   private void OnEnable()
   {
      GlobalEventManager.OnGameEnded += StopAttackig;
   }

   private void OnDisable()
   {
      GlobalEventManager.OnGameEnded -= StopAttackig;
   }

   private void Awake()
   {
      _customize = GetComponent<CustomizeMag>();
      _audio = GetComponent<AudioSource>();
      _animator = GetComponent<Animator>();
      _visual = GetComponent<VisualMag>();
      _animator.speed = _attackSpeed;
      _visual.VisualSpawn();
   }

   private void Start()
   {
      _attack = _startDamage + GameManager.Instance.magLevels.CalculateAttack(element);
      Debug.Log($"{element}: {_attack}");
   }

   private void Update()
   {
      if ((GetTarget() != null) && _canAttack)
      {
         _animator.SetBool("isAttack", true);
      }
      else
         _animator.SetBool("isAttack", false);
   }

   private void StopAttackig() => _canAttack = false;

   public void LevelUp()
   {
      if (mergeLevel < maxMergeLevel)
      {
         mergeLevel++;
         _customize.Customize(mergeLevel);
         _visual.VisualLevelUp();
         _attack = (int)(_attack * 1.5f);
         _animator.speed += 0.5f;
      }

   }

   public void Attack()
   {
      _audio.Play();
      Bullet bullet = Instantiate(_bullet, _attackPoint.position, Quaternion.identity);
      bullet.target = GetTarget();
      bullet.damage = _attack;
   }

   protected abstract Transform GetTarget();
}
