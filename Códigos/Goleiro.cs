using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goleiro : MonoBehaviour
{
    private Time1 time;
    public bool ataque = false;
    
    // Start is called before the first frame update
    void Start()
    {
        time = transform.GetComponent<Time1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time.linha == 0)
        {
            //Movimenta��o Goleiro
            if (transform.position.x > -19)
            {
                if (Input.GetKey("w"))
                {
                    transform.Translate(-Vector3.right * Time.deltaTime * time.velocidade_casa);
                    
                    if (ataque == true)
                    {
                        transform.GetComponent<Animator>().SetBool("IdAt", false);
                        transform.GetComponent<Animator>().SetBool("AtId", true);
                    }
                }
            }

            if (transform.position.x < 19)
            {
                if (Input.GetKey("s"))
                {
                    transform.Translate(Vector3.right * Time.deltaTime * time.velocidade_casa);
                    
                    if (ataque == true)
                    {
                        transform.GetComponent<Animator>().SetBool("IdAt", false);
                        transform.GetComponent<Animator>().SetBool("AtId", true);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter (Collider objeto)
    {
        if (objeto.tag == "Bola" || objeto.tag == "BolaSecundaria" || objeto.tag == "BolaTerciaria")
        {
            transform.GetComponent<Animator>().SetBool("IdAt", true);
            ataque = true;
        }
    }
}
