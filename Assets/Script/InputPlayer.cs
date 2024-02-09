using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    HelmetPool pool;
   
    private void Awake()
    {
        pool = GetComponent<HelmetPool>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject casco = pool.ObtenerObjeto();


        if (casco.GetComponent<Rigidbody>() == null)
            {
                casco.AddComponent<Rigidbody>();
            }

            casco.transform.position = transform.position;
            casco.GetComponent<Rigidbody>().velocity = Vector3.zero;
               casco.GetComponent<Rigidbody>().AddForce(new Vector3(0f,30f,5f), ForceMode.Impulse);
        }
    }

   
}
