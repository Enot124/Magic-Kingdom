using UnityEngine;
using UnityEngine.UI;

public class GlobalAudio : MonoBehaviour
{
   [SerializeField] private Button _musicButton;
   [SerializeField] private Sprite[] _musicImages;

   internal void ChangeButtonImage()
   {
      _musicButton.image.sprite = _musicImages[(int)AudioListener.volume];
   }

   public void ChangeVolume()
   {
      if (AudioListener.volume == 0)
         AudioListener.volume = 1;
      else
         AudioListener.volume = 0;
      ChangeButtonImage();
   }

}
