using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeMovel : MonoBehaviour
{
    public Rigidbody Bola, BolaSecundaria, BolaTerciaria;

    private int velocidade = 1500;
    
    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.tag == "Bola")
        {
            Bola.AddForce(gameObject.transform.forward * velocidade, ForceMode.Force);
        }

        if (objeto.tag == "BolaSecundaria")
        {
            BolaSecundaria.AddForce(gameObject.transform.forward * velocidade, ForceMode.Force);
        }

        if (objeto.tag == "BolaTerciaria")
        {
            BolaTerciaria.AddForce(gameObject.transform.forward * velocidade, ForceMode.Force);
        }
    }
}
