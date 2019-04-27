using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float tiempo;
    private Vector3 offset;
    public bool seDetuvo = false;

    void Update()
    {
        if (seDetuvo == false) { tiempo = Time.deltaTime + tiempo; }
        asignar();
    }
    void Start()
    {

        
    }
    public void asignar()
    {
        if(tiempo >= 0.01f)
        {
            player = GameObject.FindGameObjectWithTag("PerPref");
            offset = transform.position - player.transform.position;
            seDetuvo = true;
            tiempo = 0;
        }
        
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
