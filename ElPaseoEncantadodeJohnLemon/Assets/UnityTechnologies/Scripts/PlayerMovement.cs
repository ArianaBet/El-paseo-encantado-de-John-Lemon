using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   public float turnSpeed = 20f;

    Animator m_Animator;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    Rigidbody m_Rigidbody;
    m_Rigidbody = GetComponent<Rigidbody>();

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        m_movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool IsWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.Setbool("IsWalking", isWalking); //Set bool es el metodo con dos parametros, uno del nombre del parametro Animator y otro del valor que quieres reestablecer para ese objeto


        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    
    
    }
}
