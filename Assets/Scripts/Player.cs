using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   public float velocidadeMaxima;
    public float forcaPulo;
    private bool estaColidindo;
    Animator animator;

    private void Start() {
        this.animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float movimento = Input.GetAxis("Horizontal");
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(movimento * velocidadeMaxima, this.GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (estaColidindo)
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forcaPulo));
            }
        }
        //Animação de pular
        if (estaColidindo)
        {
            this.animator.SetBool("pular", false);
        }
        else
        {
            this.animator.SetBool("pular", true);
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
