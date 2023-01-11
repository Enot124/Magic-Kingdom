using System.Dynamic;
using System;

public static class GlobalEventManager
{
   internal static Action OnEnemyDied;
   internal static Action OnEnemyHealthChanged;
   internal static Action OnBossSpawn;
   internal static Action OnGameEnded;
   internal static Action OnGameWon;


   public static void SendEnemyDied() => OnEnemyDied?.Invoke();

   public static void SendEnemyHealthChanged() => OnEnemyHealthChanged?.Invoke();

   public static void SendBossSpawn() => OnBossSpawn?.Invoke();

   public static void SendGameEnded() => OnGameEnded?.Invoke();

   public static void SendGameWon() => OnGameWon?.Invoke();
}

