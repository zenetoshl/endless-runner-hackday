using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGravidade : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private bool onSreen = false;

    void OnTriggerEnter2D(Collider2D collider)
   {
    if(collider.gameObject.tag == "Player"){
        Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
        Transform transform = collider.gameObject.GetComponent<Transform>();
        Player p = collider.gameObject.GetComponent<Player>();

        p.forcaPulo *= -1;
        rb.gravityScale *= -1;
        transform.Rotate(new Vector3(180.0f, 0.0f, 0.0f), Space.World);
        Destroy(this.gameObject);
        }
   }

   private void OnTriggerExit2D(Collider2D other) {
       if(!onSreen){
           onSreen = true;
       }
        else{
            Destroy(this.gameObject);
        }
   }

   private void FixedUpdate() {
       Vector3 move = new Vector3(- 1.0f, 0.0f, 0.0f);
       this.transform.position = speed * move * Time.deltaTime + this.transform.position;
   }

}
