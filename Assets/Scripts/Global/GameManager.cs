using System.Collections;
using UnityEngine;
using YG;

public class GameManager : MonoBehaviour
{
   private bool _bossIsSpawn;
   private float _timer;
   internal MagLevels magLevels;
   internal float enemyHealthIndex = 1;
   internal static GameManager Instance;
   [SerializeField] private SpawnEnemies _spawnEnemies;
   [SerializeField] private LayerMask _enemy;

   private void OnEnable()
   {
      GlobalEventManager.OnGameEnded += StopSpawnEnemies;
   }

   private void OnDisable()
   {
      StopCoroutine(UpIndex());
      GlobalEventManager.OnGameEnded -= StopSpawnEnemies;
   }

   private void Awake()
   {
      magLevels = GetComponent<MagLevels>();
   }

   private void Start()
   {
      Instance = this;
      StartCoroutine(UpIndex());
      _spawnEnemies.StartSpawn();
      _timer = 0;
   }

   private void Update()
   {
      _timer += Time.deltaTime;
      if (_timer > 180 && !_bossIsSpawn)
      {
         SpawnBoss();
      }
   }

   private IEnumerator UpIndex()
   {
      while (true)
      {
         yield return new WaitForSeconds(2);
         enemyHealthIndex += 0.16f;
      }
   }

   private void SpawnBoss()
   {
      _bossIsSpawn = true;
      StopSpawnEnemies();
      DeleteAllEnemies();
      GlobalEventManager.SendBossSpawn();
      _spawnEnemies.BossSpawn();
   }

   private void StopSpawnEnemies() => _spawnEnemies.CancelInvoke();

   private void DeleteAllEnemies()
   {
      Collider2D[] enemies = Physics2D.OverlapCircleAll(new Vector2(0, 0), 1000f, _enemy);
      foreach (Collider2D enemyCollider in enemies)
      {
         if (enemyCollider.TryGetComponent<Enemy>(out Enemy enemyObject))
         {
            enemyObject.Die();
         }
      }
   }
}
