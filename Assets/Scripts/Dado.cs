using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dado : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Marco;
    public GameObject Habilidades,btnHab1,btnHab2,btnHab3,mapa,personaje,objPH;
    public TextMeshProUGUI contDado;
    public bool esTurno=false, seDetuvo=false, caminando=false;
    public float  caminarCasilla, destino,posReal;
    public int valorDado = 1, valorMax = 6 , valHab3Len;
    public bool yaTiro = false, verificado;
    public Sprite[] PH;
    public SpriteRenderer spriteR;

    private float tiempo, tiempoPH;
    private int  valorAnimPH = 0, valAnterior = 1;

    // Update is called once per frame
    /// <summary>
    ///  Update
    ///  Este metodo se llama una vez por frame
    ///  Manda a llamar los metodos "estadoDado", "estadoHabilidades", "contador", "animaPH", ademas de incrementa la variable tiempo, 1 por segundo
    ///  ademas busca al objeto con la etiqueta "Personaje" y lo guarda en el objeto "personaje" y  busca al objeto con la etiqueta "AnimaPH" y 
    ///  lo guarda en el objeto "objPH"
    /// </summary>
    void Update()
    {
        personaje = GameObject.FindGameObjectWithTag("PerPref");
        objPH = GameObject.FindGameObjectWithTag("AnimaPH");
        tiempo = Time.deltaTime + tiempo;
        tiempoPH = Time.deltaTime + tiempoPH;
        estadoDado();
        estadoHabilidades();
        contador();
        animaPH();
        caminar();
        
    }

    /// <summary>
    /// animaPH
    /// este metodo es llamado por Update
    /// si la variable "tiempoPH" es mayor a 0.1, la variable "tiempoPH" adquiere el valor de 0, en caso de que la variable "valorAnimPH" sea igual a 2, "valorAnimPH"
    /// adquiere el valor de 0 de lo contrario "valorAnimPH" se incrementa por 1, si "tiempoPH" es menor a 0.1, el objeto spriteR guarda el componente SpriteRenderer
    /// del objeto "objPH" y despues la propiedad "sprite" del objeto "spriteR" adquiere el sprite de la posicion "valorAnimPH" del arreglo PH
    /// </summary>
    public void animaPH()
    {
        if(tiempoPH >= 0.1f) {
            tiempoPH = 0;
            if (valorAnimPH == 2)
            {valorAnimPH = 0;}
            else { valorAnimPH++; }
           }
        spriteR = objPH.GetComponent<SpriteRenderer>();
        spriteR.sprite = PH[valorAnimPH];
    }

    /// <summary>
    /// contador
    /// Este metodo es llamado por Update y genera el valor de un dado incrementandolo de 1 hasta su valor maximo hasta que el usuario lo detenga mediante una variable booleana
    /// Primero verifica si la variable "seDetuvo" es falsa, en caso de que se cumpla este caso significa que el usuario no ha tirado el dado por lo tanto 
    /// la variable "yaTiro" se le otroga el valor de false, se coloca una condicion, si la variable "tiempo" es mayor a 0.08 , la variable tiempo adquiere el valor de 
    /// 0, ademas la variable "valorDado" adquiere un valor aleatorio entre 1 y "valMax"+1 cada 0.08 segundos, se tiene una variable "valAnterior" para evitar que 
    /// se repita se manera seguida el valor aleatorio cada 0.08 segundos, haciendo que si "valorDado" es igual a "valAnterior" se obtenga otro valor aleatorio hasta que
    /// "valorDado" sea diferente a "valAterior"
    /// En caso que el usuario detenga el dado, osease si la variable "seDetuvo" es igual a true, el texto cambiara a color rojo igualando el color del texto a 
    /// color.red y si el valor de "tiempo" es mayor o igual a 1.5, la variable "casillaActual" se le sumara lo que se obtuvo en "valorDado", ademas las variables
    /// "esTurno" y "seDetuvo" adquiriran el valor de false
    /// </summary>
    public void contador()
    {
        if (seDetuvo == false)
        {
            yaTiro = false;
            contDado.color = Color.black;
            if (tiempo >= 0.08f)
            {
                tiempo = 0.0f;
                valorDado = Random.Range(1, valorMax+1);      
                do 
                {
                 valorDado = Random.Range(1, valorMax + 1);
                } while (valorDado == valAnterior) ;
                valAnterior = valorDado;
                if (GetComponent<Habilidades>().repite == true) { valHab3Len = valorDado; }
            }
        }
        else
        {
            mapa.SetActive(false);
            contDado.color = Color.red;
           
            if (tiempo >= 1.5f)
            {
                if (GetComponent<Habilidades>().repite == true)
                {
                    
                    esTurno = true;
                    seDetuvo = false;
                    GetComponent<Habilidades>().repite = false;
                }
                else
                {
                    valorDado = valHab3Len + valorDado;
                    personaje.GetComponent<Personaje>().casillaActual = personaje.GetComponent<Personaje>().casillaActual + valorDado;
                    destino = valorDado;
                    esTurno = false;
                    seDetuvo = false;
                    caminando = true;
                    personaje.GetComponent<Animator>().SetBool("isWalking", true);
                    valorMax = 6;
                    GetComponent<Habilidades>().usoHab = false;
                    if(GetComponent<CrearPersonaje>().idPersonaje==5){GetComponent<Habilidades>().esHab3 = false;}
                }
            }
            
        }
        

    }

    public void casillaOcupada(){
        if (yaTiro == true)
        {

        }
    }


