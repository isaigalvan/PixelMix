using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla : MonoBehaviour
{
    public int numCasilla;
    public int idCasilla = 0;
    public SpriteRenderer spriteR;
    public Sprite[] sprite;
    public bool esHabilidad, esDeshabilidad, esNegra, esMinijuego, esPintada, esMeta, esInicio, esFinal, esOcupada, esDesLeonn, esDesLeonn2;

    /// <summary>
    /// AsignarTextura
    /// Este metodo es llamadado por "AsignarTexturas" del script "CrearCasilla" y tiene como parametro un objeto del tipo "Sprite", le asigna una textura
    /// de la lista de sprites a una casilla.
    /// Se le asigna al objeto "SpriteR" el componente "SpriteRenderer" del objeto, despues se guarda el parametro de entrada tipo Sprite dentro del campo .sprite 
    /// del objeto spriteR 
    /// </summary>
    /// <param name="_sprite"></param>
    public void AsignarTextura(Sprite _sprite)
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.sprite = _sprite;
    }
}
