using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    
    public int idCarta = 0;
    public Vector3 posicionOriginal;
    public Texture2D texturaAnverso;
    public Texture2D texturaReverso;
    public int tiempo;
    public GameObject crearCartas;
    public bool seMuestra;

    /// <summary>
    /// Awake
    /// al ejecutarse el programa se busca el objeto llamado "Scripts" y se guarda en el objeto "crearCartas"
    /// </summary>
    private void Awake()
    {
        crearCartas = GameObject.Find("Scripts");
    }

    /// <summary>
    /// Start
    /// Al ejecutarse el programa oculta los sprites de las cartas mostrando el "reverso" de la carta, invoca "EsconderCarta"
    /// </summary>
    private void Start()
    {
        EsconderCarta();
    }
   
    /// <summary>
    /// OnMouseDown 
    /// Al hacer clic en una carta manda a llamar MostrarCarta e imprimir en la consola la id de la carta que se mostro mediante print
    /// </summary>
    private void OnMouseDown()
    {
        print(idCarta.ToString());
        MostrarCarta();
    }


    /// <summary>
    /// AsignarTextura
    /// Le asigna un sprite a una carta, lo invoca "AsignarTexturas" en el script "CrearCarta" y recibe como parametro una Textura2D llamada "_textura"
    /// la variable "TexturaAnverso" de la carta se iguala a la textura que se recibio como parametro 
    /// </summary>
    /// <param name="_textura"></param>
    public void AsignarTextura(Texture2D _textura)
    {
        texturaAnverso = _textura;
    }

    /// <summary>
    /// MostrarCarta
    /// Es invocado por "OnMouseDown", cuado se de clic mostrar el sprite del anverso de la carta
    /// Verifica si la carta aun no esta mostrada con la variable "seMuestra" ademas con la variable "sePuedeMostrar" del script "CrearCarta", si esta condicion 
    /// se cumple la variable "seMuestra" adquiere el valor de true, ademas la textura de la carta se iguala a "texturaAnverso" y por ultimo se manda a llamar el metodo 
    /// "hacerClick" en el script "CrearCarta"
    /// </summary>
    public void MostrarCarta()
    {
        if (!seMuestra && crearCartas.GetComponent<CrearCarta>().sePuedeMostrar)
        {
            seMuestra = true;
            GetComponent<MeshRenderer>().material.mainTexture = texturaAnverso;
            crearCartas.GetComponent<CrearCarta>().hacerClick(this);
            
        }
    }

    /// <summary>
    /// EsconderCarta
    /// lo invoca "Start" y "hacerClick" del script "CrearCarta", este metodo invoca "Esconder" despues de un tiempo establecido por la variable "tiempo" 
    /// ademas la variable "sePuedeMostrar" del script "CrearCarta" adquiere el valor de false
    /// </summary>
    public void EsconderCarta()
    {
        Invoke("Esconder", tiempo);
        crearCartas.GetComponent<CrearCarta>().sePuedeMostrar = false;


    }

    /// <summary>
    /// Esconder
    /// cambia la textura de anverso por la de reverso, haciendo que la carta "se oculte", lo invoca el metodo "EsconderCarta"
    /// Se coloca el sprite de reverso de la carta igualando su "mainTexture" con "texturaReverso"
    /// la variable "seMuestra" adquiere el valor de false mientras que la variable "sePuedeMostrar" adquiere el valor de true
    /// </summary>
    void Esconder()
    {
        GetComponent<MeshRenderer>().material.mainTexture = texturaReverso;
        seMuestra = false;
        crearCartas.GetComponent<CrearCarta>().sePuedeMostrar = true;
    }
}
