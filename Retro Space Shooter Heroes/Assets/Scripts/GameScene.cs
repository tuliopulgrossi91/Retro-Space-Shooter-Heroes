using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameScene : MonoBehaviour
{    
    public Text score, time, npcs, msg; // TEXTOS - PONTOS, TEMPO, NPC E MENSAGEM
    public static int s; // CONTADOR DE PONTOS
    public static float t; // CONTADOR DE TEMPO
    public static int n; // CONTADOR DE NPCS
    public GameObject retry, next; // OBJETO BOTAO 
    public GameObject coin; // OBJETO MOEDA
    public GameObject nextNPC; // OBJETO PROXIMO NPC

    void Start()
    {
        Player.lifes = false; // VIDAS DE JOGADOR DESATIVADAS
        NPC.lifes = false; // VIDAS DE NPCS DESATIVADAS
        Player.life = 0; 

        s = 0; // CONTADOR DE PONTOS = 0
        t = 30; // CONTADOR DE TEMPO = 30
        n = 15; // CONTADOR DE NPCS = 15
        Time.timeScale = 1; // ATIVA O TEMPO
        msg.text = "MISSION 1 START!"; // MENSAGEM RECEBE TEXTO 
        StartCoroutine(ShowMessenger());
    }

    void Update()
    {
        score.text = "" + s; // TEXTO DE PONTOS RECEBE CONTADOR
        npcs.text = "x" + n; // TEXTO DE NPC RECEBE CONTADOR

        t -= Time.deltaTime; // CONTADOR DO TEMPO
        time.text = "" + Mathf.Round(t); // TEMPO USA 2 CASAS

        if (Player.moved == true) // SE MOVIMENTO DO JOGADOR É ATIVADO
        {
            msg.text = "MISSION 1 COMPLETED!"; // MENSAGEM RECEBE TEXTO 
            next.SetActive(true); // BOTAO NEXT É ATIVADO
            npcs.text = "";
        }
        if (Player.loser == true)
        {
            Time.timeScale = 0; // PARAR O TEMPO
            msg.text = "MISSION 1 FAILED!"; // MENSAGEM RECEBE TEXTO
            retry.SetActive(true); // BOTAO RETRY É ATIVADO
        }
        if (t < 0) // SE TEMPO < 0
        {
            Time.timeScale = 0; // PARAR O TEMPO
            msg.text = "MISSION 1 FAILED!";
            retry.SetActive(true); // BOTAO RETRY É ATIVADO
        }
        if (n > 0 || Coin.d == true) // SE NUMERO DE NPC > 0 OU OBJETO MOEDA DESATIVADO
        {
            coin.SetActive(false); // DESATIVA OBJETO MOEDA
        }
        if (n == 0 && Coin.d == false) // SE NUMERO DE NPC = 0 OU OBJETO MOEDA ATIVADO
        {
            npcs.text = "";
            coin.SetActive(true); // ATIVA OBJETO MOEDA
        }
    }

    // RESETAR A CENA ATUAL
    public void Retry()
    {
        Scene game = SceneManager.GetActiveScene();
        SceneManager.LoadScene(game.buildIndex);
    }

    // IR PARA PROXIMA CENA
    public void Next()
    {
        SceneManager.LoadScene(3);
    }

    IEnumerator ShowMessenger()
    {
        yield return new WaitForSeconds(1); // ESPERAR 1 SEGUNDO
        msg.text = ""; // MENSAGEM RECEBE TEXTO VAZIO
        Player.shot = true; // ATIVAR O TIRO DO JOGADOR
        nextNPC.SetActive(true); // ATIVA O PROXIMO NPC
    }
}