using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction leftAction;
    public InputAction moveAction;
    public int maxHealth = 5; //Creats integer "maxHealth" and sets it equal to 5.
    int currentHealth;

   public int health { get { return currentHealth; }}

    Rigidbody2D rigidbody2d;
    Vector2 move;
    public float speed = 7.0f;
    // Start is called before the first frame update

    void Start()
    {
     leftAction.Enable();
     moveAction.Enable();
     rigidbody2d = GetComponent<Rigidbody2D>();
     currentHealth = maxHealth;
     //QualitySettings.vSyncCount = 0;
     //Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
      //Stores vector 2 value for movement.
       move = moveAction.ReadValue<Vector2>();
        //display in console
        //Debug.Log(move);
    }

    void FixedUpdate()
   {
       Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
       rigidbody2d.MovePosition(position);
   }

   public void ChangeHealth (int amount)
   {
    currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    Debug.Log(currentHealth + "/" + maxHealth);
   }
}
