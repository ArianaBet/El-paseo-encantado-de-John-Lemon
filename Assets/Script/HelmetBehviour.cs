using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetBehviour : MonoBehaviour
{
    float time = 0.0f;
    float lifetime = 0.5f;
    // Start is called before the first frame update
    void Update()
    {
        time += Time.deltaTime;
        if (time > 2f)
        {
            time = 0.0f;
            this.gameObject.SetActive(false);
            HelmetPool.instance.devolverObjeto(this.gameObject);
            //AlActivas();
        }


    }

    // Update is called once per frame
   void OnEnable()
    {
        time = 0.0f;
    }
}
