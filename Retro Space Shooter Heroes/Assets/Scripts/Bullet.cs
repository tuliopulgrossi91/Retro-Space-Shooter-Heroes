using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// ARMA DO PLAYER
    /// </summary>

    public SpriteRenderer sprtRend; // SPRITE DO OBJETO
    float randC0, randC1, randC2; // VALORES ALEATORIO
    float speed = 10; // VELOCIDADE
    Rigidbody2D rb2d; // CORPO RIGIDO

    void Start()
    {
        // RECEBE COR RANDOMICA
        randC0 = Random.Range(0f, 1f);
        randC1 = Random.Range(0f, 1f);
        randC2 = Random.Range(0f, 1f);
        sprtRend.color = new Color(randC0, randC1, randC2, 1);

        rb2d = GetComponent<Rigidbody2D>(); // PEGANDO O CORPO RIGIDO
    }

    void LateUpdate()
    {
        // SE ATIVAR TIRO
        if (Player.shot == true)
        {
            rb2d.velocity = Vector2.up * speed; // TIRO PARA CIMA
        }
        if (Player.moved == true || Death.life == 0) // SE MOVIMENTO DO JOGADOR É ATIVADO
        {
            Destroy(gameObject);
        }
        if (Time.timeScale == 0)
        {
            gameObject.SetActive(false);
        }
    }

    // METODO DE COLISAO TRIGGER
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "BulletNPC" || c.gameObject.tag == "BulletDeath" || c.gameObject.tag == "NPC" || c.gameObject.tag == "Death")
        {
            Destroy(gameObject); // DESTROI OBJETO
        }
        if (c.gameObject.tag == "NPC") // SE COLIDIR COM NPC
        {
            if (NPC.lifes == false)
            {
                Destroy(gameObject); // DESTROI OBJETO
            }
        }
    }

    // METODO TORNAR-SE INVISIVEL - SAIR DA TELA
    void OnBecameInvisible()
    {
        Destroy(gameObject); // DESTROI OBJETO
    }
}