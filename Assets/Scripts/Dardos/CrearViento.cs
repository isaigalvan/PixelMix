using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearViento : MonoBehaviour
{
    public float tiempo, posx, posy;
    public GameObject vientoPrefab; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = Time.deltaTime + tiempo;
        crear();
    }
    public void crear()
    {
        if (tiempo >= 1.4f)
        {
            posy = Random.Range(-3.5f, 3.5f);
            posx = Random.Range(-3.5f, 5f);
            GameObject GloboTemp = Instantiate(vientoPrefab, new Vector3(posx, posy, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            tiempo = 0; 
        }
    }
    
}
