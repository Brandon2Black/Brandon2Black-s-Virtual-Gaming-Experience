using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
 public AudioClip DamageSound;
   void OnTriggerStay2D(Collider2D other)
   {
      PlayerController controller = other.GetComponent<PlayerController>(); //Checks to see if the object has a playercontroller.
    if (controller != null && controller.health > 0)
    {
      controller.ChangeHealth(-1);
     // controller.PlaySound(DamageSound);
      //Destroy(gameObject);
    }

      Debug.Log("Object that got hit: " + other);

   } 

}
