using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time2 : MonoBehaviour
{
    private Global controlador;
    private Time1 time1;

    public float velocidade_fora = 5f;

    public int linha = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        controlador = GameObject.Find("Controlador").GetComponent<Global>();
        time1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Time1>();

        SorteioManagerFora();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right") && linha == 1)
        {
            linha--;
        }
        if (Input.GetKeyDown("left") && linha == 0)
        {
            linha++;
        }

        if (controlador.pontosTime1 - controlador.pontosTime2 >= 1)
        {
            Debug.Log("Habilidade de Manager do time da casa desbloqueada!");

            controlador.time = false;
            controlador.AtivaMisterio();

            if (Input.GetKeyDown("m"))
            {
                controlador.DesativaMisterios();
                controlador.AtivaEsculturas();
            }

            if (Input.GetKeyDown("n"))
            {
                HabilidadesManagerFora();
            }
        }
    }

    public void SorteioManagerFora()
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

    public void HabilidadesManagerFora()
    {
        if (controlador.VAR == true)
        {
            controlador.pontosTime1--;

            Debug.Log("Time Casa perdeu ponto \nVAR utilizado!");
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
            time1.velocidade_casa = 3f;

            controlador.DesativaEsculturas();

            Debug.Log("Time Casa está mais lento \nCaibra utilizado!");

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
            
            controlador.time_gol = true;
            controlador.RetiraJogador();
            controlador.retirada_temporaria_casa = controlador.retirada_jogador;

            controlador.DesativaEsculturas();

            Debug.Log("Time Casa perdeu um jogador \nLesao utilizado!");

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
            // Posse do Time 2
            controlador.time_posse = true;

            controlador.DesativaEsculturas();
            
            Debug.Log("Time Fora tem a posse na proxima Saida de Bola \nDono da Bola utilizado!");

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
            velocidade_fora = 7f;

            controlador.DesativaEsculturas();

            Debug.Log("Time Fora tem mais velocidade \nCapitao Nato utilizado!");

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
