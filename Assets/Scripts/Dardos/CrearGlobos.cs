using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearGlobos : MonoBehaviour
{
    public int total;
    public float posx, posy;
    public GameObject GloboPrefab;
    public Transform ListaGlobos;
    public List<GameObject> globos = new List<GameObject>();
    public bool[] Exploatdos = new bool[7];
    public float[] tiempo = new float[7];
    // Start is called before the first frame update
    void Start()
    {
        Crear();
    }

    // Update is called once per frame
    void Update()
    {
        verifExplotados();
        revivir();
    }
    public void Crear()
    {
        total = 7;
        posy = 4; posx = 6.4f;
        for (int i = 0; i < total; i++)
        {

            GameObject GloboTemp = Instantiate(GloboPrefab, new Vector3(posx, posy, 0), Quaternion.Euler(new Vector3(0, 180, -90)));
            globos.Add(GloboTemp);
            GloboTemp.name = "Globo" + i + "";

            GloboTemp.transform.parent = ListaGlobos;
            posy = posy - 1.3f;

        }
    }

    public void revivir()
    {
        for (int x = 0; x < 7; x++)
        {
            if (tiempo[x] >= 5f)
            {
                globos[x].SetActive(true);
                Exploatdos[x] = false;
                tiempo[x] = 0;
            }
        }
    }

    public void verifExplotados()
    {
        for (int x = 0; x < 7; x++)
        {
            if (Exploatdos[x] == true)
            {
                tiempo[x] = Time.deltaTime + tiempo[x];
            }
        }
    }

}
