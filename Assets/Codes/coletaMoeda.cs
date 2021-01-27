using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coletaMoeda : MonoBehaviour
{

    public bool coleta;
    public int totalMoeda = 0;

    void Start()
    {

        coleta = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D outro) 
    {
        coleta = true;

        if (outro.gameObject.CompareTag("Moeda"))
        {

            if (coleta == true)
            {

                totalMoeda++;
                Destroy(outro.gameObject);

            }

        }
    }

    void OnTriggerExit2D (Collider2D outro) 
    {
        coleta = false;
    }

}
