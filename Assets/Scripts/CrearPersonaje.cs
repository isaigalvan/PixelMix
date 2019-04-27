using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrearPersonaje : MonoBehaviour
{
    public float posx, posy, posx2, posy2;
    public int idPersonaje,total;
    public GameObject personajePrefab, per,personajeTemp;
    public Transform personajeParent;
    public Sprite[] sprites;
    public GameObject IconoPrefab;
    public Transform IconoParent;
    public List<GameObject> iconos = new List<GameObject>();
    
    void Start()
    {
        Crear();
        crearIconos();
    }

    public void Crear()
    {
        posy = 4.5f; posx = 5;
        AsignarCoord();
        personajeTemp = Instantiate(personajePrefab, new Vector3(posx, posy, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        personajeTemp.transform.parent = personajeParent;
        AsignarNombres();
        per = GameObject.FindGameObjectWithTag("PerPref");
        per.GetComponent<Personaje>().AsignarTamanos();
        AsignarTexturas();  
    }

    public void crearIconos()
    {
        total = 3;
        posx2 = 2.57f;
        posy2 = -1.45f;
        for (int i = 0; i < total; i++)
        {

            GameObject iconoTemp = Instantiate(IconoPrefab, new Vector3(posx2, posy2, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            iconos.Add(iconoTemp);
            iconoTemp.transform.parent = IconoParent;
            posx2 = posx2 + 1.92f;
        }
        iconosPersonajes();
    }

    public void iconosPersonajes()
    {
        switch (idPersonaje)
        {
            case 0:
                iconos[0].GetComponent<Icono>().AsignarTextura(sprites[0]);
                iconos[1].GetComponent<Icono>().AsignarTextura(sprites[1]);
                iconos[2].GetComponent<Icono>().AsignarTextura(sprites[2]);
                break;
            case 1:
                iconos[0].GetComponent<Icono>().AsignarTextura(sprites[3]);
                iconos[1].GetComponent<Icono>().AsignarTextura(sprites[4]);
                iconos[2].GetComponent<Icono>().AsignarTextura(sprites[5]);
                break;
            case 2:
                iconos[0].GetComponent<Icono>().AsignarTextura(sprites[6]);
                iconos[1].GetComponent<Icono>().AsignarTextura(sprites[7]);
                iconos[2].GetComponent<Icono>().AsignarTextura(sprites[8]);
                break;
            case 3:
                iconos[0].GetComponent<Icono>().AsignarTextura(sprites[9]);
                iconos[1].GetComponent<Icono>().AsignarTextura(sprites[10]);
                iconos[2].GetComponent<Icono>().AsignarTextura(sprites[11]);
                break;
            case 4:
                iconos[0].GetComponent<Icono>().AsignarTextura(sprites[12]);
                iconos[1].GetComponent<Icono>().AsignarTextura(sprites[13]);
                iconos[2].GetComponent<Icono>().AsignarTextura(sprites[14]);
                break;
            case 5:
                iconos[0].GetComponent<Icono>().AsignarTextura(sprites[15]);
                iconos[1].GetComponent<Icono>().AsignarTextura(sprites[16]);
                iconos[2].GetComponent<Icono>().AsignarTextura(sprites[17]);
                break;
            default:
                break;
        }
    }

    public void AsignarCoord()
    {
        switch (idPersonaje)
        {
            case 0:
                posy = 2.7f;
                break;
            case 1:
                posy = 2.5f;
                break;
            case 2:
                posy = 2.4f;
                break;
            case 3:
                posy = 2.1f;
                break;
            case 4:
                posy = 2.7f;
                break;
            case 5:
                posy = 2.7f;
                break;
            default:
                break;
        }

    }
    public void AsignarNombres()
    {
        switch (idPersonaje)
        {
            case 0:
                personajeTemp.name = "Zorem";
                break;
            case 1:
                personajeTemp.name = "Ian";
                break;
            case 2:
                personajeTemp.name = "Austin";
                break;
            case 3:
                personajeTemp.name = "Rubi";
                break;
            case 4:
                personajeTemp.name = "Stella";
                break;
            case 5:
                personajeTemp.name = "Leonn";
                break;
            default:
                break;
        }
    }
    public void AsignarTexturas()
    {
        switch (idPersonaje)
        {
            case 0:
                per.GetComponent<Animator>().SetFloat("personaje", 1f);
                break;
            case 1:
                per.GetComponent<Animator>().SetFloat("personaje", 2f);
                break;
            case 2:
                per.GetComponent<Animator>().SetFloat("personaje", 3f);
                break;
            case 3:
                per.GetComponent<Animator>().SetFloat("personaje", 4f);
                break;
            case 4:
                per.GetComponent<Animator>().SetFloat("personaje", 5f);
                break;
            case 5:
                per.GetComponent<Animator>().SetFloat("personaje", 6f);
                break;
            default:
                break;
        }      

    }

   

}