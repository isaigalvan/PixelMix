using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrearCarta : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public GameObject CartaPrefab;
    public int Ancho = 4, posx, posy;
    public Material[] materiales;
    public Texture2D[] texturas;
    public Transform CartasParent;
    private List<GameObject> cartas = new List<GameObject>() ;
    public int contador;
    public TextMeshProUGUI textCont;
    public Carta cartaMostrada;
    public bool sePuedeMostrar = true;
    public TextMeshProUGUI Tiempo;
    public float tiempo = 60.0f;
    public AudioSource source { get { return GetComponent<AudioSource>(); } }
    public AudioClip clip;

    /// <summary>
    /// Start
    /// Al ejecutarse el programa crear las cartas
    /// Manda a llamar a "Crear"
    /// </summary>
    private void Start()
    {
        Crear();
        gameObject.AddComponent<AudioSource>();

    }

    /// <summary>
    /// 
    /// </summary>
    void PlaySound()
    {
        source.PlayOneShot(clip);
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnMouseDown()
    {
        PlaySound();
    }

    /// <summary>
    /// Update
    /// Este metodo se invoca una vez por cada frame, imprimiendo un contador de tiempo en el juego 
    /// Se usa la variable "tiempo" con una valor incial de 60, si "tiempo" es igual o menor a 0 se acaba el juego, de lo contrario se resta 1 cada segundo a
    /// la varible "tiempo"     
    /// </summary>
    private void Update()
    {
        if (tiempo <= 0.0f) 
        {
        }
        else
        {
            tiempo -= Time.deltaTime;
        }
        Tiempo.text = "Tiempo:" + "" + tiempo.ToString("f0");
    }

    /// <summary>
    /// Crear
    /// Crea las cartas en una posicion del tablero de forma que queden acomodadas en una matriz 4 x 4, lo hace asignando valores iniciales de
    /// "x" y "y" en las variables "posy" y "posx", por medio 2 "For" anidados, un for aumenta el valor de "posx" creando una carta en dicho lugar,
    /// despues de crear 4 cartas aumentando el valor de "posx", la variable posx se resetea a su valor inicial y se aumenta la variable "posy".
    /// se crea una carta guardandola en "Carta Temp" ya que ese objeto se guardara en la lista de "cartas" otorgandole una posicion guardandola en "posicionOriginal"
    /// y otorgandole una id a partir de la variable "cont" guardandolo en "idCarta"
    /// Despues de crear la matriz se invoca "AsignarTexturas" y "Barajar".
    /// Este metodo es invocado por "Start" (cuando se ejecuta el programa) 
    /// 
    /// </summary>
    public void Crear()
    {
        int cont = 0;
        posy = 55; posx = 250;
        for (int i = 0; i < Ancho; i++)
        {
            for (int x = 0; x < Ancho; x++)
            {
                GameObject cartaTemp = Instantiate(CartaPrefab, new Vector3(posx, posy, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
                cartas.Add(cartaTemp);
                cartaTemp.GetComponent<Carta>().posicionOriginal = new Vector3(posx, posy, 0);
                cartaTemp.GetComponent<Carta>().idCarta = cont;

                cartaTemp.transform.parent = CartasParent;
                posx = posx + 50;
                
                cont++;
            }
            posx = 250;
            posy = posy + 70;
        }
        AsignarTexturas();
        Barajar();
    }

    /// <summary>
    /// AsignarTexturas
    /// Este metodo es invocado por Crear. Le asigna un sprite a cada objeto de la lista "cartas", mediante un for el objeto de la posicion "i" de la lista de
    /// "cartas" hace uso de "AsignarTextura" del script "Carta" mandando como parametro un sprite de la lista de "texturas", se le asigna 1 mismo sprite cada 2
    /// cartas dividiendo la variable "i" entre 2 para tener las cartas pares, la variable "i" se incrementara por 1 mediante el for 
    /// </summary>
    void AsignarTexturas()
    {
        for(int i = 0;i<cartas.Count; i++)
        {
            cartas[i].GetComponent<Carta>().AsignarTextura(texturas[(i)/2]);
        }
    }

    /// <summary>
    /// Barajar
    /// Este metodo es llamado por "crear" ya que al crear la lista de cartas a estos se le asigna las sprites de forma ordenada, este metodo se encarga de 
    /// mover aleatoriamente la posicion de las cartas, mediante un for se obtiene un valor aletorio entre la variable "i" del for y el numero total de cartas que
    /// hay en la lista guardandolo en la variable "aleatorio", se realiza el metodo burbuja entre las 2 cartas a intercambiar, se guarda la posicion original del
    /// elemento "aleatorio" y se guarda en elemento "i" mediante tranform.position, se guarda la posicion original del elemento "i" y se guarda en elemento
    /// "aleatorio" mediante tranform.position. por ultimo los valores de las posiciones originales de los elementos "i" y "aleatorio" se igualan a las posiciones
    /// guardadas de de tranform.position de cada elemento
    /// </summary>
    void Barajar()
    {

        int aleatorio;
        for (int i = 0; i < cartas.Count; i++)
        {
            aleatorio = Random.Range(i, cartas.Count);
            cartas[i].transform.position = cartas[aleatorio].transform.position;
            cartas[aleatorio].transform.position = cartas[i].GetComponent<Carta>().posicionOriginal;

            cartas[i].GetComponent<Carta>().posicionOriginal = cartas[i].transform.position;
            cartas[aleatorio].GetComponent<Carta>().posicionOriginal = cartas[aleatorio].transform.position;


        }

    }

    /// <summary>
    /// hacerClick
    /// Este metodo es llamado por "MostrarCarta" del script Carta, se muestra una carta hasta que se muestre otra distinta para ser comparadas, en caso de ser iguales 
    /// se aumenta un punto, de lo contrario se ocultan las cartas.
    /// Se recibe como parametro un objeto del script carta, la carta a la cual se esta haciendo click, primero se verifica si se esta haciendo click en una carta
    /// aun no mostrada mediante la variable "cartaMostrada", de ser asi se muestra la carta, al hacer click a una carta cuando una ya fue mostrada, estas son comparadas llamando el metodo "CompararCartas"
    /// en caso de que se cumpla la condicion la variable "contador" se incrementa por 1 y se manda a llamar "actualizarUI", en caso de que no se cumpla la condicion 
    /// se manda a llamar el metodo "EsconderCarta" de solo las cartas que fueron mostradas y la variable "cartaMostrada" toma el valor de false
    /// </summary>
    /// <param name="_carta"></param>
     public void hacerClick(Carta _carta)
    {
        if (cartaMostrada == null)
        {
            cartaMostrada = _carta;
        }
        else
        {
            if (CompararCartas(_carta.gameObject, cartaMostrada.gameObject))
            {
                contador++;
                actualizarUI();
            }
            else
            {
                _carta.EsconderCarta();
                cartaMostrada.EsconderCarta();
            }
            cartaMostrada = null; 
             
        }
        
    }

    /// <summary>
    /// CompararCartas
    /// Este metodo es llamadado por "hacerClick", compara las texturas de las 2 cartas mostradas, si las cartas son iguales el metodo retorna un true
    /// de caso contrario retorna un false.
    /// Se recibe como parametros 2 objetos, en este caso "carta1" y "carta2", se crea la variable "resul" que almacenara un valor booleano, se compara si 
    /// la textura de "carta1" es igual a la de "carta2" es caso de que sean iguales la variable "resul" guarda el valor de true, de ser contrario guarda el valor de false
    /// por ultimo se retorna el valor de la variable "resul"
    /// </summary>
    /// <param name="carta1"></param>
    /// <param name="carta2"></param>
    /// <returns>resul</returns>
    public bool CompararCartas(GameObject carta1, GameObject carta2)
    {
        bool resul;
        if(carta1.GetComponent<MeshRenderer>().material.mainTexture== carta2.GetComponent<MeshRenderer>().material.mainTexture)
        {
            resul = true;
        }
        else
        {
            resul = false;
        }
        return resul;
    }

    /// <summary>
    /// actualizarUI
    /// Este metodo es llamado por "hacerClick", imprime los puntos del jugador en el minijuego
    /// imprime mediante .text en el cuadro de texto llamado textCont, "PUNTOS: " y el valor de la variable contador
    /// </summary>
    public void actualizarUI()
    {
        textCont.text = "PUNTOS:" + contador;
    }
}
