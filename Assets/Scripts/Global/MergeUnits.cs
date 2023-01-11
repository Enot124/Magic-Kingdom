using System.Collections.Generic;
using UnityEngine;

public class MergeUnits : MonoBehaviour
{
   [SerializeField] LayerMask _layerUnit;
   [SerializeField] LayerMask _layerSector;
   private Vector3 _currentPosition;
   private Mag _currentUnit;
   private Camera _camera;
   internal Sector parentSector;

   public delegate void SendMergedUnit(Sector freeSector);
   public static event SendMergedUnit OnMergedUnit;


   private void Awake()
   {
      _camera = Camera.main;
   }

   private void OnMouseDown()
   {
      _currentPosition = transform.position;
      gameObject.layer = 0;
      _currentUnit = gameObject.GetComponent<Mag>();

      RaycastHit2D rayhitSector = FindObject(gameObject.transform.position, _layerSector);
      if (rayhitSector)
         parentSector = rayhitSector.collider.gameObject.GetComponent<Sector>();
   }

   private void OnMouseDrag()
   {
      transform.position = new Vector3(_camera.ScreenToWorldPoint(Input.mousePosition).x,
                                       _camera.ScreenToWorldPoint(Input.mousePosition).y,
                                       transform.position.z);
   }

   private void OnMouseUp()
   {
      RaycastHit2D rayhitUnit = FindObject(_camera.ScreenToWorldPoint(Input.mousePosition), _layerUnit);
      if (rayhitUnit)
      {
         Mag foundUnit = rayhitUnit.collider.gameObject.GetComponent<Mag>();
         if (foundUnit.mergeLevel < foundUnit.maxMergeLevel)
         {
            if (_currentUnit.element == foundUnit.element && _currentUnit.mergeLevel == foundUnit.mergeLevel)
            {
               foundUnit.LevelUp();
               Destroy(_currentUnit.gameObject);
               OnMergedUnit(parentSector);
               return;
            }
         }
      }
      NotFoundUnit();
   }

   private RaycastHit2D FindObject(Vector3 position, LayerMask layer)
   {
      return Physics2D.Raycast(position, _camera.transform.forward, 10f, layer);
   }

   private void NotFoundUnit()
   {
      transform.position = _currentPosition;
      gameObject.layer = 3;
   }
}
