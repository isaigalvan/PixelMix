using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicadores : MonoBehaviour
{
    public Sprite[] DadoBuff, DadoNerf;   
    public GameObject inmu, pintu, bloq, atrac, buff, nerf, scripts;
    public SpriteRenderer spriteRBuff, spriteRNerf;

    private int valAnimBuff, valAnimNerf;
    private float tiempoDado, tiempoFrame;
    private bool actTiempo, actFrame;
    // Start is called before the first frame update
    void Start()
    {
        inmu = GameObject.FindGameObjectWithTag("ObjInmune");
        pintu = GameObject.FindGameObjectWithTag("ObjPintura");
        bloq = GameObject.FindGameObjectWithTag("ObjBloqueado");
        atrac = GameObject.FindGameObjectWithTag("ObjAtraccion");
        buff = GameObject.FindGameObjectWithTag("ObjBuff");
        nerf = GameObject.FindGameObjectWithTag("ObjNerf");
        scripts = GameObject.Find("Scripts");
        alturas();
    }

    // Update is called once per frame
    void Update()
    {
        if (actTiempo == true) { tiempoDado = Time.deltaTime + tiempoDado; }
        if (actFrame == true) { tiempoFrame = Time.deltaTime + tiempoFrame; }
        estadoIndicadores();
    }


    public void estadoIndicadores()
    {
        animaBuff();
        animaNerf();
        bloqueado();
        pintado();
        atraccion();
        inmune();
    }

    public void alturas()
    {
        switch (scripts.GetComponent<CrearPersonaje>().idPersonaje)
        {
            case 0:
            case 4: 
                inmu.transform.localPosition = new Vector3(4,8f);
                pintu.transform.localPosition = new Vector3(1.5f, 8f);
                bloq.transform.localPosition = new Vector3(-3.56f, 8f);
                atrac.transform.localPosition = new Vector3(-0.83f, 8);
                buff.transform.localPosition = new Vector3(1.8f,10.8f);
                nerf.transform.localPosition = new Vector3(-1.6f,10.8f);
                break;
            case 3:
                inmu.transform.localPosition = new Vector3(4, 6f);
                pintu.transform.localPosition = new Vector3(1.5f, 6f);
                bloq.transform.localPosition = new Vector3(-3.56f, 6f);
                atrac.transform.localPosition = new Vector3(-0.83f, 6);
                buff.transform.localPosition = new Vector3(1.8f, 8.8f);
                nerf.transform.localPosition = new Vector3(-1.6f, 8.8f);
                break;
            case 5:
                inmu.transform.localPosition = new Vector3(4, 5f);
                pintu.transform.localPosition = new Vector3(1.5f, 5f);
                bloq.transform.localPosition = new Vector3(-3.56f, 5f);
                atrac.transform.localPosition = new Vector3(-0.83f, 5);
                buff.transform.localPosition = new Vector3(1.8f, 7.8f);
                nerf.transform.localPosition = new Vector3(-1.6f, 7.8f);
                break;
            default:
                break;
        }
    }
    public void animaBuff()
    {
        if (GetComponent<Personaje>().esBuff == true)
        {
            actTiempo = true;
            actFrame = true;
            
            if (tiempoDado <= 2.5f)
            {
                buff.SetActive(true);
                if (tiempoFrame >= 0.1f)
                {
                    if (valAnimBuff == 2)
                    { valAnimBuff = 0; }
                    else { valAnimBuff++; }
                    tiempoFrame = 0;
                }
                spriteRBuff = buff.GetComponent<SpriteRenderer>();
                spriteRBuff.sprite = DadoBuff[valAnimBuff];
            }
            else{buff.SetActive(false);actFrame = false;actTiempo = false;tiempoDado = 0;tiempoFrame = 0; GetComponent<Personaje>().esBuff = false; }
        }
        else {buff.SetActive(false);}
    }

    public void animaNerf()
    {
        if (GetComponent<Personaje>().esNerf == true)
        {
            actTiempo = true;
            actFrame = true;

            if (tiempoDado <= 2.5f)
            {
                nerf.SetActive(true);
                if (tiempoFrame >= 0.1f)
                {                   
                    if (valAnimNerf == 2)
                    { valAnimNerf = 0; }
                    else { valAnimNerf++; }
                    tiempoFrame = 0;
                }
                spriteRNerf = nerf.GetComponent<SpriteRenderer>();
                spriteRNerf.sprite = DadoNerf[valAnimNerf];
            }
            else { nerf.SetActive(false); actFrame = false; actTiempo = false; tiempoDado = 0; tiempoFrame = 0; GetComponent<Personaje>().esNerf = false; }
        }
        else { nerf.SetActive(false); }
    }

    public void atraccion()
    {
        if (GetComponent<Personaje>().esAtraido == true) {
            atrac.SetActive(true);
        }
        else
        {
            atrac.SetActive(false);
        }
    }
    public void bloqueado()
    {
        if (GetComponent<Personaje>().esBloqueado == true)
        {
            bloq.SetActive(true);
        }
        else
        {
            bloq.SetActive(false);
        }  
    }
    public void pintado()
    {
        if (GetComponent<Personaje>().esPintado == true)
        {
            pintu.SetActive(true);
        }
        else
        {
            pintu.SetActive(false);
        }
    }
    public void inmune()
    {
        if (GetComponent<Personaje>().esInmune == true)
        {
            inmu.SetActive(true);
        }
        else
        {
            inmu.SetActive(false);
        }
        
    }
}
