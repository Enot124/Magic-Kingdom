using UnityEngine;
using System.Collections.Generic;

public class SpawnUnit : MonoBehaviour
{
   private Vector3 _offset = new Vector3(0, 0.3f, 0);
   internal List<Sector> freeSectors = new List<Sector>();
   [SerializeField] private ManaCounter _manaCounter;
   [SerializeField] private Sector[] _sectors;
   [SerializeField] private Mag[] _unit;

   private void OnEnable()
   {
      MergeUnits.OnMergedUnit += AddFreeSector;
   }

   private void OnDisable()
   {
      MergeUnits.OnMergedUnit -= AddFreeSector;
   }

   private void Awake()
   {
      foreach (Sector currentSector in _sectors)
      {
         freeSectors.Add(currentSector);
      }
   }
   public void SpawnUnitOnField()
   {
      if (freeSectors.Count != 0 && _manaCounter.currentMana >= _manaCounter.unitCost)
      {
         int randomElement = Random.Range(0, _unit.Length);
         Sector freeSector = freeSectors[Random.Range(0, freeSectors.Count)];
         Mag randomMag = Instantiate(_unit[randomElement], freeSector.transform.position, Quaternion.identity);
         freeSectors.Remove(freeSector);
         _manaCounter.ReCount();
      }
   }

   private void AddFreeSector(Sector freeSector)
   {
      freeSectors.Add(freeSector);
   }

}
