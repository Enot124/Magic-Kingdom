using UnityEngine;

public class VisualMag : MonoBehaviour
{
   [SerializeField] private ParticleSystem _spawn;
   [SerializeField] private ParticleSystem _levelUp;

   internal void VisualSpawn()
   {
      Instantiate(_spawn, transform.position, Quaternion.identity);
   }

   internal void VisualLevelUp()
   {
      Instantiate(_levelUp, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.Euler(-90, 0, 0));
   }
}
