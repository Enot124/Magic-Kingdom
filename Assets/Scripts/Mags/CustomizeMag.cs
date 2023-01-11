using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeMag : MonoBehaviour
{
   [SerializeField] private SpriteRenderer[] _spriteMag;
   [SerializeField] private Sprite[] _spriteHead;
   [SerializeField] private Sprite[] _spriteBody;
   [SerializeField] private Sprite[] _spriteLeftArm;
   [SerializeField] private Sprite[] _spriteRightArm;
   [SerializeField] private Sprite[] _spriteStick;

   public void Customize(int level)
   {
      _spriteMag[0].sprite = _spriteHead[level - 1];
      _spriteMag[1].sprite = _spriteBody[level - 1];
      _spriteMag[2].sprite = _spriteLeftArm[level - 1];
      _spriteMag[3].sprite = _spriteRightArm[level - 1];
      _spriteMag[4].sprite = _spriteStick[level - 1];
   }
}
