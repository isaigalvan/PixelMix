using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granizo : MonoBehaviour
{
    public float tiempo;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = Time.deltaTime + tiempo;
        destruir();
    }

    public void destruir()
    {
        if (tiempo >= 2.5f)
        {
            Destroy(gameObject);
        }
    }
}
