using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputExample : MonoBehaviour
{
    public void ActionButtonSouuth(InputAction.CallbackContext callback)
    {
        Debug.Log("presionado boton sur");
    }
   //empezar
   //callback.started

    //cancela
    //callback.canceled

    //callback.duration

    // Update is called once per frame
    void Update()
    {
        
    }
}
