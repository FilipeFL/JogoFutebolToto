using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public GameObject BolaObjeto, BolaSecundaria, BolaTerciaria;
    public GameObject SaidaInicio;
    public GameObject ParedeSaidaInicio;
    public GameObject AtivaJogoInicio;
    public GameObject Gol1, Gol2;
    public GameObject Triplicador1, Triplicador2, Triplicador3, Triplicador4;

    // Time 1
    public GameObject GO1, ZAG1, LD1, LE1, MCE1, MCD1, MD1, ME1, AT1, ATE1, ATD1;
    // Time 2
    public GameObject GO2, ZAG2, LD2, LE2, MCE2, MCD2, MD2, ME2, AT2, ATE2, ATD2;

    // Habilidades Casa
    public GameObject VAR1, Lesao1, DonoBola1, Capitao1, Caibra1;

    // Habilidades Fora
    public GameObject VAR2, Lesao2, DonoBola2, Capitao2, Caibra2;

    public GameObject MisterioCasa, MisterioFora;
    
    public Rigidbody bola;

    private int[] impulso_saida = {800, 850, 900, 950, 1000, 1500}, impulso_lado = {75, 100, 150, 175, 200, 250};
    private int posVetor_saida = 0, posVetor_lado = 0;
    private System.Random variavel_saida = new System.Random();
    private System.Random decide_lado = new System.Random();
    private int escolhe_lado = 0;
    
    public int numPartidas = 0, pontosTime1 = 0, pontosTime2 = 0;
    public bool Emjogo = false, saidaAlternativa = false;

    /*
        1 - VAR
        2 - Cãibra na Área
        3 - Lesão
        4 - Dono da Bola
        5 - Capitão Nato
    */

    public int[] habilidades_manager = {1, 2, 3, 4, 5};
    public System.Random sorteio_habilidade = new System.Random();
    public int indice_habilidade = 0;
    public bool VAR = false, Caibra = false, Lesao = false, DonoBola = false, CapNato = false, time = false;

    public System.Random sorteio_retirada_jogador = new System.Random();
    public int[] vetor_retira = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    public bool time_gol = false;
    public int retirada_jogador = 0, retirada_temporaria_casa = 0, retirada_temporaria_fora = 0;
    public int contador_time1 = 11, contador_time2 = 11;

    public bool encerra_jogo = false, vitoria_time = false; 

    public bool time_posse = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Inicio();
    }

    // Update is called once per frame
    void Update()
    {
        ChecaSaidas();
        Escolher_Lado();

        if (contador_time1 == 6)
        {
            vitoria_time = false;
            // Time 1 venceu
            encerra_jogo = true;
        }
        if (contador_time2 == 6)
        {
            vitoria_time = true;
            // Time 2 venceu
            encerra_jogo = true;
        }

        if (encerra_jogo == true)
        {
            ReiniciaPartida();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Coloca a bola na posição inicial
    public void Inicio()
    {
        //Saída de Bola
        BolaObjeto.transform.position = new Vector3(-20.74f, 1.75f, -0.14f);

        posVetor_saida = variavel_saida.Next(0, impulso_saida.Length);

        bola.AddForce(-SaidaInicio.transform.up * impulso_saida[posVetor_saida], ForceMode.Force);

        // Escolhe o lado
        if(escolhe_lado / 2 == 0)
        {
            bola.AddForce(-SaidaInicio.transform.right * impulso_lado[posVetor_lado], ForceMode.Force);
        }
        else
        {
            bola.AddForce(SaidaInicio.transform.right * impulso_lado[posVetor_lado], ForceMode.Force);
        }
    }

    public void ChecaSaidas()
    {
        if(Emjogo == true)
        {
            SaidaInicio.SetActive(false);
            ParedeSaidaInicio.SetActive(true);
        }
        else
        {
            SaidaInicio.SetActive(true);
            ParedeSaidaInicio.SetActive(false);
        }
    }

    public void Escolher_Lado()
    {
        if (DonoBola == false)
        {
            escolhe_lado = decide_lado.Next(0, 100);
        }
        else
        {
            if (time_posse == false)
            {
                escolhe_lado = 1;
                DonoBola = false;
            }
            else
            {
                escolhe_lado = 2;
                DonoBola = false;
            }
        }
    }

    public void AdicionaBolas()
    {
        BolaSecundaria.SetActive(true);
        BolaTerciaria.SetActive(true);
        Triplicador1.SetActive(false);
        Triplicador2.SetActive(false);
        Triplicador3.SetActive(false);
        Triplicador4.SetActive(false);
    }

    public void ReiniciaBolas()
    {
        BolaSecundaria.transform.position = new Vector3(-8.2f, 15.0f, 11.88f);
        BolaTerciaria.transform.position = new Vector3(11.2f, 15.0f, -14.1f);
        
        BolaSecundaria.SetActive(false);
        BolaTerciaria.SetActive(false);
        Triplicador1.SetActive(true);
        Triplicador2.SetActive(true);
        Triplicador3.SetActive(true);
        Triplicador4.SetActive(true);
    }

    public void ChecaEncerramento()
    {
        if (contador_time1 == 6 || contador_time2 == 6)
        {
            encerra_jogo = true;
            
            if (vitoria_time == false)
            {
                Debug.Log("Time 1 Venceu");
            }
            else
            {
                Debug.Log("Time 2 Venceu");
            }
        }
    }

    public void RetiraJogador()
    {
        // Sai Jogador Aleatorio
        retirada_jogador = sorteio_retirada_jogador.Next(0, vetor_retira.Length);
        retirada_jogador = vetor_retira[retirada_jogador];
        
        // Time 2
        if (time_gol == false)
        {
           if(retirada_jogador == 1)
           {
               ZAG2.SetActive(false);
               contador_time2--;
           }
           if(retirada_jogador == 2)
           {
               LD2.SetActive(false);
               contador_time2--;
           }
           if(retirada_jogador == 3)
           {
               LE2.SetActive(false);
               contador_time2--;
           }
           if(retirada_jogador == 4)
           {
               MCE2.SetActive(false);
               contador_time2--;
           }
           if(retirada_jogador == 5)
           {
               MCD2.SetActive(false);
               contador_time2--;
           }
           if(retirada_jogador == 6)
           {
               MD2.SetActive(false);
               contador_time2--;
           }
           if(retirada_jogador == 7)
           {
               ME2.SetActive(false);
               contador_time2--;
           }
           if(retirada_jogador == 8)
           {
               AT2.SetActive(false);
               contador_time2--;
           }
           if(retirada_jogador == 9)
           {
               ATE2.SetActive(false);
               contador_time2--;
           }
           if(retirada_jogador == 10)
           {
               ATD2.SetActive(false);
               contador_time2--;
           }
        }
        // Time 1
        else
        {
           if(retirada_jogador == 1)
           {
               ZAG1.SetActive(false);
               contador_time1--;
           }
           if(retirada_jogador == 2)
           {
               LD1.SetActive(false);
               contador_time1--;
           }
           if(retirada_jogador == 3)
           {
               LE1.SetActive(false);
               contador_time1--;
           }
           if(retirada_jogador == 4)
           {
               MCE1.SetActive(false);
               contador_time1--;
           }
           if(retirada_jogador == 5)
           {
               MCD1.SetActive(false);
               contador_time1--;
           }
           if(retirada_jogador == 6)
           {
               MD1.SetActive(false);
               contador_time1--;
           }
           if(retirada_jogador == 7)
           {
               ME1.SetActive(false);
               contador_time1--;
           }
           if(retirada_jogador == 8)
           {
               AT1.SetActive(false);
               contador_time1--;
           }
           if(retirada_jogador == 9)
           {
               ATE1.SetActive(false);
               contador_time1--;
           }
           if(retirada_jogador == 10)
           {
               ATD1.SetActive(false);
               contador_time1--;
           }
        }
    }

    public void ReviveJogadorCasa()
    {
        if(retirada_temporaria_casa == 1)
        {
            ZAG1.SetActive(true);
            contador_time1++;
        }
        if(retirada_temporaria_casa == 2)
        {
            LD1.SetActive(true);
            contador_time1++;
        }
        if(retirada_temporaria_casa == 3)
        {
            LE1.SetActive(true);
            contador_time1++;
        }
        if(retirada_temporaria_casa == 4)
        {
            MCE1.SetActive(true);
            contador_time1++;
        }
        if(retirada_temporaria_casa == 5)
        {
            MCD1.SetActive(true);
            contador_time1++;
        }
        if(retirada_temporaria_casa == 6)
        {
            MD1.SetActive(true);
            contador_time1++;
        }
        if(retirada_temporaria_casa == 7)
        {
            ME1.SetActive(true);
            contador_time1++;
        }
        if(retirada_temporaria_casa == 8)
        {
            AT1.SetActive(true);
            contador_time1++;
        }
        if(retirada_temporaria_casa == 9)
        {
            ATE1.SetActive(true);
            contador_time1++;
        }
        if(retirada_temporaria_casa == 10)
        {
            ATD1.SetActive(true);
            contador_time1++;
        }
    }

    public void ReviveJogadorFora()
    {
        if(retirada_temporaria_fora == 1)
        {
            ZAG2.SetActive(true);
            contador_time2++;
        }
        if(retirada_temporaria_fora == 2)
        {
            LD2.SetActive(true);
            contador_time2++;
        }
        if(retirada_temporaria_fora == 3)
        {
            LE2.SetActive(true);
            contador_time2++;
        }
        if(retirada_temporaria_fora == 4)
        {
            MCE2.SetActive(true);
            contador_time2++;
        }
        if(retirada_temporaria_fora == 5)
        {
            MCD2.SetActive(true);
            contador_time2++;
        }
        if(retirada_temporaria_fora == 6)
        {
            MD2.SetActive(true);
            contador_time2++;
        }
        if(retirada_temporaria_fora == 7)
        {
            ME2.SetActive(true);
            contador_time2++;
        }
        if(retirada_temporaria_fora == 8)
        {
            AT2.SetActive(true);
            contador_time2++;
        }
        if(retirada_temporaria_fora == 9)
        {
            ATE2.SetActive(true);
            contador_time2++;
        }
        if(retirada_temporaria_fora == 10)
        {
            ATD2.SetActive(true);
            contador_time2++;
        }
    }

    public void JogadoresAtivos()
    {
        // Time 1
        GO1.SetActive(true);
        ZAG1.SetActive(true);
        LD1.SetActive(true);
        LE1.SetActive(true);
        MCE1.SetActive(true);
        MCD1.SetActive(true);
        MD1.SetActive(true);
        ME1.SetActive(true);
        AT1.SetActive(true);
        ATE1.SetActive(true);
        ATD1.SetActive(true);

        // Time 2
        GO2.SetActive(true);
        ZAG2.SetActive(true);
        LD2.SetActive(true);
        LE2.SetActive(true);
        MCE2.SetActive(true);
        MCD2.SetActive(true);
        MD2.SetActive(true);
        ME2.SetActive(true);
        AT2.SetActive(true);
        ATE2.SetActive(true);
        ATD2.SetActive(true);
    }

    public void ReiniciaPartida()
    {
        JogadoresAtivos();
        ReiniciaBolas();
        DesativaEsculturas();
        DesativaMisterios();
        
        numPartidas = 0;
        pontosTime1 = 0;
        pontosTime2 = 0;
        contador_time1 = 11;
        contador_time2 = 11;
        VAR = false;
        Caibra = false;
        Lesao = false;
        DonoBola = false;
        CapNato = false;
        
        encerra_jogo = false;
        Inicio();
    }

    public void AtivaEsculturas()
    {
        // Time 1
        
        if (VAR == true && time == true)
        {
            VAR1.SetActive(true);
        }
        if (Lesao == true && time == true)
        {
            Lesao1.SetActive(true);
        }
        if (DonoBola == true && time == true)
        {
            DonoBola1.SetActive(true);
        }
        if (CapNato == true && time == true)
        {
            Capitao1.SetActive(true);
        }
        if (Caibra == true && time == true)
        {
            Caibra1.SetActive(true);
        }

        // Time 2

        if (VAR == true && time == false)
        {
            VAR2.SetActive(true);
        }
        if (Lesao == true && time == false)
        {
            Lesao2.SetActive(true);
        }
        if (DonoBola == true && time == false)
        {
            DonoBola2.SetActive(true);
        }
        if (CapNato == true && time == false)
        {
            Capitao2.SetActive(true);
        }
        if (Caibra == true && time == false)
        {
            Caibra2.SetActive(true);
        }
    }

    public void DesativaEsculturas()
    {
        VAR1.SetActive(false);
        VAR2.SetActive(false);
        Lesao1.SetActive(false);
        Lesao2.SetActive(false);
        DonoBola1.SetActive(false);
        DonoBola2.SetActive(false);
        Capitao1.SetActive(false);
        Capitao2.SetActive(false);
        Caibra1.SetActive(false);
        Caibra2.SetActive(false);
    }

    public void AtivaMisterio()
    {
        // Time 1

        if (time == true)
        {
            MisterioCasa.SetActive(true);
        }

        // Time 2

        if (time == false)
        {
            MisterioFora.SetActive(true);
        }
    }

    public void DesativaMisterios()
    {
        MisterioCasa.SetActive(false);
        MisterioFora.SetActive(false);
    }
}
