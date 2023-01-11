using UnityEngine;

public class StateEnemy : MonoBehaviour
{
   [SerializeField] private SpriteRenderer[] _spritesEnemy;
   [SerializeField] private GameObject _fire;
   [SerializeField] private ParticleSystem _lightingDamage;
   [SerializeField] private ParticleSystem _fireDamage;
   [SerializeField] private ParticleSystem _waterDamage;
   [SerializeField] private ParticleSystem _earthDamage;
   [SerializeField] private ParticleSystem _dead;

   internal void FireState(bool isFire) => _fire.SetActive(isFire);

   internal void WaterState(bool isWater)
   {
      if (isWater)
      {
         for (var i = 0; i < _spritesEnemy.Length; i++)
         {
            _spritesEnemy[i].color = new Color32(76, 121, 255, 255);
         }
      }
      else
      {
         for (var i = 0; i < _spritesEnemy.Length; i++)
         {
            _spritesEnemy[i].color = Color.white;
         }
      }
   }
   internal void DamageEnemy(string element)
   {
      switch (element)
      {
         case "Fire": Instantiate(_fireDamage, transform.position, Quaternion.identity); break;
         case "Water": Instantiate(_waterDamage, transform.position, Quaternion.identity); break;
         case "Earth": Instantiate(_earthDamage, transform.position, Quaternion.identity); break;
         case "Air": Instantiate(_lightingDamage, transform.position, Quaternion.identity); break;
      }
   }

   internal void DieEnemy()
   {
      Instantiate(_dead, transform.position, Quaternion.identity);
   }
}
