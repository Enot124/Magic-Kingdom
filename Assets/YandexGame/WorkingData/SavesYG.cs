
namespace YG
{
   [System.Serializable]
   public class SavesYG
   {
      // "Технические сохранения" для работы плагина (Не удалять)
      public int idSave;
      public bool isFirstSession = true;
      public string language = "ru";
      public bool promptDone;

      public int coins = 150;
      public int fireLevel;
      public int waterLevel;
      public int earthLevel;
      public int airLevel;
      public int levelsOpened = 1;
   }
}
