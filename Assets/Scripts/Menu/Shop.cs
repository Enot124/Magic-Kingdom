using UnityEngine;
using UnityEngine.UI;
using YG;

public class Shop : MonoBehaviour
{
   private int _coins;
   private int rewardCount = 1;
   private AudioSource _audio;
   [SerializeField] internal Lot[] lots;
   [SerializeField] private Text _coinCount;

   private void OnEnable()
   {
      YandexGame.GetDataEvent += GetData;
      YandexGame.RewardVideoEvent += UpgradeUnit;
   }

   private void OnDisable()
   {
      YandexGame.GetDataEvent -= GetData;
      YandexGame.RewardVideoEvent -= UpgradeUnit;
   }

   private void Awake()
   {
      _audio = GetComponent<AudioSource>();
   }

   private void Start()
   {
      if (YandexGame.SDKEnabled == true)
      {
         GetData();
         FillLots();
      }
      rewardCount = 1;
   }

   private void FillLots()
   {
      lots[0].level = YandexGame.savesData.fireLevel;
      lots[1].level = YandexGame.savesData.waterLevel;
      lots[2].level = YandexGame.savesData.earthLevel;
      lots[3].level = YandexGame.savesData.airLevel;

      for (var i = 0; i < lots.Length; i++)
      {
         lots[i].CalculateStats();
         lots[i].ChangeButtonImage(_coins, rewardCount);
      }
   }

   public void BuyUpgrade(int id)
   {
      if (_coins >= lots[id].cost)
      {
         _coins -= lots[id].cost;
         _coinCount.text = _coins.ToString();
         UpgradeUnit(id);
      }
      else if (rewardCount > 0)
      {
         rewardCount = 0;
         YandexGame.RewVideoShow(id);
      }
   }

   private void UpgradeUnit(int id)
   {
      lots[id].level++;
      lots[id].CalculateStats();
      _audio.Play();
      SaveData();
      CheckButtons();

   }

   private void GetData()
   {
      _coins = YandexGame.savesData.coins;
      _coinCount.text = _coins.ToString();
   }

   public void SaveData()
   {
      YandexGame.savesData.coins = _coins;
      YandexGame.savesData.fireLevel = lots[0].level;
      YandexGame.savesData.waterLevel = lots[1].level;
      YandexGame.savesData.earthLevel = lots[2].level;
      YandexGame.savesData.airLevel = lots[3].level;
      YandexGame.SaveProgress();
   }

   private void CheckButtons()
   {
      for (var i = 0; i < lots.Length; i++)
      {
         lots[i].ChangeButtonImage(_coins, rewardCount);
      }
   }
}