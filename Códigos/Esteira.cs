using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esteira : MonoBehaviour
{
    public Rigidbody Bola, BolaSecundaria, BolaTerciaria;

    private int velocidade = 1500;
    
    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.tag == "Bola")
        {
            Bola.AddForce(-gameObject.transform.right * velocidade, ForceMode.Force);
        }
    }
}
