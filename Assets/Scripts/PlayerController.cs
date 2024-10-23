using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction leftAction;
    public InputAction moveAction;
    // Start is called before the first frame update

    void Start()
    {
     leftAction.Enable();
     moveAction.Enable();

     //QualitySettings.vSyncCount = 0;
     //Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
      //Stores vector 2 value for movement.
        Vector2 move = moveAction.ReadValue<Vector2>();
        //display in console
        Debug.Log(move);
        //handling said plr movement stuf.
        Vector2 position = (Vector2)transform.position + move * 5.0f * Time.deltaTime;
        transform.position = position;
        //position.x = position.x + 0.04f * horizontal;
        //position.y = position.y + 0.04f * vertical;
    }
}