/// <summary>
/// estadoDado
/// este metodo es llamado por Update
/// Verifica si ya es el turno del jugador y por lo tanto activa el dado para que se imprima los valores del dado y que pueda tirar o desactiva el dado
/// si ya paso su turno. Se verifica si la variable "esTurno" es verdadera, si es asi entonces activamos los objetos guardados en la variable "Marco" mediante 
/// .SetActive y se imprime el valor de la variable "valorDado" en el objeto de texto "contDado", en caso de que no sea turno, los objetos guardados en 
/// "Marco" se desactivaran y el valor del dado permanecera en 1 igualando la variable "valorDado" a 1.
/// </summary>
public void estadoDado()
    {
        if (esTurno == true)
        {
            mapa.SetActive(true);
            Marco.SetActive(true);
            contDado.text = "" + valorDado;
        }
        else
        {
           
            Marco.SetActive(false);
            valorDado = 1;
        }
    }
    
    /// <summary>
    /// parar
    /// Este metodo es llamado por el boton "parar", este boton hace que el dado se detenga 
    /// asigna el valor "true" a las variables "yaTiro" y "seDetuvo"
    /// </summary>
    public void parar()
    {
        yaTiro = true;
        seDetuvo = true;
    }

    /// <summary>
    /// estadoHabilidades
    /// Lo invoca el metodo Update, se encarga de habilitas y desabilitar los botones para accionar las habilidades,
    /// primero verifica si las variables "yaTiro" es true y "esTurno" es false, en caso de que se cumpla, significa que el jugador no puede usar los botones 
    /// de las habilidades por lo cual desactiva los objetos guardados en "Habilidades" mediante .SetActive, de caso contrario activa los objetos guardados en
    /// "Habilidades" para despues comparar el valor de la variable "ph", con los valores estaticos de 1,2 e igual o mayor a 3, en caso de que "ph" sea igual a 1, 
    /// activa el objeto guardado en "btnhab1" y desactiva "btnhab2" y "btnhab3", en caso de que "ph" sea igual a 2, activa el objeto guardado en "btnhab1","btnhab2" 
    /// y desactiva "btnhab3" y en caso de que "ph" sea mayor o igual a 3, activara "btnhab1", "btnhab2" y "btnhab3"
    /// 
    /// </summary>
    public void estadoHabilidades()
    {
        if (yaTiro == true || esTurno == false || GetComponent<Habilidades>().usoHab == true|| personaje.GetComponent<Personaje>().esPintado==true)
        {
            Habilidades.SetActive(false);
        }
        else
        {
            Habilidades.SetActive(true);
            if (personaje.GetComponent<Personaje>().ph == 0)
            {
                Habilidades.SetActive(false);
            }
            if (personaje.GetComponent<Personaje>().ph == 1)
            {
                btnHab1.SetActive(true);
                btnHab2.SetActive(false);
                btnHab3.SetActive(false);
            }
            if (personaje.GetComponent<Personaje>().ph == 2)
            {
                btnHab1.SetActive(true);
                btnHab2.SetActive(true);
                btnHab3.SetActive(false);
            }
            if (personaje.GetComponent<Personaje>().ph >= 3)
            {
                btnHab1.SetActive(true);
                btnHab2.SetActive(true);
                btnHab3.SetActive(true);
            }
        }
    }

    public void caminar()
    {
        if (caminando==true) {
           
            if(caminarCasilla <= destino*2) { 
                GetComponent<CrearPersonaje>().posx = GetComponent<CrearPersonaje>().posx + 0.05f;
                caminarCasilla = caminarCasilla + 0.05f;
                personaje.transform.localPosition = new Vector3(GetComponent<CrearPersonaje>().posx, GetComponent<CrearPersonaje>().posy);
            } 
            else
            {
                if (caminarCasilla > destino * 2) {
                    posReal = caminarCasilla - destino * 2;
                    GetComponent<CrearPersonaje>().posx = GetComponent<CrearPersonaje>().posx - posReal;
                    personaje.transform.localPosition = new Vector3(GetComponent<CrearPersonaje>().posx, GetComponent<CrearPersonaje>().posy);
                }
                personaje.GetComponent<Animator>().SetBool("isWalking", false);
                caminando = false;
                caminarCasilla = 0;
                GetComponent<Dado>().valHab3Len = 0;
            }

        }
        
    }
}
