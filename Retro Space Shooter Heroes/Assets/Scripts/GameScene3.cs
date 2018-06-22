using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameScene3 : MonoBehaviour
{
    public Text npcs, msg, time, score;
    public static int s, n;
    public GameObject retry, menu;
    public GameObject coin, death, powerup, life;
    public GameObject nextNPC;
    public static float t;

    void Start()
    {
        Player.lifes = true;
        NPC.lifes = true;
        Player.life = 3;
        s = 0;
        n = 15;
        t = 90;
        Time.timeScale = 1;
        msg.text = "FINAL MISSION START!";
        StartCoroutine(ShowMessenger());
    }

    void Update()
    {
        score.text = "" + s; // TEXTO DE PONTOS RECEBE CONTADOR
        npcs.text = "x" + n;
        t -= Time.deltaTime; // CONTADOR DO TEMPO
        time.text = "" + Mathf.Round(t); // TEMPO USA 2 CASAS

        if (t < 0) // SE TEMPO < 0
        {
            Time.timeScale = 0; // PARAR O TEMPO
            msg.text = "FINAL MISSION FAILED!";
            retry.SetActive(true); // BOTAO RETRY É ATIVADO
        }

        if (Player.moved == true)
        {
            msg.text = "FINAL MISSION COMPLETED!";
            menu.SetActive(true); // BOTAO RETRY É ATIVADO
        }
        if (Player.loser == true)
        {
            Time.timeScale = 0;
            msg.text = "FINAL MISSION FAILED!";
            retry.SetActive(true); // BOTAO RETRY É ATIVADO
        }
        if (n == 0)
        {
            npcs.text = "";
            death.SetActive(true);
            powerup.SetActive(true);
            life.SetActive(true);
            NextNPC.d = false;
            nextNPC.SetActive(false);
        }
        if (Death.life == 0)
        {
            death.SetActive(false);
            coin.SetActive(true);
        }
        if (PowerUp.d == true)
        {
            powerup.SetActive(false);
        }
        if (Life.d == true)
        {
            life.SetActive(false);
        }
        if (Coin.d == true)
        {
            coin.SetActive(false);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        Scene game = SceneManager.GetActiveScene();
        SceneManager.LoadScene(game.buildIndex);
    }

    IEnumerator ShowMessenger()
    {
        yield return new WaitForSeconds(1);
        msg.text = "";
        Player.shot = true;
        nextNPC.SetActive(true);
    }
}