using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
   private float _time;
   private AudioSource _audio;
   private bool _gameEnded;
   [SerializeField] private CoinCounter _coinCounter;
   [SerializeField] private Text _currentCoin;
   [SerializeField] private Text _timeCounter;
   #region Mana
   [SerializeField] private ManaCounter _manaCounter;
   [SerializeField] private Text _currentMana;
   [SerializeField] private Text _unitCost;
   #endregion
   [SerializeField] private GameObject _endGamePanel;
   [SerializeField] private Text _liveTime;
   [SerializeField] private Text _endedCoins;
   [SerializeField] private AudioClip _endSound;
   [SerializeField] private AudioClip _wonSound;

   private void OnEnable()
   {
      GlobalEventManager.OnGameEnded += AddEndStats;
      GlobalEventManager.OnGameWon += AddWonStats;
      _time = 0;
      _audio = _endGamePanel.GetComponent<AudioSource>();
   }

   private void OnDisable()
   {
      GlobalEventManager.OnGameEnded -= AddEndStats;
      GlobalEventManager.OnGameWon += AddWonStats;
   }

   private void Update()
   {
      if (!_gameEnded)
      {
         _currentMana.text = _manaCounter.currentMana.ToString();
         _unitCost.text = _manaCounter.unitCost.ToString();
         _time += Time.deltaTime;
         _timeCounter.text = TimeFormat.Format(_time);
         _currentCoin.text = _coinCounter.currentCoin.ToString();
      }
   }

   private void AddEndStats()
   {
      string stroke;
      if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "English")
         stroke = $"YOU LASTED {TimeFormat.Format(_time)} MINUTES";
      else
         stroke = $"ВЫ ПРОДЕРЖАЛИСЬ {TimeFormat.Format(_time)} МИНУТ";
      ShowPanel(stroke, _endSound);
   }

   private void AddWonStats()
   {
      string stroke;
      if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "English")
         stroke = "YOU COMPLETED THE LEVEL";
      else
         stroke = "ВЫ ПРОШЛИ УРОВЕНЬ";
      ShowPanel(stroke, _wonSound);

   }

   private void ShowPanel(string endStroke, AudioClip _clip)
   {
      _gameEnded = true;
      _liveTime.text = endStroke;
      _endedCoins.text = _coinCounter.currentCoin.ToString();
      _endGamePanel.SetActive(true);
      _audio.PlayOneShot(_clip);
      YG.YandexGame.FullscreenShow();
   }

   public void GoToMenu() => SceneManager.LoadScene(0);
}
