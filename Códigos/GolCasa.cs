using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolCasa : MonoBehaviour
{
    Global controlador;

    // Start is called before the first frame update
    void Start()
    {
        controlador = GameObject.Find("Controlador").GetComponent<Global>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.tag == "Bola")
        {
            Debug.Log(controlador.pontosTime2);
            controlador.pontosTime2++;
            Debug.Log(controlador.pontosTime2);
            controlador.time_gol = false;
        }
    }
}
