using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaBolita : Movibles
{
    public float velocidadCaida = 5f; 

    void Update()
    {
        Moverse(velocidadCaida);
    }
    public override void Moverse(float velocidad)
    {
        base.Moverse(velocidad);
        transform.Translate(Vector3.down * velocidad * Time.deltaTime);

        if (transform.position.y < -1.61)
        {
            Destroy(gameObject);
        }
    }
}
