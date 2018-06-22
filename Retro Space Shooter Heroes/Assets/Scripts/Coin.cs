using UnityEngine;

public class Coin : MonoBehaviour
{
    float x, y; // POSICOES X E Y
    public static bool d; // DESATIVAR OBJETO
    Vector2 v2; // VETOR DE 2 POSICOES

    void Start()
    {
        d = false; // OBJETO ATIVADO

        if (GameScene.n == 0 || Death.life == 0) 
        {
            RandomCoin();
        }

        if (GameScene2.c <= 15) // VERIFICA MISSAO 2 - SE NUMERO DE MOEDAS > 0
        {
            InvokeRepeating("RandomCoin", 0, 1);
        }
    }

    void Update()
    {
        if (GameScene2.c == 0) // SE NUMERO DE MOEDAS = 0
        {
            CancelInvoke("RandomCoin"); // CANCELA METODO DE REPETICAO
        }
        if (GameScene2.c > 0) // SE NUMERO DE MOEDAS > 0
        {
            if (d == true) // SE OBJETO DESATIVAR
            {
                d = !d; // ATIVAR OBJETO
                RandomCoin();
            }
        }
    }

    // METODO MOEDA ALEATORIA
    void RandomCoin()
    {
        x = Random.Range(-7.45f, 7.45f);
        y = Random.Range(-2.5f, 2.5f);
        v2 = new Vector2(x, y);
        transform.position = v2;

        // VERIFICA MISSAO 2
        if (GameScene2.c > 0 && d == false) 
        {
            x = Random.Range(-7.45f, 7.45f);
            y = Random.Range(-2.5f, 2.5f);
            v2 = new Vector2(x, y);
            transform.position = v2;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            d = true;
            Player.loser = false;
        }
    }
}