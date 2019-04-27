using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viento : MonoBehaviour
{
    public BoxCollider2D bc;
    public Rigidbody2D rbDardo;
    public GameObject dardo;
    public float tiempo;

    // Update is called once per frame
    void Update()
    {
        dardo = GameObject.FindGameObjectWithTag("dardo");
        rbDardo = dardo.gameObject.GetComponent<Rigidbody2D>();
        tiempo = Time.deltaTime + tiempo;
        destruir();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dardo")
        {
            rbDardo.velocity = new Vector3(rbDardo.velocity.x-9, rbDardo.velocity.y);
        }
    }

    public void destruir()
    {
        if(tiempo>= 1.40f)
        {
            Destroy(gameObject);
        }
    }
}
