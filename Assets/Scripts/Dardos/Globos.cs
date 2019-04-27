using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globos : MonoBehaviour
{
    public float vidaGlobo = 15f;
    public GameObject scripts;
    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        Debug.Log(colInfo.relativeVelocity.magnitude);
        if (colInfo.relativeVelocity.magnitude > vidaGlobo)
        {
            explota();
            
        }
    }

    void explota()
    {
        gameObject.SetActive(false);
        nombres();
        scripts.GetComponent<Puntaje>().puntos = scripts.GetComponent<Puntaje>().puntos + 1;
    }

    private void Start()
    {
        scripts = GameObject.Find("Scripts");
    }

    public void nombres()
    {
        for(int z = 0; z<7; z++)
        {
            if (gameObject.name == "Globo" + (z))
            {
                scripts.GetComponent<CrearGlobos>().Exploatdos[z] = true;
            }
        }
       
    }
}
