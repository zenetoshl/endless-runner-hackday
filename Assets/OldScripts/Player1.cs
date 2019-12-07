using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{   public float velocidadeMaxima;
    public float forcaPulo;
    public bool estaColidindo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Animator animator = GetComponent<Animator>();

        float movimento = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(movimento * velocidadeMaxima, rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (estaColidindo)
            {
                rigidbody.AddForce(new Vector2(0, forcaPulo));
            }
        }
        //Animação de pular
        if (estaColidindo)
        {
            GetComponent<Animator>().SetBool("pular", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("pular", true);
        }
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
