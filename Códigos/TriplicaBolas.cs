using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriplicaBolas : MonoBehaviour
{   
    private Global controlador;

    private float min = 1.5f, max = 15.5f, velocidade = 0.03f;
    private int sinal = 1;

    // Start is called before the first frame update
    void Start()
    {
        controlador = GameObject.Find("Controlador").GetComponent<Global>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= min)
        {
            sinal = 1;
        }
        if (transform.position.y >= max)
        {
            sinal = -1;
        }
        

        transform.Translate(0, 0, velocidade * sinal);

    }

    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.tag == "Bola")
        {
            controlador.AdicionaBolas();
        }
    }
}
