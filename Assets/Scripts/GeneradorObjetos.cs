using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetos : MonoBehaviour
{
    public GameObject objetoPrefab; 
    public float intervaloDeGeneracion = 1; 
    public float rangoGeneracionX = 5; 
    public float alturaGeneracion = 10; 

    private float tiempoUltimaGeneracion;
    

    void Start()
    {
        tiempoUltimaGeneracion = Time.time;
        
    }

    void Update()
    {
        GenerarObjetos();
        
    }
    void GenerarObjetos()
    {
        if (Time.time - tiempoUltimaGeneracion > intervaloDeGeneracion)
        {

            float posicionX = Random.Range(-rangoGeneracionX, rangoGeneracionX);
            Vector3 posicionGeneracion = new Vector3(posicionX, alturaGeneracion, 0);
            Instantiate(objetoPrefab, posicionGeneracion, transform.rotation);

            tiempoUltimaGeneracion = Time.time;
        }
    }
}
