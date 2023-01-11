using UnityEngine;
using UnityEngine.UI;

public class Lot : MonoBehaviour
{
   internal int level;
   internal int attack;
   internal int cost;
   private int _startCost = 50;
   [SerializeField] internal int startAttack;
   [SerializeField] private Text _levelText;
   [SerializeField] private Text _attackText;
   [SerializeField] private Text _costText;
   [SerializeField] private Image _buyButton;
   [SerializeField] private Sprite[] buttons;

   internal void CalculateStats()
   {
      attack = startAttack + level;
      int ratio = 1 + level / 5;
      cost = (int)(_startCost + ratio * 0.4f * (level * 10));

      if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "English")
         _levelText.text = $"LEVEL {level}";
      else
         _levelText.text = $"УРОВЕНЬ {level}";

      _attackText.text = attack.ToString();
      _costText.text = cost.ToString();
   }

   internal void ChangeButtonImage(int coins, int rewardCount)
   {
      if (coins >= cost)
      {
         _buyButton.sprite = buttons[0];
         _costText.text = cost.ToString();
      }
      else
      {
         if (rewardCount == 0)
         {
            _buyButton.sprite = buttons[1];
            _costText.text = cost.ToString();
         }
         else
         {
            _buyButton.sprite = buttons[2];
            _costText.text = "WATCH VIDEO";
         }
      }
   }
}
