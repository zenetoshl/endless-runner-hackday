using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemF : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private bool onSreen = false;

    void OnTriggerEnter2D(Collider2D collider)
   {
    if(collider.gameObject.tag == "Player"){
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
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
