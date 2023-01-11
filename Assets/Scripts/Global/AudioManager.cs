using UnityEngine;

public class AudioManager : MonoBehaviour
{
   private AudioSource _audio;
   [SerializeField] private AudioClip _bossAudio;

   private void Awake()
   {
      _audio = GetComponent<AudioSource>();
   }

   private void OnEnable()
   {
      GlobalEventManager.OnGameEnded += StopAudio;
      GlobalEventManager.OnGameWon += StopAudio;
      GlobalEventManager.OnBossSpawn += ChangeAudio;
   }

   private void OnDisable()
   {
      GlobalEventManager.OnGameEnded -= StopAudio;
      GlobalEventManager.OnGameWon -= StopAudio;
      GlobalEventManager.OnBossSpawn -= ChangeAudio;
   }

   private void ChangeAudio()
   {
      _audio.clip = _bossAudio;
      _audio.Play();
   }

   private void StopAudio()
   {
      _audio.Stop();
   }
}
