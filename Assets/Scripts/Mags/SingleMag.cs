using UnityEngine;

public class SingleMag : Mag
{
   [SerializeField] private Transform[] _points;
   [SerializeField] private LayerMask _enemyLayer;

   protected override Transform GetTarget()
   {
      for (var i = _points.Length - 1; i != 0; i--)
      {
         RaycastHit2D rayhit = Physics2D.Linecast(_points[i].position, _points[i - 1].position, _enemyLayer);
         if (rayhit)
         {
            return rayhit.collider.transform;
         }

      }
      return null;
   }
}
