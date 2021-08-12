using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolFora : MonoBehaviour
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
            Debug.Log(controlador.pontosTime1);
            controlador.pontosTime1++;
            Debug.Log(controlador.pontosTime1);
            controlador.time_gol = true;
        }
    }
}
