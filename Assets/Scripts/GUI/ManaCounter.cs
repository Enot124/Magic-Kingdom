using System.Collections;
using UnityEngine;

public class ManaCounter : MonoBehaviour
{
   private float _manaRatio = 50;
   private float _timer;
   internal int currentMana = 500;
   internal int unitCost = 100;

   private void OnEnable()
   {
      StartCoroutine(AddMana());
   }
   private void OnDisable()
   {
      StopCoroutine(AddMana());
   }

   private void Update()
   {
      _timer += Time.deltaTime;
   }

   private IEnumerator AddMana()
   {
      while (true)
      {
         yield return new WaitForSeconds(2);
         currentMana += (int)_manaRatio;
         if ((int)_timer % 30 == 0)
         {
            _manaRatio *= 1.5f;
         }
      }
   }

   internal void ReCount()
   {
      currentMana -= unitCost;
      unitCost = (int)(unitCost * 1.1f);
   }
}
