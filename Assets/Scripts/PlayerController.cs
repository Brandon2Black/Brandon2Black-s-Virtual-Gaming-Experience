using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //creating var to do plr movement stuf.
        float horizontal = 0.0f;
        float vertical = 0.0f;
        if(Keyboard.current.leftArrowKey.isPressed)
        {
          horizontal = -1.0f;
        }
     else if(Keyboard.current.rightArrowKey.isPressed)
        {
          horizontal = 1.0f;
        }
         if(Keyboard.current.upArrowKey.isPressed)
        {
          vertical = 1.0f;
        }
     else if(Keyboard.current.downArrowKey.isPressed)
        {
          vertical = -1.0f;
        }
         Debug.Log(horizontal);
         Debug.Log(vertical);
        //handling said plr movement stuf.
        Vector2 position = transform.position;
        position.x = position.x + 0.04f * horizontal;
        position.y = position.y + 0.04f * vertical;
        transform.position = position;
        
    }
}
