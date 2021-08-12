using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time1 : MonoBehaviour
{
    private Global controlador;
    private Time2 time2;

    public float velocidade_casa = 5f;

    public int linha = 0;

    /*Linha 0 - Goleiro e Meio
    Linha 1 - Zaga e Ataque*/
    
    // Start is called before the first frame update
    void Start()
    {
        controlador = GameObject.Find("Controlador").GetComponent<Global>();
        time2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Time2>();

        SorteioManagerCasa();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a") && linha == 1)
        {
            linha--;
        }
        if (Input.GetKeyDown("d") && linha == 0)
        {
            linha++;
        }

        if (controlador.pontosTime2 - controlador.pontosTime1 >= 1)
        {
            Debug.Log("Habilidade de Manager do time da casa desbloqueada!");

            controlador.time = true;
            controlador.AtivaMisterio();
            
            if (Input.GetKeyDown("z"))
            {
                controlador.DesativaMisterios();
                controlador.AtivaEsculturas();
            }

            if (Input.GetKeyDown("x"))
            {
                HabilidadesManagerCasa();
            }
        }
    }

    public void SorteioManagerCasa()
    {
        controlador.indice_habilidade = 2;
        Debug.Log(controlador.indice_habilidade);

        VerificaSorteio();
    }

    public void VerificaSorteio()
    {
        switch (controlador.indice_habilidade)
        {
            case 1:
                controlador.VAR = true;
                Debug.Log("VAR Desbloqueado");
                break;
            case 2:
                controlador.Caibra = true;
                Debug.Log("Caibra Desbloqueado");
                break;
            case 3:
                controlador.Lesao = true;
                Debug.Log("Lesao Desbloqueado");
                break;
            case 4:
                controlador.DonoBola = true;
                Debug.Log("Dono da Bola Desbloqueado");
                break;
            case 5:
                controlador.CapNato = true;
                Debug.Log("Capitao Nato Desbloqueado");
                break;
            default:
                break;
        }
    }

    public void HabilidadesManagerCasa()
    {
        if (controlador.VAR == true)
        {
            controlador.pontosTime2--;
            
            Debug.Log("Time Fora perdeu ponto \nVAR utilizado!");
            Debug.Log("Time Casa: " + controlador.pontosTime1 + " x Time Fora" + controlador.pontosTime2);

            controlador.VAR = false;
            controlador.DesativaEsculturas();

            if (controlador.indice_habilidade != 5)
            {
                controlador.indice_habilidade++;    
            }
            else
            {
                controlador.indice_habilidade = 1;
            }
        }
        if (controlador.Caibra == true)
        {
            time2.velocidade_fora = 3f;

            controlador.DesativaEsculturas();
            
            Debug.Log("Time Fora está mais lento");

            if (controlador.indice_habilidade != 5)
            {
                controlador.indice_habilidade++;    
            }
            else
            {
                controlador.indice_habilidade = 1;
            }
        }
        if (controlador.Lesao == true)
        {
            // Retira Jogador do Time 2

            controlador.time_gol = false;
            controlador.RetiraJogador();
            controlador.retirada_temporaria_fora = controlador.retirada_jogador;

            controlador.DesativaEsculturas();

            Debug.Log("Time Fora perdeu um jogador \nLesao utilizado!");

            if (controlador.indice_habilidade != 5)
            {
                controlador.indice_habilidade++;    
            }
            else
            {
                controlador.indice_habilidade = 1;
            }
        }
        if (controlador.DonoBola == true)
        {
            // Posse do Time 1
            controlador.time_posse = false;

            controlador.DesativaEsculturas();
            
            Debug.Log("Time Casa tem a posse na proxima Saida de Bola \nDono da Bola utilizado!");

            if (controlador.indice_habilidade != 5)
            {
                controlador.indice_habilidade++;    
            }
            else
            {
                controlador.indice_habilidade = 1;
            }
        }
        if (controlador.CapNato == true)
        {
            velocidade_casa = 7f;

            controlador.DesativaEsculturas();

            Debug.Log("Time Casa tem mais velocidade \nCapitao Nato utilizado!");

            if (controlador.indice_habilidade != 5)
            {
                controlador.indice_habilidade++;    
            }
            else
            {
                controlador.indice_habilidade = 1;
            }
        }
    }
}
