using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
 
   

   void OnTriggerEnter2D(Collider2D other)
   {
      PlayerController controller = other.GetComponent<PlayerController>(); //Checks to see if the object has a playercontroller.
    if (controller != null)
    {
      controller.ChangeHealth(1);
      Destroy(gameObject);
    }

      Debug.Log("Object that entered the trigger: " + other);

   } 

}
