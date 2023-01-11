using UnityEngine;

namespace YG
{
   public class MagLevels : MonoBehaviour
   {
      private int _fireLevel;
      private int _waterLevel;
      private int _earthLevel;
      private int _airLevel;

      private void OnEnable()
      {
         YandexGame.GetDataEvent += GetData;
      }

      private void OnDisable() => YandexGame.GetDataEvent -= GetData;

      private void Awake()
      {
         if (YandexGame.SDKEnabled == true)
         {
            GetData();
         }
      }

      private void GetData()
      {
         _fireLevel = YandexGame.savesData.fireLevel;
         _waterLevel = YandexGame.savesData.waterLevel;
         _earthLevel = YandexGame.savesData.earthLevel;
         _airLevel = YandexGame.savesData.airLevel;
      }

      public int CalculateAttack(string element)
      {
         int attack = 0;

         switch (element)
         {
            case "Fire": attack = _fireLevel; break;
            case "Water": attack = _waterLevel; break;
            case "Earth": attack = _earthLevel; break;
            case "Air": attack = _airLevel; break;
         }
         return attack;
      }
   }
}