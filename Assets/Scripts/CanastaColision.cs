using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanastaColision : MonoBehaviour
{
    private Puntuacion puntuacion; 

    void Start()
    {        
        puntuacion = FindObjectOfType<Puntuacion>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Bolita"))
        {
            
            if (puntuacion != null)
            {
                puntuacion.AumentarPuntuacion();
            }

            
            Destroy(other.gameObject);
        }
    }
}
