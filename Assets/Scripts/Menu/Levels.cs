using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YG;

public class Levels : MonoBehaviour
{
   private int _levelComplete;
   private AudioSource _audio;
   [SerializeField] private Button[] _levelButtons;

   private void OnEnable() => YandexGame.GetDataEvent += GetData;

   private void OnDisable() => YandexGame.GetDataEvent -= GetData;

   private void Awake()
   {
      _audio = GetComponent<AudioSource>();
   }

   private void Start()
   {
      GetData();
      OpenLevels();
   }

   private void GetData()
   {
      _levelComplete = YandexGame.savesData.levelsOpened;
   }

   private void OpenLevels()
   {
      for (var i = 0; i < _levelButtons.Length; i++)
      {
         _levelButtons[i].interactable = (i < _levelComplete);
      }
   }

   public void LoadScene(int levelIndex)
   {
      _audio.Play();
      SceneManager.LoadScene(levelIndex);
   }
}

