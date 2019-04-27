using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class Personaje : MonoBehaviour
{
    public int casillaActual=0, ph=0;
    public SpriteRenderer spriteR;
    public Sprite[] sprite;
    public GameObject textCasilla, textPh,scripts;
    public bool esPintado, esBloqueado, esBuff, esNerf, esInmune, esAtraido, verificado, condi;

    /*void Start()
    {
        
    }*/

    /// <summary>
    /// Update
    /// Este metodo se llama una vez por frame
    /// Manda a llamar a los metodos "imprimeCasilla" y "verificarCasilla"
    /// </summary>
    void Update()
    {
        imprimeCasilla();
        verificaCasilla();
       
    }
    private void Awake()
    {
        textCasilla = GameObject.FindGameObjectWithTag("NumCasilla");
        textPh = GameObject.FindGameObjectWithTag("Ph");
        scripts = GameObject.Find("Scripts");

    }
    
    public void AsignarTamanos()
    {
        switch (scripts.GetComponent<CrearPersonaje>().idPersonaje)
        {
            case 0:
                transform.localScale = new Vector3(0.23f, 0.23f, 1);
                break;
            case 1:
                transform.localScale = new Vector3(0.25f, 0.25f, 1);
                break;
            case 2:
                transform.localScale = new Vector3(0.26f, 0.26f, 1);
                break;
            case 3:
                transform.localScale = new Vector3(0.29f, 0.29f, 1);
                break;
            case 4:
                transform.localScale = new Vector3(0.24f, 0.24f, 1);
                break;
            case 5:
                transform.localScale = new Vector3(0.23f, 0.23f, 1);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// imprimeCasilla
    /// Este metodo es llamado por update, despues del turno del jugador imprime la casilla actual del jugador de todo el tablero 
    /// primero se verifica si el turno del jugador ya termino comparando la variable "esTurno" con el valor false, en caso de que se cumpla la condicion 
    /// verifica si la variable "casillaActual" del jugador es menor a 10, en ese caso se imprime un 0 y despues la variable "casillaActual" en el objeto de texto
    /// "textoCasillaActual", en caso de que la variable "casillaActual" sea mayor a 10 y menor a 100, solo se imprime la variable "casillaActual" en el objeto de 
    /// texto "textoCasillaActual", en caso de que la variable "casillaActual" sea mayor a 100, se reucira el tamaño de la fuente a un valor de 30 del objeto de texto 
    /// "textoCasilaActual"
    /// </summary>
    public void imprimeCasilla()
    {
        if (scripts.GetComponent<Dado>().esTurno == false)
        {
            if (casillaActual < 10)
            {
             textCasilla.GetComponent<TextMeshProUGUI>().text = "0" + casillaActual;
            }
            else
            {
                textCasilla.GetComponent<TextMeshProUGUI>().text = "" + casillaActual;
            }
            if (casillaActual >= 100)
            {
                textCasilla.GetComponent<TextMeshProUGUI>().fontSize = 30;
            }
        }
    }

    /// <summary>
    /// imprimePh
    /// Este metodo es llamado por verificarCasilla, imprime el valor de los puntos de habilidad del jugador
    /// Este metodo imprime la variable "ph" en el objeto de texto "textoPH"
    /// </summary>
    public void imprimePh()
    {
        textPh.GetComponent<TextMeshProUGUI>().text = "" + ph;
    }


    /// <summary>
    /// verificarCasilla
    /// este metodo es llamado por update
    /// verifica la casilla en la que cayo el jugador para realizar acciones dependiendo del tipo de casilla en el que cayo 
    /// primero se verifica si el jugador ya tiro mediante la variable "yaTiro" comparandola con el valor true y la variable "esTurno" comparandola con false, en caso de que se cumpla
    /// se verifica si el el valor "casillaActual-1" de la lista "casillas" es del tipo de habilidad comparando la variable "esHabilidad" con el valor true, en caso de 
    /// que se cumpla, se verifica si la variable "ph" es mayor o igual a 4, en caso de ser asi la variable "ph" se le asignara el valor de 4, en caso contrario se le 
    /// sumara 1 a la variable "ph", en caso de no ser del tipo "esHabilidad" se compara si es del tipo "esDesabilidad" si dicha variable es igual a true
    /// se verifica si la variable "ph" es igual a 0, en caso de ser asi la variable "ph" se le asignara el valor de 0, en caso contrario se le 
    /// restara 1 a la variable "ph", en caso de no ser tipo "esDeshabilidad" se compara si es del tipo "esNegra" si dicha variable es igual a true
    /// en este caso automaticamente la variable "ph"se le asigna el valor de 0, terminando esto se manda a llamar el metodo "imprimePh"
    /// </summary>
    public void verificaCasilla()
    {
        if(scripts.GetComponent<Dado>().yaTiro == true)
        {
            condi = true;
        }
        if ((casillaActual > 0 && verificado == false && scripts.GetComponent<Dado>().caminando == false && condi == true && scripts.GetComponent<Dado>().yaTiro == false) || (scripts.GetComponent<Habilidades>().verCasiHab1Zor == true))
        {
            if (scripts.GetComponent<CrearCasilla>().casillas[casillaActual].GetComponent<Casilla>().esHabilidad == true)
            {
                if (ph >= 4)
                {
                    ph = 4;
                }
                else
                {
                    ph++;
                }
                scripts.GetComponent<Habilidades>().verCasiHab1Zor = false;

            }
            else if (scripts.GetComponent<CrearCasilla>().casillas[casillaActual].GetComponent<Casilla>().esDeshabilidad == true)
            {
                if (ph <= 0)
                {
                    ph = 0;
                }
                else
                {
                    ph--;
                }
                scripts.GetComponent<Habilidades>().verCasiHab1Zor = false;
            }
            else if (scripts.GetComponent<CrearCasilla>().casillas[casillaActual].GetComponent<Casilla>().esNegra == true)
            {
                ph = 0;
            }
            else if (scripts.GetComponent<CrearCasilla>().casillas[casillaActual].GetComponent<Casilla>().esMinijuego== true)
            {
                int random = Random.Range(2, 11);
                PhotonNetwork.LoadLevel(random);
            }
            if (scripts.GetComponent<CrearCasilla>().casillas[casillaActual].GetComponent<Casilla>().esPintada == true)
            {
                esPintado = true;
            }
            else
            {
                esPintado = false;
            }
            if (scripts.GetComponent<CrearCasilla>().casillas[casillaActual].GetComponent<Casilla>().esDesLeonn == true)
            {
                if (ph >= 1) { ph = ph - 1; } else { ph = 0; }
                scripts.GetComponent<Habilidades>().verCasiHab1Zor = false;
                //falta que los puntos robados vayan a leonn 
            }
            if (scripts.GetComponent<CrearCasilla>().casillas[casillaActual].GetComponent<Casilla>().esDesLeonn2 == true)
            {
                if (ph >= 2) { ph = ph - 2; } else { ph = 0; }
                scripts.GetComponent<Habilidades>().verCasiHab1Zor = false;
                //falta que los puntos robados vayan a leonn 
            }
            verificado = false;
            condi = false; 
            imprimePh();
            scripts.GetComponent<Habilidades>().verCasiHab1Zor = false;
        }        
    }
    
}
