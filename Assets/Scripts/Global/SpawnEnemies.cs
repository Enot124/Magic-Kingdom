using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
   private float _cooldown = 1.5f;
   private float _startSpawn = 2f;
   private int _enemycount;
   internal List<Enemy> enemies = new List<Enemy>();
   [SerializeField] private Enemy[] _enemyPrefab;
   [SerializeField] private Transform _spawnPoint;
   [SerializeField] private Enemy _boss;

   private void OnEnable()
   {
      Enemy.OnEnemyDied += UnRegisterEnemy;
   }

   private void OnDisable()
   {
      Enemy.OnEnemyDied -= UnRegisterEnemy;
      enemies.Clear();
   }

   internal void StartSpawn()
   {
      InvokeRepeating("SpawnEnemy", _startSpawn, _cooldown);
   }

   private void SpawnEnemy()
   {
      Enemy enemy;
      if (_enemycount % 4 == 0)
         enemy = GameObject.Instantiate(_enemyPrefab[1], _spawnPoint.position, Quaternion.identity);
      else if (_enemycount % 7 == 0)
         enemy = GameObject.Instantiate(_enemyPrefab[2], _spawnPoint.position, Quaternion.identity);
      else
         enemy = GameObject.Instantiate(_enemyPrefab[0], _spawnPoint.position, Quaternion.identity);
      RegisterEnemy(enemy);
      _enemycount++;
   }

   internal void BossSpawn()
   {
      Enemy boss = Instantiate(_boss, _spawnPoint.position, Quaternion.identity);
      RegisterEnemy(boss);
   }

   private void RegisterEnemy(Enemy enemy)
   {
      enemies.Add(enemy);
   }

   private void UnRegisterEnemy(Enemy enemy)
   {
      enemies.Remove(enemy);
   }
}
