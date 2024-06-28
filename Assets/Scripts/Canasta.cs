using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Canasta : Movibles
{   

    public float velocidadMovimiento = 10f;
    public float xLimit=7.7f;
    private void Start()
    {
       GetComponent<Renderer>().material.color=FindObjectOfType<MainManager>().TeamColor;
    }
    void Update()
    {
        Moverse(velocidadMovimiento);
        
    }
    public override void Moverse(float velocidad)
    {
        base.Moverse(velocidad);
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        float movimiento = movimientoHorizontal * velocidadMovimiento * Time.deltaTime;

        float nuevaPosicionX = Mathf.Clamp(transform.position.x + movimiento, -xLimit, xLimit);

        transform.position = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);
    }
}
