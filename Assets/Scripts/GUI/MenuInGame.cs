using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class MenuInGame : MonoBehaviour
{
   [SerializeField] private GameObject _menu;
   [SerializeField] private GameObject _exitPanel;
   [SerializeField] private GlobalAudio _globalAudio;
   [SerializeField] private Animator _animator;

   public void ShowAndCloseMenu()
   {
      if (_menu.activeSelf)
      {
         _menu.SetActive(false);

      }
      else
      {
         _globalAudio.ChangeButtonImage();
         _menu.SetActive(true);
      }
   }

   public void GoMainMenu()
   {
      SceneManager.LoadScene(0);
   }
}

