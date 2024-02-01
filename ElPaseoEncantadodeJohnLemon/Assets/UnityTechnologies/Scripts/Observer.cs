using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
  
    bool m_IsPlayerInRange;

    public AudioSource enemielook;
    bool m_EnemieIslooking;
    bool m_AudioHasPlayed;

    //signos de exclamación
    bool m_AppearExclamation;

    //tiempo para los dos segundos
    public float time = 2;

    public GameObject Exclamation;
    public GameObject Point;

    private void Start()
    {
        // enemielook = GetComponent<AudioSource>();
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
           m_IsPlayerInRange = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }

    }

    private void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            //V = P2 - P1 (vector = JohnLemon - PointOfView ) +vector3up(0,1,0) es para ver el centro de gravedad de John

            Ray ray = new Ray(transform.position, direction);

            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {

                    m_AppearExclamation = true;
                    m_EnemieIslooking = true;
                    m_AudioHasPlayed =false;

                    time -= Time.deltaTime;


                    if (time <= 0)
                    {
                        gameEnding.CaughtPlayer();
                    }

                }
            }
        }
          if (m_IsPlayerInRange == false)
            {
            time = 2;
            m_AppearExclamation = false;
            }

        
         if (m_EnemieIslooking == true)
        {
            if (!m_AudioHasPlayed) 
            {
                enemielook.Play();
                m_AudioHasPlayed = true;
            }
          
        }

        
        if (m_AppearExclamation == true)
        {
            Exclamation.SetActive(true);
            Point.SetActive(true);

        }
        else
        {
            Exclamation.SetActive(false);
            Point.SetActive(false);
        }
    }
  
}
