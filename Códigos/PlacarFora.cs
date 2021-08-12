using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacarFora : MonoBehaviour
{
    private Global controlador;
    
    // Start is called before the first frame update
    void Start()
    {
        controlador = GameObject.Find("Controlador").GetComponent<Global>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlador.pontosTime2 == 0)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, -89.98f);
        }
        if (controlador.pontosTime2 == 1)
        {
            transform.rotation = Quaternion.Euler(-89.9f, 180f, 0f);
        }
        if (controlador.pontosTime2 == 2)
        {
            transform.rotation = Quaternion.Euler(-89.9f, -90f, 0f);
        }
        if (controlador.pontosTime2 == 3)
        {
            transform.rotation = Quaternion.Euler(-89.9f, 0f, 0f);
        }
        if (controlador.pontosTime2 == 4)
        {
            transform.rotation = Quaternion.Euler(-89.9f, 90f, 0f);
        }
        if (controlador.pontosTime2 == 5)
        {
            transform.rotation = Quaternion.Euler(181f, 90f, -90f);
        }
    }
}
