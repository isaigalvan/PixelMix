using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dardo : MonoBehaviour
{
    public Rigidbody2D rb, hookrb;
    public int numDard;
    public SpringJoint2D SJ;
    private bool presionado;
    public float tiempoLiberado = 0.15f;
    public float maxEstirado = 2f;
    public GameObject nuevoDardo, hook, scripts;

    private void Start()
    {
        hook = GameObject.Find("Hook");
        hookrb = hook.gameObject.GetComponent<Rigidbody2D>();
        SJ = gameObject.GetComponent<SpringJoint2D>();
        SJ.connectedBody = hookrb;
        scripts = GameObject.Find("Scripts");
    }
    // Update is called once per frame
    void Update()
    {
       // transform.Rotate(0, 0, 0);
        if (presionado)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector3.Distance(pos , hookrb.position) > maxEstirado)
            {
                rb.position = hookrb.position + (pos - hookrb.position ).normalized * maxEstirado;
            }
            else
            {
                rb.position = pos;
            }
           
        }
    }

    private void OnMouseDown()
    {
        presionado = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        presionado = false;
        rb.isKinematic = false;
        StartCoroutine( Liberar());
    }

    IEnumerator Liberar()
    {
        yield return new WaitForSeconds(tiempoLiberado);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
       
        yield return new WaitForSeconds(3f);
        nuevoDardo.SetActive(true);
        scripts.GetComponent<CrearDardos>().dardoEnJuego++;
        scripts.GetComponent<CrearDardos>().yaTermino = true;
    }

   
}
