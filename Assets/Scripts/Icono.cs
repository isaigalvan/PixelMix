using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icono : MonoBehaviour
{
    public Sprite[] sprite;
    public SpriteRenderer spriteR;

    public void AsignarTextura(Sprite _sprite)
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.sprite = _sprite;
    }
}
