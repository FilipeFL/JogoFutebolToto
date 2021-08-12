using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bola : MonoBehaviour
{
    private Global controlador;
    private Time1 time1;
    private Time2 time2;

    public Rigidbody bola;
    
    private int[] impulso_horizontal_frente = {600, 750, 800, 850, 900, 950, 1000, 1500, 2000, 2500}, impulso_vertical = {0, 50, 100, 150}, impulso_horizontal_lado = {50, 100, 150, 200, 250};
    
    private System.Random decisao_lado = new System.Random();
    private System.Random variavel_horizontal_frente = new System.Random();
    private System.Random variavel_horizontal_lado = new System.Random();
    private System.Random variavel_vertical = new System.Random();
    
    private int posVetor_horizontal_frente = 0, posVetor_horizontal_lado = 0, posVetor_vertical = 0;
    private int lado_escolhido = 0;

    // Start is called before the first frame update
    void Start()
    {
        controlador = GameObject.Find("Controlador").GetComponent<Global>();
        time1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Time1>();
        time2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Time2>();
    }

    // Update is called once per frame
    void Update()
    {
        EscolhaLado();
    }

    // Implementação da direção da bola, por enquanto ela só está indo para a frente
    // O objetivo é que ela mova para o lado e para cima também
    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.tag == "Player1")
        {
            posVetor_horizontal_frente = variavel_horizontal_frente.Next(0, impulso_horizontal_frente.Length);
            posVetor_horizontal_lado = variavel_horizontal_lado.Next(0, impulso_horizontal_lado.Length);
            posVetor_vertical = variavel_vertical.Next(0, impulso_vertical.Length);
            
            if(posVetor_horizontal_frente > 6)
            {
                // Movimentação para frente
                bola.AddForce(objeto.transform.forward * impulso_horizontal_frente[posVetor_horizontal_frente], ForceMode.Force);
            }
            else if(posVetor_horizontal_frente > 7 && posVetor_horizontal_frente < 12)
            {
                // Movimentação vertical
                bola.AddForce(objeto.transform.forward * impulso_horizontal_frente[posVetor_horizontal_frente], ForceMode.Force);
                bola.AddForce(objeto.transform.up * impulso_vertical[posVetor_vertical], ForceMode.Force);
            }
            else
            {
                // Movimentação Lateral para a esquerda ou direita
                if(lado_escolhido / 2 == 0)
                {
                    bola.AddForce(objeto.transform.forward * impulso_horizontal_frente[posVetor_horizontal_frente], ForceMode.Force);
                    bola.AddForce(objeto.transform.right * impulso_horizontal_lado[posVetor_horizontal_lado], ForceMode.Force);
                }
                else
                {
                    bola.AddForce(objeto.transform.forward * impulso_horizontal_frente[posVetor_horizontal_frente], ForceMode.Force);
                    bola.AddForce(-objeto.transform.right * impulso_horizontal_lado[posVetor_horizontal_lado], ForceMode.Force);
                }
                
            }    
        }
        if (objeto.tag == "Player2")
        {
            posVetor_horizontal_frente = variavel_horizontal_frente.Next(0, impulso_horizontal_frente.Length);
            posVetor_horizontal_lado = variavel_horizontal_lado.Next(0, impulso_horizontal_lado.Length);
            posVetor_vertical = variavel_vertical.Next(0, impulso_vertical.Length);
            
            if(posVetor_horizontal_frente > 6)
            {
                // Movimentação para frente
                bola.AddForce(objeto.transform.forward * impulso_horizontal_frente[posVetor_horizontal_frente], ForceMode.Force);
            }
            else if(posVetor_horizontal_frente > 7 && posVetor_horizontal_frente < 12)
            {
                // Movimentação vertical
                bola.AddForce(objeto.transform.forward * impulso_horizontal_frente[posVetor_horizontal_frente], ForceMode.Force);
                bola.AddForce(objeto.transform.up * impulso_vertical[posVetor_vertical], ForceMode.Force);
            }
            else
            {
                // Movimentação Lateral para a esquerda ou direita
                if(lado_escolhido / 2 == 0)
                {
                    bola.AddForce(objeto.transform.forward * impulso_horizontal_frente[posVetor_horizontal_frente], ForceMode.Force);
                    bola.AddForce(objeto.transform.right * impulso_horizontal_lado[posVetor_horizontal_lado], ForceMode.Force);
                }
                else
                {
                    bola.AddForce(objeto.transform.forward * impulso_horizontal_frente[posVetor_horizontal_frente], ForceMode.Force);
                    bola.AddForce(-objeto.transform.right * impulso_horizontal_lado[posVetor_horizontal_lado], ForceMode.Force);
                }
                
            }
        }
        if(objeto.tag == "Gol")
        {
            Debug.Log("Gol!");
            Debug.Log("Time Casa: " + controlador.pontosTime1 + " x Time Fora " + controlador.pontosTime2);
            
            controlador.numPartidas++;
            Debug.Log(controlador.numPartidas);

            controlador.Emjogo = false;

            if (controlador.retirada_temporaria_casa != 0)
            {
                controlador.ReviveJogadorCasa();
                Debug.Log("Lesao perdeu efeito! \nJogador da Casa volta ao jogo");
                controlador.Lesao = false;
            }
            if (controlador.retirada_temporaria_fora != 0)
            {
                controlador.ReviveJogadorFora();
                Debug.Log("Lesao perdeu efeito! \nJogador de Fora volta ao jogo");
                controlador.Lesao = false;
            }

            if (time1.velocidade_casa != 5f)
            {
                time1.velocidade_casa = 5f;
                
                Debug.Log("Velocidade dos jogadores Casa volta ao normal");
                controlador.CapNato = false;
                controlador.Caibra = false;
            }
            if (time2.velocidade_fora != 5f)
            {
                time2.velocidade_fora = 5f;
                
                Debug.Log("Velocidade dos jogadores Fora volta ao normal");
                controlador.CapNato = false;
                controlador.Caibra = false;
            }
            
            controlador.RetiraJogador();
            controlador.Inicio();
        }
        if(objeto.tag == "SaidaBola")
        {
            controlador.Emjogo = true;
        }
        if(objeto.tag == "Tunel1")
        {
            posVetor_horizontal_frente = variavel_horizontal_frente.Next(0, impulso_horizontal_frente.Length);

            transform.position = new Vector3(16.58f, 1.36f, 23.27f);

            bola.AddForce(-objeto.transform.forward * impulso_horizontal_frente[posVetor_horizontal_frente], ForceMode.Force);

        }
        if(objeto.tag == "Tunel2")
        {
            posVetor_horizontal_frente = variavel_horizontal_frente.Next(0, impulso_horizontal_frente.Length);

            transform.position = new Vector3(-16.09f, 1.06f, -23.27f);

            bola.AddForce(-objeto.transform.forward * impulso_horizontal_frente[posVetor_horizontal_frente], ForceMode.Force);

        }
    }

    public void EscolhaLado()
    {
        lado_escolhido = decisao_lado.Next(0, 100);
    }
}
