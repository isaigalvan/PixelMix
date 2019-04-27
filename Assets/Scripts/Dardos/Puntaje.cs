using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    public TextMeshProUGUI textCont, Tiempo;
    public int puntos;
    public float tiempo=60; 

    private void Update()
    {
        actualizarUI();
        if (tiempo <= 0.0f)
        {
        }
        else
        {
            tiempo -= Time.deltaTime;
        }
    }

    public void actualizarUI()
    {
        textCont.text = "PUNTOS:" + puntos;
        Tiempo.text = "Tiempo:" + "" + tiempo.ToString("f0");
    }
}
