using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harpoon_hit : MonoBehaviour
{
    /* Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    void OnTriggerEnter(Collider fish)
    {
        if (fish.gameObject.tag == "pez")
        {
            print("HERIDO");
        }
    }

    void OnTriggerStay(Collider fish)
    {
        if (fish.gameObject.tag == "pez")
        {
            print("Hiriendo...");
        }
    }

    void OnTriggerExit(Collider fish)
    {
        if (fish.gameObject.tag == "pez")
        {
            print("Soltado");
        }
    }
}
