using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EejemploInstance : MonoBehaviour
{

    [SerializeField]
    GameObject gameObjectPrefab;
    float maxZ = 1.8f;
    float minZ = -1.75f;
    float maxX = 3.6f;
    float minX = 0;
    float size = 2;
    Vector2 rangeZ = new Vector2(-1.75f, 1.8f);

    public class Range
    {
        [Tooltip("Minimo del rango")]
        public float min;

        [Tooltip("Maximo del rango")]
        public float max;

        public Range(float minimo,float maximo)//constructor
        {
            this.min = minimo;
            this.max = maximo;
        }

        public Range()
        {
            min = Random.Range(-999, 999);
            max = Random.Range(-999, 999);
        }
       

    }
    [SerializeField]
    Range rangeX = new Range(0, 3.6f);

    // Start is called before the first frame update
    void Start()
    {
        //crear muchos cascos 
        
        CrearCasco();

      

    /* clone.AddComponent<Rigidbody>();
     * clone.GetComponent<Rigitbody>().velocity = new Vector3(1,0,0);
     * */
    }
    void CrearCasco()
    {
        GameObject clone = Instantiate(gameObjectPrefab);
        clone.name = "Mi casco";
        clone.transform.position = new Vector3(Random.Range(rangeX.min, rangeX.max), 0, Random.Range(rangeZ.x, rangeZ.y));
        clone.transform.localScale *= size;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
