using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameScene2 : MonoBehaviour
{
    public Text coins, msg;
    public static int s;
    public static int c;
    public GameObject retry, next;
    public GameObject coin;
    public GameObject nextNPC;
    public static float t;

    void Start()
    {
        Player.lifes = true;
        NPC.lifes = true;
        Player.life = 3;
        c = 15;
        t = 4;
        Time.timeScale = 1;
        msg.text = "MISSION 2 START!";
        StartCoroutine(ShowMessenger());
    }

    void Update()
    {
        coins.text = "x" + c;
        t -= Time.deltaTime; // CONTADOR DO TEMPO

        if (t <= 0)
        {
            t = 4;
            NextNPC.d = true;
        }

        if (Player.moved == true)
        {
            coins.text = "";
            msg.text = "MISSION 2 COMPLETED!";
            next.SetActive(true); // BOTAO NEXT É ATIVADO
        }
        if (Player.loser == true)
        {
            Time.timeScale = 0;
            msg.text = "MISSION 2 FAILED!";
            retry.SetActive(true);
        }
        if (c == 0)
        {
            coin.SetActive(false);
        }
    }

    public void Retry()
    {
        Scene game = SceneManager.GetActiveScene();
        SceneManager.LoadScene(game.buildIndex);
    }

    // IR PARA PROXIMA CENA
    public void Next()
    {
        SceneManager.LoadScene(4);
    }

    IEnumerator ShowMessenger()
    {
        yield return new WaitForSeconds(1);
        msg.text = "";
        Player.shot = true;
        nextNPC.SetActive(true);
    }
}