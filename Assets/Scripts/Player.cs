using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   public float velocidadeMaxima;
    public float forcaPulo;
    public bool estaColidindo;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
         rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimento = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimento * velocidadeMaxima, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (estaColidindo)
            {
                rb.AddForce(new Vector2(0, forcaPulo));
            }
        }
        //Animação de pular
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plataforma"))
        {
            estaColidindo = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plataforma"))
        {
            estaColidindo = false;
        }
    }
}
