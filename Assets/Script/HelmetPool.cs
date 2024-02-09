using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HelmetPool : MonoBehaviour
{
    [SerializeField] int maximoElementos = 100; //máximo de cascos
    [SerializeField] GameObject objetoACrear;

    private Stack<GameObject> pool; // donde guardar los objetos


   public static HelmetPool instance;


    //Singleton
    void Awake()
    {
       if ( HelmetPool.instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }





    // Start is called before the first frame update
    void Start()
    {
        SetUpPoll();
    }

    void SetUpPoll()
    {
        pool = new Stack<GameObject>();
        GameObject cascoCreado = null;//pa no clonar
        // crear for para todos los elementos
        //en casco creado instanciamos nuestro profabs
        //cascocreado lo desactivo
        //cascocreado lo meto en la pool
        // pool.Push(cascoCreado);
        // GameObject casco = pool.Pop();
        for (int i = 0; i <maximoElementos ; i++)
        {


            cascoCreado = Instantiate(objetoACrear);
            
            
            cascoCreado.SetActive(false);//cascocreado lo desactivo


            pool.Push(cascoCreado);  //cascocreado lo meto en la pool
        }

    }
    public GameObject ObtenerObjeto()
    {
       
       
        /*if (pool.Count == 0)
        {
           
            GameObject cascoCreado = Instantiate(objetoACrear);
            return cascoCreado;
        }

        GameObject casco = pool.Pop();
        casco.SetActive(true);


        return pool.Pop();*/

        GameObject casco = null;
       if (pool.Count == 0)
        {
            casco = Instantiate(objetoACrear);//crea una nueva
            casco.SetActive(true);
        }
        else
        {
             casco = pool.Pop();
            casco.SetActive(true);
        }
        return casco;
    }
    public void devolverObjeto(GameObject cascoDevuelto)
    {
        pool.Push(cascoDevuelto);
        cascoDevuelto.SetActive(false);
    }
}
