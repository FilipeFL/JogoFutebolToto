using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZagaAdversario : MonoBehaviour
{
    private Time2 time;
    public bool ataque = false;

    // Start is called before the first frame update
    void Start()
    {
        time = transform.GetComponent<Time2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time.linha == 1)
        {
            //Movimenta��o Zagueiros

            if (GameObject.Find("PivoDefesa_AD").transform.position.x > -9)
            {
                if (Input.GetKey("up"))
                {
                    transform.Translate(Vector3.right * Time.deltaTime * time.velocidade_fora);

                    if (ataque == true)
                    {
                        transform.GetComponent<Animator>().SetBool("IdAt", false);
                        transform.GetComponent<Animator>().SetBool("AtId", true);
                    }
                }
            }

            if (GameObject.Find("PivoDefesa_AD").transform.position.x < 9)
            {
                if (Input.GetKey("down"))
                {
                    transform.Translate(-Vector3.right * Time.deltaTime * time.velocidade_fora);

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
