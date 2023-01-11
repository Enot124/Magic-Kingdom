using UnityEngine;
using YG;

public class MainMenu : MonoBehaviour
{
   private AudioSource _audio;
   private string _language;
   [SerializeField] private GameObject _shop;
   [SerializeField] private GameObject _levels;


   private void OnEnable() => YandexGame.GetDataEvent += GetData;

   private void OnDisable() => YandexGame.GetDataEvent -= GetData;

   private void Awake()
   {
      _audio = GetComponent<AudioSource>();
   }

   private void Start()
   {
      GetData();
      if ((_language == "ru") && (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "English"))
      {
         ChangeLanguage();
      }
      else if ((_language == "en") && (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "Russian"))
      {
         ChangeLanguage();
      }
   }

   private void GetData()
   {
      _language = YandexGame.savesData.language;
   }

   public void PlaySound()
   {
      _audio.Play();
   }

   public void ChangeLanguage()
   {
      if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "English")
         Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Russian");
      else
         Lean.Localization.LeanLocalization.SetCurrentLanguageAll("English");
      _audio.Play();
   }
}
