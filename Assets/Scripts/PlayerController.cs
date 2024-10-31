using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction leftAction;
    public InputAction moveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    // Start is called before the first frame update

    void Start()
    {
     leftAction.Enable();
     moveAction.Enable();
     rigidbody2d = GetComponent<Rigidbody2D>();

     //QualitySettings.vSyncCount = 0;
     //Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
      //Stores vector 2 value for movement.
       move = moveAction.ReadValue<Vector2>();
        //display in console
        Debug.Log(move);
        //handling said plr movement stuf.
        //Vector2 position = (Vector2)transform.position + move * 7.0f * Time.deltaTime;
        //transform.position = position;
        //position.x = position.x + 0.04f * horizontal;
        //position.y = position.y + 0.04f * vertical;
    }

    void FixedUpdate()
   {
       Vector2 position = (Vector2)rigidbody2d.position + move * 7.0f * Time.deltaTime;
       rigidbody2d.MovePosition(position);
   }
}
