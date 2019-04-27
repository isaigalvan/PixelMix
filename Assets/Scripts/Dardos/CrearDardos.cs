using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearDardos : MonoBehaviour
{
    public int total, dardoEnJuego;
    public GameObject DardoPrefab, dardo;
    public Transform dardosParent;
    public List<GameObject> dardos = new List<GameObject>();
    public bool yaTermino;
    // Start is called before the first frame update
    void Start()
    {
        Crear();
        esconder();
    }
    private void Update()
    {
        dardo = GameObject.Find("dardo" + (dardoEnJuego-1));
        destruir();
    }
    public void Crear()
    {
        total = 30;
        for (int i = 0; i < total; i++)
        {

            GameObject dardoTemp = Instantiate(DardoPrefab, new Vector3(-5.69f, 0.85f, 0), Quaternion.Euler(new Vector3(0,0, 0)));
            dardos.Add(dardoTemp);
            dardoTemp.name = "dardo" + i + "";

            dardoTemp.transform.parent = dardosParent;
            
        }
        ObtenerDardo();
    }

    public void ObtenerDardo()
    {
        for (int i = 0; i <total; i++)
        {
            dardos[i].GetComponent<Dardo>().nuevoDardo = GameObject.Find("dardo" + (i + 1));
        }
    }

    public void esconder()
    {
        for (int i = 1; i < total; i++)
        {
            dardos[i].SetActive(false);
        }
    }

    public void destruir()
    {
        if (yaTermino == true)
        {
            Destroy(dardo);
            yaTermino = false;
        }
       
    }

}

