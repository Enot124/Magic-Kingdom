using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
   private Slider _slider;
   [SerializeField] private Enemy _enemy;

   private void Awake()
   {
      _slider = GetComponent<Slider>();
      SetMaxHealth();
   }

   private void OnEnable()
   {
      GlobalEventManager.OnEnemyHealthChanged += SetHealth;
   }

   private void OnDisable()
   {
      GlobalEventManager.OnEnemyHealthChanged -= SetHealth;
   }

   internal void SetHealth()
   {
      _slider.value = _enemy.health;
   }

   internal void SetMaxHealth()
   {
      _slider.maxValue = _enemy.health;
      SetHealth();
   }
}

